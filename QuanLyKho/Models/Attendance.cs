using System;
using System.Collections.Generic;

namespace QuanLyKho.Models;

public partial class Attendance
{
    public int Id { get; set; }

    public int EmployeeId { get; set; }

    public DateOnly Date { get; set; }

    public bool IsAbsent { get; set; }

    public string? Note { get; set; }

    public virtual Employee Employee { get; set; } = null!;
}
