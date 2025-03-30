using System;
using System.Collections.Generic;

namespace QuanLyKho.Models;

public partial class Customer
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Address { get; set; }

    public string? Email { get; set; }

    public string? Phone { get; set; }

    public DateOnly? ContactDate { get; set; }

    public string? MoreInfo { get; set; }

    public virtual ICollection<OutputInfo> OutputInfos { get; set; } = new List<OutputInfo>();
}
