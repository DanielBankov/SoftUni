using System;
using System.Collections.Generic;
using System.Linq;

namespace SimpleSnake.GameObjects.Foods
{
    public abstract class Food : Point
    {
        private char foodSymbol;
        private Random random;

        public Food(char foodSymbol, int points)
        {
            this.foodSymbol = foodSymbol;
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

            this.Draw(foodSymbol);
        }

        public bool IsFoodPoint(Point snake)
        {
            return snake.LeftX == this.LeftX && snake.TopY == this.TopY;
        }

        private bool IsPointOfSnake(Queue<Point> snakeElements)
        {
            this.LeftX = random.Next(2, Console.WindowWidth);
            this.TopY = random.Next(2, Console.WindowHeight);

            return snakeElements.Any(p => p.LeftX == this.LeftX && p.TopY == this.TopY);
        }
    }
}
