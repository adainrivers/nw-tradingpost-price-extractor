using System;
using System.Windows.Forms;

namespace TradingPostDataExtractor
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            ItemNameFixer.Initialize();

            Application.Run(new MainForm());
        }

    }
}
