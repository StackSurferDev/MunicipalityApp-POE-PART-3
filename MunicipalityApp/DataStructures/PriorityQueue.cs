using System.Collections.Generic;

namespace MunicipalityApp.DataStructures
{
    // PriorityQueue class implementing a queue where elements are prioritized
    public class PriorityQueue<T> where T : IPrioritizable
    {
        private List<T> data = new List<T>(); // Internal list to store the queue elements

        // Method to add an item to the queue and sort by priority
        public void Enqueue(T item)
        {
            data.Add(item); // Add the item to the queue
            data.Sort((x, y) => x.Priority.CompareTo(y.Priority)); // Sort items by their priority
        }
        //------------------------------End of method--------------------------------//

        // Method to remove and return the item with the highest priority (lowest priority value)
        public T Dequeue()
        {
            if (data.Count > 0)
            {
                var item = data[0]; // Get the item with the highest priority
                data.RemoveAt(0); // Remove the item from the queue
                return item; // Return the item
            }
            return default; // Return default value if the queue is empty
        }
        //------------------------------End of method--------------------------------//

        // Property to get the number of elements in the queue
        public int Count => data.Count;
        //------------------------------End of property--------------------------------//

        // Method to return the highest-priority item without removing it
        public T Peek()
        {
            if (data.Count > 0)
            {
                return data[0]; // Return the highest-priority item without removing it
            }
            return default; // Return default value if the queue is empty
        }
        //------------------------------End of method--------------------------------//
    }
    //-----------------------------End of class-------------------------------------//
}
//----------------------------------End of File-------------------------------------//
