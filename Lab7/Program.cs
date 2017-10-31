using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab7
{
    class Program
    {
        static void Main(string[] args)
        {
            bool repeat = true;
            while (repeat)
            {
                //declare string arrays that have all the student information in them
                string[] Students = { "Amanda", "Blake", "Chris", "David", "Eugene", "Frank", "Gerald", "Hank", "Isabelle", "Judy", "Kathy" };
                string[] foods = { "Pizza", "Cheeseburger", "Ice Cream", "Taco", "Steak", "Bacon", "Chocolate", "French Fries", "Hot dog", "Sushi", "Spaghetti" };
                string[] hometowns = { "Lansing, MI", "Springfield, IL", "Montgomery, AL", "Denver, CO", "Hartford, CT", "Dover, DE", "Tallahassee, FL", "Atlanta, GA", "Boise, ID", "Topeka, KS", "Boston, Massachusetts" };
                //introduce program purpose
                Console.WriteLine("Hello! This program lets you know a little bit about each student in our C# class. \n\nBelow is the list of students in our class.\n");
                {
                    //call method to list off names of students
                    ListStudents(Students);
                    int number = GetNumber("\nWhich student would you like to learn about? (Enter a number 1-11)\n");

                    //gives user student info based on response either "favorite food" or "hometown" - if anything other than those two words, it will say invalid and ask again
                    bool again = true;
                    while (again)
                    {
                        string input2 = StudentInfo(Students, number);
                        if (input2 == "favorite food")
                        {
                            Console.WriteLine($"\n{Students[number - 1]}'s favorite food is {foods[number - 1]}. ");
                            again = false;

                        }
                        else if (input2 == "hometown")
                        {
                            Console.WriteLine($"\n{Students[number - 1]} is from {hometowns[number - 1]}.");
                            again = false;
                        }
                        else
                        {
                            Console.WriteLine("I'm sorry, that was not a valid response. Please try again.");
                            again = true;
                        }
                    }
                }
                repeat = DoAgain($"\nWould you like to learn more about our class? (Y or N): ");
            }
            //if user does not want to run program again, tells user goodbye
            Console.WriteLine("Goodbye!");
        }
        //Lists out the students so the user knows what number corresponds to what student
        private static void ListStudents(string[] Students)
        {
            for (int i = 0; i < Students.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {Students[i]}");
            }
        }
        //method that asks for user input of what info they would like to know about selected student
        private static string StudentInfo(string[] Students, int number)
        {
            Console.WriteLine($"\nStudent {number} is {Students[number - 1]}. What would you like to know about {Students[number - 1]}? (Enter \"favorite food \" or \"hometown\"): ");
            string input2 = Console.ReadLine().ToLower();
            return input2;
        }

        //method to get number that corresponds to a student - checks for valid number in range too
        private static int GetNumber(string prompt)
        {
            Console.Write(prompt);
            string input = Console.ReadLine().Trim();
            int.TryParse(input, out int number);

            if (number > 0 && number <= 11)
            {
                return number;

            }
            else
            {
                Console.WriteLine("I'm sorry, that was not a valid input.");
                return GetNumber(prompt);
            }
        }
        //method to repeat program - will only accept responses of y or no, otherwise will keep asking
        private static bool DoAgain(string prompt)
        {
            Console.Write(prompt);
            string input = Console.ReadLine().ToLower();
            if (input == "y")
            {
                return true;
            }
            else if (input == "n")
            {
                return false;
            }
            else
            {
                Console.Write("Invalid input. ");
                return DoAgain(prompt);
            }
        }
    }
}
