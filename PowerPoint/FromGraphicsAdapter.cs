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
            _graphics.DrawEllipse(Pens.Black, (float)x1, (float)y1, (float)(x2 - x1), (float)(y2 - y1));

            // 計算橢圓中心和半軸
            float centerX = (float)((x1 + x2) / SIZE_TWO);
            float centerY = (float)((y1 + y2) / SIZE_TWO);
            float semiMajorAxis = (float)Math.Abs(x2 - x1) / SIZE_TWO;
            float semiMinorAxis = (float)Math.Abs(y2 - y1) / SIZE_TWO;

            // 計算上下左右四個邊線的坐標
            float topX = centerX;
            float topY = centerY - semiMinorAxis;

            float bottomX = centerX;
            float bottomY = centerY + semiMinorAxis;

            float leftX = centerX - semiMajorAxis;
            float leftY = centerY;

            float rightX = centerX + semiMajorAxis;
            float rightY = centerY;

            float cornerRadius = FIVE; // 小圓的半徑

            // 在四個角和四條邊線畫小圓形
            _graphics.DrawEllipse(Pens.Red, topX - cornerRadius, topY - cornerRadius, SIZE_TWO * cornerRadius, SIZE_TWO * cornerRadius);
            _graphics.DrawEllipse(Pens.Red, bottomX - cornerRadius, bottomY - cornerRadius, SIZE_TWO * cornerRadius, SIZE_TWO * cornerRadius);
            _graphics.DrawEllipse(Pens.Red, leftX - cornerRadius, leftY - cornerRadius, SIZE_TWO * cornerRadius, SIZE_TWO * cornerRadius);
            _graphics.DrawEllipse(Pens.Red, rightX - cornerRadius, rightY - cornerRadius, SIZE_TWO * cornerRadius, SIZE_TWO * cornerRadius);

        }
    }
}
