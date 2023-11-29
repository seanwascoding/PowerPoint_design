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
            _privateObject.Invoke("PressedPointerTest", new object[] { -3, 4 });

            Assert.IsFalse((bool)_privateObject.GetFieldOrProperty("CheckPressed"));
            _privateObject.Invoke("PressedPointerTest", new object[] { 3, 4 });
            Assert.IsTrue((bool)_privateObject.GetFieldOrProperty("CheckPressed"));
            _model.Clear();
            _model.SetSelectShape(new Shape());
            _privateObject.Invoke("PressedPointerTest", new object[] { 3, 4 });
            Assert.IsTrue((bool)_privateObject.GetFieldOrProperty("CheckPressed"));
        }

        [TestMethod()]
        public void MovedPointerTest()
        {
            _privateObject.Invoke("MovedPointerTest", new object[] { 5, 7 });

            _privateObject.Invoke("PressedPointerTest", new object[] { 3, 4 });
            _privateObject.Invoke("MovedPointerTest", new object[] { 5, 7 });
            Assert.IsTrue((bool)_privateObject.GetFieldOrProperty("CheckPressed"));
        }

        [TestMethod()]
        public void ReleasedPointerTest()
        {
            _privateObject.Invoke("ReleasedPointerTest", new object[] { 9, 10 });

            _privateObject.Invoke("PressedPointerTest", new object[] { 3, 4 });
            Assert.IsTrue((bool)_privateObject.GetFieldOrProperty("CheckPressed"));
            _privateObject.Invoke("MovedPointerTest", new object[] { 5, 7 });
            Assert.IsTrue((bool)_privateObject.GetFieldOrProperty("CheckPressed"));
            _privateObject.Invoke("ReleasedPointerTest", new object[] { 9, 10 });
            Assert.IsFalse((bool)_privateObject.GetFieldOrProperty("CheckPressed"));
        }

        [TestMethod()]
        public void ClearTest()
        {
            _privateObject.Invoke("PressedPointerTest", new object[] { 3, 4 });
            Assert.IsTrue((bool)_privateObject.GetFieldOrProperty("CheckPressed"));
            _model.Clear();
            Assert.IsFalse((bool)_privateObject.GetFieldOrProperty("CheckPressed"));
        }

        [TestMethod()]
        public void DrawTest()
        {
            _model.ShapeReset();
            _model.SetState(0);
            _privateObject.Invoke("PressedPointerTest", new object[] { 3.0, 4.0 });
            _privateObject.Invoke("MovedPointerTest", new object[] { 5.0, 7.0 });
            _privateObject.Invoke("DrawTest");
            _privateObject.Invoke("ReleasedPointerTest", new object[] { 9, 10 });
            _privateObject.Invoke("DrawTest");

            _model.SetState(1);
            _privateObject.Invoke("PressedPointerTest", new object[] { 3, 4 });
            _privateObject.Invoke("MovedPointerTest", new object[] { 5, 7 });
            _privateObject.Invoke("DrawTest");
            _privateObject.Invoke("ReleasedPointerTest", new object[] { 9, 10 });
            _privateObject.Invoke("DrawTest");

            _model.SetState(2);
            _privateObject.Invoke("PressedPointerTest", new object[] { 3, 4 });
            _privateObject.Invoke("MovedPointerTest", new object[] { 5, 7 });
            _privateObject.Invoke("DrawTest");
            _privateObject.Invoke("ReleasedPointerTest", new object[] { 9, 10 });
            _privateObject.Invoke("DrawTest");

            _model.SetState(3);
            _privateObject.Invoke("PressedPointerTest", new object[] { 3, 4 });
            _privateObject.Invoke("MovedPointerTest", new object[] { 5, 7 });
            _privateObject.Invoke("DrawTest");
            _privateObject.Invoke("ReleasedPointerTest", new object[] { 9, 10 });

            _model.Clear();

            /* switch */

            Shape shape = ShapeFactory.CreateLine();
            _model.AddElement(shape);
            _model.SetSelectShape(shape);
            double[] temp = shape.GetCoordinates();
            Assert.AreEqual("Line", shape.GetShapeName());
            Assert.IsInstanceOfType(_privateObject.Invoke("SelectedShapeTest", new object[] { (int)temp[0], (int)temp[1] }), typeof(Line));
            _privateObject.Invoke("PressedPointerTest", new object[] { (int)temp[0], (int)temp[1] });
            _privateObject.Invoke("MovedPointerTest", new object[] { (int)temp[0] + 50, (int)temp[1] + 50 });
            _privateObject.Invoke("ReleasedPointerTest", new object[] { (int)temp[0] + 100, (int)temp[1] + 100 });
            _privateObject.Invoke("DrawTest");
            _model.Clear();

            Shape shape1 = ShapeFactory.CreateRectangle();
            _model.AddElement(shape1);
            _model.SetSelectShape(shape1);
            double[] temp1 = shape1.GetCoordinates();
            Assert.AreEqual("Rectangle", shape1.GetShapeName());
            Assert.IsNull(_privateObject.Invoke("SelectedShapeTest", new object[] { -1, 5 }));
            Assert.IsInstanceOfType(_privateObject.Invoke("SelectedShapeTest", new object[] { (int)((temp1[0] + temp1[2]) / 2), (int)((temp1[1] + temp1[3]) / 2) }), typeof(Rectangle));
            _privateObject.Invoke("DrawTest");
            _model.Clear();

            Shape shape2 = ShapeFactory.CreateCircle();
            _model.AddElement(shape2);
            _model.SetSelectShape(shape2);
            double[] temp2 = shape2.GetCoordinates();
            Assert.AreEqual("Circle", shape2.GetShapeName());
            Assert.IsInstanceOfType(_privateObject.Invoke("SelectedShapeTest", new object[] { (int)((temp2[0] + temp2[2]) / 2), (int)((temp2[1] + temp2[3]) / 2) }), typeof(Circle));
            _privateObject.Invoke("DrawTest");

            _model.Clear();

            /* switch 2 */
            Shape shape3 = new Line(0, 1, 4, 6);
            _model.AddElement(shape3);
            double[] temp3 = shape3.GetCoordinates();
            _model.SetSelectShape(shape3);
            _model.ShapeMoveChange(shape3, true);
            _privateObject.Invoke("SelectedShapeTest", new object[] { (int)temp3[0], (int)temp3[1] });
            _privateObject.Invoke("PressedPointerTest", new object[] { (int)temp3[2], (int)temp3[3] });
            _privateObject.Invoke("MovedPointerTest", new object[] { (int)temp3[0] + 50, (int)temp3[1] + 50 });
            _privateObject.Invoke("ReleasedPointerTest", new object[] { (int)temp3[0] + 100, (int)temp3[1] + 100 });
            _privateObject.Invoke("DrawTest");
            _model.Clear();

            Shape shape4 = new Rectangle(0, 1, 4, 6);
            _model.AddElement(shape4);
            double[] temp4 = shape4.GetCoordinates();
            _model.SetSelectShape(shape4);
            _model.ShapeMoveChange(shape4, true);
            _privateObject.Invoke("SelectedShapeTest", new object[] { (int)temp4[0], (int)temp4[1] });
            _privateObject.Invoke("PressedPointerTest", new object[] { (int)temp4[2], (int)temp4[3] });
            _privateObject.Invoke("MovedPointerTest", new object[] { (int)temp4[0] + 50, (int)temp4[1] + 50 });
            _privateObject.Invoke("ReleasedPointerTest", new object[] { (int)temp4[0] + 100, (int)temp4[1] + 100 });
            _privateObject.Invoke("DrawTest");
            _model.Clear();

            Shape shape5 = new Circle(0, 1, 4, 6);
            _model.AddElement(shape5);
            double[] temp5 = shape5.GetCoordinates();
            _model.SetSelectShape(shape5);
            _model.ShapeMoveChange(shape5, true);
            _privateObject.Invoke("SelectedShapeTest", new object[] { (int)temp5[0], (int)temp5[1] });
            _privateObject.Invoke("PressedPointerTest", new object[] { (int)temp5[2], (int)temp5[3] });
            _privateObject.Invoke("MovedPointerTest", new object[] { (int)temp5[0] + 50, (int)temp5[1] + 50 });
            _privateObject.Invoke("ReleasedPointerTest", new object[] { (int)temp5[0] + 100, (int)temp5[1] + 100 });
            _privateObject.Invoke("DrawTest");
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
            Shape shape = ShapeFactory.CreateLine();
            _model.AddElement(shape);
            _model.AddElement(ShapeFactory.CreateRectangle());
            _model.AddElement(ShapeFactory.CreateCircle());
            double[] temp = shape.GetCoordinates();
            Assert.IsInstanceOfType(_privateObject.Invoke("SelectedShapeTest", new object[] { (int)temp[0], (int)temp[1] }), typeof(Shape));
            Assert.IsNull(_privateObject.Invoke("SelectedShapeTest", new object[] { 999, 999 }));
        }

        [TestMethod()]
        public void ShapeResetTest()
        {
            Shape shape = new Shape();
            _model.AddElement(shape);
            _model.SetSelectShape(shape);
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
            Shape shape = ShapeFactory.CreateLine();
            _model.AddElement(ShapeFactory.CreateRectangle());
            _model.AddElement(shape);
            _model.AddElement(ShapeFactory.CreateCircle());
            double[] temp = shape.GetCoordinates();
            Assert.IsInstanceOfType(_privateObject.Invoke("SelectedShapeTest", new object[] { (int)temp[0], (int)temp[1] }), typeof(Shape));
            Assert.AreEqual(1, _model.GetPosition());
        }

        [TestMethod()]
        public void GetSelectShapeTest()
        {
            Assert.IsFalse(_model.IsSelectedState());
            _model.SetSelectShape(ShapeFactory.CreateCircle());
            Assert.IsTrue(_model.IsSelectedState());
            Assert.IsInstanceOfType(_model.GetSelectShape(), typeof(Circle));
        }

        [TestMethod()]
        public void ShapeMoveChangeTest()
        {
            Shape shape = ShapeFactory.CreateLine();
            _model.ShapeMoveChange(shape, true);
        }
    }
}