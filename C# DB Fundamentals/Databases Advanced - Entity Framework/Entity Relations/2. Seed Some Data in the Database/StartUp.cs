using P01_StudentSystem.Data;
using P01_StudentSystem.Data.Models;
using System;

namespace _2.SeedSomeDataintheDatabase
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            using (var dbContext = new StudentSystemContext())
            {
                Seed(dbContext);
            }
        }

        private static void Seed(StudentSystemContext dbContext)
        {
            var students = StudentInfo(dbContext);
            dbContext.Students.AddRange(students);

            var courses = CourseInfo(dbContext);
            dbContext.Courses.AddRange(courses);

            var resources = ResourceInfo(dbContext, courses);
            dbContext.Resources.AddRange(resources);

            var homeworks = HomeworkInfo(dbContext, students, courses);
            dbContext.HomeworkSubmissions.AddRange(homeworks);

            dbContext.SaveChanges();
        }

        private static Homework[] HomeworkInfo(StudentSystemContext dbContext, Student[] seedStudents, Course[] seedCourses)
        {
            var homeworks = new[]
            {
                new Homework
                {
                     Content = "judge.softuni.bg/Contests/1677/Databases-MSSQL-Server",
                     ContentType = ContentType.Zip,
                     SubmissionTime = DateTime.Now,
                     Student = seedStudents[0],
                     Course = seedCourses[1]
                },

                new Homework
                {
                    Content = "judge.softuni.bg/Contests/2592/databases-advanced-entity-framework",
                    ContentType = ContentType.Zip,
                    SubmissionTime = DateTime.Now.AddDays(12),
                    Student = seedStudents[1],
                    Course = seedCourses[0]
                },

                new Homework
                {
                    Content = "judge.softuni.bg/Contests/5902/csharp-advanced",
                    ContentType = ContentType.Application,
                    SubmissionTime = new DateTime(2019, 02, 04),
                    Student = seedStudents[2],
                    Course = seedCourses[2]
                }
            };

            return homeworks;
        }

        private static Resource[] ResourceInfo(StudentSystemContext dbContext, Course[] seedCourses)
        {
            var resources = new[]
            {
                new Resource
                {
                    Name = "Exercise - Problem Descriptions",
                    Url = "softuni.bg/trainings/2351/databases-advanced-entity-framework",
                    ResourceType = ResourceType.Video,
                    Course = seedCourses[0]
                },

                new Resource
                {
                    Name = "SQL Joins LAB",
                    Url = "softuni.bg/trainings/4324/databases-basics-mssql-server",
                    ResourceType = ResourceType.Video,
                    Course = seedCourses[1]
                },

                new Resource
                {
                    Name = "Presentation",
                    Url = "softuni.bg/trainings/5902/csharp-advanced",
                    ResourceType = ResourceType.Presentation,
                    Course = seedCourses[2]
                }
            };

            return resources;
        }

        private static Course[] CourseInfo(StudentSystemContext dbContext)
        {
            var courses = new[]
            {
                new Course
                {
                    Name = "Databases Advanced - Entity Framework",
                    StartDate = new DateTime(2018, 5, 22),
                    EndDate = new DateTime(2017, 11, 10),
                    Price = 480.00m
                },

                new Course
                {
                    Name = "Databases Basics - MSSQL Server",
                    Description = "DB for beginners",
                    StartDate = new DateTime(2017, 03, 07),
                    EndDate = new DateTime(2017, 05, 14),
                    Price = 480.00m
                },

                new Course
                {
                    Name = "C# Advanced",
                    StartDate = new DateTime(2019, 03, 22),
                    EndDate = new DateTime(2019, 12, 10),
                    Price = 380.00m
                }
            };

            return courses;
        }

        private static Student[] StudentInfo(StudentSystemContext dbContext)
        {
            var students = new[]
            {
                new Student
                {
                     Birthday = new DateTime(1994, 02, 23),
                     Name = "Kiro",
                     PhoneNumber = "0877723784",
                     RegisteredOn = DateTime.Now
                },

                new Student
                {
                    Birthday = new DateTime(1989, 11, 11),
                    Name = "Marko",
                    RegisteredOn = DateTime.Now.AddDays(13)
                },

                new Student
                {
                    Birthday = new DateTime(2001, 06, 13),
                    Name = "Petia",
                    PhoneNumber = "0893723482",
                    RegisteredOn =  new DateTime(2009, 04, 12)
                }
            };

            return students;
        }
    }
}
