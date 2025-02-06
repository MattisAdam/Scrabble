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
        public static string EnterString(string message = "Enter a string : ")
        {
            Console.WriteLine(message);
            var x = Console.ReadLine();

            return x;
        }
        public static char EnterChar(string message = "Enter a char : ") { 
            Console.Write(message);
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
            int choice = 0;
            bool check = false;
            while (!check)
            {
                Console.WriteLine("How many letters were on your word ?");
                choice = EnterNumber();
            
                if (choice < Game.MaxLettersPerPlayer)
                {
                    check = true;
                    break;
                }
                else
                {
                    Console.WriteLine("That's impossible ! retry.");
                }
                
            }
            return choice;
            
        }
        public static int HorizontalOrVertical()
        {
            bool check = false;
            int result = 0;
            while (check == false)
            {
                Console.WriteLine("Choose the orientation of your word");
                Console.WriteLine("Horizontal --> h");
                Console.WriteLine("Vertical --> v");
                char choice = Fonction.EnterChar();
                choice = Fonction.CharToUpper(choice);
                if(choice == 'H')
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
