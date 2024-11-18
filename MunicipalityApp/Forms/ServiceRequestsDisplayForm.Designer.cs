using System.Windows.Forms;

namespace MunicipalityApp
{
    partial class ServiceRequestsDisplayForm
    {
        private ListView lvServiceRequests;
        private Button btnBack;
        private Button btnDelete;
        private Button btnUpdateProgress;
        private Button btnViewGraph;

        // Initialize components and set up the layout of the form
        private void InitializeComponent()
        {
            this.lvServiceRequests = new ListView();
            this.btnBack = new Button();
            this.btnDelete = new Button();
            this.btnUpdateProgress = new Button();
            this.btnViewGraph = new Button();

            // lvServiceRequests setup
            this.lvServiceRequests.Location = new System.Drawing.Point(20, 20); // Position the ListView
            this.lvServiceRequests.Size = new System.Drawing.Size(500, 200); // Set size for the ListView
            this.lvServiceRequests.View = View.Details; // Set view to show details
            this.lvServiceRequests.FullRowSelect = true; // Select the entire row
            this.lvServiceRequests.MultiSelect = false; // Only allow single item selection
            this.lvServiceRequests.SelectedIndexChanged += LvServiceRequests_SelectedIndexChanged; // Attach event handler for selection change

            // Add columns to the ListView
            this.lvServiceRequests.Columns.Add("Date", 120); // Add Date column
            this.lvServiceRequests.Columns.Add("Service Type", 180); // Add Service Type column
            this.lvServiceRequests.Columns.Add("Priority", 80); // Add Priority column
            this.lvServiceRequests.Columns.Add("Resolved", 100); // Add Resolved column
            this.lvServiceRequests.Columns.Add("Progress (%)", 100); // Add Progress column

            // btnDelete setup
            this.btnDelete.Text = "Delete"; // Set button text
            this.btnDelete.Location = new System.Drawing.Point(20, 230); // Position the button
            this.btnDelete.Size = new System.Drawing.Size(75, 23); // Set size for the button
            this.btnDelete.Click += BtnDelete_Click; // Attach event handler for button click

            // btnUpdateProgress setup
            this.btnUpdateProgress.Text = "Update Progress"; // Set button text
            this.btnUpdateProgress.Location = new System.Drawing.Point(120, 230); // Position the button
            this.btnUpdateProgress.Size = new System.Drawing.Size(100, 23); // Set size for the button
            this.btnUpdateProgress.Click += BtnUpdateProgress_Click; // Attach event handler for button click

            // btnViewGraph setup
            this.btnViewGraph.Text = "View Graph"; // Set button text
            this.btnViewGraph.Location = new System.Drawing.Point(240, 230); // Position the button
            this.btnViewGraph.Size = new System.Drawing.Size(100, 23); // Set size for the button
            this.btnViewGraph.Click += BtnViewGraph_Click; // Attach event handler for button click

            // btnBack setup
            this.btnBack.Text = "Back"; // Set button text
            this.btnBack.Location = new System.Drawing.Point(360, 230); // Position the button
            this.btnBack.Size = new System.Drawing.Size(75, 23); // Set size for the button
            this.btnBack.Click += BtnBack_Click; // Attach event handler for button click

            // ServiceRequestsDisplayForm setup
            this.ClientSize = new System.Drawing.Size(550, 300); // Set form size
            this.Controls.Add(this.lvServiceRequests); // Add ListView to the form
            this.Controls.Add(this.btnDelete); // Add Delete button to the form
            this.Controls.Add(this.btnUpdateProgress); // Add Update Progress button to the form
            this.Controls.Add(this.btnViewGraph); // Add View Graph button to the form
            this.Controls.Add(this.btnBack); // Add Back button to the form
            this.Name = "ServiceRequestsDisplayForm"; // Set form name
            this.Text = "Service Requests Display"; // Set form title
            this.FormBorderStyle = FormBorderStyle.FixedSingle; // Set form border style
            this.MaximizeBox = false; // Disable maximize button
            this.MinimizeBox = false; // Disable minimize button
        }
        //------------------------------End of method--------------------------------//
    }
    //-----------------------------End of class-------------------------------------//
}
//----------------------------------End of File-------------------------------------//
