using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AVL_Tree
{
    class Program
    {
        static void Main(string[] args)
        {
            AVL_Tree BinaryTree = new AVL_Tree(Comp);


            BinaryTree.Add(10);
            BinaryTree.Add(5);
            BinaryTree.Add(3);
            BinaryTree.Add(1);
            BinaryTree.Add(4);
            BinaryTree.Add(7);
            BinaryTree.Add(8);
            BinaryTree.Add(6);
            BinaryTree.Add(15);
            BinaryTree.Add(17);
            BinaryTree.Add(20);
            BinaryTree.Add(16);
            BinaryTree.Add(12);
            BinaryTree.Add(11);
            BinaryTree.Add(14);
            Print();
            Console.ReadKey();
            BinaryTree.Delete(12);
            BinaryTree.Delete(14);
            Print();
            BinaryTree.Find(25);
            Console.ReadKey();



            void Print()
            {
                if (BinaryTree.root == null)
                {
                    Console.WriteLine("Tree is empty");
                    return;
                }
                InOrderDisplayTree(BinaryTree.root);
                Console.WriteLine();
            }
            void InOrderDisplayTree(Node current)
            {
                if (current != null)
                {
                    InOrderDisplayTree(current.left);
                    Console.Write($"({current.data})" /*current.data*/);
                    InOrderDisplayTree(current.right);
                }

            }

            static int Comp(int a, int b)
            {
                if (a < b) return -1;
                if (a == b) return 0;
                if (a > b) return 1;

                return 0;
            }
        }
    }

}
