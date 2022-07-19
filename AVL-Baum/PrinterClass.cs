using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVL_Tree
{
    internal class PrinterClass
    {
        int _userArrayAmount = 0;
        int userChosenNumber = 0;
        int _result;
        int min = 0;
        int max = int.MaxValue;
        public int[]? _userArray;

        public PrinterClass()
        {
            _userArray = null;
        }

        public void defineArrayLength(CommandsClass commandsObject)
        {
            Console.WriteLine("Please enter the Length of your Array:");
            Console.WriteLine("The length must be bigger than 0.");
            commandsObject.ValidateInput(_userArrayAmount, 1, max, out _result);
            _userArrayAmount = _result;
            _userArray = new int[_userArrayAmount];
        }

        //Sets the size of the array by user input with validity check
        public void FillYourself(CommandsClass commandsObject)
        {
            defineArrayLength(commandsObject);

            Console.WriteLine($"The amount of numbers in the Array is: {_userArrayAmount}");
            Console.WriteLine($"Please enter {_userArrayAmount} numbers, between \n0 \nand \n{max}.");
            if (null != _userArray)
            {
                for (int i = 0; i < _userArray.Length; i++)
                {
                    Console.Write($"Please enter the {i + 1}. number in your List:");
                    commandsObject.ValidateInput(_userArray[i], min, max, out _result);
                    _userArray[i] = _result;
                }
            }
        }
    }
}
