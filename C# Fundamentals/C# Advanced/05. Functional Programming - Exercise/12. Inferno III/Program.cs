using System;
using System.Collections.Generic;
using System.Linq;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
            //Input: Exclude; Sum Left; 1
            //Dict<Sum Left, Dict<1, Func<i, 1, bool>>>
            var activefilters = new Dictionary<string, Dictionary<int, Func<int, int, bool>>>();

            var inputNumbers = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            var inputCommands = Console.ReadLine();

            while (inputCommands != "Forge")
            {
                var commandArgs = inputCommands.Split(';').ToArray();
                var command = commandArgs[0];
                var funcName = commandArgs[1];
                var targetSum = int.Parse(commandArgs[2]);

                Func<int, int, bool> sumFunc = GetFunction(inputNumbers, funcName);

                if (command == "Exclude")
                {
                    if (!activefilters.ContainsKey(funcName))
                    {
                        activefilters.Add(funcName, new Dictionary<int, Func<int, int, bool>>());
                    }

                    if (!activefilters[funcName].ContainsKey(targetSum))
                    {
                        activefilters[funcName].Add(targetSum, sumFunc);
                    }
                }
                else
                {
                    if (activefilters.ContainsKey(funcName))
                    {
                        activefilters[funcName].Remove(targetSum);
                    }
                }

                inputCommands = Console.ReadLine();
            }

            var finalNumbers = new List<int>();

            for (int i = 0; i < inputNumbers.Count; i++)
            {
                var isValid = true;

                foreach (var currFilter in activefilters)
                {
                    foreach (var kvp in currFilter.Value)
                    {
                        if (kvp.Value(i, kvp.Key))
                        {
                            isValid = false;
                            break;
                        }
                    }
                }

                if (isValid)
                {
                    finalNumbers.Add(inputNumbers[i]);
                }
            }

            Action<List<int>> print = p => Console.WriteLine(string.Join(' ', p));
            print(finalNumbers);
        }

        private static Func<int, int, bool> GetFunction(List<int> numbers, string funcName)
        {
            if (funcName == "Sum Left")
            {
                return (a, b) => a == 0 ? numbers[a] == b : numbers[a - 1] + numbers[a] == b;
            }
            else if (funcName == "Sum Right")
            {
                return (a, b) => numbers.Count - 1 == a ? numbers[a] == b : numbers[a + 1] + numbers[a] == b;
            }
            else if (funcName == "Sum Left Right")
            {
                if (numbers.Count == 1)
                {
                    return (a, b) => numbers[a] == b;
                }

                return (a, b) => 0 != a && numbers.Count - 1 != a ?
                                 numbers[a] + numbers[a + 1] + numbers[a - 1] == b :
                                 0 == a ?
                                 numbers[a] + numbers[a + 1] == b :
                                 numbers[numbers.Count - 1] + numbers[a - 1] == b;
            }

            return null;
        }

        // private static Func<int, int, bool> GetFunction(List<int> numbers, string functionName)
        //{

        //    if (functionName == "Sum Left")
        //    {
        //        return (i, targetSum) => i == 0 ? numbers[i] == targetSum : numbers[i] + numbers[i - 1] == targetSum;
        //    }
        //    else if (functionName == "Sum Right")
        //    {
        //        return (i, targetSum) => i == numbers.Count - 1 ? numbers[i] == targetSum : numbers[i] + numbers[i + 1] ==
        //         targetSum;
        //    }
        //    else if (functionName == "Sum Left Right")
        //    {
        //        return (i, targetSum) => numbers.Count == 1 ?
        //                                numbers[i] == targetSum :
        //                                i == numbers.Count - 1 ?
        //                                numbers[i - 1] + numbers[i] == targetSum :
        //                                i == 0 ?
        //                                numbers[i] + numbers[i + 1] == targetSum :
        //                                numbers[i - 1] + numbers[i] + numbers[i + 1] == targetSum;
        //    }

        //    return null;
        //}
    }
}
