using System.Windows.Forms;

namespace MunicipalityApp
{
    partial class SubmitServiceRequestForm
    {
        private Label lblServiceType;
        private ComboBox cmbServiceType;
        private Label lblDescription;
        private TextBox txtDescription;
        private Label lblServiceDate;
        private DateTimePicker dtpServiceDate;
        private Label lblPriority;
        private NumericUpDown numPriority;
        private CheckBox chkResolved;
        private Button btnSubmit;
        private Button btnBack;

        // Initialize components and set up the layout of the form
        private void InitializeComponent()
        {
            this.lblServiceType = new Label();
            this.cmbServiceType = new ComboBox();
            this.lblDescription = new Label();
            this.txtDescription = new TextBox();
            this.lblServiceDate = new Label();
            this.dtpServiceDate = new DateTimePicker();
            this.lblPriority = new Label();
            this.numPriority = new NumericUpDown();
            this.chkResolved = new CheckBox();
            this.btnSubmit = new Button();
            this.btnBack = new Button();

            // lblServiceType setup
            this.lblServiceType.Text = "Service Type:"; // Set label text
            this.lblServiceType.Location = new System.Drawing.Point(20, 20); // Position the label

            // cmbServiceType setup
            this.cmbServiceType.Location = new System.Drawing.Point(120, 20); // Position the combo box
            this.cmbServiceType.Size = new System.Drawing.Size(200, 22); // Set size for the combo box
            this.cmbServiceType.Items.AddRange(new object[] { "Road Maintenance", "Sanitation", "Electrical", "Plumbing" }); // Add items to the combo box

            // lblDescription setup
            this.lblDescription.Text = "Description:"; // Set label text
            this.lblDescription.Location = new System.Drawing.Point(20, 60); // Position the label

            // txtDescription setup
            this.txtDescription.Location = new System.Drawing.Point(120, 60); // Position the text box
            this.txtDescription.Size = new System.Drawing.Size(200, 100); // Set size for the text box
            this.txtDescription.Multiline = true; // Allow multi-line input

            // lblServiceDate setup
            this.lblServiceDate.Text = "Service Date:"; // Set label text
            this.lblServiceDate.Location = new System.Drawing.Point(20, 180); // Position the label

            // dtpServiceDate setup
            this.dtpServiceDate.Location = new System.Drawing.Point(120, 180); // Position the date picker
            this.dtpServiceDate.Size = new System.Drawing.Size(200, 22); // Set size for the date picker

            // lblPriority setup
            this.lblPriority.Text = "Priority (1-5):"; // Set label text
            this.lblPriority.Location = new System.Drawing.Point(20, 220); // Position the label

            // numPriority setup
            this.numPriority.Location = new System.Drawing.Point(120, 220); // Position the numeric up-down control
            this.numPriority.Minimum = 1; // Set minimum value
            this.numPriority.Maximum = 5; // Set maximum value

            // chkResolved setup
            this.chkResolved.Text = "Is Resolved?"; // Set checkbox text
            this.chkResolved.Location = new System.Drawing.Point(20, 260); // Position the checkbox

            // btnSubmit setup
            this.btnSubmit.Text = "Submit"; // Set button text
            this.btnSubmit.Location = new System.Drawing.Point(20, 300); // Position the button
            this.btnSubmit.Click += BtnSubmit_Click; // Attach event handler for button click

            // btnBack setup
            this.btnBack.Text = "Back"; // Set button text
            this.btnBack.Location = new System.Drawing.Point(120, 300); // Position the button
            this.btnBack.Click += BtnBack_Click; // Attach event handler for button click

            // SubmitServiceRequestForm setup
            this.ClientSize = new System.Drawing.Size(400, 350); // Set form size
            this.Controls.AddRange(new Control[] {
                lblServiceType, cmbServiceType, lblDescription, txtDescription, lblServiceDate, dtpServiceDate,
                lblPriority, numPriority, chkResolved, btnSubmit, btnBack }); // Add all controls to the form
            this.Text = "Submit Service Request"; // Set form title
            this.FormBorderStyle = FormBorderStyle.FixedSingle; // Set form border style
            this.MaximizeBox = false; // Disable maximize button
            this.MinimizeBox = false; // Disable minimize button
        }
        //------------------------------End of method--------------------------------//
    }
    //-----------------------------End of class-------------------------------------//
}
//----------------------------------End of File-------------------------------------//
