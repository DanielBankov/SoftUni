using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._Balanced_Parenthesis
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Stack<char> stack = new Stack<char>();
            char[] brackets = new char[] { '(', '{', '[' };
            bool isValid = true;

            for (int i = 0; i < input.Length; i++)
            {
                char currentBracket = input[i];

                if (brackets.Contains(currentBracket))
                {
                    stack.Push(currentBracket);
                    continue;
                }

                if (stack.Count == 0)
                {
                    isValid = false;
                    break;
                }

                char bracketForRemove = stack.Peek();

                if (bracketForRemove == '(' && currentBracket == ')')
                {
                    stack.Pop();
                }
                else if (bracketForRemove == '[' && currentBracket == ']')
                {
                    stack.Pop();
                }
                else if (bracketForRemove == '{' && currentBracket == '}')
                {
                    stack.Pop();
                }

            }

            if (stack.Count == 0 && isValid)
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }
        }
    }
}
