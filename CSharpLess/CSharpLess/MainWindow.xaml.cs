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
        public MainWindow(SceneManager sceneManager, RootController rootController)
        {
            InitializeComponent();

            //var sceneManager = SceneManager.GetInstance();
            sceneManager.SetRoot(RootFrame);

            //var rootController = new RootController();
            rootController.Run();
        }
    }
}
