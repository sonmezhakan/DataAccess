using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CA_Barbut.Models;

public partial class BarbutGameDbContext : DbContext
{
    public BarbutGameDbContext()
    {
    }

    public BarbutGameDbContext(DbContextOptions<BarbutGameDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Balance> Balances { get; set; }

    public virtual DbSet<GameHistory> GameHistories { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("server=DESKTOP-S8RDFAU;database=BarbutGameDB;uid=sa;pwd=123;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Balance>(entity =>
        {
            entity.ToTable("Balance");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");

            entity.HasOne(d => d.IdNavigation).WithOne(p => p.Balance)
                .HasForeignKey<Balance>(d => d.Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserAccount_Users");
        });

        modelBuilder.Entity<GameHistory>(entity =>
        {
            entity.HasKey(e => e.GameId).HasName("PK_GameList");

            entity.ToTable("GameHistory");

            entity.Property(e => e.GameDate).HasColumnType("datetime");
            entity.Property(e => e.Pcdice).HasColumnName("PCDice");

            entity.HasOne(d => d.User).WithMany(p => p.GameHistories)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GameList_Users");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Password).HasMaxLength(50);
            entity.Property(e => e.UserName).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
