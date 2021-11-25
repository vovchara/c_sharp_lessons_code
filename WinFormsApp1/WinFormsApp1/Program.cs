using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
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
            var form = new Form1();
            form.Load += OnLoaded;
            //form.ClientSize = new Size(800, 600); //ця пропертя це сайз без рамки
            Application.Run(form);
        }

        private static void OnLoaded(object sender, EventArgs e)
        {
            var mainController = new MainController(sender as Form1);
            mainController.Run();
        }
    }
}
