using System;
using System.Collections.Generic;

namespace DEMO.Entities;

public partial class Supplier
{
    public int IdSupplier { get; set; }

    public string? Supplier1 { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
