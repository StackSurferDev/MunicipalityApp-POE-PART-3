using System;
using System.Windows.Forms;

namespace MunicipalityApp
{
    // Program class to start the application and run the main menu form
    static class Program
    {
        // Main entry point for the application
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles(); // Enable visual styles for the application
            Application.SetCompatibleTextRenderingDefault(false); // Set default rendering for text
            Application.Run(new MainMenuForm()); // Run the main menu form
        }
        //------------------------------End of method--------------------------------//
    }
    //-----------------------------End of class-------------------------------------//
}
//----------------------------------End of File-------------------------------------//
