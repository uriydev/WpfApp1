using System.IO;
using System.Windows;
using System.Windows.Threading;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Wpf.Ui;
using WpfApp1.Services;
using WpfApp1.Views;

namespace WpfApp1;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App
{
    private static readonly IHost _host = Host.CreateDefaultBuilder()
        .ConfigureAppConfiguration(c =>
        {
            var basePath =
                Path.GetDirectoryName(AppContext.BaseDirectory)
                ?? throw new DirectoryNotFoundException(
                    "Unable to find the base directory of the application."
                );
            _ = c.SetBasePath(basePath);
        })
        .ConfigureServices(
            (context, services) =>
            {
                // App Host
                _ = services.AddHostedService<ApplicationHostService>();

                // Page resolver service
                _ = services.AddSingleton<IPageService, PageService>();

                // Theme manipulation
                _ = services.AddSingleton<IThemeService, ThemeService>();

                // TaskBar manipulation
                _ = services.AddSingleton<ITaskBarService, TaskBarService>();

                // Service containing navigation, same as INavigationWindow... but without window
                _ = services.AddSingleton<INavigationService, NavigationService>();

                // Main window with navigation
                _ = services.AddSingleton<INavigationWindow, MainWindow>();
                _ = services.AddSingleton<ViewModels.MainWindowViewModel>();

                // Views and ViewModels
                _ = services.AddSingleton<Views.Pages.DashboardPage>();
                _ = services.AddSingleton<ViewModels.DashboardViewModel>();
                _ = services.AddSingleton<Views.Pages.DataPage>();
                _ = services.AddSingleton<ViewModels.DataViewModel>();
                _ = services.AddSingleton<Views.Pages.SettingsPage>();
                _ = services.AddSingleton<ViewModels.SettingsViewModel>();
            }
        )
        .Build();

    /// <summary>
    /// Gets registered service.
    /// </summary>
    /// <typeparam name="T">Type of the service to get.</typeparam>
    /// <returns>Instance of the service or <see langword="null"/>.</returns>
    public static T? GetService<T>()
        where T : class
    {
        return _host.Services.GetService(typeof(T)) as T;
    }

    /// <summary>
    /// Occurs when the application is loading.
    /// </summary>
    private async void OnStartup(object sender, StartupEventArgs e)
    {
        await _host.StartAsync();
    }

    /// <summary>
    /// Occurs when the application is closing.
    /// </summary>
    private async void OnExit(object sender, ExitEventArgs e)
    {
        await _host.StopAsync();

        _host.Dispose();
    }

    /// <summary>
    /// Occurs when an exception is thrown by an application but not handled.
    /// </summary>
    private void OnDispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
    {
        // For more info see https://docs.microsoft.com/en-us/dotnet/api/system.windows.application.dispatcherunhandledexception?view=windowsdesktop-6.0
    }
}