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
            Assert.IsNotNull(_pModel.GetModel());
            Assert.IsTrue((bool)_privateObject.GetFieldOrProperty("GetCursorState"));
        }

        //[TestMethod()]
        //public void FormPresentationModelTest()
        //{
        //    Assert.Fail();
        //}

        [TestMethod()]
        public void AddShapeTest()
        {
            Assert.AreEqual(0, _model.GetComponent().Count());
            _model.AddElement(new Shape());
            Assert.IsFalse(_model.GetComponent().Count() == 0);
            Assert.AreEqual(1, _model.GetComponent().Count());
        }

        [TestMethod()]
        public void RemoveShapeTest()
        {
            Assert.AreEqual(0, _model.GetComponent().Count());
            _model.AddElement(new Shape());
            Assert.AreEqual(1, _model.GetComponent().Count());
            _model.RemoveElement(0);
            Assert.AreEqual(0, _model.GetComponent().Count());
        }

        [TestMethod()]
        public void GetModelTest()
        {
            Assert.IsNotNull(_model);
        }

        //[TestMethod()]
        //public void DrawTest()
        //{
        //    Assert.Fail();
        //}

        [TestMethod()]
        public void GetCompoundTest()
        {
            Assert.IsNotNull(_model.GetComponent());
        }

        [TestMethod()]
        public void SetShapeStateTest()
        {
            _model.SetState(-1);
            Assert.IsNull(_model.CheckState());
            _model.SetState(0);
            Assert.IsInstanceOfType(_model.CheckState(), typeof(Shape));
            _model.SetState(1);
            Assert.IsInstanceOfType(_model.CheckState(), typeof(Shape));
            _model.SetState(2);
            Assert.IsInstanceOfType(_model.CheckState(), typeof(Shape));
        }

        [TestMethod()]
        public void SetCheckedTest()
        {
            _privateObject.Invoke("ChangeState", new object[] { false, false, false, true });
            Assert.IsFalse((bool)_privateObject.GetFieldOrProperty("GetLineState"));
            Assert.IsFalse(_pModel.GetRectangleState);
            Assert.IsFalse(_pModel.GetCircleState);
            Assert.IsTrue(_pModel.GetCursorState);
            _privateObject.Invoke("ChangeState", new object[] { true, false, false, false });
            Assert.IsTrue(_pModel.GetLineState);
            Assert.IsFalse(_pModel.GetRectangleState);
            Assert.IsFalse(_pModel.GetCircleState);
            Assert.IsFalse(_pModel.GetCursorState);
        }

        [TestMethod()]
        public void SetSelectShapeTest()
        {
            Assert.IsNull(_model.GetSelectShape());
            _model.SetSelectShape(new Shape());
            Assert.IsInstanceOfType(_model.GetSelectShape(), typeof(Shape));
        }

        [TestMethod()]
        public void GetSelectShapeTest()
        {
            Assert.IsNull(_model.GetSelectShape());
            _model.SetSelectShape(new Shape());
            Assert.IsInstanceOfType(_model.GetSelectShape(), typeof(Shape));
        }

        [TestMethod()]
        public void IsSelectedStateTest()
        {
            Assert.IsFalse(_model.IsSelectedState());
            _model.SetSelectShape(new Shape());
            Assert.IsTrue(_model.IsSelectedState());
        }

        [TestMethod()]
        public void GetPositionTest()
        {
            Assert.AreEqual(0, _model.GetPosition());
        }
    }
}