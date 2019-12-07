using System;
using System.Collections.Generic;
using System.Linq;

namespace SimpleSnake.GameObjects.Foods
{
    public abstract class Food : Point
    {
        private char foodSymbol;
        private Random random;
        private Wall wall;

        public Food(Wall wall, char foodSymbol, int points)
            : base(wall.LeftX, wall.TopY)
        {
            this.foodSymbol = foodSymbol;
            this.wall = wall;
            this.FoodPoints = points;
            this.random = new Random();
        }

        public int FoodPoints { get; private set; }

        public void SetRandomPosition(Queue<Point> snakeElements)
        {
            bool isPointOfSnake = IsPointOfSnake(snakeElements);

            while (isPointOfSnake)
            {
                isPointOfSnake = IsPointOfSnake(snakeElements);
            }

            //Console.BackgroundColor = ConsoleColor.Red;
            this.Draw(foodSymbol);
            //Console.BackgroundColor = ConsoleColor.White;
        }

        public bool IsFoodPoint(Point snake)
        {
            return snake.LeftX == this.LeftX && snake.TopY == this.TopY;
        }

        private bool IsPointOfSnake(Queue<Point> snakeElements)
        {
            this.LeftX = random.Next(2, wall.LeftX - 2);
            this.TopY = random.Next(2, wall.TopY - 2);

            return snakeElements.Any(p => p.LeftX == this.LeftX && p.TopY == this.TopY);
        }
    }
}
