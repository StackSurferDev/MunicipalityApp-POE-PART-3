using System;
using System.Linq;
using System.Windows.Forms;
using MunicipalityApp.Repositories;

namespace MunicipalityApp
{
    public partial class SubmitServiceRequestForm : Form
    {
        public SubmitServiceRequestForm()
        {
            InitializeComponent(); // Initialize form components
        }
        //------------------------------End of constructor--------------------------------//

        // Handle the Submit button click event
        private void BtnSubmit_Click(object sender, EventArgs e)
        {
            string serviceType = cmbServiceType.SelectedItem?.ToString(); // Get the selected service type
            string description = txtDescription.Text; // Get the description from the text box
            DateTime serviceDate = dtpServiceDate.Value; // Get the selected service date
            int priority = (int)numPriority.Value; // Get the priority value
            bool isResolved = chkResolved.Checked; // Get the resolved status

            // Validate Service Type
            if (string.IsNullOrWhiteSpace(serviceType))
            {
                MessageBox.Show("Please select a Service Type.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Stop execution if Service Type is missing
            }

            // Validate Description
            if (string.IsNullOrWhiteSpace(description))
            {
                MessageBox.Show("Please provide a Description for the service request.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Stop execution if Description is missing
            }

            // Prevent Duplicate Requests
            var existingRequest = ServiceRequestRepository.GetServiceRequests()
                .FirstOrDefault(r => r.Description.Equals(description, StringComparison.OrdinalIgnoreCase) &&
                                     r.ServiceType.Equals(serviceType, StringComparison.OrdinalIgnoreCase));
            if (existingRequest != null)
            {
                MessageBox.Show("A service request with the same description and service type already exists.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Stop execution if a duplicate request is found
            }

            // Create and add a new service request
            var newRequest = new ServiceRequest(serviceType, description, serviceDate, priority, isResolved);
            ServiceRequestRepository.AddServiceRequest(newRequest);

            // Show success message
            MessageBox.Show("Service request submitted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Clear form fields for the next input
            ResetFormFields();
        }
        //------------------------------End of method--------------------------------//

        // Reset the form fields to their default values
        private void ResetFormFields()
        {
            cmbServiceType.SelectedIndex = -1; // Reset service type dropdown
            txtDescription.Clear(); // Clear the description text box
            dtpServiceDate.Value = DateTime.Now; // Set the date picker to current date
            numPriority.Value = 1; // Reset priority to default value
            chkResolved.Checked = false; // Uncheck the resolved checkbox
        }
        //------------------------------End of method--------------------------------//

        // Handle the Back button click event
        private void BtnBack_Click(object sender, EventArgs e)
        {
            this.Close(); // Close the current form
        }
        //------------------------------End of method--------------------------------//
    }
    //-----------------------------End of class-------------------------------------//
}
//----------------------------------End of File-------------------------------------//
