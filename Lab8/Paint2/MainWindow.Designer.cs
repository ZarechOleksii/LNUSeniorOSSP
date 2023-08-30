namespace Paint2
{
    partial class MainWindow
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            menuStrip1 = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            newFileToolStripMenuItem = new ToolStripMenuItem();
            openStripMenuItem = new ToolStripMenuItem();
            saveToolStripMenuItem = new ToolStripMenuItem();
            saveAsToolStripMenuItem = new ToolStripMenuItem();
            exitToolStripMenuItem = new ToolStripMenuItem();
            allContainer = new Panel();
            areaPanel = new Panel();
            resizablePanel = new Panel();
            drawPictureBox = new PictureBox();
            flowLayoutPanel2 = new FlowLayoutPanel();
            lineWidthBox = new GroupBox();
            lineWidthControl = new NumericUpDown();
            lineColorBox = new GroupBox();
            selectedLineColor = new Panel();
            selectColorButton = new Button();
            fillColorBox = new GroupBox();
            selectedFillColor = new Panel();
            selectFillColorButton = new Button();
            flowLayoutPanel1 = new FlowLayoutPanel();
            lineRadio = new RadioButton();
            rectRadio = new RadioButton();
            rectFillRadio = new RadioButton();
            ellipseRadio = new RadioButton();
            ellipseFillRadio = new RadioButton();
            statusStrip1 = new StatusStrip();
            statusLabel = new ToolStripStatusLabel();
            menuStrip1.SuspendLayout();
            allContainer.SuspendLayout();
            areaPanel.SuspendLayout();
            resizablePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)drawPictureBox).BeginInit();
            flowLayoutPanel2.SuspendLayout();
            lineWidthBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)lineWidthControl).BeginInit();
            lineColorBox.SuspendLayout();
            fillColorBox.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.RenderMode = ToolStripRenderMode.System;
            menuStrip1.Size = new Size(1402, 28);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { newFileToolStripMenuItem, openStripMenuItem, saveToolStripMenuItem, saveAsToolStripMenuItem, exitToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(46, 24);
            fileToolStripMenuItem.Text = "File";
            // 
            // newFileToolStripMenuItem
            // 
            newFileToolStripMenuItem.Name = "newFileToolStripMenuItem";
            newFileToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.N;
            newFileToolStripMenuItem.Size = new Size(231, 26);
            newFileToolStripMenuItem.Text = "New file";
            newFileToolStripMenuItem.Click += NewFileToolStripMenuItem_Click;
            // 
            // openStripMenuItem
            // 
            openStripMenuItem.Name = "openStripMenuItem";
            openStripMenuItem.ShortcutKeys = Keys.Control | Keys.O;
            openStripMenuItem.Size = new Size(231, 26);
            openStripMenuItem.Text = "Open";
            openStripMenuItem.Click += OpenStripMenuItem_Click;
            // 
            // saveToolStripMenuItem
            // 
            saveToolStripMenuItem.Enabled = false;
            saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            saveToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.S;
            saveToolStripMenuItem.Size = new Size(231, 26);
            saveToolStripMenuItem.Text = "Save";
            saveToolStripMenuItem.Click += SaveToolStripMenuItem_Click;
            // 
            // saveAsToolStripMenuItem
            // 
            saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            saveAsToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.Shift | Keys.S;
            saveAsToolStripMenuItem.Size = new Size(231, 26);
            saveAsToolStripMenuItem.Text = "Save as";
            saveAsToolStripMenuItem.Click += SaveAsToolStripMenuItem_Click;
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new Size(231, 26);
            exitToolStripMenuItem.Text = "Exit";
            exitToolStripMenuItem.Click += ExitToolStripMenuItem_Click;
            // 
            // allContainer
            // 
            allContainer.Controls.Add(areaPanel);
            allContainer.Controls.Add(flowLayoutPanel2);
            allContainer.Controls.Add(flowLayoutPanel1);
            allContainer.Controls.Add(statusStrip1);
            allContainer.Dock = DockStyle.Fill;
            allContainer.Location = new Point(0, 28);
            allContainer.Name = "allContainer";
            allContainer.Size = new Size(1402, 654);
            allContainer.TabIndex = 1;
            // 
            // areaPanel
            // 
            areaPanel.AutoScroll = true;
            areaPanel.AutoSize = true;
            areaPanel.BackColor = Color.FromArgb(0, 0, 64);
            areaPanel.BorderStyle = BorderStyle.FixedSingle;
            areaPanel.Controls.Add(resizablePanel);
            areaPanel.Dock = DockStyle.Fill;
            areaPanel.Location = new Point(135, 0);
            areaPanel.MinimumSize = new Size(200, 200);
            areaPanel.Name = "areaPanel";
            areaPanel.Size = new Size(1151, 628);
            areaPanel.TabIndex = 3;
            // 
            // resizablePanel
            // 
            resizablePanel.BackColor = Color.MediumPurple;
            resizablePanel.Controls.Add(drawPictureBox);
            resizablePanel.Location = new Point(3, 3);
            resizablePanel.MinimumSize = new Size(50, 50);
            resizablePanel.Name = "resizablePanel";
            resizablePanel.Size = new Size(891, 518);
            resizablePanel.TabIndex = 0;
            resizablePanel.MouseDown += ResizablePanel_MouseDown;
            resizablePanel.MouseMove += ResizablePanel_MouseMove;
            resizablePanel.MouseUp += ResizablePanel_MouseUp;
            // 
            // drawPictureBox
            // 
            drawPictureBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            drawPictureBox.BackColor = Color.White;
            drawPictureBox.Location = new Point(0, 0);
            drawPictureBox.Name = "drawPictureBox";
            drawPictureBox.Size = new Size(888, 515);
            drawPictureBox.TabIndex = 0;
            drawPictureBox.TabStop = false;
            drawPictureBox.Paint += DrawPictureBox_Paint;
            drawPictureBox.MouseDown += DrawPictureBox_MouseDown;
            drawPictureBox.MouseLeave += DrawPictureBox_MouseLeave;
            drawPictureBox.MouseMove += DrawPictureBox_MouseMove;
            drawPictureBox.MouseUp += DrawPictureBox_MouseUp;
            // 
            // flowLayoutPanel2
            // 
            flowLayoutPanel2.BackColor = Color.MidnightBlue;
            flowLayoutPanel2.BorderStyle = BorderStyle.FixedSingle;
            flowLayoutPanel2.Controls.Add(lineWidthBox);
            flowLayoutPanel2.Controls.Add(lineColorBox);
            flowLayoutPanel2.Controls.Add(fillColorBox);
            flowLayoutPanel2.Dock = DockStyle.Right;
            flowLayoutPanel2.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel2.Location = new Point(1286, 0);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            flowLayoutPanel2.Size = new Size(116, 628);
            flowLayoutPanel2.TabIndex = 2;
            // 
            // lineWidthBox
            // 
            lineWidthBox.Controls.Add(lineWidthControl);
            lineWidthBox.ForeColor = Color.White;
            lineWidthBox.Location = new Point(3, 3);
            lineWidthBox.Name = "lineWidthBox";
            lineWidthBox.RightToLeft = RightToLeft.No;
            lineWidthBox.Size = new Size(110, 65);
            lineWidthBox.TabIndex = 0;
            lineWidthBox.TabStop = false;
            lineWidthBox.Text = "Line Width";
            // 
            // lineWidthControl
            // 
            lineWidthControl.Location = new Point(6, 26);
            lineWidthControl.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            lineWidthControl.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            lineWidthControl.Name = "lineWidthControl";
            lineWidthControl.Size = new Size(98, 27);
            lineWidthControl.TabIndex = 3;
            lineWidthControl.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // lineColorBox
            // 
            lineColorBox.Controls.Add(selectedLineColor);
            lineColorBox.Controls.Add(selectColorButton);
            lineColorBox.ForeColor = Color.White;
            lineColorBox.Location = new Point(3, 74);
            lineColorBox.Name = "lineColorBox";
            lineColorBox.RightToLeft = RightToLeft.No;
            lineColorBox.Size = new Size(110, 98);
            lineColorBox.TabIndex = 4;
            lineColorBox.TabStop = false;
            lineColorBox.Text = "Line Color";
            // 
            // selectedLineColor
            // 
            selectedLineColor.BackColor = Color.Black;
            selectedLineColor.BorderStyle = BorderStyle.FixedSingle;
            selectedLineColor.Location = new Point(6, 26);
            selectedLineColor.Name = "selectedLineColor";
            selectedLineColor.Size = new Size(98, 29);
            selectedLineColor.TabIndex = 4;
            // 
            // selectColorButton
            // 
            selectColorButton.ForeColor = Color.Black;
            selectColorButton.Location = new Point(6, 61);
            selectColorButton.Name = "selectColorButton";
            selectColorButton.Size = new Size(98, 30);
            selectColorButton.TabIndex = 3;
            selectColorButton.Text = "Select";
            selectColorButton.UseVisualStyleBackColor = true;
            selectColorButton.Click += SelectLineColorButton_Click;
            // 
            // fillColorBox
            // 
            fillColorBox.Controls.Add(selectedFillColor);
            fillColorBox.Controls.Add(selectFillColorButton);
            fillColorBox.ForeColor = Color.White;
            fillColorBox.Location = new Point(3, 178);
            fillColorBox.Name = "fillColorBox";
            fillColorBox.RightToLeft = RightToLeft.No;
            fillColorBox.Size = new Size(110, 98);
            fillColorBox.TabIndex = 5;
            fillColorBox.TabStop = false;
            fillColorBox.Text = "Fill Color";
            // 
            // selectedFillColor
            // 
            selectedFillColor.BackColor = Color.Black;
            selectedFillColor.BorderStyle = BorderStyle.FixedSingle;
            selectedFillColor.Location = new Point(6, 26);
            selectedFillColor.Name = "selectedFillColor";
            selectedFillColor.Size = new Size(98, 29);
            selectedFillColor.TabIndex = 4;
            // 
            // selectFillColorButton
            // 
            selectFillColorButton.ForeColor = Color.Black;
            selectFillColorButton.Location = new Point(6, 61);
            selectFillColorButton.Name = "selectFillColorButton";
            selectFillColorButton.Size = new Size(98, 30);
            selectFillColorButton.TabIndex = 3;
            selectFillColorButton.Text = "Select";
            selectFillColorButton.UseVisualStyleBackColor = true;
            selectFillColorButton.Click += SelectFillColorButton_Click;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.BackColor = Color.MidnightBlue;
            flowLayoutPanel1.BorderStyle = BorderStyle.FixedSingle;
            flowLayoutPanel1.Controls.Add(lineRadio);
            flowLayoutPanel1.Controls.Add(rectRadio);
            flowLayoutPanel1.Controls.Add(rectFillRadio);
            flowLayoutPanel1.Controls.Add(ellipseRadio);
            flowLayoutPanel1.Controls.Add(ellipseFillRadio);
            flowLayoutPanel1.Dock = DockStyle.Left;
            flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel1.Location = new Point(0, 0);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(135, 628);
            flowLayoutPanel1.TabIndex = 1;
            // 
            // lineRadio
            // 
            lineRadio.AutoSize = true;
            lineRadio.Checked = true;
            lineRadio.ForeColor = Color.White;
            lineRadio.Location = new Point(3, 3);
            lineRadio.Name = "lineRadio";
            lineRadio.Size = new Size(57, 24);
            lineRadio.TabIndex = 0;
            lineRadio.TabStop = true;
            lineRadio.Text = "Line";
            lineRadio.UseVisualStyleBackColor = true;
            // 
            // rectRadio
            // 
            rectRadio.AutoSize = true;
            rectRadio.ForeColor = Color.White;
            rectRadio.Location = new Point(3, 33);
            rectRadio.Name = "rectRadio";
            rectRadio.Size = new Size(96, 24);
            rectRadio.TabIndex = 1;
            rectRadio.Text = "Rectangle";
            rectRadio.UseVisualStyleBackColor = true;
            // 
            // rectFillRadio
            // 
            rectFillRadio.AutoSize = true;
            rectFillRadio.ForeColor = Color.White;
            rectFillRadio.Location = new Point(3, 63);
            rectFillRadio.Name = "rectFillRadio";
            rectFillRadio.Size = new Size(129, 24);
            rectFillRadio.TabIndex = 3;
            rectFillRadio.Text = "Rectangle (Fill)";
            rectFillRadio.UseVisualStyleBackColor = true;
            // 
            // ellipseRadio
            // 
            ellipseRadio.AutoSize = true;
            ellipseRadio.ForeColor = Color.White;
            ellipseRadio.Location = new Point(3, 93);
            ellipseRadio.Name = "ellipseRadio";
            ellipseRadio.Size = new Size(73, 24);
            ellipseRadio.TabIndex = 2;
            ellipseRadio.Text = "Ellipse";
            ellipseRadio.UseVisualStyleBackColor = true;
            // 
            // ellipseFillRadio
            // 
            ellipseFillRadio.AutoSize = true;
            ellipseFillRadio.ForeColor = Color.White;
            ellipseFillRadio.Location = new Point(3, 123);
            ellipseFillRadio.Name = "ellipseFillRadio";
            ellipseFillRadio.Size = new Size(106, 24);
            ellipseFillRadio.TabIndex = 4;
            ellipseFillRadio.Text = "Ellipse (Fill)";
            ellipseFillRadio.UseVisualStyleBackColor = true;
            // 
            // statusStrip1
            // 
            statusStrip1.BackColor = Color.MidnightBlue;
            statusStrip1.ImageScalingSize = new Size(20, 20);
            statusStrip1.Items.AddRange(new ToolStripItem[] { statusLabel });
            statusStrip1.Location = new Point(0, 628);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(1402, 26);
            statusStrip1.TabIndex = 0;
            statusStrip1.Text = "statusStrip1";
            // 
            // statusLabel
            // 
            statusLabel.ForeColor = Color.White;
            statusLabel.Name = "statusLabel";
            statusLabel.Size = new Size(1387, 20);
            statusLabel.Spring = true;
            statusLabel.Text = "Waiting...";
            statusLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // MainWindow
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1402, 682);
            Controls.Add(allContainer);
            Controls.Add(menuStrip1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStrip1;
            MinimumSize = new Size(500, 500);
            Name = "MainWindow";
            Text = "Paint 2.0";
            WindowState = FormWindowState.Maximized;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            allContainer.ResumeLayout(false);
            allContainer.PerformLayout();
            areaPanel.ResumeLayout(false);
            resizablePanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)drawPictureBox).EndInit();
            flowLayoutPanel2.ResumeLayout(false);
            lineWidthBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)lineWidthControl).EndInit();
            lineColorBox.ResumeLayout(false);
            fillColorBox.ResumeLayout(false);
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem newFileToolStripMenuItem;
        private ToolStripMenuItem openStripMenuItem;
        private ToolStripMenuItem saveToolStripMenuItem;
        private ToolStripMenuItem saveAsToolStripMenuItem;
        private ToolStripMenuItem exitToolStripMenuItem;
        private Panel allContainer;
        private Panel areaPanel;
        private Panel resizablePanel;
        private FlowLayoutPanel flowLayoutPanel2;
        private FlowLayoutPanel flowLayoutPanel1;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel statusLabel;
        private Button selectColorButton;
        private GroupBox lineWidthBox;
        private NumericUpDown lineWidthControl;
        private GroupBox lineColorBox;
        private Panel selectedLineColor;
        private GroupBox fillColorBox;
        private Panel selectedFillColor;
        private Button selectFillColorButton;
        private RadioButton lineRadio;
        private RadioButton rectRadio;
        private RadioButton ellipseRadio;
        private RadioButton rectFillRadio;
        private RadioButton ellipseFillRadio;
        private PictureBox drawPictureBox;
    }
}