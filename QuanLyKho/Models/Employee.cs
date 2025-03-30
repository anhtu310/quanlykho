using System;
using System.Collections.Generic;

namespace QuanLyKho.Models;

public partial class Employee
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Address { get; set; }

    public string? Phone { get; set; }

    public string? Email { get; set; }

    public bool Status { get; set; }

    public virtual ICollection<Attendance> Attendances { get; set; } = new List<Attendance>();
}
