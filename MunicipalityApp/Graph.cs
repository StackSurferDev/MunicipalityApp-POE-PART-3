using System;
using System.Collections.Generic;

namespace MunicipalityApp.DataStructures
{
    // Graph class representing a graph with nodes of type T
    public class Graph<T> where T : class
    {
        private readonly Dictionary<T, List<T>> adjacencyList; // Dictionary to store nodes and their neighbors

        // Constructor to initialize the adjacency list
        public Graph()
        {
            adjacencyList = new Dictionary<T, List<T>>(); // Initialize the adjacency list as an empty dictionary
        }
        //------------------------------End of method--------------------------------//

        // Method to add a node to the graph
        public void AddNode(T node)
        {
            if (node == null) throw new ArgumentNullException(nameof(node)); // Check if the node is null
            if (!adjacencyList.ContainsKey(node))
            {
                adjacencyList[node] = new List<T>(); // Add the node with an empty list of neighbors
            }
        }
        //------------------------------End of method--------------------------------//

        // Method to add an edge between two nodes
        public void AddEdge(T from, T to)
        {
            if (from == null || to == null) throw new ArgumentNullException(); // Check if any of the nodes are null
            AddNode(from); // Ensure the 'from' node exists
            AddNode(to); // Ensure the 'to' node exists
            adjacencyList[from].Add(to); // Add the 'to' node as a neighbor to the 'from' node
        }
        //------------------------------End of method--------------------------------//

        // Method to get the neighbors of a given node
        public List<T> GetNeighbors(T node)
        {
            if (node == null) throw new ArgumentNullException(nameof(node)); // Check if the node is null
            return adjacencyList.TryGetValue(node, out var neighbors) ? neighbors : new List<T>(); // Return the neighbors or an empty list if no neighbors
        }
        //------------------------------End of method--------------------------------//

        // Method to display the graph
        public void DisplayGraph()
        {
            foreach (var node in adjacencyList)
            {
                // Print each node and its corresponding neighbors
                Console.WriteLine($"{node.Key}: {string.Join(", ", node.Value)}");
            }
        }
        //------------------------------End of method--------------------------------//
    }
    //-----------------------------End of class-------------------------------------//
}
//----------------------------------End of File-------------------------------------//
