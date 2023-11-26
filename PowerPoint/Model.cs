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
        bool _isPressed = false;
        Shape _hint = ShapeFactory.CreateLine();
        int _state = 0;
        Shapes _compound;
        const int SIZE_ZERO = 0;
        const int SIZE_ONE = 1;
        const int SIZE_TWO = 2;
        Shape _selectedShape;
        int _count;
        IState _stateMode;

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
        public void PressedPointer(double firstPointX, double firstPointY)
        {
            if (firstPointX > 0 && firstPointY > 0)
            {
                if (_selectedShape == null)
                {
                    _stateMode = new DrawingState();
                    _stateMode.InitializeState(_hint, _compound, _state);
                }
                else
                {
                    _stateMode = new PointState();
                    _stateMode.InitializeState(_selectedShape, null, _state);
                }
                _stateMode.PressMouse(firstPointX, firstPointY);
                _isPressed = true;
            }
        }

        // PointerMoved
        public void MovedPointer(double firstPointX, double firstPointY)
        {
            if (_isPressed)
            {
                _stateMode.MoveMouse(firstPointX, firstPointY);
                NotifyModelChanged();
            }
        }

        // PointerReleased
        public void ReleasedPointer(double firstPointX, double firstPointY)
        {
            if (_isPressed)
            {
                _isPressed = false;
                _stateMode.MoveDownMouse(firstPointX, firstPointY);
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
            if (_isPressed && _selectedShape == null)
            {
                _hint.Draw(graphics);
            }
        }

        // GetComponent
        public List<Shape> GetComponent()
        {
            return _compound.GetComponents();
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
        public Shape SelectedShape(System.Drawing.Point point)
        {
            _count = 0;
            foreach (Shape shape in _compound.GetComponents())
            {
                if (shape.IsContain(point))
                {
                    shape._selected = true;
                    return shape;
                }
                _count++;
            }
            return null;
        }

        // ShapeReset
        public void ShapeReset()
        {
            _selectedShape = null;
            foreach (Shape shape in _compound.GetComponents())
            {
                shape._selected = false;
            }
        }

        // SetSelectShape
        public void SetSelectShape(Shape shape)
        {
            _selectedShape = shape;
        }

        // GetSelectedState
        public bool IsSelectedState()
        {
            return _selectedShape != null;
        }

        // GetPosition
        public int GetPosition()
        {
            return _count;
        }

        // GetSelectShape
        public Shape GetSelectShape()
        {
            return _selectedShape;
        }
    }
}
