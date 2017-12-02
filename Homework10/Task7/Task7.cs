using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task7
{
    /// <summary>
    /// Develop a generic class-collection BinarySearchTree that implements the basic operations for working with the stucture data binary search tree.
    /// Provide an opportunity of using a plug-in interface to implement the order relation. Implement three ways of traversing the tree:
    /// direct (preorder), transverse (inorder), reverse (postorder) (use the block iterator yield). Develop unit-tests.
    /// Use for the testiong the following types:
    /// System.String (use default comparison and plug-in comparator);
    /// the custom class Book, for objects of which the order relation is implemented(use the default comparison and plug-in comparator);
    /// the custom structure Point, for instance of which the relation of order is not implemented(use a plug-in comparator).
    /// /// </summary>
    class Task7
    {
        static void Main(string[] args)
        {
        }
    }

    public class BinarySearchTree<TKey, TValue> where TKey : IComparable<TKey>
                                                where TValue : IComparable<TValue>
    {
        Node _root;
        public BinarySearchTree(TKey key, TValue value)
        {
            _root = new Node(key, value);
        }

        public bool Add(TKey key, TValue value)
        {
            var nodeToAdd = new Node(key, value);
            return AddNode(nodeToAdd, _root);
        }
        bool AddNode(Node nodeToAdd, Node nodeToCompare)
        {
            if (nodeToAdd == null)
                throw new ArgumentNullException(nameof(nodeToAdd), "argument should not be null");
            if (nodeToCompare == null)
                throw new ArgumentNullException(nameof(nodeToCompare), "argument should not be null");

            if (nodeToAdd.key.CompareTo(nodeToCompare.key)<0)
            {
                if (nodeToCompare.left == null)
                {
                    nodeToCompare.left = nodeToAdd;
                    return true;
                }                    
                else
                {
                    return AddNode(nodeToAdd, nodeToCompare.left);
                }
                
            }
            else if(nodeToAdd.key.CompareTo(nodeToCompare.key)>0)
            {
                if (nodeToCompare.right == null)
                {
                    nodeToCompare.right = nodeToAdd;
                    return true;
                }
                else
                {
                    return AddNode(nodeToAdd, nodeToCompare.right);
                }
            }
            else if(nodeToAdd.key.CompareTo(nodeToCompare.key)==0)
            {
                nodeToCompare.value = nodeToAdd.value;
                return true;
            }
            return false;
        }
        public bool Remove(TKey key)
        {
            var nodeToRemove = new Node(key, default(TValue));
            return RemoveNode(nodeToRemove, _root);
        }
        bool RemoveNode(Node nodeToRemove, Node nodeToCompare)
        {
            if (nodeToRemove == null)
                throw new ArgumentNullException(nameof(nodeToRemove), "argument should not be null");
            if (nodeToCompare == null)
                throw new ArgumentNullException(nameof(nodeToCompare), "argument should not be null");

            if (nodeToRemove.key.CompareTo(nodeToCompare.key) < 0)
            {
                if (nodeToCompare.left == null)
                {
                    return false;
                }
                else
                {
                    return RemoveNode(nodeToRemove, nodeToCompare.left);
                }

            }
            else if (nodeToRemove.key.CompareTo(nodeToCompare.key) > 0)
            {
                if (nodeToCompare.right == null)
                {
                    return false;
                }
                else
                {
                    return RemoveNode(nodeToRemove, nodeToCompare.right);
                }
            }
            else if (nodeToRemove.key.CompareTo(nodeToCompare.key) == 0)
            {
                var tmpNode = nodeToCompare.left;
                nodeToCompare.key = nodeToCompare.right.key;
                nodeToCompare.value = nodeToCompare.right.value;
                nodeToCompare.left = nodeToCompare.right.left;
                nodeToCompare.right = nodeToCompare.right.right;

                var node = nodeToCompare.left;
                if (nodeToCompare.left == null)
                    nodeToCompare.left = tmpNode;
                else
                {
                    while (node.left != null)
                    {
                        node.left = node.left.left;
                    }
                    node.left = tmpNode;
                }                
                return true;
            }
            return false;
        }
        public TValue GetValueByKey(TKey key)
        {
            return GetValue(key, _root);
        }
        TValue GetValue(TKey key, Node nodeToCompare)
        {
            if (nodeToCompare == null) throw new ArgumentNullException(nameof(nodeToCompare), "argument should not be null");

            if (key.CompareTo(nodeToCompare.key) < 0)
            {
                if (nodeToCompare.left != null)
                {
                    return GetValue(key, nodeToCompare.left);
                }
            }
            else if (key.CompareTo(nodeToCompare.key) > 0)
            {
                if (nodeToCompare.right != null)
                {
                    return GetValue(key, nodeToCompare.right);
                }
            }
            else if (key.CompareTo(nodeToCompare.key) == 0)
            {
                return nodeToCompare.value;
            }
            throw new ArgumentException("Key not found");
        }
        public class Node
        {
            public Node(TKey key, TValue value = default(TValue))
            {
                if (key == null) throw new ArgumentNullException(nameof(key), "argument should not be null");
                this.key = key;
                this.value = value;
            }
            public Node left;
            public Node right;
            public TValue value;
            public TKey key;
        }

    }

    
}
