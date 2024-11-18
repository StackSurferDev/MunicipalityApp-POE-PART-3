using System.Windows.Forms;

namespace MunicipalityApp
{
    partial class EventDetailsForm
    {
        private Label lblEventDetails;
        private PictureBox pictureBoxEvent;
        private Button btnClose;

        // Initialize the form components and set up the layout
        private void InitializeComponent()
        {
            this.lblEventDetails = new Label();
            this.pictureBoxEvent = new PictureBox();
            this.btnClose = new Button();

            // lblEventDetails setup
            this.lblEventDetails.Location = new System.Drawing.Point(20, 20); // Position the label
            this.lblEventDetails.Size = new System.Drawing.Size(300, 150); // Set the size of the label

            // pictureBoxEvent setup
            this.pictureBoxEvent.Location = new System.Drawing.Point(20, 180); // Position the picture box
            this.pictureBoxEvent.Size = new System.Drawing.Size(300, 150); // Set the size of the picture box

            // btnClose setup
            this.btnClose.Text = "Close"; // Set the button text
            this.btnClose.Location = new System.Drawing.Point(120, 350); // Position the close button
            this.btnClose.Click += BtnClose_Click; // Attach event handler for button click

            // EventDetailsForm setup
            this.ClientSize = new System.Drawing.Size(360, 400); // Set the form size
            this.Controls.Add(this.lblEventDetails); // Add the label to the form
            this.Controls.Add(this.pictureBoxEvent); // Add the picture box to the form
            this.Controls.Add(this.btnClose); // Add the close button to the form
            this.Name = "EventDetailsForm"; // Set the form's name
            this.Text = "Event Details"; // Set the form's title
            this.FormBorderStyle = FormBorderStyle.FixedSingle; // Set the form's border style
            this.MaximizeBox = false; // Disable maximize button
            this.MinimizeBox = false; // Disable minimize button
        }
        //------------------------------End of method--------------------------------//
    }
    //-----------------------------End of class-------------------------------------//
}
//----------------------------------End of File-------------------------------------//
