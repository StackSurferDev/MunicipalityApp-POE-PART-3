using System;
using System.Collections.Generic;
using System.IO;
using MunicipalityApp.DataStructures;
using Newtonsoft.Json;

namespace MunicipalityApp.Repositories
{
    // EventRepository to manage LocalEvent objects in an AVL Tree and save/load from a file
    public static class EventRepository
    {
        // AVL Tree to store LocalEvent objects
        private static AVLTree<LocalEvent> localEventsTree = new AVLTree<LocalEvent>();

        // File path for saving and loading events
        private static readonly string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "events.json");

        // Static constructor to load events when the repository is first used
        static EventRepository()
        {
            LoadEvents(); // Load events from file
        }
        //------------------------------End of constructor--------------------------------//

        // Adds a new LocalEvent and saves it to the file
        public static void AddLocalEvent(LocalEvent newEvent)
        {
            localEventsTree.Insert(newEvent); // Add event to the tree
            SaveEvents(); // Save to file
        }
        //------------------------------End of method--------------------------------//

        // Retrieves all LocalEvents in sorted order
        public static List<LocalEvent> GetLocalEvents()
        {
            var eventsList = new List<LocalEvent>();
            localEventsTree.TraverseInOrder(eventsList.Add); // Get events in order
            return eventsList;
        }
        //------------------------------End of method--------------------------------//

        // Saves all events to the file
        private static void SaveEvents()
        {
            var eventsList = GetLocalEvents(); // Get all events
            var json = JsonConvert.SerializeObject(eventsList, Formatting.Indented); // Convert to JSON
            File.WriteAllText(filePath, json); // Write to file
        }
        //------------------------------End of method--------------------------------//

        // Loads events from the file into the AVL Tree
        private static void LoadEvents()
        {
            if (File.Exists(filePath)) // Check if the file exists
            {
                var json = File.ReadAllText(filePath); // Read the file
                var eventsList = JsonConvert.DeserializeObject<List<LocalEvent>>(json) ?? new List<LocalEvent>();
                foreach (var ev in eventsList)
                {
                    localEventsTree.Insert(ev); // Add each event to the tree
                }
            }
        }
        //------------------------------End of method--------------------------------//
    }
    //-----------------------------End of class-------------------------------------//
}
//----------------------------------End of File-------------------------------------//
