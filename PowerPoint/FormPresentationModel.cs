using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Forms;

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
        const int ERROR_KEY = -1;
        const string GET_LINE_STATE = "GetLineState";
        const string GET_RECTANGLE_STATE = "GetRectangleState";
        const string GET_CIRCLE_STATE = "GetCircleState";
        const string GET_CURSOR_STATE = "GetCursorState";

        // construct
        public FormPresentationModel(Model model)
        {
            this._model = model;
        }

        // AddShape
        public void AddShape(Shape shape)
        {
            _model.ClickAdd(shape);
        }

        // RemoveShape
        public void RemoveShape(int position)
        {
            _model.ClickRemove(position);
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
        public void SetChecked(int state = ERROR_KEY)
        {
            if (state == ERROR_KEY)
                ChangeState(false, false, false, true);
            else if (state == SIZE_ZERO)
                ChangeState(true, false, false, false);
            else if (state == SIZE_ONE)
                ChangeState(false, true, false, false);
            else if (state == SIZE_TWO)
                ChangeState(false, false, true, false);
            else if (state == SIZE_THREE)
                ChangeState(false, false, false, true);
            NotifyPropertyChanged();
        }

        // ChangeState
        private void ChangeState(bool temp1, bool temp2, bool temp3, bool temp4)
        {
            _lineButton = temp1;
            _rectangleButton = temp2;
            _circleButton = temp3;
            _cursor = temp4;
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
            NotifyPropertyChanged(GET_LINE_STATE);
            NotifyPropertyChanged(GET_RECTANGLE_STATE);
            NotifyPropertyChanged(GET_CIRCLE_STATE);
            NotifyPropertyChanged(GET_CURSOR_STATE);
        }

        // NotifyPropertyChanged
        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        // ShapeMoveChange
        public void ShapeMoveChange(Shape shape, bool state)
        {
            _model.ShapeMoveChange(shape, state);
        }

        // CreateShapes
        public void CreateCanvas()
        {
            _model.CreateCanvas();
        }

        // SetCurrentShapes
        public void SetCurrentCanvas(int position)
        {
            _model.SetCurrentCanvas(position);
        }

        /* Testing method */

        // DrawTest
        private void DrawTest()
        {
            Draw(new DoubleBufferedPanel().CreateGraphics());
        }

        // IsContainTest
        private bool IsContainTest()
        {
            Shape shape = new Shape();
            return shape.IsContain(new System.Drawing.Point());
        }
    }
}
