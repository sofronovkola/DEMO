using Avalonia.Controls;
using System.Runtime.CompilerServices;
using System.Security.AccessControl;
using Microsoft.VisualBasic;
using DEMO.AllUserControl;
namespace DEMO;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        App.MainWindow = this;
        App.MainWindow.MainContentControl.Content = new AuthUC();
    }
}