using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace PowerPoint
{
    public class Model
    {
        public event ModelChangedEventHandler _modelChanged;
        public delegate void ModelChangedEventHandler();
        bool _isPressed = false;
        Shape _hint = ShapeFactory.CreateLine(0, 0, 0, 0);
        int _state = 0;
        Shapes _compound;
        const int SIZE_ZERO = 0;
        const int SIZE_ONE = 1;
        const int SIZE_TWO = 2;
        Shape _selectedShape;
        int _count;
        IState _stateMode;
        CommandManager _commandManager;
        List<Shapes> _allShapes;
        List<CommandManager> _allCommandManager;

        // Model
        public Model()
        {
            // shapes
            _allShapes = new List<Shapes>();
            _allShapes.Add(new Shapes());
            _compound = _allShapes[0];

            // commandmanagers
            _allCommandManager = new List<CommandManager>();
            _allCommandManager.Add(new CommandManager());
            _commandManager = _allCommandManager[0];
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

        /* new function */

        // AddElement
        public void ClickAdd(Shape shape)
        {
            _commandManager.Execute(new AddCommand(this, shape));
        }

        // RemoveElement
        public void ClickRemove(int position)
        {
            _commandManager.Execute(new DeleteCommand(this, position));
        }

        // Undo
        public void Undo()
        {
            _commandManager.Undo();
        }

        // Redo
        public void Redo()
        {
            _commandManager.Redo();
        }

        public bool IsRedoEnabled
        {
            get
            {
                return _commandManager.IsRedoEnabled;
            }
        }

        public bool IsUndoEnabled
        {
            get
            {
                return _commandManager.IsUndoEnabled;
            }
        }

        /* new function */

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
                if (_stateMode as DrawingState != null)
                    _commandManager.Execute(new DrawCommand(this, _stateMode.GetCompleteShape()));
                else if (CheckProperty((_stateMode as PointState).GetBeforePosition(), (_stateMode as PointState).GetAfterPosition()))
                    _commandManager.Execute(new MoveCommand(this, _stateMode.GetCompleteShape(), (_stateMode as PointState).GetBeforePosition(), (_stateMode as PointState).GetAfterPosition()));
                NotifyModelChanged();
            }
        }

        // CheckProperty
        private bool CheckProperty(double[] shapeBefore, double[] shapeAfter)
        {
            int counter = 0;
            for (int i = 0; i < shapeAfter.Length - 1; i++)
            {
                if (shapeAfter[i] == shapeBefore[i])
                {
                    counter++;
                    if (counter == shapeAfter.Length - 1)
                        return false;
                }
            }
            return true;
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
            foreach (Shape aline in _compound.GetComponents())
                aline.Draw(graphics);
            if (_isPressed && _selectedShape == null)
                _hint.Draw(graphics);
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
                _modelChanged();
        }

        // SetState
        public void SetState(int state)
        {
            if (state == SIZE_ZERO)
            {
                _hint = ShapeFactory.CreateLine(0, 0, 0, 0);
            }
            else if (state == SIZE_ONE)
            {
                _hint = ShapeFactory.CreateRectangle(0, 0, 0, 0);
            }
            else if (state == SIZE_TWO)
            {
                _hint = ShapeFactory.CreateCircle(0, 0, 0, 0);
            }
            _state = state;
        }

        // CheckState
        public Shape CheckState()
        {
            if (_state == SIZE_ZERO)
            {
                return ShapeFactory.CreateLine(0, 0, 0, 0);
            }
            else if (_state == SIZE_ONE)
            {
                return ShapeFactory.CreateRectangle(0, 0, 0, 0);
            }
            else if (_state == SIZE_TWO)
            {
                return ShapeFactory.CreateCircle(0, 0, 0, 0);
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

        // ShapeMoveChange
        public void ShapeMoveChange(Shape shape, bool state)
        {
            shape._moveState = state;
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

        // CreateShapes
        public void CreateCanvas()
        {
            _allShapes.Add(new Shapes());
            _allCommandManager.Add(new CommandManager());
        }

        // SetCurrentShapes
        public void SetCurrentCanvas(int position)
        {
            _compound = _allShapes[position];
            _commandManager = _allCommandManager[position];
        }

        // DeleteCanvas
        public void DeleteCanvas(int position)
        {
            _allShapes.RemoveAt(position);
            _allCommandManager.RemoveAt(position);
        }

        // ProcessData
        public void ProcessData()
        {
            string filePath = "D:\\code\\VS\\PowerPoint\\PowerPoint\\sample\\";
            string shapesJson = Newtonsoft.Json.JsonConvert.SerializeObject(_allShapes);
            File.WriteAllText(Path.Combine(filePath, "shapes.json"), shapesJson);
        }

        // UpdateModel
        public void UpdateModel()
        {
            string filePath = "D:\\code\\VS\\PowerPoint\\PowerPoint\\sample\\";
            string shapesJsonFilePath = Path.Combine(filePath, "shapes.json");
            if (File.Exists(shapesJsonFilePath))
            {
                try
                {
                    string jsonContent = File.ReadAllText(shapesJsonFilePath);
                    List<Shapes> loadedShapes = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Shapes>>(jsonContent);

                    _allShapes.Clear();
                    _allCommandManager.Clear();

                    foreach (Shapes shapes in loadedShapes)
                    {
                        Shapes temp = new Shapes();
                        foreach (Shape shape in shapes.GetComponents())
                        {
                            temp.AddShape(CheckType(shape.ShapeName, shape.Coordinates));
                        }
                        _allCommandManager.Add(new CommandManager());
                        _allShapes.Add(temp);
                    }
                    _compound = _allShapes[0];
                    _commandManager = _allCommandManager[0];
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error loading shapes data: {ex.Message}");
                }
            }
        }

        // CheckType
        private Shape CheckType(string name, double[] coordinate)
        {
            if (name == "Line")
                return ShapeFactory.CreateLine((int)coordinate[0], (int)coordinate[2], (int)coordinate[1], (int)coordinate[3]);
            else if (name == "Rectangle")
                return ShapeFactory.CreateRectangle((int)coordinate[0], (int)coordinate[2], (int)coordinate[1], (int)coordinate[3]);
            else if (name == "Circle")
                return ShapeFactory.CreateCircle((int)coordinate[0], (int)coordinate[2], (int)coordinate[1], (int)coordinate[3]);
            else
                throw new Exception("error type");
        }

        // GetPageSize
        public int GetPageSize()
        {
            return _allShapes.Count();
        }


        /* Testing method */

        // CheckStaticTest
        private bool CheckPressed
        {
            get
            {
                return _isPressed;
            }
        }

        // CheckStateTest
        private void PressedPointerTest(double firstPointX, double firstPointY)
        {
            PressedPointer(firstPointX, firstPointY);
        }

        // MovedPointerTest
        private void MovedPointerTest(double firstPointX, double firstPointY)
        {
            MovedPointer(firstPointX, firstPointY);
        }

        // ReleasedPointerTest
        private void ReleasedPointerTest(double firstPointX, double firstPointY)
        {
            ReleasedPointer(firstPointX, firstPointY);
        }

        // DrawTest
        private void DrawTest()
        {
            Draw(new FromGraphicsAdapter(new DoubleBufferedPanel().CreateGraphics()));
        }

        // SelectedShapeTest
        private Shape SelectedShapeTest(int firstPointX, int firstPointY)
        {
            System.Drawing.Point point = new System.Drawing.Point();
            point.X = firstPointX;
            point.Y = firstPointY;
            return SelectedShape(point);
        }
    }
}
