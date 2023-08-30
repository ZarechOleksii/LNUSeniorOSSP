using System.Drawing.Drawing2D;

namespace Paint2
{
    public partial class MainWindow : Form
    {
        #region Private Class Variables

        private bool _changesMade;
        private bool _isDrawing;
        private bool _isResizeMode;
        private bool _isMovingSelection;
        private string? _fileInWork;
        private List<Func<Graphics, Bitmap?, Point, Point, Pen, Color, bool>> _toDraw;
        private List<Bitmap?> _images;
        private List<Point> _firstPoints;
        private List<Point> _secondPoints;
        private List<Pen> _pens;
        private List<Color> _fillColors;
        private Point? _firstPoint;
        private Point? _secondPoint;
        private Rectangle? _selection;
        private Bitmap? _movedPart;
        private Bitmap? _copied;

        #endregion

        #region Constructor

        public MainWindow()
        {
            _isResizeMode = false;
            _changesMade = false;
            _isDrawing = false;
            _isMovingSelection = false;
            _fileInWork = null;
            _movedPart = null;
            _copied = null;
            _toDraw = new();
            _images = new();
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

        private void UndoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int index = _toDraw.Count - 1;
            _toDraw.RemoveAt(index);
            _images.Last()?.Dispose();
            _images.RemoveAt(index);
            _firstPoints.RemoveAt(index);
            _secondPoints.RemoveAt(index);
            _pens.Last().Dispose();
            _pens.RemoveAt(index);
            _fillColors.RemoveAt(index);
            _changesMade = true;

            if (_toDraw.Count == 0)
            {
                undoToolStripMenuItem.Enabled = false;
            }

            drawPictureBox.Invalidate();
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_selection is not null)
            {
                _copied = null;

                int x = _selection.Value.X + 1;
                int y = _selection.Value.Y + 1;
                int width = _selection.Value.Width - 1;
                int height = _selection.Value.Height - 1;

                if (x < 0)
                {
                    width += x;
                    x = 0;
                }
                if (x + width > drawPictureBox.Width)
                {
                    width -= x - drawPictureBox.Width;
                }
                if (y < 0)
                {
                    height += y;
                    y = 0;
                }
                if (y + height > drawPictureBox.Height)
                {
                    height += drawPictureBox.Height - y;
                }

                Bitmap temp = new(drawPictureBox.Width, drawPictureBox.Height);
                drawPictureBox.DrawToBitmap(temp, new Rectangle(0, 0, drawPictureBox.Width, drawPictureBox.Height));
                _copied = temp.Clone(new Rectangle(x, y, width, height), System.Drawing.Imaging.PixelFormat.DontCare);
                temp.Dispose();

                pasteToolStripMenuItem.Enabled = true;
            }
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_copied is not null)
            {
                if (_movedPart is not null)
                {
                    _toDraw.Add(DrawImage);
                    _images.Add(_movedPart);
                    _pens.Add(new Pen(Color.Black, 1));
                    _firstPoints.Add(new Point(_selection.Value.X, _selection.Value.Y));
                    _secondPoints.Add(new Point(0));
                    _fillColors.Add(Color.Black);
                    _movedPart = null;
                }

                _movedPart = (Bitmap)_copied.Clone();
                _selection = new(0, 0, _copied.Width, _copied.Height);

                copyToolStripMenuItem.Enabled = true;
                drawPictureBox.Invalidate();
            }
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
            foreach (var pen in _pens)
            {
                pen.Dispose();
            }

            foreach (var image in _images)
            {
                image?.Dispose();
            }

            _pens = new();
            _toDraw = new();
            _images = new();
            _firstPoints = new();
            _secondPoints = new();
            _fillColors = new();

            drawPictureBox.Image?.Dispose();
            drawPictureBox.Image = null;

            _copied?.Dispose();
            _copied = null;

            saveToolStripMenuItem.Enabled = false;
            _fileInWork = null;
            _selection = null;
            _changesMade = false;

