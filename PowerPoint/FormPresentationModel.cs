using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace PowerPoint
{
    public class FormPresentationModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        Model _model;
        bool _lineButton = false;
        bool _rectangleButton = false;
        bool _circleButton = false;
        bool _cursor = true;
        const int SIZE_ZERO = 0;
        const int SIZE_ONE = 1;
        const int SIZE_TWO = 2;
        const int SIZE_THREE = 3;
        const int ERRORKEY = -1;
        const string GETLINESTATE = "GetLineState";
        const string GETRECTANGLESTATE = "GetRectangleState";
        const string GETCIRCLESTATE = "GetCircleState";
        const string GETCURSORSTATE = "GetCursorState";

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
        public List<Shape> GetCompound()
        {
            return _model.GetComponent();
        }

        // SetShapeState
        public void SetShapeState(int state)
        {
            _model.SetState(state);
        }

        // SetChecked
        public void SetChecked(int i = ERRORKEY)
        {
            if (i == ERRORKEY)
            {
                _lineButton = false;
                _rectangleButton = false;
                _circleButton = false;
                _cursor = true;
            }
            else if (i == SIZE_ZERO)
            {
                _lineButton = true;
                _rectangleButton = false;
                _circleButton = false;
                _cursor = false;
            }
            else if (i == SIZE_ONE)
            {
                _lineButton = false;
                _rectangleButton = true;
                _circleButton = false;
                _cursor = false;
            }
            else if (i == SIZE_TWO)
            {
                _lineButton = false;
                _rectangleButton = false;
                _circleButton = true;
                _cursor = false;
            }
            else if (i == SIZE_THREE)
            {
                _lineButton = false;
                _rectangleButton = false;
                _circleButton = false;
                _cursor = true;
            }
            NotifyPropertyChanged();
        }

        // GetLineState
        public bool GetLineState
        {
            get
            {
                return _lineButton;
            }
            
        }

        // GetRectangleState
        public bool GetRectangleState
        {
            get
            {
                return _rectangleButton;
            }
        }

        // GetCircleState
        public bool GetCircleState
        {
            get
            {
                return _circleButton;
            }
        }

        // GetCursorState
        public bool GetCursorState
        {
            get
            {
                return _cursor;
            }
        }

        // SetSelectShape
        public void SetSelectShape(Shape shape)
        {
            _model.SetSelectShape(shape);
        }

        // GetSelectShape
        public Shape GetSelectShape()
        {
            return _model.GetSelectShape();
        }

        // GetSelectedState
        public bool IsSelectedState()
        {
            return _model.IsSelectedState();
        }

        // GetPosition
        public int GetPosition()
        {
            return _model.GetPosition();
        }

        // NotifyPropertyChanged
        private void NotifyPropertyChanged()
        {
            NotifyPropertyChanged(GETLINESTATE);
            NotifyPropertyChanged(GETRECTANGLESTATE);
            NotifyPropertyChanged(GETCIRCLESTATE);
            NotifyPropertyChanged(GETCURSORSTATE);
        }

        // call NotifyPropertyChanged
        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
