﻿using System;
using System.Collections.Generic;

namespace UsingEFCoreDatabaseFirst.Models.db;

public partial class OrderSubtotal
{
    public int OrderId { get; set; }

    public decimal? Subtotal { get; set; }
}
