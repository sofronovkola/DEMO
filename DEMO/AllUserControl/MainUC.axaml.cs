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

public partial class MainUC : UserControl
{
    public List<Product> ProductList{get; set;} = new List<Product>();
    public List<Manufacturer> manufacturer1 { get; set; } = new List<Manufacturer>();
    public MainUC()
    {
        InitializeComponent();
        ProductList = Context.Connect.Products.Include(c => c.ManufacturerNavigation)
                                      .Include(c => c.NameProductNavigation)
                                      .Include(c => c.Ordersproducts)
                                      .Include(c => c.SupplierNavigation).ToList();

        manufacturer1=Context.Connect.Manufacturers.ToList();
        EventUI();
    }

    private void EventUI()
    {
        MUControl.Loaded += Control_OnLoaded; // Подписка на событие
        ProdustListB.SelectionChanged+=ProductListBox_OnSelectionChanged;
        RemoveButton.Click += DeleteButton_OnClick;
        AddButton.Click+=AddButton_OnClick;
        EditButton.Click+=EditButton_OnClick;

        //Подписки для реализации сортировки и поиска
        ManufacturersCBox.SelectionChanged += ManufacturersCBox_OnSelectionChanged;

        SearchTextB.TextChanged += SearchTextB_OnTextChanged;
        SortUpButton.IsCheckedChanged += SortButton_OnChecked;
        SortDownButton.IsCheckedChanged += SortButton_OnChecked;
    }


    public void Control_OnLoaded(object? sender, RoutedEventArgs e)
    {
        DataContext = this;
    }

    private void AddButton_OnClick(object? sender, RoutedEventArgs e)
    {
        App.MainWindow.MainContentControl.Content = new EditAddProductUC();
    }

    Product selectProduct;
    private void ProductListBox_OnSelectionChanged(object? sender, RoutedEventArgs e)
    {
        selectProduct = (Product)ProdustListB.SelectedItem;
    }

    private void EditButton_OnClick(object? sender, RoutedEventArgs e)
    {
        App.MainWindow.MainContentControl.Content = new EditAddProductUC(selectProduct);
    }

    private void DeleteButton_OnClick(object? sender, RoutedEventArgs e)
    {
        if (Context.Connect.Ordersproducts.FirstOrDefault(c => c.ProductNavigation.IdProduct == selectProduct.IdProduct) != null)
    {
    }
    else
    {
        Context.Connect.Products.Remove(selectProduct);
        Context.Connect.SaveChanges();
    }

    App.MainWindow.MainContentControl.Content = new MainUC();
    }

    private string manufacturPar;
    private string searchPar;
    private int sort = 0;

    void Search(string manufacturer, string search, int sort = -1)
    {
    ProductList = Context.Connect.Products.Include(c => c.ManufacturerNavigation).Where
        (c => c.ManufacturerNavigation.Manufacturer1.Contains(manufacturPar) && c.NameProductNavigation.NameProduct.Contains(searchPar)).ToList();

    if (sort == 1)
    {
        ProductList = ProductList.OrderBy(c => c.CountInStock).ToList();
    }

    if (sort == 0)
    {
        ProductList = ProductList.OrderByDescending(c => c.CountInStock).ToList();
    }

    ProdustListB.ItemsSource = ProductList;
    }

    private void ManufacturersCBox_OnSelectionChanged(object? sender, RoutedEventArgs e)
    {
    manufacturPar = ((Manufacturer)ManufacturersCBox.SelectedItem).Manufacturer1;
    Search(manufacturPar, searchPar);
    }

    private void SearchTextB_OnTextChanged(object? sender, RoutedEventArgs e)
    {
    searchPar = SearchTextB.Text;
    Search(manufacturPar, searchPar);
    }

    private void SortButton_OnChecked(object? sender, RoutedEventArgs e)
    {
    if (SortUpButton.IsChecked == true)
    {
        sort = 1;
    }

    if (SortDownButton.IsChecked == true)
    {
        sort = 0;
    }
    Search(manufacturPar, searchPar, sort);
    }
}