using System.Drawing.Drawing2D;

namespace Paint2
{
    public partial class MainWindow : Form
    {
        #region Private Class Variables

        private bool _changesMade;
        private bool _isDrawing;
        private bool _isResizeMode;
        private string? _fileInWork;
        private List<Func<Graphics, Point, Point, Pen, Color, bool>> _toDraw;
        private List<Point> _firstPoints;
        private List<Point> _secondPoints;
        private List<Pen> _pens;
        private List<Color> _fillColors;
        private Point? _firstPoint;
        private Point? _secondPoint;

        #endregion

        #region Constructor

        public MainWindow()
        {
            _isResizeMode = false;
            _changesMade = false;
            _isDrawing = false;
            _fileInWork = null;
            _toDraw = new();
            _firstPoints = new();
            _secondPoints = new();
            _pens = new();
            _fillColors = new();
            InitializeComponent();
        }

        #endregion

        #region Settings Getters

        private int GetLineWidth()
        {
            return (int)lineWidthControl.Value;
        }

        private Color GetLineColor()
        {
            return selectedLineColor.BackColor;
        }

        private Color GetFillColor()
        {
            return selectedFillColor.BackColor;
        }

        #endregion

        #region ToolStripMenuItems Click Actions

        private void NewFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UnsavedChangesPrompt(this.CreateNewCanvas, "Save them before creating new?", "Are you sure you want to create new?", "Creating new canceled.");
        }

