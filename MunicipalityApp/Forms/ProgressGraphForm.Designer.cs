using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace MunicipalityApp
{
    partial class ProgressGraphForm
    {
        private Chart progressChart;
        private Button btnClose;

        // Initialize the form components and set up the layout
        private void InitializeComponent()
        {
            this.progressChart = new Chart();
            this.btnClose = new Button();

            // progressChart setup
            this.progressChart.Location = new System.Drawing.Point(10, 10); // Position the chart
            this.progressChart.Size = new System.Drawing.Size(600, 400); // Set chart size
            this.progressChart.TabIndex = 0; // Set tab index for chart

            // btnClose setup
            this.btnClose.Text = "Close"; // Set button text
            this.btnClose.Location = new System.Drawing.Point(270, 420); // Position the close button
            this.btnClose.Size = new System.Drawing.Size(100, 30); // Set button size
            this.btnClose.Click += BtnClose_Click; // Attach event handler for button click

            // ProgressGraphForm setup
            this.ClientSize = new System.Drawing.Size(620, 470); // Set form size
            this.Controls.Add(this.progressChart); // Add chart to the form
            this.Controls.Add(this.btnClose); // Add close button to the form
            this.FormBorderStyle = FormBorderStyle.FixedSingle; // Set form border style
            this.MaximizeBox = false; // Disable maximize button
            this.MinimizeBox = false; // Disable minimize button
            this.StartPosition = FormStartPosition.CenterParent; // Center the form
            this.Text = "Progress Graph"; // Set form title
        }
        //------------------------------End of method--------------------------------//

        // Handle close button click event
        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close(); // Close the form
        }
        //------------------------------End of method--------------------------------//
    }
    //-----------------------------End of class-------------------------------------//
}
//----------------------------------End of File-------------------------------------//
