using System;
using System.Collections.Generic;
using System.Linq;

namespace P04_Hospital
{
    public class StartUp
    {
        static List<Department> departments;
        static List<Doctor> doctors;

        public static void Main()
        {
            doctors = new List<Doctor>();
            departments = new List<Department>();

            string command = Console.ReadLine();

            while (command != "Output")
            {
                string[] commandArgs = command.Split();
                var departamentName = commandArgs[0];
                var firstName = commandArgs[1];
                var lastName = commandArgs[2];
                var pacient = commandArgs[3];

                Department department = GetDepartment(departamentName);
                Doctor doctor = GetDoctor(firstName, lastName); 

                bool containsFreeSpace = department.Rooms.Sum(x => x.Pacients.Count) < 60;

                if (containsFreeSpace)
                {
                    int targetRoom = 0;

                    doctor.Pacients.Add(pacient);

                    for (int room = 0; room < department.Rooms.Count; room++)
                    {
                        if (department.Rooms[room].Pacients.Count < 3)
                        {
                            targetRoom = room;
                            break;
                        }
                    }

                    department.Rooms[targetRoom].Pacients.Add(pacient);
                }

                command = Console.ReadLine();
            }

            command = Console.ReadLine();

            while (command != "End")
            {
                string[] args = command.Split();

                if (args.Length == 1)
                {
                    var department = GetDepartment(args[0]);

                    foreach (var room in department.Rooms.Where(x => x.Pacients.Count > 0))
                    {
                        foreach (var pacient in room.Pacients)
                        {
                            Console.WriteLine(pacient);
                        }
                    }

                   // Console.WriteLine(string.Join("\n", departments[args[0]].Where(x => x.Count > 0).SelectMany(x => x)));
                }
                else if (args.Length == 2 && int.TryParse(args[1], out int room))
                {
                    var department = GetDepartment(args[0]);

                    foreach (var name in department.Rooms[room - 1].Pacients.OrderBy(x => x))
                    {
                        Console.WriteLine(name);
                    }
                }
                else
                {
                    string firstName = args[0];
                    string lastName = args[1];

                    Doctor doctor = GetDoctor(firstName, lastName);

                    foreach (var pacient in doctor.Pacients.OrderBy(x => x))
                    {
                        Console.WriteLine(pacient);
                    }
                }

                command = Console.ReadLine();
            }
        }

        private static Doctor GetDoctor(string firstName, string lastName)
        {
            Doctor doctor = doctors.Where(x => x.FirstName == firstName && x.LastName == lastName).FirstOrDefault();

            if(doctor == null)
            {
                doctor = new Doctor(firstName, lastName);
                doctors.Add(doctor);
            }

            return doctor;
        }

        private static Department GetDepartment(string departamentName)
        {
            Department department = departments.Where(x => x.Name == departamentName).FirstOrDefault();

            if(department == null)
            {
                department = new Department(departamentName);
                departments.Add(department);

                for (int i = 0; i < 20; i++)
                {
                    department.Rooms.Add(new Room());   
                }
            }

            return department;
        }
    }
}
