
using System.Text.RegularExpressions;

namespace AVL_Tree
{   /// <summary>
    /// Collection of useful helpers and Error messages 
    /// </summary> 
    class CommandsClass
    {
        public bool IsValid(string userInput, int min, int max, out int result)
        {
            if (int.TryParse(userInput, out result))
            {
                return IsValid(result, min, max);
            }
            return false;
        }
        public bool IsValid(int userInput, int min, int max)
        {
            if (userInput >= min && userInput <= max)
            {
                return true;
            }
            if (userInput > min || userInput < max)
            {
                return false;
            }
            else
            {
                return false;
            }
        }
        public bool NotNumber(string userInput)
        {
            return Regex.IsMatch(userInput, @"[^\d]");
        }
        public void NumberNotInRange()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Clear();
            Console.WriteLine(asciiError);
            Console.WriteLine("The number is invalid!");
            Console.WriteLine("Please try again: \n");
            Console.WriteLine("Press Enter for another entry");
            Console.ReadKey();
            Console.Clear();
            Console.ResetColor();
        }
        public void ValidationInputRangeMethod(string userInput, int min, int max, int userChosenNumber)
        {
            if (IsValid(userInput, min, max, out userChosenNumber))
            {
                return;
            }
            else if (NotNumber(userInput))
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.Clear();
                Console.WriteLine("This is not a Number!");
                Console.Write("Please try again: \n");
            }
            else
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.Clear();
                Console.WriteLine("The number is invalid!");
                Console.WriteLine("Please try again: \n");
                Console.ResetColor();
            }
        }
        public void NoNumberError()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Clear();
            Console.WriteLine(asciiError);
            Console.WriteLine("This is not a Number!");
            Console.WriteLine("Please try again: \n");
            Console.WriteLine("Press Enter for another entry");
            Console.ReadKey();
            Console.ResetColor();
            Console.Clear();
        }
        public void ValidateInput(int inputToValidate, int min, int max, out int result)
        {
            while (true)
            {
                string? userInput = Console.ReadLine();

                if (IsValid(userInput, min, max, out result))
                {
                    inputToValidate = result;
                    Console.Clear();
                    break;
                }
                else if (NotNumber(userInput))
                {
                    NoNumberError();
                    break;
                }
                else
                {
                    NumberNotInRange();
                    break;
                }
            }
        }

        //public bool NumberExists(int)
        //Delegate for BinaryTree
        public int Comp(int a, int b)
        {
            if (a < b) return -1;
            if (a == b) return 0;
            if (a > b) return 1;

            return 0;
        }
        #region ACSII Art
        public string asciiError = @"
             ___                 
            | __|_ _ _ _ ___ _ _ 
            | _|| '_| '_/ _ \ '_|
            |___|_| |_| \___/_|  
                                 
                                    "; // Quelle http://patorjk.com/software/taag/#p=display&h=2&v=3&c=c%2B%2B&f=Small&t=Error
        #endregion
    }
}
