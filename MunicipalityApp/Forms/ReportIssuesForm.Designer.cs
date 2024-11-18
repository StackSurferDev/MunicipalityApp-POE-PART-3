using System.Windows.Forms;

namespace MunicipalityApp
{
    partial class ReportIssuesForm
    {
        private Label lblLocation;
        private TextBox txtLocation;
        private Label lblCategory;
        private ComboBox cmbCategory;
        private Label lblProvince;
        private ComboBox cmbProvince;
        private Label lblDescription;
        private TextBox txtDescription;
        private Button btnAttachMedia;
        private Label lblMediaAttachment;
        private Button btnSubmit;
        private Button btnBack;

        // Initialize components and set up the layout of the form
        private void InitializeComponent()
        {
            this.lblLocation = new Label();
            this.txtLocation = new TextBox();
            this.lblCategory = new Label();
            this.cmbCategory = new ComboBox();
            this.lblProvince = new Label();
            this.cmbProvince = new ComboBox();
            this.lblDescription = new Label();
            this.txtDescription = new TextBox();
            this.btnAttachMedia = new Button();
            this.lblMediaAttachment = new Label();
            this.btnSubmit = new Button();
            this.btnBack = new Button();

            // lblLocation setup
            this.lblLocation.Text = "Location:"; // Set label text
            this.lblLocation.Location = new System.Drawing.Point(20, 20); // Position the label

            // txtLocation setup
            this.txtLocation.Location = new System.Drawing.Point(120, 20); // Position the text box
            this.txtLocation.Size = new System.Drawing.Size(200, 22); // Set size for the text box

            // lblCategory setup
            this.lblCategory.Text = "Category:"; // Set label text
            this.lblCategory.Location = new System.Drawing.Point(20, 60); // Position the label

            // cmbCategory setup
            this.cmbCategory.Location = new System.Drawing.Point(120, 60); // Position the combo box
            this.cmbCategory.Size = new System.Drawing.Size(200, 22); // Set size for the combo box
            this.cmbCategory.Items.AddRange(new object[] { "Roads", "Sanitation", "Utilities" }); // Add items to the combo box

            // lblProvince setup
            this.lblProvince.Text = "Province:"; // Set label text
            this.lblProvince.Location = new System.Drawing.Point(20, 100); // Position the label

            // cmbProvince setup
            this.cmbProvince.Location = new System.Drawing.Point(120, 100); // Position the combo box
            this.cmbProvince.Size = new System.Drawing.Size(200, 22); // Set size for the combo box
            this.cmbProvince.Items.AddRange(new object[] { "Western Cape", "Eastern Cape", "Gauteng", "KwaZulu-Natal" }); // Add items to the combo box

            // lblDescription setup
            this.lblDescription.Text = "Description:"; // Set label text
            this.lblDescription.Location = new System.Drawing.Point(20, 140); // Position the label

            // txtDescription setup
            this.txtDescription.Location = new System.Drawing.Point(120, 140); // Position the text box
            this.txtDescription.Size = new System.Drawing.Size(200, 100); // Set size for the text box
            this.txtDescription.Multiline = true; // Allow multi-line text input

            // btnAttachMedia setup
            this.btnAttachMedia.Text = "Attach Media"; // Set button text
            this.btnAttachMedia.Location = new System.Drawing.Point(20, 260); // Position the button
            this.btnAttachMedia.Click += BtnAttachMedia_Click; // Attach event handler for button click

            // lblMediaAttachment setup
            this.lblMediaAttachment.Text = "No file attached."; // Set label text
            this.lblMediaAttachment.Location = new System.Drawing.Point(20, 290); // Position the label

            // btnSubmit setup
            this.btnSubmit.Text = "Submit"; // Set button text
            this.btnSubmit.Location = new System.Drawing.Point(20, 320); // Position the button
            this.btnSubmit.Click += BtnSubmit_Click; // Attach event handler for button click

            // btnBack setup
            this.btnBack.Text = "Back"; // Set button text
            this.btnBack.Location = new System.Drawing.Point(120, 320); // Position the button
            this.btnBack.Click += BtnBack_Click; // Attach event handler for button click

            // ReportIssuesForm setup
            this.ClientSize = new System.Drawing.Size(400, 400); // Set form size
            this.Controls.AddRange(new Control[] {
                lblLocation, txtLocation, lblCategory, cmbCategory, lblProvince, cmbProvince,
                lblDescription, txtDescription, btnAttachMedia, lblMediaAttachment, btnSubmit, btnBack }); // Add all controls to the form
            this.Text = "Report Issues"; // Set form title
            this.FormBorderStyle = FormBorderStyle.FixedSingle; // Set form border style
            this.MaximizeBox = false; // Disable maximize button
            this.MinimizeBox = false; // Disable minimize button
            this.ControlBox = false; // Disable control box (no close button)
        }
        //------------------------------End of method--------------------------------//
    }
    //-----------------------------End of class-------------------------------------//
}
//----------------------------------End of File-------------------------------------//
