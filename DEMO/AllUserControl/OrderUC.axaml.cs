using System.Collections.Generic;
using System.Linq;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using DEMO.Entities;
using DEMO.Models;
using Microsoft.EntityFrameworkCore;

namespace DEMO.AllUserControl;

public partial class OrderUC : UserControl
{
    public List<Order> OrderList{get; set;}=new List<Order>();
    public OrderUC()
    {
        InitializeComponent();
        OrderList=Context.Connect.Orders.Include(c=>c.AddressNavigation).ToList();
    }

    public void Control_OnLoaded(object? sender, RoutedEventArgs e)
    {
        DataContext = this;
    }

    private void AddButton_OnClick(object? sender, RoutedEventArgs e)
    {
        App.MainWindow.MainContentControl.Content = new EditAddProductUC();
    }

    private void EditButton_OnClick(object? sender, RoutedEventArgs e)
    {
        
    }

    private void DeleteButton_OnClick(object? sender, RoutedEventArgs e)
    {
        
    }

        private void ProductListBox_OnSelectionChanged(object? sender, RoutedEventArgs e)
    {

    }
}