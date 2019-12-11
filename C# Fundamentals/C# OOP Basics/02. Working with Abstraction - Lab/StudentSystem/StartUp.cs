namespace P03_StudentSystem
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        static void Main()
        {
            string[] args = Console.ReadLine().Split();
            Dictionary<string, Student> repo = new Dictionary<string, Student>();

            while (args[0] != "Exit")
            {
                if (args[0] == "Create")
                {
                    string name = args[1];
                    int age = int.Parse(args[2]);
                    double grade = double.Parse(args[3]);

                    if (!repo.ContainsKey(name))
                    {
                        Student student = new Student(name, age, grade);
                        repo[name] = student;
                    }
                }
                else if (args[0] == "Show")
                {
                    var name = args[1];

                    if (repo.ContainsKey(name))
                    {
                        Student student = repo[name];
                        string view = $"{student.Name} is {student.Age} years old.";

                        if (student.Grade >= 5.00)
                        {
                            view += " Excellent student.";
                        }
                        else if (student.Grade < 5.00 && student.Grade >= 3.50)
                        {
                            view += " Average student.";
                        }
                        else
                        {
                            view += " Very nice person.";
                        }

                        Console.WriteLine(view);
                    }
                }

                args = Console.ReadLine().Split();
            }
        }
    }
}