            undoToolStripMenuItem.Enabled = false;
            copyToolStripMenuItem.Enabled = false;
            pasteToolStripMenuItem.Enabled = false;
            drawPictureBox.Invalidate();
        }

        private void OpenFile()
        {
            OpenFileDialog dialog = new()
            {
                RestoreDirectory = true,
                Filter = "Bitmap Image (.bmp)|*.bmp|All Files|*.*"
            };

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                _changesMade = false;
                _fileInWork = dialog.FileName;

                foreach (var pen in _pens)
                {
                    pen.Dispose();
                }

                foreach (var image in _images)
                {
                    image?.Dispose();
                }

                _pens = new();
                _toDraw = new();
                _images = new();
                _firstPoints = new();
                _secondPoints = new();
                _fillColors = new();

                drawPictureBox.Image?.Dispose();
                drawPictureBox.Image = null;
                _selection = null;

                _copied?.Dispose();
                _copied = null;

                undoToolStripMenuItem.Enabled = false;

                FileStream fs = File.Open(_fileInWork, FileMode.Open);
                MemoryStream mms = new();
                fs.CopyTo(mms);
                fs.Close();

                Image newImage = Image.FromStream(mms);
                drawPictureBox.Image = newImage;
                resizablePanel.Width = newImage.Width + (resizablePanel.Width - drawPictureBox.Width);
                resizablePanel.Height = newImage.Height + (resizablePanel.Height - drawPictureBox.Height);

                saveToolStripMenuItem.Enabled = true;
                copyToolStripMenuItem.Enabled = false;
                pasteToolStripMenuItem.Enabled = false;
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
                _toDraw[i].Invoke(e.Graphics, _images[i], _firstPoints[i], _secondPoints[i], _pens[i], _fillColors[i]);
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
                        DrawLine(e.Graphics, null, (Point)_firstPoint, (Point)_secondPoint, noDash, GetFillColor());
                        noDash.Dispose();
                    }
                    else if (rectRadio.Checked || rectFillRadio.Checked)
                    {
                        DrawRectNoFill(e.Graphics, null, (Point)_firstPoint, (Point)_secondPoint, dashed, Color.Black);
                    }
                    else if (ellipseRadio.Checked || ellipseFillRadio.Checked)
                    {
                        DrawEllipseNoFill(e.Graphics, null, (Point)_firstPoint, (Point)_secondPoint, dashed, Color.Black);
                    }
                    else if (selectionRadio.Checked)
                    {
                        Pen dashedSelection = new(Color.Black, 1)
                        {
                            DashStyle = DashStyle.Dash
                        };

                        if (_movedPart is not null && _selection.HasValue && _isMovingSelection)
                        {
                            var toMove = Point.Subtract(_secondPoint.Value, (Size)_firstPoint);

                            var newRect = new Rectangle(_selection.Value.X + toMove.X,
                                _selection.Value.Y + toMove.Y,
                                _selection.Value.Width,
                                _selection.Value.Height);

                            //e.Graphics.FillRectangle(Brushes.White, _selection.Value);
                            e.Graphics.DrawRectangle(dashedSelection, newRect);
                            e.Graphics.DrawImage(_movedPart, new Point(newRect.X, newRect.Y));
                        }
                        else if (!_selection.HasValue)
                        {
                            DrawRectNoFill(e.Graphics,
                                null,
                                _firstPoint.Value,
                                _secondPoint.Value,
                                dashedSelection,
                                Color.Black);
                        }

                        dashedSelection.Dispose();
                    }

                    dashed.Dispose();
                }
            }

            if (_selection is not null && !_isMovingSelection)
            {
                Pen dashed = new(Color.Black, 1)
                {
                    DashStyle = DashStyle.Dash
                };

                if (_movedPart is not null)
                {
                    e.Graphics.DrawImage(_movedPart, new Point(_selection.Value.X, _selection.Value.Y));
                }

                e.Graphics.DrawRectangle(dashed, (Rectangle)_selection.Value);

                dashed.Dispose();
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
                _isMovingSelection = _selection?.Contains(e.Location) ?? false;

                _firstPoint = e.Location;
                _secondPoint = e.Location;
                _isDrawing = true;

                if (_isMovingSelection && _selection is not null)
                {
                    int x = _selection.Value.X;
                    int y = _selection.Value.Y;
                    int width = _selection.Value.Width;
                    int height = _selection.Value.Height;

                    if (x < 0)
                    {
                        width += x;
                        x = 0;
                    }
                    if (x + width > drawPictureBox.Width)
                    {
                        width -= x - drawPictureBox.Width;
                    }
                    if (y < 0)
                    {
                        height += y;
                        y = 0;
                    }
                    if (y + height > drawPictureBox.Height)
                    {
                        height += drawPictureBox.Height - y;
                    }

                    if (_movedPart is null)
                    {
                        Bitmap temp = new(drawPictureBox.Width, drawPictureBox.Height);
                        drawPictureBox.DrawToBitmap(temp, new Rectangle(0, 0, drawPictureBox.Width, drawPictureBox.Height));
                        _movedPart = temp.Clone(new Rectangle(x, y, width, height), System.Drawing.Imaging.PixelFormat.DontCare);
                        temp.Dispose();

                        _toDraw.Add(DrawRectNoBorder);
                        _pens.Add(new Pen(Color.Black));
                        _images.Add(null);
                        _firstPoints.Add(new Point(x, y));
                        _secondPoints.Add(new Point(x + width, y + height));
                        _fillColors.Add(Color.White);
                    }

                    Cursor.Current = Cursors.SizeAll;
                    drawPictureBox.Invalidate();
                }
                else
                {
                    if (_selection is not null)
                    {
                        if (_movedPart is not null)
                        {
                            _toDraw.Add(DrawImage);
                            _images.Add(_movedPart);
                            _pens.Add(new Pen(Color.Black, 1));
                            _firstPoints.Add(new Point(_selection.Value.X, _selection.Value.Y));
                            _secondPoints.Add(e.Location);
                            _fillColors.Add(Color.Black);
                            _movedPart = null;
                        }

                        _selection = null;
                        copyToolStripMenuItem.Enabled = false;
                    }
                }
            }
        }

        private void DrawPictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && _isDrawing)
            {
                var secondPoint = e.Location;
                _isDrawing = false;
                _changesMade = true;

                Func<Graphics, Bitmap?, Point, Point, Pen, Color, bool> drawFigure;

                if (selectionRadio.Checked && !_isMovingSelection)
                {
                    if (_firstPoint.Value.X - secondPoint.X != 0 && _firstPoint.Value.Y - secondPoint.Y != 0)
                    {
                        _selection = GetRectangleFromTwoPoints(_firstPoint ?? throw new Exception(), secondPoint);
                        copyToolStripMenuItem.Enabled = true;
                    }
                }
                else
                {
                    if (_selection is not null && _isMovingSelection && _secondPoint is not null && _firstPoint is not null)
                    {
                        _isMovingSelection = false;

                        var toMove = Point.Subtract(_secondPoint.Value, (Size)_firstPoint);

                        _selection = new Rectangle(_selection.Value.X + toMove.X,
                            _selection.Value.Y + toMove.Y,
                            _selection.Value.Width,
                            _selection.Value.Height);

                        Cursor.Current = Cursors.Default;
                    }
                    else
                    {
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

                        _images.Add(null);
                        _firstPoints.Add(_firstPoint ?? throw new Exception());
                        _toDraw.Add(drawFigure);
                        _secondPoints.Add(secondPoint);
                        _fillColors.Add(GetFillColor());
                        undoToolStripMenuItem.Enabled = true;
                    }
                }
                drawPictureBox.Invalidate();
            }
        }

        #endregion

        #region Static Drawing Shapes In Graphics Functions

        private static bool DrawLine(Graphics g, Image? image, Point first, Point second, Pen pen, Color fillColor)
        {
            g.DrawLine(pen, first, second);
            return true;
        }

        private static bool DrawRect(Graphics g, Image? image, Point first, Point second, Pen pen, Color fillColor)
        {
            Rectangle rect = GetRectangleFromTwoPoints(first, second);
            g.DrawRectangle(pen, rect);
            g.FillRectangle(new SolidBrush(fillColor), rect);
            return true;
        }

        private static bool DrawRectNoBorder(Graphics g, Image? image, Point first, Point second, Pen pen, Color fillColor)
        {
            Rectangle rect = GetRectangleFromTwoPoints(first, second);
            g.FillRectangle(new SolidBrush(fillColor), rect);
            return true;
        }

        private static bool DrawRectNoFill(Graphics g, Image? image, Point first, Point second, Pen pen, Color fillColor)
        {
            Rectangle rect = GetRectangleFromTwoPoints(first, second);
            g.DrawRectangle(pen, rect);
            return true;
        }

        private static bool DrawEllipse(Graphics g, Image? image, Point first, Point second, Pen pen, Color fillColor)
        {
            Rectangle rect = GetRectangleFromTwoPoints(first, second);
            g.DrawEllipse(pen, rect);
            g.FillEllipse(new SolidBrush(fillColor), rect);
            return true;
        }

        private static bool DrawEllipseNoFill(Graphics g, Image? image, Point first, Point second, Pen pen, Color fillColor)
        {
            Rectangle rect = GetRectangleFromTwoPoints(first, second);
            g.DrawEllipse(pen, rect);
            return true;
        }

        private static bool DrawImage(Graphics g, Image? image, Point first, Point second, Pen pen, Color fillColor)
        {
            if (image is not null)
            {
                g.DrawImage(image, first);
            }
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

        #region Key Events

        private void MainWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if (_isDrawing && e.KeyCode == Keys.Escape)
            {
                _isDrawing = false;
                _isMovingSelection = false;
                _firstPoint = null;
                _secondPoint = null;
                Cursor.Current = Cursors.Default;
                drawPictureBox.Invalidate();
            }
        }

        #endregion

    }
}