using System;
using System.Drawing;
using System.Windows.Forms;

namespace DrawingProgram
{
    // Form is the base class from Windows Forms (a window)
    // partial class means the class is split between Form1.cs and Form1.Designer.cs
    public partial class Form1 : Form
    {
        // Currrent color and shape
        private ShapeType currentShapeType = ShapeType.Line;
        private DrawableShape currentShape = null;
        private Color currentColor = Color.Black;

        // Polymorphic container for completed shapes
        private System.Collections.Generic.List<DrawableShape> shapes = new System.Collections.Generic.List<DrawableShape>();

        // Mouse positions
        private Point startPoint, endPoint;

        // Flag for if user currently drawing
        private bool isDrawing = false;

        // Double buffering
        private Bitmap backgroundBitmap;

        // Graphics object for drawing
        private Graphics backgroundGraphics;

        public enum ShapeType
        {
            Line, Rectangle, Ellipse
        }
        public Form1() // 
        {
            InitializeComponent(); // This will set up the UI by building all the buttons/controls from the Designer
            InitializeBackgroundBitmap();

            // Initial values for RGB
            txtRed.Text = "0";
            txtGreen.Text = "0";
            txtBlue.Text = "0";

            // Enable hidden property of double buffering on the panel
            drawingPanel.GetType().GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(drawingPanel, true, null);

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        // Method to create the correct shape based on currentShapeType
        private DrawableShape CreateShape(Point start, Point end, Color color)
        {
            switch (currentShapeType)
            {
                case ShapeType.Rectangle:
                    return new Rectangle(start, end, color);
                case ShapeType.Ellipse:
                    return new Ellipse(start, end, color);
                default:
                    return new Line(start, end, color);
            }
        }

        // Method to create background bitmap for double buffering
        private void InitializeBackgroundBitmap()
        {
            // Cleanup
            if (backgroundBitmap != null) { backgroundBitmap.Dispose(); }
            if (backgroundGraphics != null) { backgroundGraphics.Dispose(); }

            backgroundBitmap = new Bitmap(drawingPanel.Width, drawingPanel.Height); // New Bitmap matching the panel size
            backgroundGraphics = Graphics.FromImage(backgroundBitmap); // Graphics obect draws on the newly created bitmap
            backgroundGraphics.Clear(Color.White); // Prevents transparency

            foreach (var shape in shapes)
            {
                shape.DrawColoredShape(backgroundGraphics);
            }

        }

        // ---------------------------- Buttons ---------------------------- //

        private void btnLine_Click(object sender, EventArgs e)
        {
            currentShapeType = ShapeType.Line;
        }

        private void btnRectangle_Click(object sender, EventArgs e)
        {
            currentShapeType = ShapeType.Rectangle;
        }

        private void btnEllipse_Click(object sender, EventArgs e)
        {
            currentShapeType = ShapeType.Ellipse;
        }

        private void btnSetColor_Click(object sender, EventArgs e)
        {
            try
            {
                // Get the user-entered RGB values
                int r = int.Parse(txtRed.Text);
                int g = int.Parse(txtGreen.Text);
                int b = int.Parse(txtBlue.Text);

                // Validate the value ranges
                if (r < 0 || r > 255 || g < 0 || g > 255 || b < 0 || b > 255)
                {
                    MessageBox.Show("RGB values must be between 0 and 255");
                    return;
                }

                // get the color if valid values
                currentColor = Color.FromArgb(r, g, b);
                // Set preview to color
                colorPreview.BackColor = currentColor;
            }
            catch (FormatException) // if user typed non-numeric characters
            {
                MessageBox.Show("Please enter numerical values");
            }
        }

        // ---------------------------- Mouse Events ---------------------------- //

        // User presses down mouse button to start drawing
        private void drawingPanel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) // Only works for left mouse button
            {
                isDrawing = true;
                startPoint = e.Location;
                endPoint = e.Location;
                currentShape = CreateShape(startPoint, endPoint, currentColor);
            }
        }

