using System;




namespace Question_2

{
    class Shape
    {
        private int ShapeID;
        private string ShapeType;
        private string Color;

        public Shape(int shapeID, string shapeType, string color)
        {
            ShapeID = shapeID;
            ShapeType = shapeType;
            Color = color;
        }

        //Deep Copy

        public Shape(Shape Original)
        {
            ShapeID = Original.ShapeID;
            ShapeType = Original.ShapeType;
            Color = Original.Color;
        }


        //GGetter Setters
        public int shapeID
        {
            get { return ShapeID; }
            set { ShapeID = value; }
        }

        public string shapeType
        {
            get { return ShapeType; }
            set { ShapeType = value; }
        }

        public string color
        {
            get { return Color; }
            set { Color = value; }
        }

        public void Draw()
        {
            Console.Write($"Shape ID: {ShapeID}, Type: {ShapeType}, Color: {Color}\n");
        }

        ~Shape()
        {
            Console.WriteLine($"Khalaaas");
        }
    }

    class Canvas
    {
        private int CanvasID;
        private Shape[] Shapes;
        private int shapeCount;

        public Canvas(int canvasID)
        {
            CanvasID = canvasID;
            Shapes = new Shape[10];
            shapeCount = 0;
        }

        //shallow copy
        public Canvas(Canvas original)
        {
            CanvasID = original.CanvasID;
            Shapes = original.Shapes;
            shapeCount = original.shapeCount;
        }

        //Copy COnstructor Deep copy
        public Canvas(Canvas original, bool deepCopy)
        {
            CanvasID = original.CanvasID;
            Shapes = new Shape[original.Shapes.Length];
            for (int i = 0; i < original.shapeCount; ++i)
            {
                Shapes[i] = new Shape(original.Shapes[i]); //new objectss

            }

            shapeCount = original.shapeCount;
        }


        //GETTING SETTING
        public int canvasID
        {
            get { return CanvasID; }
            set { CanvasID = value; }
        }

        public void AddShape(Shape shape)
        {
            if (shapeCount < Shapes.Length)
            {
                Shapes[shapeCount] = shape;
                shapeCount++;
            }
            else
            {
                Console.WriteLine("list is Full");
            }
        }

        public void DisplayShapes()
        {
            Console.WriteLine($"\nCanvas ID: {CanvasID} - Shapes List:");
            for (int i = 0; i < Shapes.Length; ++i)
            {
                if (Shapes[i] != null)
                {
                    Shapes[i].Draw();
                }
            }
        }

        ~Canvas()
        {
            Console.WriteLine($"Bye Bye Objects of Canvas ID: {CanvasID}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Shape shape1 = new Shape(1, "Circle", "laal");

            Shape shape2 = new Shape(2, "rectangle", "nila");

            Shape shape3 = new Shape(3, "square", "Hara");

            Canvas canvas1 = new Canvas(101);
            canvas1.AddShape(shape1);
            canvas1.AddShape(shape2);
            canvas1.AddShape(shape3);


            //Display both orignal and copied
            Console.WriteLine("\nOrignal Canvas");
            canvas1.DisplayShapes();

            //shallow 
            Canvas shallowCanvas = new Canvas(canvas1);


            //DEEP
            Canvas deepCanvas = new Canvas(canvas1, true);


            //add newshape to canvas
            Shape shape4 = new Shape(4, "Triangle", "Kaala");
            canvas1.AddShape(shape4);



            Console.WriteLine("\n");


            Console.WriteLine("Canvas After Adding New Shape");
            canvas1.DisplayShapes();


            Console.WriteLine("\nShallow Copy Canvas");
            shallowCanvas.DisplayShapes();

            Console.WriteLine("\n");

            Console.WriteLine("\nDeep Copy Canvas");
            deepCanvas.DisplayShapes();

            Console.WriteLine("\n");
            Console.ReadKey();
        }
    }
}