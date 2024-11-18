using System.Windows.Forms;

namespace MunicipalityApp
{
    partial class LocalEventsForm
    {
        private ListBox lstEvents;
        private Button btnBack;

        // Initialize form components and set up layout
        private void InitializeComponent()
        {
            this.lstEvents = new ListBox();
            this.btnBack = new Button();

            // lstEvents setup
            this.lstEvents.Location = new System.Drawing.Point(20, 20); // Position the list box
            this.lstEvents.Size = new System.Drawing.Size(360, 200); // Set size of the list box
            this.lstEvents.Name = "lstEvents"; // Set the name of the list box
            this.lstEvents.SelectedIndexChanged += new System.EventHandler(this.LstEvents_SelectedIndexChanged); // Handle item selection

            // btnBack setup
            this.btnBack.Text = "Back"; // Set the button text
            this.btnBack.Location = new System.Drawing.Point(20, 250); // Position the button
            this.btnBack.Size = new System.Drawing.Size(75, 23); // Set button size
            this.btnBack.Name = "btnBack"; // Set the name of the button
            this.btnBack.Click += new System.EventHandler(this.BtnBack_Click); // Handle button click

            // LocalEventsForm setup
            this.ClientSize = new System.Drawing.Size(400, 300); // Set form size
            this.Controls.Add(this.lstEvents); // Add the list box to the form
            this.Controls.Add(this.btnBack); // Add the back button to the form
            this.Name = "LocalEventsForm"; // Set form name
            this.Text = "Local Events"; // Set form title
            this.FormBorderStyle = FormBorderStyle.FixedSingle; // Set form border style
            this.MaximizeBox = false; // Disable maximize button
            this.MinimizeBox = false; // Disable minimize button
            this.ControlBox = true; // Allow closing the form with the [X] button
        }
        //------------------------------End of method--------------------------------//
    }
    //-----------------------------End of class-------------------------------------//
}
//----------------------------------End of File-------------------------------------//
