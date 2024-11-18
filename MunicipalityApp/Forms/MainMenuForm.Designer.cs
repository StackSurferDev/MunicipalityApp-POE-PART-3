using System.Windows.Forms;

namespace MunicipalityApp
{
    partial class MainMenuForm
    {
        private MenuStrip menuStrip;
        private ToolStripMenuItem reportIssuesMenuItem;
        private ToolStripMenuItem localEventsMenuItem;
        private ToolStripMenuItem serviceRequestMenuItem;
        private ToolStripMenuItem viewServiceRequestsMenuItem;

        // Initialize the form components and set up the menu
        private void InitializeComponent()
        {
            this.menuStrip = new MenuStrip();
            this.reportIssuesMenuItem = new ToolStripMenuItem();
            this.localEventsMenuItem = new ToolStripMenuItem();
            this.serviceRequestMenuItem = new ToolStripMenuItem();
            this.viewServiceRequestsMenuItem = new ToolStripMenuItem();

            // Add menu items to the menu strip
            this.menuStrip.Items.AddRange(new ToolStripItem[] {
                this.reportIssuesMenuItem,
                this.localEventsMenuItem,
                this.serviceRequestMenuItem,
                this.viewServiceRequestsMenuItem });
            this.MainMenuStrip = this.menuStrip; // Set the menu strip as the main menu
            this.Controls.Add(this.menuStrip); // Add the menu strip to the form

            // Set the text for each menu item
            this.reportIssuesMenuItem.Text = "Report Issues";
            this.localEventsMenuItem.Text = "Local Events";
            this.serviceRequestMenuItem.Text = "Submit Service Request";
            this.viewServiceRequestsMenuItem.Text = "View Service Requests";

            // Attach event handlers to each menu item
            this.reportIssuesMenuItem.Click += ReportIssuesMenuItem_Click;
            this.localEventsMenuItem.Click += LocalEventsMenuItem_Click;
            this.serviceRequestMenuItem.Click += ServiceRequestMenuItem_Click;
            this.viewServiceRequestsMenuItem.Click += ViewServiceRequestsMenuItem_Click;

            // Set the size and title of the form
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Text = "Municipality App - Main Menu";
        }
        //------------------------------End of method--------------------------------//
    }
    //-----------------------------End of class-------------------------------------//
}
//----------------------------------End of File-------------------------------------//
