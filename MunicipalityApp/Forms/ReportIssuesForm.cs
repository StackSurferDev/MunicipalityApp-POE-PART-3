using System;
using System.IO;
using System.Windows.Forms;
using MunicipalityApp.Repositories;

namespace MunicipalityApp
{
    public partial class ReportIssuesForm : Form
    {
        private string selectedMediaPath; // Store the selected media file path

        public ReportIssuesForm()
        {
            InitializeComponent(); // Initialize the form components
        }
        //------------------------------End of constructor--------------------------------//

        // Handle the Attach Media button click event
        private void BtnAttachMedia_Click(object sender, EventArgs e)
        {
            using (var openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;"; // Filter for image files
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    selectedMediaPath = openFileDialog.FileName; // Store the selected file path
                    lblMediaAttachment.Text = Path.GetFileName(selectedMediaPath); // Display the file name
                }
            }
        }
        //------------------------------End of method--------------------------------//

        // Handle the Submit button click event
        private void BtnSubmit_Click(object sender, EventArgs e)
        {
            string location = txtLocation.Text; // Get the location from the text box
            string? category = cmbCategory.SelectedItem?.ToString(); // Get the selected category
            string? province = cmbProvince.SelectedItem?.ToString(); // Get the selected province
            string description = txtDescription.Text; // Get the description from the text box

            // Validate required fields
            if (string.IsNullOrWhiteSpace(location) || string.IsNullOrWhiteSpace(category) ||
                string.IsNullOrWhiteSpace(province) || string.IsNullOrWhiteSpace(description))
            {
                MessageBox.Show("Please fill in all required fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Create and save a new LocalEvent
            var newEvent = new LocalEvent(
                "User Reported Issue", // Event name
                location, // Event location
                category, // Event category
                province, // Event province
                description, // Event description
                selectedMediaPath, // Path to attached media
                DateTime.Now, // Current date and time
                1, // Default priority
                true // Mark as reported issue
            );

            EventRepository.AddLocalEvent(newEvent); // Add the new event to the repository
            MessageBox.Show("Issue reported successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Reset the form for a new submission
            txtLocation.Clear();
            cmbCategory.SelectedIndex = -1;
            cmbProvince.SelectedIndex = -1;
            txtDescription.Clear();
            lblMediaAttachment.Text = "No file attached."; // Reset media attachment label
            selectedMediaPath = null; // Clear the selected media path
        }
        //------------------------------End of method--------------------------------//

        // Handle the Back button click event
        private void BtnBack_Click(object sender, EventArgs e)
        {
            this.Close(); // Close the form
        }
        //------------------------------End of method--------------------------------//
    }
    //-----------------------------End of class-------------------------------------//
}
//----------------------------------End of File-------------------------------------//
