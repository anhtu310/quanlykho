﻿using System;
using System.Collections.Generic;

namespace QuanLyKho.Models;

public partial class OutputInfo
{
    public int Id { get; set; }

    public int IdOutput { get; set; }

    public int IdProduct { get; set; }

    public int IdInputInfo { get; set; }

    public int Count { get; set; }

    public int IdCustomer { get; set; }

    public string? Status { get; set; }

    public virtual Customer IdCustomerNavigation { get; set; } = null!;

    public virtual InputInfo IdInputInfoNavigation { get; set; } = null!;

    public virtual Output IdOutputNavigation { get; set; } = null!;

    public virtual Product IdProductNavigation { get; set; } = null!;
}
