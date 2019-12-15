using SimpleSnake.GameObjects.Foods;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SimpleSnake.GameObjects
{
    public class Snake
    {
        private const char snakeSymbol = '\u25CF';

        private Queue<Point> snakeElements;
        private Food[] foods;
        private Player player;

        private int nextLeftX;
        private int nextTopY;
        private int foodIndex;

        public Snake()
        {
            this.foods = new Food[3];
            this.foodIndex = this.RandomFoodNumber;
            this.snakeElements = new Queue<Point>();
            this.player = new Player();

            this.GetFoods();
            this.CreateSnake();
        }

        private int RandomFoodNumber => new Random().Next(0, foods.Length);

        public int TotalPoints { get; private set; }

        public bool IsMoving(Point direction)
        {
            
            Point currentSnakeHead = this.snakeElements.Last();

            GetNextPoint(direction, currentSnakeHead);
            IfSnkaeHitBorderContinueOtherSide();

            bool isPointOfSnake = this.snakeElements.Any(e => e.LeftX == this.nextLeftX && e.TopY == this.nextTopY);

            if (isPointOfSnake)
            {
                return false;
            }

            Point newSnakeHead = new Point(this.nextLeftX, this.nextTopY);

            this.snakeElements.Enqueue(newSnakeHead);
            newSnakeHead.Draw(snakeSymbol);

            if (this.foods[this.foodIndex].IsFoodPoint(newSnakeHead))
            {
                this.Eat(direction, currentSnakeHead);
            }

            Point snakeTail = this.snakeElements.Dequeue();
            snakeTail.Draw(' ');

            return true;
        }

        private void IfSnkaeHitBorderContinueOtherSide()
        {
            if (this.nextLeftX == -1)
            {
                this.nextLeftX = Console.WindowWidth - 1;
            }
            else if (this.nextLeftX == Console.WindowWidth)
            {
                this.nextLeftX = 0;
            }
            else if (this.nextTopY == 1)
            {
                this.nextTopY = Console.WindowHeight - 1;
            }
            else if (this.nextTopY == Console.WindowHeight)
            {
                this.nextTopY = 2;
            }
        }

        private void CreateSnake()
        {
            for (int leftX = 1; leftX <= 6; leftX++)
            {
                this.snakeElements.Enqueue(new Point(leftX, 2));
            }

            this.foods[foodIndex].SetRandomPosition(this.snakeElements);
        }

        private void Eat(Point direction, Point currentSnakeHead)
        {
            int currFoodPoint = this.foods[this.foodIndex].FoodPoints;
            this.player.SetPlayerStats(currFoodPoint);

            //Increase snake length according what is eaten
            for (int i = 0; i < currFoodPoint; i++)
            {
                this.snakeElements.Enqueue(new Point(this.nextLeftX, this.nextTopY));
                this.GetNextPoint(direction, currentSnakeHead);
            }

            this.foodIndex = this.RandomFoodNumber;
            this.foods[foodIndex].SetRandomPosition(this.snakeElements);
        }

        private void GetFoods()
        {
            this.foods[0] = new FoodAsterisk();
            this.foods[1] = new FoodDollar();
            this.foods[2] = new FoodHash();
        }

        private void GetNextPoint(Point direction, Point snakeHead)
        {
            this.nextLeftX = snakeHead.LeftX + direction.LeftX;
            this.nextTopY = snakeHead.TopY + direction.TopY;
        }
    }
}