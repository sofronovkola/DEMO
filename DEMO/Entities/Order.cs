using System;
using System.Collections.Generic;

namespace DEMO.Entities;

public partial class Order
{
    public int IdOrder { get; set; }

    public int? Number { get; set; }

    public string? Article { get; set; }

    public int? Count { get; set; }

    public string? DateOrder { get; set; }

    public string? DateDelvery { get; set; }

    public int? Address { get; set; }

    public int? IdUser { get; set; }

    public int? CodeToReceive { get; set; }

    public string? Status { get; set; }

    public virtual Address? AddressNavigation { get; set; }

    public virtual User? IdUserNavigation { get; set; }

    public virtual ICollection<Ordersproduct> Ordersproducts { get; set; } = new List<Ordersproduct>();
}
