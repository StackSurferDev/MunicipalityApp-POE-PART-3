using System;
using System.Windows.Forms;
using MunicipalityApp.DataStructures;
using MunicipalityApp.Repositories;

namespace MunicipalityApp
{
    public partial class LocalEventsForm : Form
    {
        private PriorityQueue<LocalEvent> eventQueue;
        private LocalEvent[] eventsArray;

        // Constructor to initialize the form and load events
        public LocalEventsForm()
        {
            InitializeComponent();
            eventQueue = new PriorityQueue<LocalEvent>(); // Initialize event queue
            LoadEvents(); // Load events into the form
        }
        //------------------------------End of constructor--------------------------------//

        // Load events from the repository and display them in the list box
        private void LoadEvents()
        {
            lstEvents.Items.Clear(); // Clear existing items to prevent duplication
            var events = EventRepository.GetLocalEvents();
            eventsArray = new LocalEvent[events.Count];

            // Add each event to the priority queue and list box
            for (int i = 0; i < events.Count; i++)
            {
                var ev = events[i];
                eventsArray[i] = ev;
                eventQueue.Enqueue(ev); // Add event to the queue
                lstEvents.Items.Add($"{ev.Date.ToShortDateString()} - {ev.Name} ({ev.Category})"); // Display event in the list box
            }
        }
        //------------------------------End of method--------------------------------//

        // Handle the event when an item is selected in the list
        private void LstEvents_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstEvents.SelectedIndex == -1) return; // If no item is selected, return

            // Retrieve the selected event from the array
            var selectedEvent = eventsArray[lstEvents.SelectedIndex];

            // Open a new form to display event details
            using (var eventDetailsForm = new EventDetailsForm(selectedEvent)) // Ensure proper disposal
            {
                eventDetailsForm.ShowDialog(); // Show event details form as a modal
            }
        }
        //------------------------------End of method--------------------------------//

        // Close the current form when the back button is clicked
        private void BtnBack_Click(object sender, EventArgs e)
        {
            this.Close(); // Close the form
        }
        //------------------------------End of method--------------------------------//
    }
    //-----------------------------End of class-------------------------------------//
}
//----------------------------------End of File-------------------------------------//
