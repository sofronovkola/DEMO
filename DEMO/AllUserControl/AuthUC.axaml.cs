using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Interactivity;
using System.Linq;
using DEMO.Entities;
using DEMO.Models;

namespace DEMO.AllUserControl;

public partial class AuthUC : UserControl
{
    public AuthUC()
    {
        InitializeComponent();
    }
    private void LoginBtn_Click(object? sender, RoutedEventArgs e)
{
     User? loginUser = Context.Connect.Users.FirstOrDefault(c => c.Login == LoginTb.Text && c.Password == PasswordTb.Text);
     if (loginUser != null)
        {
           App.MainWindow!.MainContentControl.Content = new MainUC();
        }
}
}