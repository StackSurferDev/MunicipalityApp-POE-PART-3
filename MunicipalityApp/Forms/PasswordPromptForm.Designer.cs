using System.Windows.Forms;

namespace MunicipalityApp
{
    partial class PasswordPromptForm
    {
        private TextBox txtPassword;
        private Button btnSubmit;
        private Button btnCancel;

        // Initialize components and set up the layout of the form
        private void InitializeComponent()
        {
            this.txtPassword = new TextBox();
            this.btnSubmit = new Button();
            this.btnCancel = new Button();

            // 
            // txtPassword setup
            // 
            this.txtPassword.Location = new System.Drawing.Point(20, 20); // Position the text box
            this.txtPassword.Size = new System.Drawing.Size(200, 22); // Set the size of the text box
            this.txtPassword.PasswordChar = '*'; // Mask the text for password input

            // 
            // btnSubmit setup
            // 
            this.btnSubmit.Text = "Submit"; // Set the button text
            this.btnSubmit.Location = new System.Drawing.Point(20, 60); // Position the submit button
            this.btnSubmit.Click += BtnSubmit_Click; // Attach event handler for submit button click

            // 
            // btnCancel setup
            // 
            this.btnCancel.Text = "Cancel"; // Set the button text
            this.btnCancel.Location = new System.Drawing.Point(120, 60); // Position the cancel button
            this.btnCancel.Click += BtnCancel_Click; // Attach event handler for cancel button click

            // 
            // PasswordPromptForm setup
            // 
            this.ClientSize = new System.Drawing.Size(250, 100); // Set the form size
            this.Controls.Add(this.txtPassword); // Add the password text box to the form
            this.Controls.Add(this.btnSubmit); // Add the submit button to the form
            this.Controls.Add(this.btnCancel); // Add the cancel button to the form
            this.Text = "Enter Password"; // Set the form's title
        }
        //------------------------------End of method--------------------------------//
    }
    //-----------------------------End of class-------------------------------------//
}
//----------------------------------End of File-------------------------------------//
