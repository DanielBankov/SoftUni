using System;
using System.Linq;

namespace _13._TriFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            int target = int.Parse(Console.ReadLine());
            var names = Console.ReadLine().Split();

            Func<string, int> sumLetters = name => name.ToCharArray().Sum(c => c);
            Func<string, int, bool> isTargetHit = (name, t) => sumLetters(name) >= t;

            var winner = names.FirstOrDefault(name => isTargetHit(name, target));
            Console.WriteLine(winner);
        }
    }
}
