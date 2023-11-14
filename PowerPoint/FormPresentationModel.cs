using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPoint
{
    public class FormPresentationModel
    {
        Model _model;
        bool _lineButton = false;
        bool _rectangleButton = false;
        bool _circleButton = false;
        bool _cursor = true;
        bool _selected = false;


        // construct
        public FormPresentationModel(Model model)
        {
            this._model = model;
        }

        // AddShape
        public void AddShape(Shape shape)
        {
            _model.AddElement(shape);
        }

        // RemoveShape
        public void RemoveShape(int position)
        {
            _model.RemoveElement(position);
        }

        // GetModel
        public Model GetModel()
        {
            return _model;
        }

        // Draw
        public void Draw(System.Drawing.Graphics graphics)
        {
            _model.Draw(new FromGraphicsAdapter(graphics));
        }

        // GetCompound
        public Shape GetCompound()
        {
            return _model.GetComponent();
        }

        // SetShapeState
        public void SetShapeState(int state)
        {
            _model.SetState(state);
        }

        // SetChecked
        public void SetChecked(int i = -1)
        {
            if (i == -1)
            {
                _lineButton = false;
                _rectangleButton = false;
                _circleButton = false;
                _cursor = true;
            }
            else if (i == 0)
            {
                _lineButton = true;
                _rectangleButton = false;
                _circleButton = false;
                _cursor = false;
            }
            else if (i == 1)
            {
                _lineButton = false;
                _rectangleButton = true;
                _circleButton = false;
                _cursor = false;
            }
            else if (i == 2)
            {
                _lineButton = false;
                _rectangleButton = false;
                _circleButton = true;
                _cursor = false;
            }
            else if (i == 3)
            {
                _lineButton = false;
                _rectangleButton = false;
                _circleButton = false;
                _cursor = true;
            }
        }

        // GetLineState
        public bool GetLineState()
        {
            return _lineButton;
        }

        // GetRectangleState
        public bool GetRectangleState()
        {
            return _rectangleButton;
        }

        // GetCircleState
        public bool GetCircleState()
        {
            return _circleButton;
        }

        // GetCursorState
        public bool GetCursorState()
        {
            return _cursor;
        }

        // SelectState
        public void SetSelectState(Shape shape, bool state = false)
        {
            _selected = state;

        }
    }
}
