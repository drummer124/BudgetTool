﻿using System;
using System.Collections.Generic;

namespace BudgetTool.Models;

public partial class Category
{
    public int Id { get; set; }

    public string Category1 { get; set; } = null!;

    public string? Description { get; set; }
}
