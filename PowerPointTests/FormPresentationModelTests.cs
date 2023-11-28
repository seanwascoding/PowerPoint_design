using Microsoft.VisualStudio.TestTools.UnitTesting;
using PowerPoint;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPoint.Tests
{
    [TestClass()]
    public class FormPresentationModelTests
    {
        Model _model;
        FormPresentationModel _pModel;
        PrivateObject _privateObject;

        [TestInitialize()]
        public void Initialize()
        {
            _model = new Model();
            _pModel = new FormPresentationModel(_model);
            _privateObject = new PrivateObject(_pModel);
        }

        [TestMethod()]
        public void FormPresentationModelTest()
        {
            Assert.IsNotNull(_pModel.GetModel());
            Assert.IsTrue((bool)_privateObject.GetFieldOrProperty("GetCursorState"));
            Shape shape = new Shape();
            Assert.IsNull(shape.GetCoordinates());
            Assert.IsNull(shape.GetShapeName());
            shape.Draw(null);
            Assert.IsFalse((bool)_privateObject.Invoke("IsContainTest"));
        }

        [TestMethod()]
        public void AddShapeTest()
        {
            Assert.AreEqual(0, _pModel.GetCompound().Count());
            _pModel.AddShape(new Shape());
            Assert.IsFalse(_pModel.GetCompound().Count() == 0);
            Assert.AreEqual(1, _pModel.GetCompound().Count());
        }

        [TestMethod()]
        public void RemoveShapeTest()
        {
            Assert.AreEqual(0, _pModel.GetCompound().Count());
            _pModel.AddShape(new Shape());
            Assert.AreEqual(1, _pModel.GetCompound().Count());
            _pModel.RemoveShape(0);
            Assert.AreEqual(0, _pModel.GetCompound().Count());
        }

        [TestMethod()]
        public void GetModelTest()
        {
            Assert.IsNotNull(_pModel.GetModel());
        }

        [TestMethod()]
        public void DrawTest()
        {
            _pModel.AddShape(ShapeFactory.CreateLine());
            _pModel.AddShape(ShapeFactory.CreateRectangle());
            _pModel.AddShape(ShapeFactory.CreateCircle());
            _privateObject.Invoke("DrawTest");
        }

        [TestMethod()]
        public void GetCompoundTest()
        {
            Assert.IsNotNull(_pModel.GetCompound());
        }

        [TestMethod()]
        public void SetShapeStateTest()
        {
            _pModel.SetShapeState(-1);
            Assert.IsNull(_model.CheckState());
            _pModel.SetShapeState(0);
            Assert.IsInstanceOfType(_model.CheckState(), typeof(Shape));
            _pModel.SetShapeState(1);
            Assert.IsInstanceOfType(_model.CheckState(), typeof(Shape));
            _pModel.SetShapeState(2);
            Assert.IsInstanceOfType(_model.CheckState(), typeof(Shape));
        }

        [TestMethod()]
        public void SetCheckedTest()
        {
            _pModel.SetChecked(-1);
            Assert.IsFalse(_pModel.GetLineState);
            Assert.IsFalse(_pModel.GetRectangleState);
            Assert.IsFalse(_pModel.GetCircleState);
            Assert.IsTrue(_pModel.GetCursorState);
            _pModel.SetChecked(0);
            Assert.IsTrue(_pModel.GetLineState);
            Assert.IsFalse(_pModel.GetRectangleState);
            Assert.IsFalse(_pModel.GetCircleState);
            Assert.IsFalse(_pModel.GetCursorState);
            _pModel.SetChecked(1);
            Assert.IsFalse(_pModel.GetLineState);
            Assert.IsTrue(_pModel.GetRectangleState);
            Assert.IsFalse(_pModel.GetCircleState);
            Assert.IsFalse(_pModel.GetCursorState);
            _pModel.SetChecked(2);
            Assert.IsFalse(_pModel.GetLineState);
            Assert.IsFalse(_pModel.GetRectangleState);
            Assert.IsTrue(_pModel.GetCircleState);
            Assert.IsFalse(_pModel.GetCursorState);
            _pModel.SetChecked(3);
            Assert.IsFalse(_pModel.GetLineState);
            Assert.IsFalse(_pModel.GetRectangleState);
            Assert.IsFalse(_pModel.GetCircleState);
            Assert.IsTrue(_pModel.GetCursorState);
            _pModel.SetChecked(4);
            Assert.IsFalse(_pModel.GetLineState);
            Assert.IsFalse(_pModel.GetRectangleState);
            Assert.IsFalse(_pModel.GetCircleState);
            Assert.IsTrue(_pModel.GetCursorState);
        }

        [TestMethod()]
        public void SetSelectShapeTest()
        {
            Assert.IsNull(_pModel.GetSelectShape());
            _pModel.SetSelectShape(new Shape());
            Assert.IsInstanceOfType(_pModel.GetSelectShape(), typeof(Shape));
        }

        [TestMethod()]
        public void GetSelectShapeTest()
        {
            Assert.IsNull(_pModel.GetSelectShape());
            _pModel.SetSelectShape(new Shape());
            Assert.IsInstanceOfType(_pModel.GetSelectShape(), typeof(Shape));
        }

        [TestMethod()]
        public void IsSelectedStateTest()
        {
            Assert.IsFalse(_pModel.IsSelectedState());
            _pModel.SetSelectShape(new Shape());
            Assert.IsTrue(_pModel.IsSelectedState());
        }

        [TestMethod()]
        public void GetPositionTest()
        {
            Assert.AreEqual(0, _pModel.GetPosition());
        }
    }
}