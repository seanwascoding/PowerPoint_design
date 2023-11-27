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
    public class ModelTests
    {
        Model _model;
        Shapes _shapes;
        PrivateObject _privateObject;

        [TestInitialize()]
        public void Initialize()
        {
            _model = new Model();
            _shapes = new Shapes();
            _privateObject = new PrivateObject(_model);
        }

        [TestMethod()]
        public void ModelTest()
        {
            Assert.IsNotNull(_model.GetComponent());
            Assert.IsNotNull(_shapes);
        }

        [TestMethod()]
        public void AddElementTest()
        {
            Assert.AreEqual(0, _shapes.GetComponents().Count());
            _shapes.AddShape(new Shape());
            Assert.AreEqual(1, _shapes.GetComponents().Count());
        }

        [TestMethod()]
        public void RemoveElementTest()
        {
            Assert.AreEqual(0, _shapes.GetComponents().Count());
            _shapes.AddShape(new Shape());
            Assert.AreEqual(1, _shapes.GetComponents().Count());
            _shapes.RemoveShape(0);
            Assert.AreEqual(0, _shapes.GetComponents().Count());
        }

        [TestMethod()]
        public void PressedPointerTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void MovedPointerTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void ReleasedPointerTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void ClearTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void DrawTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetComponentTest()
        {
            Assert.IsNotNull(_shapes.GetComponents());
        }

        [TestMethod()]
        public void SetStateTest()
        {
            _model.SetState(-1);
            Assert.IsNull(_model.CheckState());
            _model.SetState(0);
            Assert.IsNotNull(_model.CheckState());
        }

        [TestMethod()]
        public void CheckStateTest()
        {
            Assert.IsNotNull(_model.CheckState());
        }

        [TestMethod()]
        public void SelectedShapeTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void ShapeResetTest()
        {
            _model.SetSelectShape(new Shape());
            Assert.IsTrue(_model.IsSelectedState());
            _model.ShapeReset();
            Assert.IsFalse(_model.IsSelectedState());
        }

        [TestMethod()]
        public void SetSelectShapeTest()
        {
            Assert.IsFalse(_model.IsSelectedState());
            _model.SetSelectShape(new Shape());
            Assert.IsTrue(_model.IsSelectedState());
        }

        [TestMethod()]
        public void IsSelectedStateTest()
        {
            Assert.IsFalse(_model.IsSelectedState());
        }

        [TestMethod()]
        public void GetPositionTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetSelectShapeTest()
        {
            Assert.Fail();
        }
    }
}