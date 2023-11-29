using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace PowerPoint
{
    public class FromGraphicsAdapter : IGraphics
    {
        Graphics _graphics;
        const int SIZE_TWO = 2;
        const int FIVE = 5;
        const int TEN = 10;

        public FromGraphicsAdapter(Graphics graphics)
        {
            this._graphics = graphics;
        }

        // ClearAll
        public void ClearAll()
        {
            // OnPaint時會自動清除畫面，因此不需實作
        }

        // DrawLine
        public void DrawLine(double x1, double y1, double x2, double y2)
        {
            _graphics.DrawLine(Pens.Black, (float)x1, (float)y1, (float)x2, (float)y2);
        }

        // DrawLineSelected
        public void DrawLineSelected(double x1, double y1, double x2, double y2)
        {
            _graphics.DrawLine(Pens.Black, (float)x1, (float)y1, (float)x2, (float)y2);
            float selectionSize = TEN;
            _graphics.DrawEllipse(Pens.Red, (float)x1 - selectionSize / SIZE_TWO, (float)y1 - selectionSize / SIZE_TWO, selectionSize, selectionSize);
            _graphics.DrawEllipse(Pens.Red, (float)x2 - selectionSize / SIZE_TWO, (float)y2 - selectionSize / SIZE_TWO, selectionSize, selectionSize);
        }

        // DrawRectangle
        public void DrawRectangle(double x1, double y1, double x2, double y2)
        {
            _graphics.DrawRectangle(Pens.Black, (float)x1, (float)y1, (float)Math.Abs(x2 - x1), (float)Math.Abs(y2 - y1));
        }
        
        // DrawRectangleSelected
        public void DrawRectangleSelected(double x1, double y1, double x2, double y2)
        {
            _graphics.DrawRectangle(Pens.Black, (float)x1, (float)y1, (float)Math.Abs(x2 - x1), (float)Math.Abs(y2 - y1));
            float topLeftX = (float)x1;
            float topLeftY = (float)y1;
            float topRightX = (float)x2;
            float topRightY = (float)y1;
            float bottomLeftX = (float)x1;
            float bottomLeftY = (float)y2;
            float bottomRightX = (float)x2;
            float bottomRightY = (float)y2;
            float cornerRadius = FIVE; // 小圓的半徑
            _graphics.DrawEllipse(Pens.Red, topLeftX - cornerRadius, topLeftY - cornerRadius, SIZE_TWO * cornerRadius, SIZE_TWO * cornerRadius);
            _graphics.DrawEllipse(Pens.Red, topRightX - cornerRadius, topRightY - cornerRadius, SIZE_TWO * cornerRadius, SIZE_TWO * cornerRadius);
            _graphics.DrawEllipse(Pens.Red, bottomLeftX - cornerRadius, bottomLeftY - cornerRadius, SIZE_TWO * cornerRadius, SIZE_TWO * cornerRadius);
            _graphics.DrawEllipse(Pens.Red, bottomRightX - cornerRadius, bottomRightY - cornerRadius, SIZE_TWO * cornerRadius, SIZE_TWO * cornerRadius);
        }
        
        // DrawCircle
        public void DrawCircle(double x1, double y1, double x2, double y2)
        {
            _graphics.DrawEllipse(Pens.Black, (float)x1, (float)y1, (float)(x2 - x1), (float)(y2 - y1));
        }
        
        // DrawCircleSelected
        public void DrawCircleSelected(double x1, double y1, double x2, double y2)
        {
            using (Pen dashedPen = new Pen(Color.Black))
            {
                dashedPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
                _graphics.DrawRectangle(dashedPen, (float)x1, (float)y1, (float)Math.Abs(x2 - x1), (float)Math.Abs(y2 - y1));
            }
            _graphics.DrawEllipse(Pens.Black, (float)x1, (float)y1, (float)(x2 - x1), (float)(y2 - y1));

            float centerX = (float)((x1 + x2) / SIZE_TWO);
            float centerY = (float)((y1 + y2) / SIZE_TWO);
            float majorValue = (float)Math.Abs(x2 - x1) / SIZE_TWO;
            float minorValue = (float)Math.Abs(y2 - y1) / SIZE_TWO;
            float cornerRadius = FIVE; // 小圓的半徑
            _graphics.DrawEllipse(Pens.Red, centerX - cornerRadius, centerY - minorValue - cornerRadius, SIZE_TWO * cornerRadius, SIZE_TWO * cornerRadius);
            _graphics.DrawEllipse(Pens.Red, centerX - cornerRadius, centerY + minorValue - cornerRadius, SIZE_TWO * cornerRadius, SIZE_TWO * cornerRadius);
            _graphics.DrawEllipse(Pens.Red, centerX - majorValue - cornerRadius, centerY - cornerRadius, SIZE_TWO * cornerRadius, SIZE_TWO * cornerRadius);
            _graphics.DrawEllipse(Pens.Red, centerX + majorValue - cornerRadius, centerY - cornerRadius, SIZE_TWO * cornerRadius, SIZE_TWO * cornerRadius);
            _graphics.DrawEllipse(Pens.Red, (float)x1 - cornerRadius, (float)y1 - cornerRadius, SIZE_TWO * cornerRadius, SIZE_TWO * cornerRadius);
            _graphics.DrawEllipse(Pens.Red, (float)x2 - cornerRadius, (float)y1 - cornerRadius, SIZE_TWO * cornerRadius, SIZE_TWO * cornerRadius);
            _graphics.DrawEllipse(Pens.Red, (float)x1 - cornerRadius, (float)y2 - cornerRadius, SIZE_TWO * cornerRadius, SIZE_TWO * cornerRadius);
            _graphics.DrawEllipse(Pens.Red, (float)x2 - cornerRadius, (float)y2 - cornerRadius, SIZE_TWO * cornerRadius, SIZE_TWO * cornerRadius);
        }
    }
}
