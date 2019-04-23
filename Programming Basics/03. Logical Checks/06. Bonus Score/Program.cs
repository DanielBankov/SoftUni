using System;

namespace _06.Bonus_Score
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter score: ");

            int score = int.Parse(Console.ReadLine());

            var bonusScore = 0.0;
            var totalScore = 0.0;

            if (score <= 100)
            {
                bonusScore = 5;
            }
            else if (score > 1000)
            {
                bonusScore = 0.1 * score;
            }
            else if (score > 100)
            {
                bonusScore = 0.2 * score;
            }
            if (score % 2 == 0)
            {
                bonusScore = bonusScore + 1;
            }
            else if (score % 5 == 0)
            {
                bonusScore = bonusScore + 2;

            }

            Console.WriteLine("Bonus score: " + bonusScore);

            totalScore = score + bonusScore;

            Console.WriteLine("Total score: " + totalScore);
        }
    }
}
