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
            float selectionSize = 10;
            _graphics.DrawEllipse(Pens.Red, (float)x1 - selectionSize / 2, (float)y1 - selectionSize / 2, selectionSize, selectionSize);
            _graphics.DrawEllipse(Pens.Red, (float)x2 - selectionSize / 2, (float)y2 - selectionSize / 2, selectionSize, selectionSize);
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
            float cornerRadius = 5; // 小圓的半徑
            _graphics.DrawEllipse(Pens.Red, topLeftX - cornerRadius, topLeftY - cornerRadius, 2 * cornerRadius, 2 * cornerRadius);
            _graphics.DrawEllipse(Pens.Red, topRightX - cornerRadius, topRightY - cornerRadius, 2 * cornerRadius, 2 * cornerRadius);
            _graphics.DrawEllipse(Pens.Red, bottomLeftX - cornerRadius, bottomLeftY - cornerRadius, 2 * cornerRadius, 2 * cornerRadius);
            _graphics.DrawEllipse(Pens.Red, bottomRightX - cornerRadius, bottomRightY - cornerRadius, 2 * cornerRadius, 2 * cornerRadius);
        }
        
        // DrawCircle
        public void DrawCircle(double x1, double y1, double x2, double y2)
        {
            _graphics.DrawEllipse(Pens.Black, (float)x1, (float)y1, (float)(x2 - x1), (float)(y2 - y1));
        }
        
        // DrawCircleSelected
        public void DrawCircleSelected(double x1, double y1, double x2, double y2)
        {
            _graphics.DrawEllipse(Pens.Black, (float)x1, (float)y1, (float)(x2 - x1), (float)(y2 - y1));

            // 計算橢圓中心和半軸
            float centerX = (float)((x1 + x2) / 2);
            float centerY = (float)((y1 + y2) / 2);
            float semiMajorAxis = (float)Math.Abs(x2 - x1) / 2;
            float semiMinorAxis = (float)Math.Abs(y2 - y1) / 2;

            // 計算上下左右四個邊線的坐標
            float topX = centerX;
            float topY = centerY - semiMinorAxis;

            float bottomX = centerX;
            float bottomY = centerY + semiMinorAxis;

            float leftX = centerX - semiMajorAxis;
            float leftY = centerY;

            float rightX = centerX + semiMajorAxis;
            float rightY = centerY;

            float cornerRadius = 5; // 小圓的半徑

            // 在四個角和四條邊線畫小圓形
            _graphics.DrawEllipse(Pens.Red, topX - cornerRadius, topY - cornerRadius, 2 * cornerRadius, 2 * cornerRadius);
            _graphics.DrawEllipse(Pens.Red, bottomX - cornerRadius, bottomY - cornerRadius, 2 * cornerRadius, 2 * cornerRadius);
            _graphics.DrawEllipse(Pens.Red, leftX - cornerRadius, leftY - cornerRadius, 2 * cornerRadius, 2 * cornerRadius);
            _graphics.DrawEllipse(Pens.Red, rightX - cornerRadius, rightY - cornerRadius, 2 * cornerRadius, 2 * cornerRadius);

        }
    }
}
