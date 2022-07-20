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

        public void defineArrayLength(CommandsClass CommandsObject)
        {
            Console.WriteLine("Please enter the Length of your Array:");
            Console.WriteLine("The length must be bigger than 0.");
            CommandsObject.ValidateInput(_userArrayAmount, 1, max, out _result);
            _userArrayAmount = _result;
            _userArray = new int[_userArrayAmount];
        }

        //Sets the size of the array by user input with validity check
        public void FillYourself(CommandsClass CommandsObject)
        {
            defineArrayLength(CommandsObject);

            Console.WriteLine($"The amount of numbers in the Array is: {_userArrayAmount}");
            Console.WriteLine($"Please enter {_userArrayAmount} numbers, between \n0 \nand \n{max}.");

            if (null != _userArray)
            {
                for (int i = 0; i < _userArray.Length; i++)
                {
                    Console.Write($"Please enter the {i + 1}. number in your List:");
                    CommandsObject.ValidateInput(_userArray[i], min, max, out _result);
                    for (int j = 0; j < _userArray.Length; j++)
                    {
                        if (_result == _userArray[j])
                        {
                            Console.WriteLine("This Number already exists, please choose another Number");
                            i--;
                            Console.WriteLine("Press any Key to continue");
                            Console.ReadKey();
                            Console.Clear();
                        }
                        else
                        {
                            _userArray[i] = _result;
                        }
                    }
                }
            }
            AVL_Tree<int> BinaryTree = new AVL_Tree<int>(CommandsObject.Comp);
            for (int i = 0; i < _userArray?.Length; i++)
            {
                BinaryTree.Add(_userArray[i]);
            }
        }
        void PrintInt(AVL_Tree<T> BinaryTree)
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
