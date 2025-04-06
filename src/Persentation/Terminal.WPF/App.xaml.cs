using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Configuration;
using System.Data;
using System.IO;
using System.Windows;
using Terminal.Infarstructure;

namespace Terminal.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static IHost AppHost { get; private set; }

        public App()
        {
            AppHost = Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) =>
                {
                    string dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Terminal.db");
                    string connectionString = $"Data Source={dbPath}";

                    services.AddDbContext<TerminalDbContext>(options =>
                    {
                        options.UseSqlite(connectionString);
                    });

                    
                }).Build();
        }

        protected override async void OnStartup(StartupEventArgs e)
        {
            await AppHost.StartAsync();
            base.OnStartup(e);
        }

        protected override async void OnExit(ExitEventArgs e)
        {
            await AppHost.StopAsync();
            base.OnExit(e);
        }
    }

}
