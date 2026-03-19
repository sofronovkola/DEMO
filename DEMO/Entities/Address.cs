using System;
using System.Collections.Generic;

namespace DEMO.Entities;

public partial class Address
{
    public int IdAdress { get; set; }

    public int? Index { get; set; }

    public string? City { get; set; }

    public string? Street { get; set; }

    public int? HouseNumber { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
