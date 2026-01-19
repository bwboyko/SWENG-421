namespace DrawingProgram
{
    partial class Form1
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
            btnLine = new Button();
            btnRectangle = new Button();
            btnEllipse = new Button();
            drawingPanel = new Panel();
            labelRed = new Label();
            labelBlue = new Label();
            labelGreen = new Label();
            txtRed = new TextBox();
            txtGreen = new TextBox();
            txtBlue = new TextBox();
            btnSetColor = new Button();
            colorPreview = new Panel();
            SuspendLayout();
            // 
            // btnLine
            // 
            btnLine.Location = new Point(12, 12);
            btnLine.Name = "btnLine";
            btnLine.Size = new Size(75, 23);
            btnLine.TabIndex = 0;
            btnLine.Text = "Line";
            btnLine.UseVisualStyleBackColor = true;
            btnLine.Click += btnLine_Click;
            // 
            // btnRectangle
            // 
            btnRectangle.Location = new Point(93, 12);
            btnRectangle.Name = "btnRectangle";
            btnRectangle.Size = new Size(75, 23);
            btnRectangle.TabIndex = 1;
            btnRectangle.Text = "Rectangle";
            btnRectangle.UseVisualStyleBackColor = true;
            btnRectangle.Click += btnRectangle_Click;
            // 
            // btnEllipse
            // 
            btnEllipse.Location = new Point(174, 12);
            btnEllipse.Name = "btnEllipse";
            btnEllipse.Size = new Size(75, 23);
            btnEllipse.TabIndex = 2;
            btnEllipse.Text = "Ellipse";
            btnEllipse.UseVisualStyleBackColor = true;
            btnEllipse.Click += btnEllipse_Click;
            // 
            // drawingPanel
            // 
            drawingPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            drawingPanel.BorderStyle = BorderStyle.FixedSingle;
            drawingPanel.Location = new Point(101, 74);
            drawingPanel.Name = "drawingPanel";
            drawingPanel.Size = new Size(681, 485);
            drawingPanel.TabIndex = 3;
            drawingPanel.Paint += drawingPanel_Paint;
            drawingPanel.MouseDown += drawingPanel_MouseDown;
            drawingPanel.MouseMove += drawingPanel_MouseMove;
            drawingPanel.MouseUp += drawingPanel_MouseUp;
            drawingPanel.Resize += drawingPanel_Resize;
            // 
            // labelRed
            // 
            labelRed.AutoSize = true;
            labelRed.Location = new Point(257, 15);
            labelRed.Name = "labelRed";
            labelRed.Size = new Size(17, 15);
            labelRed.TabIndex = 4;
            labelRed.Text = "R:";
            // 
            // labelBlue
            // 
            labelBlue.AutoSize = true;
            labelBlue.Location = new Point(421, 15);
            labelBlue.Name = "labelBlue";
            labelBlue.Size = new Size(17, 15);
            labelBlue.TabIndex = 5;
            labelBlue.Text = "B:";
            // 
            // labelGreen
            // 
            labelGreen.AutoSize = true;
            labelGreen.Location = new Point(337, 16);
            labelGreen.Name = "labelGreen";
            labelGreen.Size = new Size(18, 15);
            labelGreen.TabIndex = 6;
            labelGreen.Text = "G:";
            // 
            // txtRed
            // 
            txtRed.Location = new Point(277, 12);
            txtRed.Name = "txtRed";
            txtRed.Size = new Size(54, 23);
            txtRed.TabIndex = 7;
            txtRed.Text = "0";
            // 
            // txtGreen
            // 
            txtGreen.Location = new Point(361, 11);
            txtGreen.Name = "txtGreen";
            txtGreen.Size = new Size(54, 23);
            txtGreen.TabIndex = 8;
            txtGreen.Text = "0";
            // 
            // txtBlue
            // 
            txtBlue.Location = new Point(444, 12);
            txtBlue.Name = "txtBlue";
            txtBlue.Size = new Size(54, 23);
            txtBlue.TabIndex = 9;
            txtBlue.Text = "0";
            // 
            // btnSetColor
            // 
            btnSetColor.Location = new Point(504, 12);
            btnSetColor.Name = "btnSetColor";
            btnSetColor.Size = new Size(75, 23);
            btnSetColor.TabIndex = 10;
            btnSetColor.Text = "Set Color";
            btnSetColor.UseVisualStyleBackColor = true;
            btnSetColor.Click += btnSetColor_Click;
            // 
            // colorPreview
            // 
            colorPreview.BackColor = Color.Black;
            colorPreview.BorderStyle = BorderStyle.FixedSingle;
            colorPreview.Location = new Point(585, 12);
            colorPreview.Name = "colorPreview";
            colorPreview.Size = new Size(35, 35);
            colorPreview.TabIndex = 11;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(933, 584);
            Controls.Add(colorPreview);
            Controls.Add(btnSetColor);
            Controls.Add(txtBlue);
            Controls.Add(txtGreen);
            Controls.Add(txtRed);
            Controls.Add(labelGreen);
            Controls.Add(labelBlue);
            Controls.Add(labelRed);
            Controls.Add(drawingPanel);
            Controls.Add(btnEllipse);
            Controls.Add(btnRectangle);
            Controls.Add(btnLine);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnLine;
        private Button btnRectangle;
        private Button btnEllipse;
        private Panel drawingPanel;
        private Label labelRed;
        private Label labelBlue;
        private Label labelGreen;
        private TextBox txtRed;
        private TextBox txtGreen;
        private TextBox txtBlue;
        private Button btnSetColor;
        private Panel colorPreview;
    }
}
