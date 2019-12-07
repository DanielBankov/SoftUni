using System;

namespace SimpleSnake.GameObjects
{
    public class Point
    {
        private int leftX;
        private int topY;

        public Point(int leftX, int topY)
        {
            this.LeftX = leftX;
            this.TopY = topY;
        }

        public int LeftX
        {
            get
            {
                return leftX;
            }
            set
            {
                if(value < -1 || value > Console.WindowWidth)
                {
                    throw new ArgumentOutOfRangeException();
                }

                leftX = value;
            }
        }

        public int TopY
        {
            get
            {
                return topY;
            }
            set
            {
                if(value < -1 || value > Console.WindowHeight)
                {
                    throw new ArgumentOutOfRangeException();
                }

                topY = value;
            }
        }

        public void Draw(char symbol)
        {
            Console.SetCursorPosition(this.LeftX, this.TopY);
            Console.Write(symbol);
        }

        public void Draw(char symbol, int leftX, int topY)
        {
            Console.SetCursorPosition(leftX, topY);
            Console.Write(symbol);
        }
    }
}