        private void OpenStripMenuItem_Click(object sender, EventArgs e)
        {
            UnsavedChangesPrompt(this.OpenFile, "Save them before opening file?", "Are you sure you want to open file?", "Opening file canceled.");
        }

        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFile();
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileAs();
            saveToolStripMenuItem.Enabled = true;
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UnsavedChangesPrompt(this.Close, "Save them before closing?", "Are you sure you want to exit?", "Exiting canceled.");
        }

        #endregion

        #region ToolStripMenuItems Button Logic

        private void UnsavedChangesPrompt(Action action, string promptText, string promptCaption, string failedMessage)
        {
            if (!_changesMade)
            {
                action();
            }
            else
            {
                DialogResult closeMessage = MessageBox.Show("You have unsaved changes.\n" + promptText,
                    promptCaption,
                    MessageBoxButtons.YesNoCancel,
                    MessageBoxIcon.Warning);

                if (closeMessage == DialogResult.No)
                {
                    action();
                }

                if (closeMessage == DialogResult.Yes)
                {
                    bool saved;

                    if (_fileInWork is null)
                    {
                        saved = SaveFileAs();
                    }
                    else
                    {
                        saved = SaveFile();
                    }

                    if (saved)
                    {
                        action();
                    }
                    else
                    {
                        MessageBox.Show("Failed to save.\n" + failedMessage, "Canceled", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }

        private void CreateNewCanvas()
        {
            foreach(var pen in _pens)
            {
                pen.Dispose();
            }

            _pens = new();
            _toDraw = new();
            _firstPoints = new();
            _secondPoints = new();
            _fillColors = new();

            drawPictureBox.Image?.Dispose();
            drawPictureBox.Image = null;

            saveToolStripMenuItem.Enabled = false;
            _fileInWork = null;
            _changesMade = false;

            drawPictureBox.Invalidate();
        }

        private void OpenFile()
        {
            OpenFileDialog dialog = new()
            {
                RestoreDirectory = true,
                Filter = "Bitmap Image (.bmp)|*.bmp|All Files|*.*"
            };

            if(dialog.ShowDialog() == DialogResult.OK)
            {
                _changesMade = false;
                _fileInWork = dialog.FileName;

                foreach (var pen in _pens)
                {
                    pen.Dispose();
                }

                _pens = new();
                _toDraw = new();
                _firstPoints = new();
                _secondPoints = new();
                _fillColors = new();

                drawPictureBox.Image?.Dispose();
                drawPictureBox.Image = null;

                FileStream fs = File.Open(_fileInWork, FileMode.Open);
                MemoryStream mms = new();
                fs.CopyTo(mms);
                fs.Close();

                Image newImage = Image.FromStream(mms);
                drawPictureBox.Image = newImage;
                resizablePanel.Width = newImage.Width + (resizablePanel.Width - drawPictureBox.Width);
                resizablePanel.Height = newImage.Height + (resizablePanel.Height - drawPictureBox.Height);

                saveToolStripMenuItem.Enabled = true;
                drawPictureBox.Invalidate();
            }
        }

        private bool SaveFile()
        {
            if (_fileInWork is not null)
            {
                _changesMade = false;
                Bitmap bmp = new(drawPictureBox.Width, drawPictureBox.Height);
                drawPictureBox.DrawToBitmap(bmp, drawPictureBox.ClientRectangle);
                bmp.Save(_fileInWork);
                bmp.Dispose();
            }
            return true;
        }

        private bool SaveFileAs()
        {
            SaveFileDialog dialog = new()
            {
                RestoreDirectory = true,
                FileName = "Paint2Work",
                DefaultExt = "bmp",
                Filter = "Bitmap Image (.bmp)|*.bmp|All Files|*.*"
            };

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                _changesMade = false;
                _fileInWork = dialog.FileName;
                Bitmap bmp = new(drawPictureBox.Width, drawPictureBox.Height);
                drawPictureBox.DrawToBitmap(bmp, drawPictureBox.ClientRectangle);
                bmp.Save(_fileInWork);
                bmp.Dispose();
                return true;
            }

            return false;
        }

        #endregion

        #region Settings Click Actions

        private void SelectLineColorButton_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new()
            {
                Color = selectedLineColor.BackColor
            };

            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                selectedLineColor.BackColor = colorDialog.Color;
                selectedLineColor.Invalidate();
            }
        }

        private void SelectFillColorButton_Click(object sender, EventArgs e)
        {

            ColorDialog colorDialog = new()
            {
                Color = selectedFillColor.BackColor
            };

            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                selectedFillColor.BackColor = colorDialog.Color;
                selectedFillColor.Invalidate();
            }
        }

        #endregion

        #region Magic Happens Here

        private void DrawPictureBox_Paint(object sender, PaintEventArgs e)
        {
            for (int i = 0; i < _toDraw.Count; i++)
            {
                _toDraw[i].Invoke(e.Graphics, _firstPoints[i], _secondPoints[i], _pens[i], _fillColors[i]);
            }

            if (_isDrawing)
            {
                if (_firstPoint is not null && _secondPoint is not null)
                {
                    Pen dashed = new(GetLineColor(), GetLineWidth())
                    {
                        DashStyle = DashStyle.Dash
                    };

                    if (lineRadio.Checked)
                    {
                        Pen noDash = new(GetLineColor(), GetLineWidth());
                        DrawLine(e.Graphics, (Point)_firstPoint, (Point)_secondPoint, noDash, GetFillColor());
                        noDash.Dispose();
                    }
                    else if (rectRadio.Checked || rectFillRadio.Checked)
                    {
                        DrawRectNoFill(e.Graphics, (Point)_firstPoint, (Point)_secondPoint, dashed, Color.Black);
                    }
                    else
                    {
                        DrawEllipseNoFill(e.Graphics, (Point)_firstPoint, (Point)_secondPoint, dashed, Color.Black);
                    }

                    dashed.Dispose();
                }
            }
        }

        #endregion

        #region ResizablePanel MouseEvents

        private void ResizablePanel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                _changesMade = true;
                _isResizeMode = true;
            }
        }

        private void ResizablePanel_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                _isResizeMode = false;
            }
        }

        private void ResizablePanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (_isResizeMode)
            {
                resizablePanel.Size = new Size(e.X, e.Y);
                areaPanel.HorizontalScroll.Value = areaPanel.HorizontalScroll.Maximum;
                areaPanel.VerticalScroll.Value = areaPanel.VerticalScroll.Maximum;
            }
        }

        #endregion

        #region DrawPictureBox MouseEvents

        private void DrawPictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            statusLabel.Text = $"Mouse position: ({e.X}, {e.Y}).";

            if (_isDrawing)
            {
                _secondPoint = e.Location;
                drawPictureBox.Invalidate();
            }
        }

        private void DrawPictureBox_MouseLeave(object sender, EventArgs e)
        {
            statusLabel.Text = "Waiting...";
        }

        private void DrawPictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                _firstPoint = e.Location;
                _changesMade = true;
                _isDrawing = true;
            }
        }

        private void DrawPictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && _isDrawing)
            {
                var secondPoint = e.Location;
                _isDrawing = false;

                Func<Graphics, Point, Point, Pen, Color, bool> drawFigure;

                if (lineRadio.Checked)
                {
                    drawFigure = DrawLine;
                    _pens.Add(new Pen(GetLineColor(), GetLineWidth()));
                }
                else if (rectRadio.Checked)
                {
                    drawFigure = DrawRectNoFill;
                    _pens.Add(new Pen(GetLineColor(), GetLineWidth()));
                }
                else if (rectFillRadio.Checked)
                {
                    drawFigure = DrawRect;
                    _pens.Add(new Pen(GetLineColor(), GetLineWidth() * 2));
                }
                else if (ellipseRadio.Checked)
                {
                    drawFigure = DrawEllipseNoFill;
                    _pens.Add(new Pen(GetLineColor(), GetLineWidth()));
                }
                else
                {
                    drawFigure = DrawEllipse;
                    _pens.Add(new Pen(GetLineColor(), GetLineWidth() * 2));
                }

                _toDraw.Add(drawFigure);
                _firstPoints.Add(_firstPoint ?? throw new Exception());
                _secondPoints.Add(secondPoint);
                _fillColors.Add(GetFillColor());
                drawPictureBox.Invalidate();
            }
        }

        #endregion

        #region Static Drawing Shapes In Graphics Functions

        private static bool DrawLine(Graphics g, Point first, Point second, Pen pen, Color fillColor)
        {
            g.DrawLine(pen, first, second);
            return true;
        }
        private static bool DrawRect(Graphics g, Point first, Point second, Pen pen, Color fillColor)
        {
            Rectangle rect = GetRectangleFromTwoPoints(first, second);
            g.DrawRectangle(pen, rect);
            g.FillRectangle(new SolidBrush(fillColor), rect);
            return true;
        }

        private static bool DrawRectNoFill(Graphics g, Point first, Point second, Pen pen, Color fillColor)
        {
            Rectangle rect = GetRectangleFromTwoPoints(first, second);
            g.DrawRectangle(pen, rect);
            return true;
        }

        private static bool DrawEllipse(Graphics g, Point first, Point second, Pen pen, Color fillColor)
        {
            Rectangle rect = GetRectangleFromTwoPoints(first, second);
            g.DrawEllipse(pen, rect);
            g.FillEllipse(new SolidBrush(fillColor), rect);
            return true;
        }

        private static bool DrawEllipseNoFill(Graphics g, Point first, Point second, Pen pen, Color fillColor)
        {
            Rectangle rect = GetRectangleFromTwoPoints(first, second);
            g.DrawEllipse(pen, rect);
            return true;
        }

        private static Rectangle GetRectangleFromTwoPoints(Point first, Point second)
        {
            int left = Math.Min(first.X, second.X);
            int right = Math.Max(first.X, second.X);
            int top = Math.Min(first.Y, second.Y);
            int bottom = Math.Max(first.Y, second.Y);
            int width = right - left;
            int height = bottom - top;
            return new Rectangle(left, top, width, height);
        }

        #endregion
    }
}