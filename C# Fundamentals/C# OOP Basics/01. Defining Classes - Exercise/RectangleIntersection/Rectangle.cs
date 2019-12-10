namespace RectangleIntersection
{
    public class Rectangle
    {
        public string Id { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
        public double Horizontal { get; set; }
        public double Vertical { get; set; }

        public Rectangle(string id, double width, double height, double horizontal, double vertical)
        {
            this.Id = id;
            this.Height = height;
            this.Width = width;
            this.Horizontal = horizontal;
            this.Vertical = vertical;
        }

        public string FindIntersection(Rectangle secondRec)
        {
            if (this.Horizontal + this.Width < secondRec.Horizontal
                || secondRec.Horizontal + secondRec.Width < this.Horizontal
                || this.Vertical + this.Height < secondRec.Vertical
                || secondRec.Vertical + secondRec.Height < this.Vertical)
            {
                return "false";
            }
            return "true";
        }
    }
}
