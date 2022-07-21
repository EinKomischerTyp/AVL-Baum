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

        /// <summary>
        /// Displays startscreen
        /// Asks user an array length
        /// User can enter numbers into an array
        /// Numbers from the array will be added to an AVL tree
        /// User can choose between actions for displaying the tree, 
        /// search, delete, add a new number or quit the programm 
        /// </summary>
        public void StartPrinter(CommandsClass CommandsObject, AVL_Tree<int> BinaryTree)
        {
            SplashScreen(CommandsObject);
            defineArrayLength(CommandsObject);
            FillYourself(CommandsObject, BinaryTree);
            SwitchCase(CommandsObject, BinaryTree);
        }

        public void SplashScreen(CommandsClass CommandsObject)
        {
            Console.WriteLine(CommandsObject.asciiTitle);
            Console.WriteLine();
            Console.WriteLine("Created by André Biedermann, Kevin Vogts und Simon Schepers");
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }

        public void defineArrayLength(CommandsClass CommandsObject)
        {
            Console.WriteLine("Please enter the Length of your Array:");
            Console.WriteLine("The length must be bigger than 0.");
            CommandsObject.ValidateInput(_userArrayAmount, 1, max, out _result);
            _userArrayAmount = _result;
            _userArray = new int[_userArrayAmount];
        }

        public void FillYourself(CommandsClass CommandsObject, AVL_Tree<int> BinaryTree)
        {
            Console.WriteLine($"The amount of numbers in the Array is: {_userArrayAmount}");
            Console.WriteLine($"Please enter {_userArrayAmount} numbers, between \n{min} \nand \n{max}.");
            if (null != _userArray) //check if _userArray Contains a number that already exists
            {
                for (int i = 0; i < _userArray.Length; i++)
                {
                    Console.WriteLine($"Please enter the {i + 1}. number in your List:");
                    Console.WriteLine("You can't enter the same number twice!");
                    CommandsObject.ValidateInput(_userArray[i], min, max, out _result);
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

        public void PrintInt(AVL_Tree<int> BinaryTree) //Sets the size of the array by user input with validity check
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

        public void ScreenClear()
        {
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
            Console.Clear();
        }

        public void SwitchCase(CommandsClass CommandsObject, AVL_Tree<int> BinaryTree)
        {
            Console.Clear();
            int _printTree = 0;
            while (true)
            {
                Console.WriteLine("Please choose what you want to do:");
                Console.WriteLine("1: Display the Tree");
                Console.WriteLine("2: Find a Number in the Tree");
                Console.WriteLine("3. Remove a Number from the Tree");
                Console.WriteLine("4. Add a Number to the Tree");
                Console.WriteLine("5. Exit the Application");
                Console.WriteLine("Confirm your choice by pressing Enter!");
                CommandsObject.ValidateInput(_printTree, 1, 5, out _result);
                _printTree = _result;
                switch (_result)
                {
                    case 1:
                        {
                            PrintInt(BinaryTree);
                            Console.WriteLine($"The Trees Height is: " + BinaryTree.getHeight(BinaryTree.root));
                            ScreenClear();
                        }
                        break;
                    case 2:
                        {
                            Console.WriteLine("Enter the Number you are searching:");
                            CommandsObject.ValidateInput(_printTree, min, max, out _result);
                            BinaryTree.Find(_result);
                            ScreenClear();
                        }
                        break;
                    case 3:
                        {
                            Console.WriteLine("Enter the Number you want to delete:");
                            CommandsObject.ValidateInput(_printTree, min, max, out _result);
                            BinaryTree.Delete(_result);
                            ScreenClear();
                        }
                        break;
                    case 4:
                        {
                            Console.WriteLine("INFO: You can now even add double numbers!");
                            Console.WriteLine("Enter the Number you want to add:");
                            CommandsObject.ValidateInput(_printTree, min, max, out _result);
                            BinaryTree.Add(_result);
                            ScreenClear();
                        }
                        break;
                    case 5:
                        {
                            Console.WriteLine("Exiting please wait...");
                            Environment.Exit(5);
                        }
                        break;
                    default:
                        Console.WriteLine("Invalid Entry");
                        ScreenClear();
                        break;
                }
            }
        }
    }
}
