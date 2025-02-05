using System.Reflection.Metadata.Ecma335;

namespace Scrable
{
    public class Fonction
    {
        public static int EnterNumber(string question = "(Enter a number...)", string messageError = "It's not a number, try again !")
        {
            while (true)
            {
                Console.WriteLine(question);
                string input = Console.ReadLine();
                if (int.TryParse(input, out int number))
                {
                    return number;
                }
                else
                {
                    Console.WriteLine(messageError);
                }
            }
        }
        public static string EnterString(string message = "(Enter a string)")
        {
            Console.WriteLine(message);
            var x = Console.ReadLine();

            return x;
        }
        public static char EnterChar(string message = "(Enter a char)")
        {
            Console.WriteLine(message);
            char x = Console.ReadKey().KeyChar;

            return x;
        }
        public static char CharToUpper (char letter)
        {
            letter = char.ToUpper(letter);
            return letter;
        }
        public static int MenuWord()
        {
            int choice;
            bool check = false;
            Console.WriteLine("Continue ?");
            Console.WriteLine("YES => 1");
            Console.WriteLine("NO => 2");
            choice = EnterNumber();
            while (!check)
            {
                if (choice != 1 || choice != 2)
                {
                    Console.WriteLine("ERROR ! retry...");

                }
                else
                {
                    check = true;
                    break;
                }
            }
            return choice;
            
        }
    }
}
