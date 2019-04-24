using System;

namespace _19._Thea_The_Photographer
{
    class Program
    {
        static void Main(string[] args)
        {
            long picturesCount = long.Parse(Console.ReadLine());
            long filterTime = long.Parse(Console.ReadLine());
            long filterFactor = long.Parse(Console.ReadLine());
            long uploadTime = long.Parse(Console.ReadLine());

            long filteredPics = (long)Math.Ceiling((filterFactor / 100.0) * picturesCount);
            long totalFiltredPics = picturesCount * filterTime;
            long totalTime = filteredPics * uploadTime;
            long final = totalTime + totalFiltredPics;

            TimeSpan result = TimeSpan.FromSeconds(final);
            string format = result.ToString(@"d\:hh\:mm\:ss");
            Console.WriteLine(format);
        }
    }
}
