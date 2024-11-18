using System;
using System.Windows.Forms;

namespace MunicipalityApp
{
    public partial class PasswordPromptForm : Form
    {
        public string Password { get; private set; } // Store the entered password

        // Constructor to initialize the form components
        public PasswordPromptForm()
        {
            InitializeComponent(); // Initialize the components
        }
        //------------------------------End of constructor--------------------------------//

        // Handle the Submit button click event
        private void BtnSubmit_Click(object sender, EventArgs e)
        {
            Password = txtPassword.Text; // Get the password from the text box
            DialogResult = DialogResult.OK; // Set dialog result as OK
            Close(); // Close the form
        }
        //------------------------------End of method--------------------------------//

        // Handle the Cancel button click event
        private void BtnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel; // Set dialog result as Cancel
            Close(); // Close the form
        }
        //------------------------------End of method--------------------------------//
    }
    //-----------------------------End of class-------------------------------------//
}
//----------------------------------End of File-------------------------------------//
