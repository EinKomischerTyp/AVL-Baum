using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AVL_Tree
{
    class Node<T>
    {
        public Node(T _data) { data = _data; }

        public T data;
        public Node<T> left;
        public Node<T> right;
    }
    internal class AVL_Tree<T>
    {
        public Node<T> root;
        Comparison<T> compare;
        public int height = 0;


        public AVL_Tree(Comparison<T> _comp)
        {
            compare = _comp;
            root = null;
        }

        public void Add(T _data)
        {
            root = AddRecursive(new Node<T>(_data), root);
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

        private Node<T> BalanceTree(Node<T> current)
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
        public void Delete(T target)
        {
            root = DeleteNode(root, target);
        }
        
        private Node<T> DeleteNode(Node<T> current, T toDelete)
        {
            Node<T> parent;
            if (null == current)
            {
                return null;
            }
            if (compare.Invoke(toDelete, current.data) < 0)
            {
                current.left = DeleteNode(current.left, toDelete);
            }
            else if (compare.Invoke(toDelete, current.data) > 0)
            {
                current.right = DeleteNode(current.right, toDelete);
            }
            else
            {
                if (null == current.left)
                {
                    return current.right;
                }
                else if (null == current.right)
                {
                    return current.left;
                }
                else
                {
                    parent = current;
                    current = current.right;
                    while (null != current.left)
                    {
                        parent = current;
                        current = current.left;
                    }
                    parent.left = current.right;
                    current.left = current.right = null;
                }
            }
            return current;
        }

        public void Find(T? key)
        {
            try
            {
                if (compare.Invoke(Find(key, root).data, key) == 0) //(Find(key, root).data == key)//If nothing is found a NullReferenceException is expected here
                {
                    Console.WriteLine("{0} was found!", key);
                }
            }
            catch (NullReferenceException)
            {
                Console.WriteLine("Nothing found!");
            }
        }

        private Node<T> Find(T? search, Node<T> current) //If nothing is found a NullReferenceException is expected here
        {
            try
            {
                if (compare.Invoke(search, current.data) < 0)
                {
                    if (compare.Invoke(search, current.data) == 0)
                    {
                        return current;
                    }
                    else
                        return Find(search, current.left);
                }
                else
                {
                    if (compare.Invoke(search, current.data) == 0)
                    {
                        return current;
                    }
                    else
                        return Find(search, current.right);
                }
            }
            catch (NullReferenceException)
            {
                return null;
            }
        }

        //The conditional operator ?:, also known as the ternary conditional operator,
        //evaluates a Boolean expression and returns the result of one of the two expressions,
        //depending on whether the Boolean expression evaluates to true or false
        //1Liner If-else
        private int max(int left, int right)
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
                int m = max(left, right);
                height = m + 1;
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
        private Node<T> RotateRight(Node<T> parent)
        {
            Node<T> pivot = parent.right;
            parent.right = pivot.left;
            pivot.left = parent;
            return pivot;
        }
        private Node<T> RotateLeft(Node<T> parent)
        {
            Node<T> pivot = parent.left;
            parent.left = pivot.right;
            pivot.right = parent;
            return pivot;
        }
        private Node<T> RotateLeftRight(Node<T> parent)
        {
            Node<T> pivot = parent.left;
            parent.left = RotateRight(pivot);
            return RotateLeft(parent);
        }
        private Node<T> RotateRightLeft(Node<T> parent)
        {
            Node<T> pivot = parent.right;
            parent.right = RotateLeft(pivot);
            return RotateRight(parent);
        }

        


    }

}





