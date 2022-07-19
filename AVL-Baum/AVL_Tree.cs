using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AVL_Tree
{
    class Node
    {
        public Node(int _data) { data = _data; }

        public int data;
        public Node left;
        public Node right;
    }
    internal class AVL_Tree
    {
        public Node root;
        Comparison<int> compare;

        //Not sure what it does...
        public AVL_Tree(Comparison<int> _comp)
        {
            compare = _comp;
        }

        public void Add(int _data)
        {
            root = AddRecursive(new Node(_data), root);
        }

        private Node AddRecursive(Node _toAdd, Node _root)
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

        private Node BalanceTree(Node current)
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
        public void Delete(int target)
        {
            root = DeleteNode(root, target);
        }

        private Node DeleteNode(Node current, int toDelete)
        {
            Node parent;
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
        public void Find(int? key)
        {
            try
            {
                if (Find(key, root).data == key)
                {
                    Console.WriteLine("{0} was found!", key);
                }
            }
            catch (NullReferenceException)
            {
                Console.WriteLine("Nothing found!");
            }
        }
        
        private Node Find(int? search, Node current)
        {
            try
            { 
                if (search < current.data)
                {
                    if (search == current.data)
                    {
                        return current;
                    }
                    else
                        return Find(search, current.left);
                }
                else
                {
                    if (search == current.data)
                    {
                        return current;
                    }
                    else
                        return Find(search, current.right);
                }
            }
            catch(NullReferenceException)
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
        private int getHeight(Node current)
        {
            int height = 0;
           if (current != null)
            {
                int left = getHeight(current.left);
                int right = getHeight(current.right);
                int m = max(left, right);
                height = m + 1;
            }
            return height;
        }
        private int balance_Factor(Node current)
        {
            int left = getHeight(current.left);
            int right = getHeight(current.right);
            int bal_Factor = left - right;
            return bal_Factor;
        }
        private Node RotateRight(Node parent)
        {
            Node pivot = parent.right;
            parent.right = pivot.left;
            pivot.left = parent;
            return pivot;
        }
        private Node RotateLeft(Node parent)
        {
            Node pivot = parent.left;
            parent.left = pivot.right;
            pivot.right = parent;
            return pivot;
        }
        private Node RotateLeftRight(Node parent)
        {
            Node pivot = parent.left;
            parent.left = RotateRight(pivot);
            return RotateLeft(parent);
        }
        private Node RotateRightLeft(Node parent)
        {
            Node pivot = parent.right;
            parent.right = RotateLeft(pivot);
            return RotateRight(parent);
        }

        


    }

}





