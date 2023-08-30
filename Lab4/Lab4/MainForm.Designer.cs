namespace ASMCompiler
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.RunTextBox = new System.Windows.Forms.RichTextBox();
            this.process1 = new System.Diagnostics.Process();
            this.RunButton = new System.Windows.Forms.Button();
            this.CompileButton = new System.Windows.Forms.Button();
            this.OutputTabControl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.InputTextBox = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.CompileErrorsTextBox = new System.Windows.Forms.RichTextBox();
            this.CodeSource = new System.Windows.Forms.RichTextBox();
            this.CompileResults = new System.Windows.Forms.DataGridView();
            this.LineNumer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Address = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Source = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CompileAndRunButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button4 = new System.Windows.Forms.Button();
            this.WorkDirTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.AutoSaveCheckbox = new System.Windows.Forms.CheckBox();
            this.ComCheckBox = new System.Windows.Forms.CheckBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.tabControl3 = new System.Windows.Forms.TabControl();
            this.OpenedFileTab = new System.Windows.Forms.TabPage();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.BinaryResultTextBox = new System.Windows.Forms.RichTextBox();
            this.OpenFileButton = new System.Windows.Forms.Button();
            this.SaveFileButton = new System.Windows.Forms.Button();
            this.SaveAsFileButton = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.OutputTabControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CompileResults)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.tabControl3.SuspendLayout();
            this.OpenedFileTab.SuspendLayout();
            this.tabPage6.SuspendLayout();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.RunTextBox.BackColor = System.Drawing.Color.DarkGray;
            this.RunTextBox.Location = new System.Drawing.Point(0, 0);
            this.RunTextBox.Name = "richTextBox1";
            this.RunTextBox.ReadOnly = true;
            this.RunTextBox.Size = new System.Drawing.Size(687, 156);
            this.RunTextBox.TabIndex = 0;
            this.RunTextBox.Text = "";
            // 
            // RunButton
            // 
            this.RunButton.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.RunButton.Location = new System.Drawing.Point(19, 4);
            this.RunButton.Name = "RunButton";
            this.RunButton.Size = new System.Drawing.Size(95, 28);
            this.RunButton.TabIndex = 2;
            this.RunButton.Text = "Run";
            this.RunButton.UseVisualStyleBackColor = true;
            this.RunButton.Click += new System.EventHandler(this.RunButtonClick);
            // 
            // CompileButton
            // 
            this.CompileButton.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.CompileButton.Location = new System.Drawing.Point(120, 4);
            this.CompileButton.Name = "CompileButton";
            this.CompileButton.Size = new System.Drawing.Size(96, 28);
            this.CompileButton.TabIndex = 3;
            this.CompileButton.Text = "Compile";
            this.CompileButton.UseVisualStyleBackColor = true;
            this.CompileButton.Click += new System.EventHandler(this.CompileButtonClick);
            // 
            // tabControl1
            // 
            this.OutputTabControl.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.OutputTabControl.Controls.Add(this.tabPage1);
            this.OutputTabControl.Controls.Add(this.tabPage2);
            this.OutputTabControl.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.OutputTabControl.Location = new System.Drawing.Point(14, 309);
            this.OutputTabControl.Name = "tabControl1";
            this.OutputTabControl.SelectedIndex = 0;
            this.OutputTabControl.Size = new System.Drawing.Size(695, 215);
            this.OutputTabControl.TabIndex = 4;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.InputTextBox);
            this.tabPage1.Controls.Add(this.RunTextBox);
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(687, 182);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Run";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.InputTextBox.Location = new System.Drawing.Point(1, 162);
            this.InputTextBox.Name = "textBox1";
            this.InputTextBox.Size = new System.Drawing.Size(686, 24);
            this.InputTextBox.TabIndex = 1;
            this.InputTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.InputButtonPressed);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.CompileErrorsTextBox);
            this.tabPage2.Location = new System.Drawing.Point(4, 29);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(687, 182);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Compile Errors";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // richTextBox2
            // 
            this.CompileErrorsTextBox.Location = new System.Drawing.Point(0, 0);
            this.CompileErrorsTextBox.Name = "richTextBox2";
            this.CompileErrorsTextBox.ReadOnly = true;
            this.CompileErrorsTextBox.Size = new System.Drawing.Size(681, 183);
            this.CompileErrorsTextBox.TabIndex = 0;
            this.CompileErrorsTextBox.Text = "";
            // 
            // CodeSource
            // 
            this.CodeSource.AcceptsTab = true;
            this.CodeSource.HideSelection = false;
            this.CodeSource.Location = new System.Drawing.Point(1, 0);
            this.CodeSource.Name = "CodeSource";
            this.CodeSource.Size = new System.Drawing.Size(438, 228);
            this.CodeSource.TabIndex = 5;
            this.CodeSource.Text = "";
            this.CodeSource.TextChanged += new System.EventHandler(this.CodeSource_TextChanged);
            // 
            // CompileResults
            // 
            this.CompileResults.AllowUserToAddRows = false;
            this.CompileResults.AllowUserToDeleteRows = false;
            this.CompileResults.AllowUserToOrderColumns = true;
            this.CompileResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.CompileResults.ColumnHeadersVisible = false;
            this.CompileResults.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.LineNumer,
            this.Address,
            this.Code,
            this.Source});
            this.CompileResults.Location = new System.Drawing.Point(0, 0);
            this.CompileResults.Name = "CompileResults";
            this.CompileResults.RowHeadersVisible = false;
            this.CompileResults.RowHeadersWidth = 51;
            this.CompileResults.RowTemplate.Height = 18;
            this.CompileResults.RowTemplate.ReadOnly = true;
            this.CompileResults.Size = new System.Drawing.Size(461, 232);
            this.CompileResults.TabIndex = 6;
            // 
            // LineNumer
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LineNumer.DefaultCellStyle = dataGridViewCellStyle1;
            this.LineNumer.HeaderText = "Line #";
            this.LineNumer.MinimumWidth = 6;
            this.LineNumer.Name = "LineNumer";
            this.LineNumer.ReadOnly = true;
            this.LineNumer.Width = 45;
            // 
            // Address
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.NullValue = null;
            this.Address.DefaultCellStyle = dataGridViewCellStyle2;
            this.Address.HeaderText = "Address";
            this.Address.MinimumWidth = 6;
            this.Address.Name = "Address";
            this.Address.ReadOnly = true;
            this.Address.Width = 50;
            // 
            // Code
            // 
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.Code.DefaultCellStyle = dataGridViewCellStyle3;
            this.Code.HeaderText = "Machine code";
            this.Code.MinimumWidth = 6;
            this.Code.Name = "Code";
            this.Code.ReadOnly = true;
            this.Code.Width = 120;
            // 
            // Source
            // 
            this.Source.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Source.HeaderText = "Source line";
            this.Source.MinimumWidth = 6;
            this.Source.Name = "Source";
            // 
            // CompileAndRunButton
            // 
            this.CompileAndRunButton.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.CompileAndRunButton.Location = new System.Drawing.Point(222, 4);
            this.CompileAndRunButton.Name = "CompileAndRunButton";
            this.CompileAndRunButton.Size = new System.Drawing.Size(93, 28);
            this.CompileAndRunButton.TabIndex = 7;
            this.CompileAndRunButton.Text = "Compile && Run";
            this.CompileAndRunButton.UseVisualStyleBackColor = true;
            this.CompileAndRunButton.Click += new System.EventHandler(this.RunAndCompileButtonClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button4);
            this.groupBox1.Controls.Add(this.WorkDirTextBox);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.AutoSaveCheckbox);
            this.groupBox1.Controls.Add(this.ComCheckBox);
            this.groupBox1.Location = new System.Drawing.Point(715, 308);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(217, 215);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Settings";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(167, 172);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(44, 37);
            this.button4.TabIndex = 6;
            this.button4.Text = "Set";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.WorkingDirectorySetButtonClick);
            // 
            // textBox3
            // 
            this.WorkDirTextBox.Location = new System.Drawing.Point(6, 188);
            this.WorkDirTextBox.Name = "textBox3";
            this.WorkDirTextBox.Size = new System.Drawing.Size(155, 23);
            this.WorkDirTextBox.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 168);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(144, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Working directory";
            // 
            // AutoSaveCheckbox
            // 
            this.AutoSaveCheckbox.AutoSize = true;
            this.AutoSaveCheckbox.Checked = true;
            this.AutoSaveCheckbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.AutoSaveCheckbox.Location = new System.Drawing.Point(6, 43);
            this.AutoSaveCheckbox.Name = "AutoSaveCheckbox";
            this.AutoSaveCheckbox.Size = new System.Drawing.Size(214, 21);
            this.AutoSaveCheckbox.TabIndex = 1;
            this.AutoSaveCheckbox.Text = "Save before compilation";
            this.AutoSaveCheckbox.UseVisualStyleBackColor = true;
            // 
            // ComCheckBox
            // 
            this.ComCheckBox.AutoSize = true;
            this.ComCheckBox.Checked = true;
            this.ComCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ComCheckBox.Location = new System.Drawing.Point(6, 19);
            this.ComCheckBox.Name = "ComCheckBox";
            this.ComCheckBox.Size = new System.Drawing.Size(142, 21);
            this.ComCheckBox.TabIndex = 0;
            this.ComCheckBox.Text = "Make com files";
            this.ComCheckBox.UseVisualStyleBackColor = true;
            this.ComCheckBox.CheckedChanged += new System.EventHandler(this.ComCheckBoxCheckChange);
            // 
            // tabControl2
            // 
            this.tabControl2.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tabControl2.Controls.Add(this.tabPage4);
            this.tabControl2.Controls.Add(this.tabPage5);
            this.tabControl2.Location = new System.Drawing.Point(467, 41);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(469, 262);
            this.tabControl2.TabIndex = 9;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.CompileResults);
            this.tabPage4.Location = new System.Drawing.Point(4, 29);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(461, 229);
            this.tabPage4.TabIndex = 1;
            this.tabPage4.Text = "Compilation Table";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.treeView1);
            this.tabPage5.Location = new System.Drawing.Point(4, 32);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(461, 226);
            this.tabPage5.TabIndex = 2;
            this.tabPage5.Text = "Operators Library";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(461, 229);
            this.treeView1.TabIndex = 0;
            // 
            // tabControl3
            // 
            this.tabControl3.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tabControl3.Controls.Add(this.OpenedFileTab);
            this.tabControl3.Controls.Add(this.tabPage6);
            this.tabControl3.Location = new System.Drawing.Point(18, 41);
            this.tabControl3.Name = "tabControl3";
            this.tabControl3.SelectedIndex = 0;
            this.tabControl3.Size = new System.Drawing.Size(447, 262);
            this.tabControl3.TabIndex = 10;
            // 
            // tabPage3
            // 
            this.OpenedFileTab.Controls.Add(this.CodeSource);
            this.OpenedFileTab.Location = new System.Drawing.Point(4, 29);
            this.OpenedFileTab.Name = "tabPage3";
            this.OpenedFileTab.Padding = new System.Windows.Forms.Padding(3);
            this.OpenedFileTab.Size = new System.Drawing.Size(439, 229);
            this.OpenedFileTab.TabIndex = 0;
            this.OpenedFileTab.Text = "try.asm";
            this.OpenedFileTab.UseVisualStyleBackColor = true;
            // 
            // tabPage6
            // 
            this.tabPage6.Controls.Add(this.BinaryResultTextBox);
            this.tabPage6.Location = new System.Drawing.Point(4, 29);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage6.Size = new System.Drawing.Size(439, 229);
            this.tabPage6.TabIndex = 1;
            this.tabPage6.Text = "(binary result)";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // richTextBox3
            // 
            this.BinaryResultTextBox.Location = new System.Drawing.Point(0, 0);
            this.BinaryResultTextBox.Name = "richTextBox3";
            this.BinaryResultTextBox.ReadOnly = true;
            this.BinaryResultTextBox.Size = new System.Drawing.Size(439, 232);
            this.BinaryResultTextBox.TabIndex = 0;
            this.BinaryResultTextBox.Text = "";
            // 
            // OpenFileButton
            // 
            this.OpenFileButton.Location = new System.Drawing.Point(685, 4);
            this.OpenFileButton.Name = "OpenFileButton";
            this.OpenFileButton.Size = new System.Drawing.Size(78, 28);
            this.OpenFileButton.TabIndex = 11;
            this.OpenFileButton.Text = "Open";
            this.OpenFileButton.UseVisualStyleBackColor = true;
            this.OpenFileButton.Click += new System.EventHandler(this.OpenButtonClick);
            // 
            // SaveFileButton
            // 
            this.SaveFileButton.Location = new System.Drawing.Point(769, 4);
            this.SaveFileButton.Name = "SaveFileButton";
            this.SaveFileButton.Size = new System.Drawing.Size(78, 28);
            this.SaveFileButton.TabIndex = 12;
            this.SaveFileButton.Text = "Save";
            this.SaveFileButton.UseVisualStyleBackColor = true;
            this.SaveFileButton.Click += new System.EventHandler(this.SaveButtonClick);
            // 
            // SaveAsFileButton
            // 
            this.SaveAsFileButton.Location = new System.Drawing.Point(853, 4);
            this.SaveAsFileButton.Name = "SaveAsFileButton";
            this.SaveAsFileButton.Size = new System.Drawing.Size(78, 28);
            this.SaveAsFileButton.TabIndex = 11;
            this.SaveAsFileButton.Text = "Save As";
            this.SaveAsFileButton.UseVisualStyleBackColor = true;
            this.SaveAsFileButton.Click += new System.EventHandler(this.SaveAsButtonClick);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(943, 535);
            this.Controls.Add(this.SaveAsFileButton);
            this.Controls.Add(this.OpenFileButton);
            this.Controls.Add(this.tabControl3);
            this.Controls.Add(this.SaveFileButton);
            this.Controls.Add(this.tabControl2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.CompileAndRunButton);
            this.Controls.Add(this.OutputTabControl);
            this.Controls.Add(this.CompileButton);
            this.Controls.Add(this.RunButton);
            this.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Name = "Form1";
            this.Text = "SimASM";
            this.OutputTabControl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.CompileResults)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabControl2.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.tabPage5.ResumeLayout(false);
            this.tabControl3.ResumeLayout(false);
            this.OpenedFileTab.ResumeLayout(false);
            this.tabPage6.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox RunTextBox;
        private System.Diagnostics.Process process1;
        private System.Windows.Forms.Button RunButton;
        private System.Windows.Forms.Button CompileButton;
        private System.Windows.Forms.TabControl OutputTabControl;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox InputTextBox;
        private System.Windows.Forms.RichTextBox CodeSource;
        private System.Windows.Forms.RichTextBox CompileErrorsTextBox;
        private System.Windows.Forms.DataGridView CompileResults;
        private System.Windows.Forms.DataGridViewTextBoxColumn LineNumer;
        private System.Windows.Forms.DataGridViewTextBoxColumn Address;
        private System.Windows.Forms.DataGridViewTextBoxColumn Code;
        private System.Windows.Forms.DataGridViewTextBoxColumn Source;
        private System.Windows.Forms.Button CompileAndRunButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox ComCheckBox;
        private System.Windows.Forms.CheckBox AutoSaveCheckbox;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.TextBox WorkDirTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Button SaveFileButton;
        private System.Windows.Forms.Button OpenFileButton;
        private System.Windows.Forms.TabControl tabControl3;
        private System.Windows.Forms.TabPage OpenedFileTab;
        private System.Windows.Forms.Button SaveAsFileButton;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.TabPage tabPage6;
        private System.Windows.Forms.RichTextBox BinaryResultTextBox;
    }
}