        // User moves mouse, update shape size
        private void drawingPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDrawing && currentShape != null)
            {
                endPoint = e.Location;
                currentShape.UpdateEndPoint(endPoint);
                drawingPanel.Invalidate(); // Forces the panel to redraw
            }
        }

        // User releases mouse button, finish shape
        private void drawingPanel_MouseUp(object sender, MouseEventArgs e)
        {
            if (isDrawing && currentShape != null)
            {
                isDrawing = false;
                shapes.Add(currentShape); // Newly created shape to list container
                currentShape.DrawColoredShape(backgroundGraphics); // Draw it permanently on background Bitmap
                currentShape = null; // Clear temp shape
                drawingPanel.Invalidate();
            }
        }

        // ---------------------------- Paint Event ---------------------------- //
        // The drawingPanel.Invalidate() method calls the Paint Event to redraw everything with updates
        private void drawingPanel_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(backgroundBitmap, 0, 0); // e.graphics is the "paintbrush", draws the Bitmap here

            // Draw the shape we're currently drawing on top of Bitmap
            if (isDrawing && currentShape != null)
            {
                currentShape.DrawColoredShape(e.Graphics);
            }
        }

        // ---------------------------- Resize Event ---------------------------- //
        // Recreate Bitmap with new size and redraw everything
        private void drawingPanel_Resize(object sender, EventArgs e)
        {
            InitializeBackgroundBitmap();
            drawingPanel.Invalidate();
        }

        // ---------------------------- Classes ---------------------------- //
        // Abstract base class for all shapes (polymorphism and abstraction)
        public abstract class DrawableShape
        {
            protected Point startPoint;
            protected Point endPoint;
            protected Color color;

            public DrawableShape(Point startPoint, Point endPoint, Color color)
            {
                this.startPoint = startPoint;
                this.endPoint = endPoint;
                this.color = color;
            }

            // Dynamic sizing
            public void UpdateEndPoint(Point newEnd)
            {
                this.endPoint = newEnd;
            }

            // Per assignment instructions
            public abstract void DrawColoredShape(Graphics g);

            // Helper method to help draw in any direction
            protected System.Drawing.Rectangle GetBoundingRectangle()
            {
                int x = Math.Min(startPoint.X, endPoint.X);
                int y = Math.Min(startPoint.Y, endPoint.Y);
                int width = Math.Abs(endPoint.X - startPoint.X);
                int height = Math.Abs(endPoint.Y - startPoint.Y);

                return new System.Drawing.Rectangle(x, y, width, height);
            }
        }

        // Line class
        public class Line : DrawableShape
        {
            public Line(Point startPoint, Point endPoint, Color color)
                : base(startPoint, endPoint, color)
            {
            }

            // Implement abstract method
            public override void DrawColoredShape(Graphics g)
            {
                using (Pen pen = new Pen(color, 2)) // 2 is the pixel width
                {
                    g.DrawLine(pen, startPoint, endPoint);
                }
            }
        }

        // Rectangle Class
        public class Rectangle : DrawableShape
        {
            public Rectangle(Point startPoint, Point endPoint, Color color)
                : base(startPoint, endPoint, color)
            {
            }

            // Implement abstract method
            public override void DrawColoredShape(Graphics g)
            {
                using (Pen pen = new Pen(color, 2)) // 2 is the pixel width
                {
                    System.Drawing.Rectangle rect = GetBoundingRectangle();
                    g.DrawRectangle(pen, rect);
                }
            }
        }

        // Ellipse Class
        public class Ellipse : DrawableShape
        {
            public Ellipse(Point startPoint, Point endPoint, Color color)
                : base(startPoint, endPoint, color)
            {
            }

            // Implement abstract method
            public override void DrawColoredShape(Graphics g)
            {
                using (Pen pen = new Pen(color, 2)) // 2 is the pixel width
                {
                    System.Drawing.Rectangle rect = GetBoundingRectangle();
                    g.DrawEllipse(pen, rect);
                }
            }
        }
    }
}


