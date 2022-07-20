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
        int min = int.MinValue;
        int max = int.MaxValue;
        public int[]? _userArray;

        public PrinterClass()
        {
            _userArray = null;
        }


        public void defineArrayLength(CommandsClass CommandsObject)
        {
            Console.WriteLine("Please enter the Length of your Array:");
            Console.WriteLine("The length must be bigger than 0.");
            CommandsObject.ValidateInput(_userArrayAmount, 1, max, out _result);
            _userArrayAmount = _result;
            _userArray = new int[_userArrayAmount];
        }

        //Sets the size of the array by user input with validity check
        public void FillYourself(CommandsClass CommandsObject, AVL_Tree<int> BinaryTree)
        {
            defineArrayLength(CommandsObject);

            Console.WriteLine($"The amount of numbers in the Array is: {_userArrayAmount}");
            Console.WriteLine($"Please enter {_userArrayAmount} numbers, between \n0 \nand \n{max}.");
            //check if _userArray Contains a number that already exists
            if (null != _userArray)
            {
                for (int i = 0; i < _userArray.Length; i++)
                {
                    Console.Write($"Please enter the {i + 1}. number in your List:");
                    CommandsObject.ValidateInput(_userArray[i], min, max, out _result);
                    /*for (int j = 0; j < _userArray.Length; j++)*/
                    
                    bool exists = Array.Exists(_userArray, x => x == _result);
                    if (exists)
                    {
                        Console.WriteLine("This number is already in the Array.");
                        i--;
                    }
                    else if (!exists)
                    {
                        _userArray[i] = _result;
                    }
                }
            }
            for (int i = 0; i < _userArray?.Length; i++)
            {
                BinaryTree.Add(_userArray[i]);
            }
        }
        public void PrintInt(AVL_Tree<int> BinaryTree)
        {
            if (BinaryTree.root == null)
            {
                Console.WriteLine("Tree is empty");
                return;
            }
            InOrderDisplayTree(BinaryTree.root);
            Console.WriteLine();
        }
        void InOrderDisplayTree(Node<int> current)
        {
            if (current != null)
            {
                InOrderDisplayTree(current.left);
                Console.Write($"({current.data})");
                InOrderDisplayTree(current.right);
            }
        }
    }
}
