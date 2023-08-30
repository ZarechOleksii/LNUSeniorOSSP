using System.Diagnostics;
using ASMEngine;

namespace ASMCompiler
{
    public partial class MainForm : Form
    {
        private Process? _cmdProcess;
        private StreamReader? _errorReader;
        private StreamReader? _outputReader;
        private StreamWriter? _inputWriter;

        private string? _sourceFilename;
        private string? _binFilename;
        private ProcessStartInfo _processStartInfo;

        public MainForm()
        {
            InitializeComponent();
            RichTextBox.CheckForIllegalCrossThreadCalls = false;
            Directory.CreateDirectory(Application.StartupPath + "\\source");
            Directory.CreateDirectory(Application.StartupPath + "\\bin");
            openFileDialog1.InitialDirectory = Application.StartupPath + "\\source";
            saveFileDialog1.InitialDirectory = Application.StartupPath + "\\source";
            folderBrowserDialog1.SelectedPath = Application.StartupPath + "\\bin";
            WorkDirTextBox.Text = Settings.WorkDir;

            foreach (Operator x in Operators.DataBase)
            {
                List<TreeNode> y = new();

                foreach (Format z in x.RegistredFormats)
                {
                    y.Add(new TreeNode(z.FormatLine));
                }

		        treeView1.Nodes.Add(new TreeNode(x.Name(), y.ToArray()));
            }

            _sourceFilename = Application.StartupPath + "\\source\\new.asm";
            OpenedFileTab.Text = Path.GetFileName(_sourceFilename);

            _processStartInfo = new("cmd.exe")
            {
                CreateNoWindow = true,
                ErrorDialog = false,
                RedirectStandardError = true,
                RedirectStandardInput = true,
                RedirectStandardOutput = true,
                UseShellExecute = false
            };
        }

        private void Run()
        {
            RunTextBox.Text = "";

            if (_binFilename == null)
            {
                Build();
            }

            // Create cmd.exe, turning off the window and redirecting I/O to us
            if (_cmdProcess != null)
            {
                _cmdProcess.Close();
            }

            _cmdProcess = new Process();
            _processStartInfo.Arguments = "/C" + _binFilename;
            _cmdProcess.StartInfo = _processStartInfo;
            _cmdProcess.Start();

            // Capture I/O
            _errorReader = _cmdProcess.StandardError;
            _outputReader = _cmdProcess.StandardOutput;
            _inputWriter = _cmdProcess.StandardInput;
            _inputWriter.AutoFlush = false;

            // Begin async read on standard error and output
            _ = ErrorBeginReadAsync();
            _ = OutputBeginReadAsync();
            OutputTabControl.SelectedIndex = 0;
        }

        private void RunButtonClick(object sender, EventArgs e)
        {
            Run();            
        }

        async Task ErrorBeginReadAsync()
        {
            if(_errorReader is not null)
            {
                var text = await _errorReader.ReadToEndAsync();
                RunTextBox.AppendText("Runtime Error!\n");
                RunTextBox.AppendText(text);
            }
        }

        async Task OutputBeginReadAsync()
        {
            if(_outputReader is not null)
            {
                var text = await _outputReader.ReadToEndAsync();
                RunTextBox.AppendText(text);
                Debug.WriteLine(string.Format("Result of running file {0}:\n{1}", _sourceFilename, text));
            }
        }

        private void Build()
        {
            CompileErrorsTextBox.Text = "";
            BinaryResultTextBox.Text = "";

            try
            {
                if (AutoSaveCheckbox.Checked)
                {
                    Save();
                }

                ASMFile file = new(new List<string>(CodeSource.Lines))
                {
                    MakeComFile = Settings.IfMakeCom
                };
                List<Line> res = file.OutCodes();
                CompileResults.Rows.Clear();

                foreach (Line x in res)
                {
                    CompileResults.Rows.Add(x.LineNumber, x.Address, x.Code, x.Source);
                }

                _binFilename = Settings.WorkDir + Path.GetFileNameWithoutExtension(_sourceFilename);

                if (Settings.IfMakeCom)
                {
                    _binFilename += ".com";
                }
                else
                {
                    _binFilename += ".exe";
                }

                file.BuildToFile(_binFilename);
                BinaryResultTextBox.Text = file.ShowFile();
            }
            catch (CompileError e1)
            {
                CompileErrorsTextBox.Text = "Compile error!\n";
                CompileErrorsTextBox.AppendText(e1.LineNumber.ToString("0000") + " : " + e1.Message);

                if (e1.LineNumber != -1)
                {
                    CodeSource.Select(CodeSource.Text.IndexOf(CodeSource.Lines[e1.LineNumber]), CodeSource.Lines[e1.LineNumber].Length);
                }

                _binFilename = null;
                OutputTabControl.SelectedIndex = 1;
            }
            catch (System.Reflection.TargetInvocationException e1)
            {
                CompileErrorsTextBox.Text = "Compile error!\n";

                if(e1.InnerException is not null)
                {

                    CompileErrorsTextBox.AppendText(
                        ((CompileError)e1.InnerException).LineNumber.ToString("0000")
                        + " : "
                        + ((CompileError)e1.InnerException).Message);

                    if (((CompileError)e1.InnerException).LineNumber != -1)
                    {
                        CodeSource.Select(CodeSource.Text.IndexOf(CodeSource.Lines[((CompileError)e1.InnerException).LineNumber]),
                            CodeSource.Lines[((CompileError)e1.InnerException).LineNumber].Length);
                    }
                }

                _binFilename = null;
                OutputTabControl.SelectedIndex = 1;
            }
        }
        
        private void CompileButtonClick(object sender, EventArgs e)
        {
            Build();
        }

        private void RunAndCompileButtonClick(object sender, EventArgs e)
        {
            _binFilename = null;
            Run();            
        }

        private void Save()
        {
            if(_sourceFilename is not null)
            {
                File.WriteAllText(_sourceFilename, CodeSource.Text);
                OpenedFileTab.Text = Path.GetFileName(_sourceFilename);
            }
        }

        private void SaveButtonClick(object sender, EventArgs e)
        {
            Save();
            SaveFileButton.Enabled = false;
        }

        private void CodeSource_TextChanged(object sender, EventArgs e)
        {
            if (!OpenedFileTab.Text.EndsWith("*"))
            {
                SaveFileButton.Enabled = true;
                OpenedFileTab.Text += "*";
            }
        }

        private void SaveAsButtonClick(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                _sourceFilename = saveFileDialog1.FileName;
                File.WriteAllText(_sourceFilename, CodeSource.Text);
                OpenedFileTab.Text = Path.GetFileName(_sourceFilename);
            }
        }

        private void OpenButtonClick(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                _sourceFilename = openFileDialog1.FileName;
                CodeSource.Text = File.ReadAllText(_sourceFilename);
                OpenedFileTab.Text = Path.GetFileName(_sourceFilename);
            }
        }

        private void ComCheckBoxCheckChange(object sender, EventArgs e)
        {
            Settings.IfMakeCom = ComCheckBox.Checked;
        }

        private void WorkingDirectorySetButtonClick(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                Settings.WorkDir = folderBrowserDialog1.SelectedPath;
                WorkDirTextBox.Text = Settings.WorkDir;
            }
        }

        private void InputButtonPressed(object sender, KeyEventArgs e)
        {
            if (_inputWriter is not null)
            {
                if (e.KeyCode == Keys.Return)
                {
                    _inputWriter.WriteLine(InputTextBox.Text);
                    _inputWriter.Flush();
                    InputTextBox.Text = "";
                }
            }
        }

    }
}




