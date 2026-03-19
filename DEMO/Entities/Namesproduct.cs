using System;
using System.Collections.Generic;

namespace DEMO.Entities;

public partial class Namesproduct
{
    public int IdNameProduct { get; set; }

    public string? NameProduct { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
