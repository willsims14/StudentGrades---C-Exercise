using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace StudentGrades
{
    class Program
    {
        static void Main(string[] args)
        {
            var will = new Student("Will", "Sims");
            var Math = new Course("Math");

            // Can create 
            var HomeworkOne = new Assignment("Homework 1", 50);
            Math.CreateAssignment("Homework 2", 25, 20);

            Math.AddAssignment(HomeworkOne);
            HomeworkOne.AddGradeForAssignment(45);




            //math.AddGradedAssignment("Homework 1", 45, 50);
            //string mathGrade = Math.GetGradeForAssignment("Homework 1");

            //Console.WriteLine("Math Grade: '", mathGrade + "'");
            Console.WriteLine("Add Course(Math), Print Courses()");
            will.AddCourse(Math);
            will.PrintCourses();


            foreach (var assignment in Math.Assignments)
            {
                Console.WriteLine("- " + assignment.Title + ": " + assignment.PointsReceived + "/" + assignment.PointsPossible);
            }


            Console.WriteLine(" --- GET ASSIGNMENT ---");
            var myAssignment = Math.GetAssignment("Homework 1");
            myAssignment.PrintAssignment();


            Console.Read();
        }


        public class Student
        {
            public string FirstName { get; }
            public string LastName { get; }
            public ICollection<Course> Courses { get; set; } = new List<Course>();
            
            //public Standing YearInSchool { get; set; } = Standing.Freshman;

            // Constructor
            public Student(string firstName, string lastName)
            {
                FirstName = firstName;
                LastName = lastName;
            }

            public void AddCourse(Course course)
            {
                Courses.Add(course);
            }

            public void PrintCourses()
            {
                foreach (var course in Courses)
                {
                    Console.WriteLine("Course: " + course.Title);
                }
            }



            
        }

        public class Course
        {
            public string Title { get; }
            public ICollection<Assignment> Assignments { get; set; } = new List<Assignment>();
            public IDictionary<string, Assignment> AssignmentsDict { get; set; } = new Dictionary<string, Assignment>();

            public Course(string title)
            {
                Title = title;
            }

            public void CreateAssignment(string title, double pointsPossible, double pointsReceived=0)
            {
                var newAssignment = new Assignment(title, pointsPossible);
                if (pointsReceived != 0)
                {
                    newAssignment.AddGradeForAssignment(pointsReceived);
                }
                Assignments.Add(newAssignment);
                AssignmentsDict[title] = newAssignment;
            }

            public void AddAssignment(Assignment assignment)
            {
                Assignments.Add(assignment);
                AssignmentsDict[assignment.Title] = assignment;
            }

            public string GetGradeForAssignment(string assignmentName)
            {
                //string grade = assignmentName + ": " + PointsReceived[assignmentName] + "/" + PointsPossible[assignmentName];
                return "";
            }

            public Assignment GetAssignment(string assignmentName)
            {
                return AssignmentsDict[assignmentName];
            }



        }

        public class Assignment
        {
            public string Title { get; set; }
            public double PointsReceived { get; set; }
            public double PointsPossible { get; set; }

            public Assignment(string name, double pointsPossible)
            {
                Title = name;
                PointsPossible = pointsPossible;
            }

            public void AddGradeForAssignment(double pointsReceived)
            {
                PointsReceived = pointsReceived;
            }

            public void PrintAssignment()
            {
                Console.WriteLine(Title + ": " + PointsReceived + "/" + PointsPossible);
            }
        }
    }
}