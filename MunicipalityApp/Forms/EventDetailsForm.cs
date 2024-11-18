using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace MunicipalityApp
{
    public partial class EventDetailsForm : Form
    {
        private LocalEvent _event;

        // Constructor to initialize the form with event details
        public EventDetailsForm(LocalEvent eventDetails)
        {
            InitializeComponent();
            _event = eventDetails; // Store event details
            DisplayEventDetails(); // Display the details on the form
        }
        //------------------------------End of constructor--------------------------------//

        // Method to display the event details on the form
        private void DisplayEventDetails()
        {
            lblEventDetails.Text = $"Location: {_event.Location}\n" +
                                   $"Category: {_event.Category}\n" +
                                   $"Province: {_event.Province}\n" +
                                   $"Description: {_event.Description}\n" +
                                   $"Date: {_event.Date.ToShortDateString()}";

            // Display media if available
            if (!string.IsNullOrEmpty(_event.MediaPath) && File.Exists(_event.MediaPath))
            {
                try
                {
                    // Load and display the media (image)
                    using (var imageStream = new FileStream(_event.MediaPath, FileMode.Open, FileAccess.Read))
                    {
                        var image = Image.FromStream(imageStream);
                        pictureBoxEvent.Image = new Bitmap(image);
                        pictureBoxEvent.SizeMode = PictureBoxSizeMode.Zoom;
                    }
                }
                catch (Exception ex)
                {
                    // Show error if media cannot be loaded
                    MessageBox.Show($"Error loading media: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                lblEventDetails.Text += "\n\nNo media available."; // Notify if no media is available
            }
        }
        //------------------------------End of method--------------------------------//

        // Close the form when the close button is clicked
        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close(); // Close the form
        }
        //------------------------------End of method--------------------------------//
    }
    //-----------------------------End of class-------------------------------------//
}
//----------------------------------End of File-------------------------------------//
