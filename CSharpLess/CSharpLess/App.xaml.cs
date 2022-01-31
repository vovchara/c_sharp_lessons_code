using CSharpLess.Controller;
using CSharpLess.Scene;
using Microsoft.Extensions.DependencyInjection;
using ShopModel.Model;
using System.Windows;

namespace CSharpLess
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly ServiceProvider _serviceProvider;

        public App()
        {
            ServiceCollection services = new ServiceCollection();
            ConfigureServices(services);
            _serviceProvider = services.BuildServiceProvider();
        }

        private void ConfigureServices(ServiceCollection services)
        {
            services.AddSingleton<MainWindow>();
            services.AddSingleton<SceneManager>();

            services.AddTransient<ControllerFactory>();

            services.AddTransient<RootController>();
            services.AddTransient<LoginController>();
            services.AddTransient<HomeController>();

            services.AddTransient<IImagesService, ImagesService>();
            services.AddTransient<IUserCredentialsService, UserCredentialsService>();
        }

        private void OnStartup(object sender, StartupEventArgs e)
        {
            var mainWindow = _serviceProvider.GetService<MainWindow>();
            mainWindow.Show();
        }
    }
}
