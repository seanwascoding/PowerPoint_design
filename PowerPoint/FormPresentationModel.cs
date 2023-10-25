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
    }
}
