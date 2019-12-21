namespace P02.Graphic_Editor
{
    class Program
    {
        static void Main()
        {
            GraphicEditor graphicEditor = new GraphicEditor();
            IShape shape = new Circle();
            IShape shape1 = new Rectangle();
            IShape shape2 = new Square();

            graphicEditor.DrawShape(shape);
        }
    }
}
