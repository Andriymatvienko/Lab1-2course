using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace WindowsFormsApp2
{
    class CCircle
    {
        const int DefaultRadius = 50;

        private Graphics graphics;
        private int _radius;

        public int X { get; set; }
        public int Y { get; set; }
        public int Radius
        {
            get
            {
                return _radius;
            }
            set
            {
                _radius = value >= 200 ? 200 : value;
                _radius = value <= 5 ? 5 : value;
            }
        }

        public CCircle(Graphics graphics, int X, int Y)
        {
            this.graphics = graphics;
            this.X = X;
            this.Y = Y;
            this.Radius = DefaultRadius;
        }

        public CCircle(Graphics graphics, int X, int Y, int Radius)
        {
            this.graphics = graphics;
            this.X = X;
            this.Y = Y;
            this.Radius = Radius;
        }

        private void DrawCircle(Pen pen)
        {
            Rectangle rectangle = new Rectangle(X - Radius, Y + Radius, 2 * Radius, 2 * Radius);
            graphics.ResetTransform();
            graphics.TranslateTransform(X, Y);
            graphics.RotateTransform(90);
            graphics.TranslateTransform(-X, -Y);
            graphics.DrawEllipse(pen, rectangle);
        }

        private void DrawSquare(Pen pen)
        {
            int squareSideLength = 2 * Radius;
            Rectangle squareRect = new Rectangle(X - squareSideLength / 2, Y - squareSideLength / 2, squareSideLength, squareSideLength);
            graphics.ResetTransform();
            graphics.TranslateTransform(X, Y);
            graphics.RotateTransform(90);
            graphics.TranslateTransform(-X, -Y);
            graphics.DrawRectangle(pen, squareRect);
        }

        private void DrawTriangle(Pen pen)
        {
            int triangleSideLength = 2 * Radius;
            int triangleX = X + 2 * Radius;
            Point[] originalTrianglePoints = new Point[]
            {
        new Point(triangleX, Y - triangleSideLength / 2),
        new Point(triangleX + triangleSideLength / 2, Y + triangleSideLength / 2),
        new Point(triangleX - triangleSideLength / 2, Y + triangleSideLength / 2)
            };
            graphics.ResetTransform();
            graphics.TranslateTransform(triangleX, Y);
            graphics.RotateTransform(90);
            graphics.TranslateTransform(-triangleX, -Y);
            graphics.DrawPolygon(pen, originalTrianglePoints);
        }

        public void Show()
        {
            DrawCircle(Pens.Red);
            DrawSquare(Pens.Green);
            DrawTriangle(Pens.Blue);
        }

        public void Hide()
        {
            DrawCircle(Pens.White);
            DrawSquare(Pens.White);
            DrawTriangle(Pens.White);
        }

        public void Expand()
        {
            Hide();
            Radius++;
            Show();
        }

        public void Expand(int dR)
        {
            Hide();
            Radius = Radius + dR;
            Show();
        }

        public void Collapse()
        {
            Hide();
            Radius--;
            Show();
        }

        public void Collapse(int dR)
        {
            Hide();
            Radius = Radius - dR;
            Show();
        }

        public void Move(int dX, int dY)
        {
            Hide();
            X = X + dX;
            Y = Y + dY;
            Show();
        }
    }
}
