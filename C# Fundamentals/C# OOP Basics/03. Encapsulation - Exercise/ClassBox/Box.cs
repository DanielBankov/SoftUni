namespace ClassBox
{
    class Box
    {
        private double Length { get; set; }
        private double Width { get; set; }
        private double Height { get; set; }

        public Box(double length, double width, double height)
        {
            this.Length = length;
            this.Width = width;
            this.Height = height;
        }

        public double SurfaceArea()
        {
            return (2 * Length * Width) + (2 * Length * Height) + (2 * Width * Height);
        }

        public double LateralSurfaceArea()
        {
            return (2 * Length * Height) + (2 * Width * Height);
        }

        public double Volume()
        {
            return Length* Width * Height;
        }
    }
}
