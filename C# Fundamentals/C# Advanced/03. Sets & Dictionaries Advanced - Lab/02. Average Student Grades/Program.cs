using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Average_Student_Grades
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            Dictionary<string, List<double>> dict = new Dictionary<string, List<double>>();

            for (int i = 0; i < number; i++)
            {
                string[] studentInfo = Console.ReadLine().Split().ToArray();
                string studentName = studentInfo[0];
                double studentGrade = double.Parse(studentInfo[1]);

                if (!dict.ContainsKey(studentName))
                {
                    dict.Add(studentName, new List<double>());
                    dict[studentName].Add(studentGrade);
                }
                else
                {
                    dict[studentName].Add(studentGrade);
                }
            }

            foreach (var student in dict)
            {
                Console.Write($"{student.Key} -> ");

                foreach (var st in student.Value)
                {
                    Console.Write($"{st:f2} ");
                }
                Console.WriteLine($"(avg: {student.Value.Average():f2})");
            }
        }
    }
}
