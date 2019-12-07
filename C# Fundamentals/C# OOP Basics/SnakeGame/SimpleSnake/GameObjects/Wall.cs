using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleSnake.GameObjects
{
    public class Wall : Point
    {
        private const char wallSymbol = '\u25A0';

        public Wall(int leftX, int topY) 
            : base(leftX, topY)
        {
            InitializeWallBorders();
        }

        public bool IsPointOfWall(Point snake)
        {
            return snake.LeftX == 0 || snake.LeftX == this.LeftX || snake.TopY == 0 || snake.TopY == this.TopY;
        }

        private void InitializeWallBorders()
        {
            SetHorizontalLine(0);
            SetHorizontalLine(this.TopY);

            SetVerticaleLine(0);
            SetVerticaleLine(this.LeftX);
        }

        private void SetHorizontalLine(int topY)
        {
            for (int leftX = 0; leftX < this.LeftX; leftX++)
            {
                this.Draw(wallSymbol, leftX, topY);
            }
        }

        private void SetVerticaleLine(int leftX)
        {
            for (int topY = 0; topY <= this.TopY; topY++)
            {
                Draw(wallSymbol, leftX, topY);
            }
        }
    }
}
