using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using DEMO.AllUserControl;

namespace DEMO;

public partial class App : Application
{
    public static MainWindow MainWindow;

    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            MainWindow = new MainWindow();
            desktop.MainWindow = MainWindow;

            MainWindow.MainContentControl.Content = new AuthUC();
        }

        base.OnFrameworkInitializationCompleted();
    }
}