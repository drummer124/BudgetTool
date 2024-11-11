using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BudgetTool.Models;

public partial class TransactionsContext : DbContext
{
    public TransactionsContext()
    {
    }

    public TransactionsContext(DbContextOptions<TransactionsContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<TransactionHistory> TransactionHistories { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-UF7M1GV;Initial Catalog=Transactions;Integrated Security=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("categories");

            entity.Property(e => e.Category1)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("category");
            entity.Property(e => e.Description)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("description");
            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");
        });

        modelBuilder.Entity<TransactionHistory>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("transactionHistory");

            entity.Property(e => e.ActivityHistory)
                .ValueGeneratedOnAdd()
                .HasColumnName("activityHistory");
            entity.Property(e => e.AddedTimeStamp)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("addedTimeStamp");
            entity.Property(e => e.TransactionAmount)
                .HasColumnType("money")
                .HasColumnName("transactionAmount");
            entity.Property(e => e.TransactionDate).HasColumnName("transactionDate");
            entity.Property(e => e.TransactionDescription)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("transactionDescription");
            entity.Property(e => e.TransactionName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("transactionName");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
