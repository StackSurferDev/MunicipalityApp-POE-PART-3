using System;
using System.Linq;
using System.Windows.Forms;
using MunicipalityApp.Repositories;

namespace MunicipalityApp
{
    public partial class ServiceRequestsDisplayForm : Form
    {
        public ServiceRequestsDisplayForm()
        {
            InitializeComponent(); // Initialize components
            LoadServiceRequests(); // Load the service requests when the form is opened
        }
        //------------------------------End of constructor--------------------------------//

        // Load and display all service requests in the ListView
        private void LoadServiceRequests()
        {
            lvServiceRequests.Items.Clear(); // Clear existing items
            var serviceRequests = ServiceRequestRepository.GetServiceRequests(); // Get service requests from the repository
            foreach (var request in serviceRequests)
            {
                // Create a list item for each service request
                var listItem = new ListViewItem(new[]
                {
                    request.ServiceDate.ToString("yyyy-MM-dd"), // Display service date
                    request.ServiceType, // Display service type
                    request.Priority.ToString(), // Display priority
                    request.IsResolved ? "Yes" : "No", // Display resolved status
                    $"{request.Progress}%" // Show progress as a percentage
                })
                {
                    Tag = request // Store the service request object in the tag for later use
                };
                lvServiceRequests.Items.Add(listItem); // Add the item to the ListView
            }
        }
        //------------------------------End of method--------------------------------//

        // Handle selection change in the ListView
        private void LvServiceRequests_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvServiceRequests.SelectedItems.Count == 0) return; // If no item is selected, do nothing

            var selectedRequest = lvServiceRequests.SelectedItems[0].Tag as ServiceRequest; // Get the selected service request

            if (selectedRequest != null)
            {
                // Show service request details in a message box
                MessageBox.Show(
                    $"Service Type: {selectedRequest.ServiceType}\n" +
                    $"Description: {selectedRequest.Description}\n" +
                    $"Service Date: {selectedRequest.ServiceDate:yyyy-MM-dd}\n" +
                    $"Priority: {selectedRequest.Priority}\n" +
                    $"Resolved: {selectedRequest.IsResolved}\n" +
                    $"Progress: {selectedRequest.Progress}%",
                    "Service Request Details",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }
        //------------------------------End of method--------------------------------//

        // Handle the button click to update the progress of a selected service request
        private void BtnUpdateProgress_Click(object sender, EventArgs e)
        {
            if (lvServiceRequests.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select a service request to update progress.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // If no request is selected, show an error message
            }

            var selectedRequest = lvServiceRequests.SelectedItems[0].Tag as ServiceRequest;
            if (selectedRequest == null) return;

            // Prompt the user to enter new progress value
            string progressInput = Microsoft.VisualBasic.Interaction.InputBox(
                "Enter new progress (0-100%):",
                "Update Progress",
                selectedRequest.Progress.ToString());

            if (int.TryParse(progressInput, out int newProgress) && newProgress >= 0 && newProgress <= 100)
            {
                try
                {
                    // Update the progress and refresh the service requests
                    ServiceRequestRepository.UpdateProgress(selectedRequest.Id, newProgress);
                    MessageBox.Show("Progress updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadServiceRequests();
                }
                catch (Exception ex)
                {
                    // Handle any errors during the progress update
                    MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Invalid progress value. Please enter a number between 0 and 100.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //------------------------------End of method--------------------------------//

        // Handle the button click to delete a selected service request
        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (lvServiceRequests.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select a service request to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // If no request is selected, show an error message
            }

            var selectedRequest = lvServiceRequests.SelectedItems[0].Tag as ServiceRequest;
            if (selectedRequest != null)
            {
                // Delete the service request and refresh the list
                ServiceRequestRepository.DeleteServiceRequest(selectedRequest);
                MessageBox.Show("Service request deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadServiceRequests();
            }
        }
        //------------------------------End of method--------------------------------//

        // Open the Progress Graph form to view progress in a graphical format
        private void BtnViewGraph_Click(object sender, EventArgs e)
        {
            var graphForm = new ProgressGraphForm();
            graphForm.ShowDialog(); // Show the graph form as a modal dialog
        }
        //------------------------------End of method--------------------------------//

        // Close the form when the back button is clicked
        private void BtnBack_Click(object sender, EventArgs e)
        {
            this.Close(); // Close the form
        }
        //------------------------------End of method--------------------------------//
    }
    //-----------------------------End of class-------------------------------------//
}
//----------------------------------End of File-------------------------------------//
