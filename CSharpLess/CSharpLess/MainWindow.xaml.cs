using CSharpLess.Controller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CSharpLess
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly RootController _rootController;
        public MainWindow()
        {
            InitializeComponent();
            Closing += OnMainClosing;
            _rootController = new RootController(this.RootFrame);
            _rootController.Run();
        }

        private void OnMainClosing(object sender, CancelEventArgs e)
        {
            Closing -= OnMainClosing;
            _rootController.Dispose();
        }
    }
}
