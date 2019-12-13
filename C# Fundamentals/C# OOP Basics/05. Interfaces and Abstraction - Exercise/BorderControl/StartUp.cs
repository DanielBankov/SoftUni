using System;
using System.Collections.Generic;

namespace BorderControl
{
    public class StartUp
    {
        static void Main()
        {
            List<IIdentifiable> identifiables = new List<IIdentifiable>(); 
            string[] input = Console.ReadLine().Split();

            while (input[0] != "End")
            {
                if (input.Length == 3)
                {
                    string name = input[0];
                    int age = int.Parse(input[1]);
                    string id = input[2];

                    identifiables.Add(new Citizen(name, age, id));
                }
                else if (input.Length == 2)
                {
                    string model = input[0];
                    string id = input[1];

                    identifiables.Add(new Robot(model, id));
                }

                input = Console.ReadLine().Split();
            }

            string fakeId = Console.ReadLine();

            foreach (var inde in identifiables)
            {
                if (inde.Id.EndsWith(fakeId))
                {
                    Console.WriteLine(inde.Id);
                }
            }
        }
    }
}
