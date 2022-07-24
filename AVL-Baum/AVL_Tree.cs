using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AVL_Tree
{
    class Node<T>
    {
        public Node(T _data) => data = _data;
        public T data;
        public Node<T> left;
        public Node<T> right;
    }

    internal class AVL_Tree<T>
    {
        public Node<T> root;
        Comparison<T> compare;
        public int height = 0;

        public AVL_Tree(Comparison<T> _comp) //defines Delegate
        {
            compare = _comp;
            root = null;
        }

        public void Add(T _data) //Adds Nodes to the Tree
        {
            root = AddRecursive(new Node<T>(_data), root);
            Console.WriteLine($"{_data} was added to the tree.");
        }

        private Node<T> AddRecursive(Node<T> _toAdd, Node<T> _root)
        {
            if (null == _root)
            {
                return _toAdd;
            }
            if (compare.Invoke(_toAdd.data, _root.data) > 0)
            {
                _root.right = AddRecursive(_toAdd, _root.right);
                _root = BalanceTree(_root);

            }
            else
            {
                _root.left = AddRecursive(_toAdd, _root.left);
                _root = BalanceTree(_root);
            }

            return _root;
        }

        private Node<T> BalanceTree(Node<T> current) // Balances the Tree based on the Balance Factor
        {
            int bal_Factor = balance_Factor(current);
            if (bal_Factor > 1)
            {
                if (balance_Factor(current.left) > 0)
                {
                    current = RotateLeft(current);
                }
                else
                {
                    current = RotateLeftRight(current);
                }
            }
            else if (bal_Factor < -1)
            {
                if (balance_Factor(current.right) > 0)
                {
                    current = RotateRightLeft(current);
                }
                else
                {
                    current = RotateRight(current);
                }
            }
            return current;
        }

        /// <summary>
        /// Deletes Nodes and rebalance tree
        /// </summary>
        public void Delete(T target)
        {
            root = DeleteNode(root, target);
        }

        private Node<T> DeleteNode(Node<T> current, T toDelete)
        {
            Node<T> parent;
            if (current == null)
            {
                Console.WriteLine("The number you're searching for wasn't found.");
                return null; 
            }
            else
            {
                if (compare.Invoke(toDelete, current.data) < 0) //Search left tree
                {
                    current.left = DeleteNode(current.left, toDelete);
                    if (balance_Factor(current) == -2)
                    {
                        if (balance_Factor(current.right) <= 0)
                        {
                            current = RotateRight(current);
                        }
                        else
                        {
                            current = RotateRightLeft(current);
                        }
                    }
                }
                else if (compare.Invoke(toDelete, current.data) > 0) //Search right tree
                {
                    current.right = DeleteNode(current.right, toDelete);
                    if (balance_Factor(current) == 2)
                    {
                        if (balance_Factor(current.left) >= 0)
                        {
                            current = RotateLeft(current);
                        }
                        else
                        {
                            current = RotateLeftRight(current);
                        }
                    }
                }
                else //Delete if found
                {
                    if (current.right != null)
                    {
                        parent = current.right;
                        while (parent.left != null)
                        {
                            parent = parent.left;
                        }
                        current.data = parent.data;
                        Console.WriteLine($"{current.data} will be deleted");
                        current.right = DeleteNode(current.right, parent.data);
                        if (balance_Factor(current) == 2)
                        {
                            if (balance_Factor(current.left) >= 0)
                            {
                                current = RotateLeft(current);
                            }
                            else { current = RotateLeftRight(current); }
                        }
                    }
                    else
                    {
                        return current.left;
                    }
                }
            }
            return current;
        }

        public void Find(T _input)
        {
            T key = _input;

            if (Find(root, key))
                Console.WriteLine();
            else
                Console.WriteLine("Nothing was found. Please try again, with a different number.");
        }

        bool Find(Node<T> node, T key)
        {
            if (node == null)
                return false;
            if (compare.Invoke(key, node.data) == 0)
            {
                Console.WriteLine($"The Node you searched was found and contains: {node.data} !");
                return true;
            }
            if (compare.Invoke(key, node.data) < 0)
            {
                bool resultleft = Find(node.left, key);
                if (resultleft) return true;
            }
            if (compare.Invoke(key, node.data) > 0)
            {
                bool resultright = Find(node.right, key);
                return resultright;
            }
            else
            {
                return false;
            }
        }

        //"The conditional operator ?:, also known as the ternary conditional operator,
        //evaluates a Boolean expression and returns the result of one of the two expressions,
        //depending on whether the Boolean expression evaluates to true or false" - *2
        //1Liner If-else
        //Source: https://simpledevcode.wordpress.com/2014/09/16/avl-tree-in-c/ *1
        //Source: https://docs.microsoft.com/de-de/dotnet/csharp/language-reference/operators/conditional-operator *2
        private int maxHeight(int left, int right) // *1
        {
            return left > right ? left : right;
        }

        public int getHeight(Node<T> current)
        {
            height = 0;
            if (current != null)
            {
                int left = getHeight(current.left);
                int right = getHeight(current.right);
                int maxHeightcount = maxHeight(left, right);
                height = maxHeightcount + 1;
            }
            return height;
        }

        private int balance_Factor(Node<T> current)
        {
            int left = getHeight(current.left);
            int right = getHeight(current.right);
            int bal_Factor = left - right;
            return bal_Factor;
        }

        /// <summary>
        /// Node is handed over
        /// declared as Pivot
        /// left/right connected nodes 
        /// rotate around pivot
        /// </summary>
        private Node<T> RotateRight(Node<T> node)
        {
            Node<T> pivot = node.right;
            node.right = pivot.left;
            pivot.left = node;
            return pivot;
        }

        private Node<T> RotateLeft(Node<T> node)
        {
            Node<T> pivot = node.left;
            node.left = pivot.right;
            pivot.right = node;
            return pivot;
        }

        private Node<T> RotateLeftRight(Node<T> node)
        {
            Node<T> pivot = node.left;
            node.left = RotateRight(pivot);
            return RotateLeft(node);
        }

        private Node<T> RotateRightLeft(Node<T> node)
        {
            Node<T> pivot = node.right;
            node.right = RotateLeft(pivot);
            return RotateRight(node);
        }
    }
}