using SimpleSnake.Enums;
using SimpleSnake.GameObjects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace SimpleSnake.Core
{
    public class Engine
    {
        private Point[] pointsOfDirection;
        private Direction direction;
        private Snake snake;
        private Wall wall;

        private double sleepTime;

        public Engine(Snake snake, Wall wall)
        {
            this.snake = snake;
            this.wall = wall;
            this.sleepTime = 100;
            this.pointsOfDirection = new Point[4];
            this.direction = Direction.Right;
        }

        public void Run()
        {
            this.CreateDirections();

            while (true)
            {
                if (Console.KeyAvailable)
                {
                    GetNextDirection();
                }

                bool isMoving = this.snake.IsMoving(this.pointsOfDirection[(int)direction]);

                if (!isMoving)
                {
                    AskPlayerForRestart();
                }

                sleepTime -= 0.01;
                Thread.Sleep((int)sleepTime);
            }    
        }

        private void AskPlayerForRestart()
        {
            int leftX = this.wall.LeftX + 2;
            int topY = 3;

            Console.SetCursorPosition(leftX, topY);
            Console.Write("Would you like to continue? Press: y");

            ConsoleKeyInfo input = Console.ReadKey();

            if(input.KeyChar == 'y')
            {
                Console.Clear();
                StartUp.Main();
            }
            else
            {
                Environment.Exit(0);
            }
        }

        private void CreateDirections()
        {
            this.pointsOfDirection[0] = new Point(1, 0); //Move right
            this.pointsOfDirection[1] = new Point(-1, 0); //Move left
            this.pointsOfDirection[2] = new Point(0, 1); //Move down
            this.pointsOfDirection[3] = new Point(0, -1); //Move up
        }

        private void GetNextDirection() 
        {
            ConsoleKeyInfo userInput = Console.ReadKey();

            if(userInput.Key == ConsoleKey.LeftArrow)
            {
                if(this.direction != Direction.Right)
                {
                    this.direction = Direction.Left;
                }
            }
            else if(userInput.Key == ConsoleKey.RightArrow)
            {
                if(this.direction != Direction.Left)
                {
                    this.direction = Direction.Right; 
                }
            }
            else if(userInput.Key == ConsoleKey.UpArrow)
            {
                if(this.direction != Direction.Down)
                {
                    this.direction = Direction.Up;
                }
            }
            else if (userInput.Key == ConsoleKey.DownArrow)
            {
                if (this.direction != Direction.Up)
                {
                    this.direction = Direction.Down;
                }
            }

            //Console.CursorVisible = false;
        }
    }
}
