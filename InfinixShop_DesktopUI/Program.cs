using System;
using System.Windows.Forms;

namespace InfinixShop_Desktop
{
    internal static class Program
    {
        /// The main entry point for the application.
        [STAThread]
        static void Main()
        {
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new frmMain());
        }
    }
}
