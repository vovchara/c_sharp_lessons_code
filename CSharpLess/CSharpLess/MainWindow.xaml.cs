using CSharpLess.Controller;
using CSharpLess.Scene;
using System.Windows;

namespace CSharpLess
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow(ISceneManager sceneManager, RootController rootController)
        {
            InitializeComponent();

            sceneManager.SetRoot(RootFrame);

            rootController.Run();
        }
    }
}
