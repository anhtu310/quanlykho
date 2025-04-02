using System;
using System.Collections.Generic;

namespace QuanLyKho.Models;

public partial class Product
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int IdUnit { get; set; }

    public int Quantity { get; set; }

    public int? WarningQuantity { get; set; }

    public int? CategoryId { get; set; }

    public virtual Unit IdUnitNavigation { get; set; } = null!;
    public virtual Category? Category { get; set; }

    public virtual ICollection<OutputInfo> OutputInfos { get; set; } = new List<OutputInfo>();

    public virtual ICollection<ProductSupplier> ProductSuppliers { get; set; } = new List<ProductSupplier>();
}
