using System;
using System.Collections.Generic;
using System.IO;
using MunicipalityApp.DataStructures;
using Newtonsoft.Json;

namespace MunicipalityApp.Repositories
{
    // ServiceRequestRepository to manage service requests and persist data to a file
    public static class ServiceRequestRepository
    {
        private static AVLTree<ServiceRequest> serviceRequestsTree = new AVLTree<ServiceRequest>();
        private static Graph<ServiceRequest> progressGraph = new Graph<ServiceRequest>();
        private static readonly string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "serviceRequests.json");

        // Static constructor to load service requests when the repository is first used
        static ServiceRequestRepository()
        {
            LoadServiceRequests(); // Load service requests from the file
        }
        //------------------------------End of constructor--------------------------------//

        // Add a new service request
        public static void AddServiceRequest(ServiceRequest newRequest)
        {
            serviceRequestsTree.Insert(newRequest); // Add the request to the AVL Tree
            progressGraph.AddNode(newRequest); // Add the request to the progress graph
            SaveServiceRequests(); // Save to the file
        }
        //------------------------------End of method--------------------------------//

        // Get all service requests in sorted order
        public static List<ServiceRequest> GetServiceRequests()
        {
            var requestsList = new List<ServiceRequest>();
            serviceRequestsTree.TraverseInOrder(requestsList.Add); // Get sorted requests
            return requestsList;
        }
        //------------------------------End of method--------------------------------//

        // Get a service request by its unique ID
        public static ServiceRequest? GetServiceRequestById(Guid id)
        {
            return GetServiceRequests().Find(request => request.Id == id); // Find request by ID
        }
        //------------------------------End of method--------------------------------//

        // Update the progress of a service request (password protected)
        public static void UpdateProgress(Guid requestId, int newProgress)
        {
            var passwordPrompt = new PasswordPromptForm();
            if (passwordPrompt.ShowDialog() == DialogResult.OK && passwordPrompt.Password == "Password1")
            {
                var request = GetServiceRequestById(requestId);
                if (request == null)
                    throw new InvalidOperationException("Service request not found.");

                if (newProgress < 0 || newProgress > 100)
                    throw new ArgumentOutOfRangeException(nameof(newProgress), "Progress must be between 0 and 100.");

                request.Progress = newProgress; // Update progress
                SaveServiceRequests(); // Save the updated requests
            }
            else
            {
                // Invalid password, show an error message and stop the operation
                MessageBox.Show("Invalid password. Operation canceled.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        //------------------------------End of method--------------------------------//

        // Save all service requests to the JSON file
        private static void SaveServiceRequests()
        {
            var requestsList = GetServiceRequests(); // Get all service requests
            var json = JsonConvert.SerializeObject(requestsList, Formatting.Indented); // Convert to JSON
            File.WriteAllText(filePath, json); // Write to the file
        }
        //------------------------------End of method--------------------------------//

        // Load service requests from the JSON file into the repository
        private static void LoadServiceRequests()
        {
            if (File.Exists(filePath)) // Check if the file exists
            {
                var json = File.ReadAllText(filePath); // Read file content
                var requestsList = JsonConvert.DeserializeObject<List<ServiceRequest>>(json) ?? new List<ServiceRequest>();
                foreach (var request in requestsList)
                {
                    serviceRequestsTree.Insert(request); // Rebuild the AVL tree
                    progressGraph.AddNode(request); // Add each request to the progress graph
                }
            }
        }
        //------------------------------End of method--------------------------------//

        // Delete a service request (password protected)
        public static void DeleteServiceRequest(ServiceRequest selectedRequest)
        {
            var passwordPrompt = new PasswordPromptForm();
            if (passwordPrompt.ShowDialog() == DialogResult.OK && passwordPrompt.Password == "Password1")
            {
                var requestsList = GetServiceRequests();
                if (requestsList.Remove(selectedRequest)) // Remove the request from the list
                {
                    // Rebuild the AVL tree and progress graph after deletion
                    serviceRequestsTree = new AVLTree<ServiceRequest>();
                    foreach (var request in requestsList)
                    {
                        serviceRequestsTree.Insert(request);
                    }

                    progressGraph = new Graph<ServiceRequest>();
                    foreach (var request in requestsList)
                    {
                        progressGraph.AddNode(request);
                    }

                    // Save the updated list to the file
                    SaveServiceRequests();
                    MessageBox.Show("Service request successfully deleted.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    throw new InvalidOperationException("Service request not found.");
                }
            }
            else
            {
                // Invalid password, show an error message and stop the operation
                MessageBox.Show("Invalid password. Operation canceled.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        //------------------------------End of method--------------------------------//
    }
    //-----------------------------End of class-------------------------------------//
}
//----------------------------------End of File-------------------------------------//
