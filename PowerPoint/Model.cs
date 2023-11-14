using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPoint
{
    public class Model
    {
        public event ModelChangedEventHandler _modelChanged;
        public delegate void ModelChangedEventHandler();
        double _firstPointX;
        double _firstPointY;
        bool _isPressed = false;
        Shape _hint = ShapeFactory.CreateLine();
        int _state = 0;
        Shapes _compound;
        const int SIZE_ZERO = 0;
        const int SIZE_ONE = 1;
        const int SIZE_TWO = 2;

        // Model
        public Model()
        {
            _compound = new Shapes();
        }

        // AddElement
        public void AddElement(Shape shape)
        {
            _compound.AddShape(shape);
        }

        // RemoveElement
        public void RemoveElement(int position)
        {
            _compound.RemoveShape(position);
        }

        // PointerPressed
        public void PressedPointer(double x, double y)
        {
            if (x > 0 && y > 0)
            {
                _firstPointX = x;
                _firstPointY = y;
                _hint._x1 = _firstPointX;
                _hint._y1 = _firstPointY;
                _isPressed = true;
            }
        }

        // PointerMoved
        public void MovedPointer(double x, double y)
        {
            if (_isPressed)
            {
                _hint._x2 = x;
                _hint._y2 = y;
                NotifyModelChanged();
            }
        }

        // PointerReleased
        public void ReleasedPointer(double x, double y)
        {
            if (_isPressed)
            {
                _isPressed = false;
                Shape hint = CheckState(); // check shape state
                hint._x1 = _firstPointX;
                hint._y1 = _firstPointY;
                hint._x2 = x;
                hint._y2 = y;
                _compound.AddShape(hint);
                NotifyModelChanged();
            }
        }

        // Clear
        public void Clear()
        {
            _isPressed = false;
            _compound.ClearShape();
            NotifyModelChanged();
        }

        // Draw
        public void Draw(IGraphics graphics)
        {
            graphics.ClearAll();
            List<Shape> temp = _compound.GetComponents();
            foreach (Shape aline in temp)
            {
                aline.Draw(graphics);
            }
            if (_isPressed)
            {
                _hint.Draw(graphics);
            }
        }

        // GetComponent
        public Shape GetComponent()
        {
            return _compound.GetComponents().Last();
        }

        // NotifyModelChanged
        void NotifyModelChanged()
        {
            if (_modelChanged != null)
            {
                _modelChanged();
            }
        }

        // SetState
        public void SetState(int state)
        {
            if (state == SIZE_ZERO)
            {
                _hint = ShapeFactory.CreateLine();
            }
            else if (state == SIZE_ONE)
            {
                _hint = ShapeFactory.CreateRectangle();
            }
            else if (state == SIZE_TWO)
            {
                _hint = ShapeFactory.CreateCircle();
            }
            _state = state;
        }

        // CheckState
        public Shape CheckState()
        {
            if (_state == SIZE_ZERO)
            {
                return ShapeFactory.CreateLine();
            }
            else if (_state == SIZE_ONE)
            {
                return ShapeFactory.CreateRectangle();
            }
            else if (_state == SIZE_TWO)
            {
                return ShapeFactory.CreateCircle();
            }
            return null;
        }

        // isShapeSelected
        public bool isShapeSelected(System.Drawing.Point point)
        {
            foreach (Shape shape in _compound.GetComponents())
            {
                shape._selected = false;
            }
            foreach (Shape shape in _compound.GetComponents())
            {
                if (shape.isContain(point))
                {
                    shape._selected = true;
                    return true;
                }
            }
            return false;
        }

    }
}
