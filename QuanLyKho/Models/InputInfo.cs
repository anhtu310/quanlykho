using System;
using System.Collections.Generic;

namespace QuanLyKho.Models;

public partial class InputInfo
{
    public int Id { get; set; }

    public int IdProduct { get; set; }

    public int IdSupplier { get; set; }

    public int IdInput { get; set; }

    public int Count { get; set; }

    public decimal InputPrice { get; set; }

    public decimal OutputPrice { get; set; }

    public string? Status { get; set; }

    public virtual Input IdInputNavigation { get; set; } = null!;

    public virtual Product IdProductNavigation { get; set; } = null!;

    public virtual Supplier IdSupplierNavigation { get; set; } = null!;

    public virtual ICollection<OutputInfo> OutputInfos { get; set; } = new List<OutputInfo>();
}
