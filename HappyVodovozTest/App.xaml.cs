using HappyVodovozTest.Factory;
using HappyVodovozTest.Model;
using HappyVodovozTest.ViewModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace HappyVodovozTest
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static IHost AppHost { get; set; }
        public App()
        {
            AppHost = Host.CreateDefaultBuilder()
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddSingleton<MainWindow>();
                    services.AddScoped<IContext, Context>();
                    services.AddScoped<AddDepartmentViewModel>();
                    services.AddScoped<MainViewModel>();
                    services.AddScoped<AddOrderViewModel>();
                    services.AddScoped<AddPersonViewModel>();
                    services.AddScoped<EditOrderViewModel>();
                    services.AddScoped<EditPersonViewModel>();
                    services.AddScoped<EditDepartmentViewModel>();
                    services.AddScoped<IMainWindowFactory, MainWindowFactory>();
                    services.AddTransient<IAddDepartmentWindow, AddDepartmentWindowFactory>();
                    services.AddTransient<ICloseWindow, CloseWindow>();
                    services.AddTransient<IAddPersonWindowFactory, AddPersonWindowFactory>();
                    services.AddTransient<IAddOrderWindowFactory, AddOrderWindowFactory>();
                    services.AddTransient<IEditDepartmentWindowFactory, EditDepartmentWindowFactory>();
                    services.AddTransient<IEditPersonWindowFactory, EditPersonWindowFactory>();
                    services.AddTransient<IEditOrderWindowFactory, EditOrderWindowFactory>();
                    

                }).Build();
        }

        protected override async void OnStartup(StartupEventArgs e)
        {
            await AppHost!.StartAsync();
            var startUpForm = AppHost.Services.GetRequiredService<MainWindow>();
            startUpForm.Show();
            base.OnStartup(e);
        }

        protected override async void OnExit(ExitEventArgs e)
        {
            await AppHost!.StopAsync();
            base.OnExit(e);
        }
    }
}
