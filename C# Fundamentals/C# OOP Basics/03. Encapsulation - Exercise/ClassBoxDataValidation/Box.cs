using System;

namespace ClassBoxDataValidation
{
    class Box
    {
        private double length;
        private double width;
        private double heigth;

        public Box(double length, double width, double height)
        {
            this.Length = length;
            this.Width = width;
            this.Height = height;
        }

        public double Length
        {
            get { return this.length; }

            set
            {
                if(value <= 0)
                {
                    Exception ex = new Exception("Length cannot be zero or negative.");
                    Console.WriteLine(ex.Message);
                    Environment.Exit(0);
                }

                this.length = value;
            }
        }

        public double Width
        {
            get { return this.width; }
            set
            {
                if (value <= 0)
                {
                    Exception ex = new Exception("Width cannot be zero or negative.");
                    Console.WriteLine(ex.Message);
                    Environment.Exit(0);
                }

                this.width = value;
            }
        }

        public double Height
        {
            get { return this.heigth; }
            set
            {
                if (value <= 0)
                {
                    Exception ex = new Exception("Height cannot be zero or negative.");
                    Console.WriteLine(ex.Message);
                    Environment.Exit(0);
                }

                this.heigth = value;
            }
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
