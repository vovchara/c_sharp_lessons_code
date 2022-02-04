using CSharpLess.Controller;
using CSharpLess.Scene;
using Microsoft.Extensions.DependencyInjection;
using ShopModel.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace CSharpLess
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private ServiceProvider serviceProvider;

        public App()
        {
            ServiceCollection services = new ServiceCollection();
            ConfigureServices(services);
            serviceProvider = services.BuildServiceProvider();
        }

        private void ConfigureServices(ServiceCollection services)
        {
            services.AddSingleton<MainWindow>();
            services.AddSingleton<ISceneManager, SceneManager>();

            services.AddTransient<RootController>();
            services.AddTransient<LoginController>();
            services.AddTransient<HomeController>();
            services.AddTransient<CategoryController>();

            services.AddTransient<IImagesService, ImagesService>();
            services.AddTransient<ICategoriesService, CategoriesService>();
            services.AddTransient<IUserCredentialsService, UserCredentialsService>();

            services.AddSingleton<UserSessionStorage>();
            services.AddSingleton<CategoriesStorage>();

        }

        private void OnStartup(object sender, StartupEventArgs e)
        {
            var mainWindow = serviceProvider.GetService<MainWindow>();
            mainWindow.Show();
        }
    }
}
