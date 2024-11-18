using System;

namespace MunicipalityApp.DataStructures
{
    // AVL Tree class implementing a self-balancing binary search tree
    public class AVLTree<T> where T : IComparable<T>
    {
        // Node class representing a single node in the tree
        private class Node
        {
            public T Value { get; set; } // The value stored in the node
            public Node Left { get; set; } // Pointer to the left child node
            public Node Right { get; set; } // Pointer to the right child node
            public int Height { get; set; } // Height of the node to maintain balance

            // Constructor for creating a new node with a value
            public Node(T value)
            {
                Value = value;
                Height = 1; // Initially, the height of the node is 1 (leaf node)
            }
        }
        //------------------------------End of method--------------------------------//

        private Node root; // Root node of the AVL tree

        // Public method to insert a value into the AVL tree
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

            // Update the height of the current node
            node.Height = 1 + Math.Max(GetHeight(node.Left), GetHeight(node.Right));

            // Rebalance the tree to maintain AVL property
            return Balance(node);
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
            if (value.CompareTo(node.Value) == 0) return true; // Value found

            // If value is smaller, search in the left subtree
            return value.CompareTo(node.Value) < 0
                ? ContainsRecursive(node.Left, value)
                // If value is larger, search in the right subtree
                : ContainsRecursive(node.Right, value);
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
                // Traverse left subtree
                TraverseInOrderRecursive(node.Left, action);
                // Perform the action on the current node's value
                action(node.Value);
                // Traverse right subtree
                TraverseInOrderRecursive(node.Right, action);
            }
        }
        //------------------------------End of method--------------------------------//

        // Private method to balance the tree and maintain AVL property
        private Node Balance(Node node)
        {
            int balanceFactor = GetBalanceFactor(node); // Get balance factor of the node

            // If the node is left heavy, perform rotations to balance
            if (balanceFactor > 1)
            {
                if (GetBalanceFactor(node.Left) < 0)
                    node.Left = RotateLeft(node.Left); // Left-Right case
                return RotateRight(node); // Left-Left case
            }

            // If the node is right heavy, perform rotations to balance
            if (balanceFactor < -1)
            {
                if (GetBalanceFactor(node.Right) > 0)
                    node.Right = RotateRight(node.Right); // Right-Left case
                return RotateLeft(node); // Right-Right case
            }

            // Return the node if it's already balanced
            return node;
        }
        //------------------------------End of method--------------------------------//

        // Method to calculate the balance factor of a node (expression-bodied method)
        private int GetBalanceFactor(Node node)
            => node == null ? 0 : GetHeight(node.Left) - GetHeight(node.Right);
        //------------------------------End of method--------------------------------//

        // Method to perform a right rotation on a node
        private Node RotateRight(Node y)
        {
            Node x = y.Left; // Set x as the left child of y
            y.Left = x.Right; // Move x's right child to y's left
            x.Right = y; // Set y as the right child of x

            // Update the heights of y and x
            y.Height = 1 + Math.Max(GetHeight(y.Left), GetHeight(y.Right));
            x.Height = 1 + Math.Max(GetHeight(x.Left), GetHeight(x.Right));
            return x; // Return the new root (x)
        }
        //------------------------------End of method--------------------------------//

        // Method to perform a left rotation on a node
        private Node RotateLeft(Node x)
        {
            Node y = x.Right; // Set y as the right child of x
            x.Right = y.Left; // Move y's left child to x's right
            y.Left = x; // Set x as the left child of y

            // Update the heights of x and y
            x.Height = 1 + Math.Max(GetHeight(x.Left), GetHeight(x.Right));
            y.Height = 1 + Math.Max(GetHeight(y.Left), GetHeight(y.Right));
            return y; // Return the new root (y)
        }
        //------------------------------End of method--------------------------------//


        // Method to get the height of a node, returns 0 if the node is null (expression-bodied method)
        private int GetHeight(Node node) => node?.Height ?? 0;
        //------------------------------End of method--------------------------------//

    }
    //-----------------------------End of class-------------------------------------//
}
//----------------------------------End of File-------------------------------------//