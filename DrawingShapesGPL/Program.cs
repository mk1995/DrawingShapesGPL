using System;
using System.Windows.Forms;

namespace DrawingShapesGPL
{
    /// <summary>Main entry class of the application.</summary>
    static class Program
    {
        /// <summary>The main entry point for the application.</summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Main());
        }
    }
}
