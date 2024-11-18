using System;

namespace MunicipalityApp.DataStructures
{
    // RedBlackTree class implementing a self-balancing binary search tree with red-black properties
    public class RedBlackTree<T> where T : IComparable<T>
    {
        // Enum to represent the color of the nodes in the tree
        private enum Color { Red, Black }

        // Node class representing a single node in the red-black tree
        private class Node
        {
            public T Value { get; set; } // The value stored in the node
            public Node Left { get; set; } // Pointer to the left child node
            public Node Right { get; set; } // Pointer to the right child node
            public Color NodeColor { get; set; } // The color of the node

            // Constructor for creating a new node with a value
            public Node(T value)
            {
                Value = value;
                NodeColor = Color.Red; // New nodes are initially red
            }
        }

        private Node root; // Root node of the red-black tree

        // Public method to insert a value into the red-black tree
        public void Insert(T value)
        {
            root = InsertRecursive(root, value); // Call the recursive insert function
            root.NodeColor = Color.Black; // Root must always be black
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

            // Fix any red-black tree violations
            if (IsRed(node.Right) && !IsRed(node.Left)) node = RotateLeft(node); // Right child red and left child black
            if (IsRed(node.Left) && IsRed(node.Left.Left)) node = RotateRight(node); // Left-left child red
            if (IsRed(node.Left) && IsRed(node.Right)) FlipColors(node); // Both children red

            return node; // Return the potentially updated node
        }
        //------------------------------End of method--------------------------------//

        // Method to check if a node is red
        private bool IsRed(Node node) => node != null && node.NodeColor == Color.Red;
        //------------------------------End of method--------------------------------//

        // Method to flip the colors of a node and its children
        private void FlipColors(Node node)
        {
            node.NodeColor = Color.Red; // Flip the node's color to red
            node.Left.NodeColor = Color.Black; // Set the left child to black
            node.Right.NodeColor = Color.Black; // Set the right child to black
        }
        //------------------------------End of method--------------------------------//

        // Method to perform a left rotation on a node
        private Node RotateLeft(Node node)
        {
            Node temp = node.Right; // Set temp to the right child of the node
            node.Right = temp.Left; // Move the left child of temp to the right child of the node
            temp.Left = node; // Set the node as the left child of temp
            temp.NodeColor = node.NodeColor; // Set temp's color to the node's color
            node.NodeColor = Color.Red; // Set the node's color to red
            return temp; // Return the new root (temp)
        }
        //------------------------------End of method--------------------------------//

        // Method to perform a right rotation on a node
        private Node RotateRight(Node node)
        {
            Node temp = node.Left; // Set temp to the left child of the node
            node.Left = temp.Right; // Move the right child of temp to the left child of the node
            temp.Right = node; // Set the node as the right child of temp
            temp.NodeColor = node.NodeColor; // Set temp's color to the node's color
            node.NodeColor = Color.Red; // Set the node's color to red
            return temp; // Return the new root (temp)
        }
        //------------------------------End of method--------------------------------//
    }
    //-----------------------------End of class-------------------------------------//
}
//----------------------------------End of File-------------------------------------//
