using System.Reflection;
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
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(messageError);
                Console.ResetColor(); 
            }
        }
        public static string EnterString(string message = "Enter a string : ")
        {
            Console.WriteLine(message);
            return Console.ReadLine();
        }
        public static char EnterChar(string message = "Enter a char : ")
        {
            Console.Write(message);
            return Console.ReadKey().KeyChar;
        }
        public static char CharToUpper(char letter) { return char.ToUpper(letter); }
        public static int MenuWord(string messageError = "That's impossible ! retry.", string question = "How many letters were on your word ?")
        {
            int choice = 0;
            bool check = false;
            while (!check)
            {
                Console.WriteLine(question);
                choice = EnterNumber();

                if (choice < Game.MaxLettersPerPlayer)
                {
                    check = true;
                    break;
                }
                
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(messageError);
                Console.ResetColor();
            }
            return choice;
        }
        public static int HorizontalOrVertical()
        {
            bool check = false;
            int result = 0;
            while (check == false)
            {
                Console.WriteLine();
                Console.WriteLine("Choose the orientation of your word");
                Console.WriteLine("Horizontal --> h");
                Console.WriteLine("Vertical --> v");
                char choice = Fonction.EnterChar();
                choice = Fonction.CharToUpper(choice);
                if (choice == 'H')
                {
                    result = 1;
                    check = true;
                    return result;
                }
                else if (choice == 'V')
                {
                    result = 2;
                    check = true;
                    return result;
                }
            }
            return result;
        }
    }
}
