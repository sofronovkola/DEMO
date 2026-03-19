using System;
using System.Collections.Generic;
using System.IO;
using Avalonia.Media.Imaging;

namespace DEMO.Entities;

public partial class Product
{
    public int IdProduct { get; set; }

    public string? Article { get; set; }

    public int? NameProduct { get; set; }

    public string? ProductUnit { get; set; }

    public int? Price { get; set; }

    public int? Supplier { get; set; }

    public int? Manufacturer { get; set; }

    public string? Category { get; set; }

    public int? Discount { get; set; }

    public int? CountInStock { get; set; }

    public string? Description { get; set; }

    public string? Photo { get; set; }

    public virtual Manufacturer? ManufacturerNavigation { get; set; }

    public virtual Namesproduct? NameProductNavigation { get; set; }

    public virtual ICollection<Ordersproduct> Ordersproducts { get; set; } = new List<Ordersproduct>();

    public virtual Supplier? SupplierNavigation { get; set; }

    string put=@"C:\Users\kolya\OneDrive\Документы\Avolonia\DEMO\bin\Debug\net10.0\import";
    public Bitmap? ImagePath
    {
        get
        {
            var ImagePath = @"C:\Users\kolya\OneDrive\Документы\Avolonia\DEMO\bin\Debug\net10.0\import\picture.png";

            if (!string.IsNullOrWhiteSpace(Photo))
            {
                ImagePath=Path.Combine(put, Photo);
            } 

            return new Bitmap(ImagePath);
        }
    }
}