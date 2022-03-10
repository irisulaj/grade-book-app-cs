// See https://aka.ms/new-console-template for more information

using System;
using System.Collections.Generic;
namespace GradeBook

{


    class Program
    {
        static void Main(string[] args)
        {


            var book = new DiskBook("Allen's Grade Book");

            book.GradeAdded += OnGradeAdded;

            EnterGrades(book);

            var stats = book.GetStatistics();

            Console.WriteLine($"For the book named: {book.Name}");
            Console.WriteLine($"The class average is: {stats.Average:N2}");
            Console.WriteLine($"The lowest grade is: {stats.Low:N2}");
            Console.WriteLine($"The highest grade is: {stats.High:N2}");
            Console.WriteLine($"The letter grade is: {stats.Letter:N2}");

        }

        private static void EnterGrades(IBook book)
        {
            while (true)
            {

                Console.WriteLine("Enter grade or q to quit: ");
                var input = Console.ReadLine();

                if (input == "q")
                {
                    break;
                }

                try
                {
                    var grade = double.Parse(input);
                    book.AddGrade(grade);

                }
                catch (ArgumentException e)
                {

                    Console.WriteLine(e.Message);
                }
                catch (FormatException e)
                {

                    Console.WriteLine(e.Message);
                }
                finally
                {

                    Console.WriteLine("Execute code  here");
                }
            }
        }

        static void OnGradeAdded(object sender, EventArgs e){

                    Console.WriteLine("A grade was added!!!");
        }
        
    }
}