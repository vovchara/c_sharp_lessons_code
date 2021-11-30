using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp2
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
            var mainForm = new Form1();
            mainForm.Load += OnLoaded;
            mainForm.FormClosed += OnExit;
            Application.Run(mainForm);
        }

        private static RootController _rootController;

        private static void OnLoaded(object sender, EventArgs e)
        {
            _rootController = new RootController(sender as Form);
            _rootController.Start();
        }

        private static void OnExit(object sender, FormClosedEventArgs e)
        {
            _rootController.Stop();
        }
    }
}
