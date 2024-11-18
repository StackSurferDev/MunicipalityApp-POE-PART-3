using System;
using System.Windows.Forms;

namespace MunicipalityApp
{
    public partial class MainMenuForm : Form
    {
        public MainMenuForm()
        {
            IsMdiContainer = true; // Set this form as the MDI parent
            InitializeComponent(); // Initialize components
        }
        //------------------------------End of constructor--------------------------------//

        // Open the Report Issues form when the menu item is clicked
        private void ReportIssuesMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new ReportIssuesForm()); // Open the Report Issues form
        }
        //------------------------------End of method--------------------------------//

        // Open the Local Events form when the menu item is clicked
        private void LocalEventsMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new LocalEventsForm()); // Open the Local Events form
        }
        //------------------------------End of method--------------------------------//

        // Open the Submit Service Request form when the menu item is clicked
        private void ServiceRequestMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new SubmitServiceRequestForm()); // Open the Submit Service Request form
        }
        //------------------------------End of method--------------------------------//

        // Open the Service Requests Display form when the menu item is clicked
        private void ViewServiceRequestsMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new ServiceRequestsDisplayForm()); // Open the Service Requests Display form
        }
        //------------------------------End of method--------------------------------//

        // Open a child form and close any existing ones
        private void OpenChildForm(Form childForm)
        {
            // Close all other child forms before opening the new one
            foreach (Form form in MdiChildren)
            {
                form.Close(); // Close each open child form
            }
            // Set the new form as a child form
            childForm.MdiParent = this;
            childForm.WindowState = FormWindowState.Maximized; // Maximize for better user experience
            childForm.Show(); // Show the child form
        }
        //------------------------------End of method--------------------------------//
    }
    //-----------------------------End of class-------------------------------------//
}
//----------------------------------End of File-------------------------------------//
