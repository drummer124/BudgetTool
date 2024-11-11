using System;
using System.Collections.Generic;

namespace BudgetTool.Models;

public partial class TransactionHistory
{
    public int ActivityHistory { get; set; }

    public string TransactionName { get; set; } = null!;

    public string? TransactionDescription { get; set; }

    public decimal TransactionAmount { get; set; }

    public DateOnly TransactionDate { get; set; }

    public DateTime? AddedTimeStamp { get; set; }
}
