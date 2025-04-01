using System;
using System.Collections.Generic;

namespace QuanLyKho.Models;

public partial class ProductSupplier
{
    public int Id { get; set; }

    public int IdProduct { get; set; }

    public int IdSupplier { get; set; }

    public virtual Product IdProductNavigation { get; set; } = null!;

    public virtual Supplier IdSupplierNavigation { get; set; } = null!;

    public virtual ICollection<InputInfo> InputInfos { get; set; } = new List<InputInfo>();
}
