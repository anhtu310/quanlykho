using System;
using System.Collections.Generic;

namespace QuanLyKho.Models;

public partial class Product
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int IdUnit { get; set; }

    public int IdSupplier { get; set; }

    public int Quantity { get; set; }

    public virtual Supplier IdSupplierNavigation { get; set; } = null!;

    public virtual Unit IdUnitNavigation { get; set; } = null!;

    public virtual ICollection<InputInfo> InputInfos { get; set; } = new List<InputInfo>();

    public virtual ICollection<OutputInfo> OutputInfos { get; set; } = new List<OutputInfo>();
}
