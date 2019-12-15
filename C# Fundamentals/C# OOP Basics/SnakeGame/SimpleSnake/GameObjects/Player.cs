using System;

namespace SimpleSnake.GameObjects
{
    public class Player : Point
    {
        private const char borderSymbol = '\u25A0';

        private int topY = 1;
        private int points = 0;
        private int level = 1;
        private int levelIncreaser = 10;

        public Player()
        {
            WritePlayerInfoBorder();
            DrawPlayerStats();
        }

        public void SetPlayerStats(int currFoodPoint)
        {
            this.points += currFoodPoint;

            if(this.points >= levelIncreaser)
            {
                this.level += 1;
                levelIncreaser += 10;
            }

            DrawPlayerStats();
        }

        private void WritePlayerInfoBorder()
        {
            for (int i = 0; i < Console.WindowWidth; i++)
            {
                this.Draw(borderSymbol, i, topY);
            }
        }

        private void DrawPlayerStats()
        {
            Console.SetCursorPosition(6, 0);
            Console.WriteLine($"Your Points: {points}");

            string playerLevel = $"Your current level: {level}";
            Console.SetCursorPosition(Console.WindowWidth - playerLevel.Length - 6, 0);
            Console.WriteLine(playerLevel);
        }
    }
}
