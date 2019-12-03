using System;
using System.Linq;

namespace _07._Predicate_For_Names
{
    class Program
    {
        static void Main(string[] args)
        {
            var nameLenght = int.Parse(Console.ReadLine());
            var inputCollection = Console.ReadLine().Split(' ').ToArray();

            Func<string[], string[]> filterNames = names => names.Where(name => name.Length <= nameLenght).ToArray();
            Action<string[]> print = names => Console.WriteLine(string.Join($"{Environment.NewLine}", names));
 
            inputCollection = filterNames(inputCollection);
            print(inputCollection);
        }
    }
}
