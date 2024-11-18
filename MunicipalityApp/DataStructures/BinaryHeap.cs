using System;
using System.Collections.Generic;

namespace MunicipalityApp.DataStructures
{
    // BinaryHeap class implementing a min-heap using a list
    public class BinaryHeap<T> where T : IComparable<T>
    {
        private readonly List<T> heap = new(); // Internal list to store heap elements

        // Method to insert a value into the heap and maintain heap property
        public void Insert(T value)
        {
            heap.Add(value); // Add the value to the end of the heap
            HeapifyUp(heap.Count - 1); // Restore heap property by bubbling up
        }
        //------------------------------End of method--------------------------------//

        // Method to extract the minimum value from the heap
        public T ExtractMin()
        {
            if (heap.Count == 0) throw new InvalidOperationException("Heap is empty."); // Handle empty heap case

            T min = heap[0]; // The root element is the minimum value
            heap[0] = heap[^1]; // Replace the root with the last element
            heap.RemoveAt(heap.Count - 1); // Remove the last element

            HeapifyDown(0); // Restore heap property by bubbling down from the root
            return min; // Return the extracted minimum value
        }
        //------------------------------End of method--------------------------------//

        // Method to peek at the minimum value without removing it
        public T Peek()
        {
            if (heap.Count == 0) throw new InvalidOperationException("Heap is empty."); // Handle empty heap case
            return heap[0]; // Return the root element (minimum value)
        }
        //------------------------------End of method--------------------------------//

        // Property to get the number of elements in the heap
        public int Count => heap.Count;
        //------------------------------End of property--------------------------------//

        // Private method to restore heap property by bubbling up
        private void HeapifyUp(int index)
        {
            int parent = (index - 1) / 2; // Get the parent index
            while (index > 0 && heap[index].CompareTo(heap[parent]) < 0)
            {
                // Swap the current element with its parent if it's smaller
                (heap[index], heap[parent]) = (heap[parent], heap[index]);
                index = parent; // Move up to the parent's position
                parent = (index - 1) / 2; // Update the parent index
            }
        }
        //------------------------------End of method--------------------------------//

        // Private method to restore heap property by bubbling down
        private void HeapifyDown(int index)
        {
            int smallest = index; // Assume the smallest value is the current node
            int left = 2 * index + 1; // Left child index
            int right = 2 * index + 2; // Right child index

            // Check if the left child is smaller than the current smallest
            if (left < heap.Count && heap[left].CompareTo(heap[smallest]) < 0)
                smallest = left;

            // Check if the right child is smaller than the current smallest
            if (right < heap.Count && heap[right].CompareTo(heap[smallest]) < 0)
                smallest = right;

            // If the smallest value is not the current index, swap and continue
            if (smallest != index)
            {
                (heap[index], heap[smallest]) = (heap[smallest], heap[index]);
                HeapifyDown(smallest); // Recursively restore heap property
            }
        }
        //------------------------------End of method--------------------------------//
    }
    //-----------------------------End of class-------------------------------------//
}
//----------------------------------End of File-------------------------------------//
