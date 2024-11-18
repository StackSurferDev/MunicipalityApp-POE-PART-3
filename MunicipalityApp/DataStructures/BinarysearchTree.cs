using System;

namespace MunicipalityApp.DataStructures
{
    // BinarySearchTree class implementing a basic binary search tree
    public class BinarySearchTree<T> where T : IComparable<T>
    {
        // Node class representing a single node in the tree
        private class Node
        {
            public T Value { get; set; } // The value stored in the node
            public Node? Left { get; set; } // Pointer to the left child node
            public Node? Right { get; set; } // Pointer to the right child node

            // Constructor for creating a new node with a value
            public Node(T value)
            {
                Value = value;
                Left = null; // Initially, no left child
                Right = null; // Initially, no right child
            }
        }

        private Node root; // Root node of the binary search tree

        // Public method to insert a value into the tree
        public void Insert(T value)
        {
            root = InsertRecursive(root, value); // Call the recursive insert function
        }
        //------------------------------End of method--------------------------------//

        // Recursive method to insert a value into the tree
        private Node InsertRecursive(Node node, T value)
        {
            // If the node is null, create a new node with the value
            if (node == null) return new Node(value);

            // If the value is smaller, go to the left subtree
            if (value.CompareTo(node.Value) < 0)
                node.Left = InsertRecursive(node.Left, value);
            // If the value is larger, go to the right subtree
            else if (value.CompareTo(node.Value) > 0)
                node.Right = InsertRecursive(node.Right, value);

            return node; // Return the node
        }
        //------------------------------End of method--------------------------------//

        // Public method to check if a value exists in the tree
        public bool Contains(T value)
        {
            return ContainsRecursive(root, value); // Call the recursive contains function
        }
        //------------------------------End of method--------------------------------//

        // Recursive method to check if a value exists in the tree
        private bool ContainsRecursive(Node node, T value)
        {
            if (node == null) return false; // Return false if node is null

            // If the value is found, return true
            if (value.CompareTo(node.Value) == 0)
                return true;
            // If value is smaller, search in the left subtree
            else if (value.CompareTo(node.Value) < 0)
                return ContainsRecursive(node.Left, value);
            // If value is larger, search in the right subtree
            else
                return ContainsRecursive(node.Right, value);
        }
        //------------------------------End of method--------------------------------//

        // Public method to traverse the tree in-order and perform an action on each value
        public void TraverseInOrder(Action<T> action)
        {
            TraverseInOrderRecursive(root, action); // Start traversal from root
        }
        //------------------------------End of method--------------------------------//

        // Recursive method to traverse the tree in-order
        private void TraverseInOrderRecursive(Node node, Action<T> action)
        {
            if (node != null)
            {
                TraverseInOrderRecursive(node.Left, action); // Traverse left subtree
                action(node.Value); // Perform the action on the current node's value
                TraverseInOrderRecursive(node.Right, action); // Traverse right subtree
            }
        }
        //------------------------------End of method--------------------------------//
    }
    //-----------------------------End of class-------------------------------------//
}
//----------------------------------End of File-------------------------------------//
