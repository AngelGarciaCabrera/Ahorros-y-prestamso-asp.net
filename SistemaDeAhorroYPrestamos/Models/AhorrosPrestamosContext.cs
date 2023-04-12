using Microsoft.EntityFrameworkCore;

namespace SistemaDeAhorroYPrestamos.Models;

public class AhorrosPrestamosContext : DbContext
{
    public AhorrosPrestamosContext(DbContextOptions options) : base(options)
    {
    }

    public virtual DbSet<Cliente> Clientes { get; set; }
    public virtual DbSet<CuentaBanco> CuentaBancos { get; set; }

    public virtual DbSet<Inversiones> Inversiones { get; set; }
    public virtual DbSet<Prestamo> Prestamos { get; set; }

    public virtual DbSet<CuotaInversion> CuotaInversiones { get; set; }
    public virtual DbSet<CuotaPrestamo> CuotaPrestamos { get; set; }
    public virtual DbSet<Garantia> Garantias { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cliente>().ToTable("Clientes");
        modelBuilder.Entity<CuentaBanco>().ToTable("CuentaBancos");

        modelBuilder.Entity<Inversiones>().ToTable("Inversiones");
        modelBuilder.Entity<Prestamo>().ToTable("Prestamos");

        modelBuilder.Entity<CuotaInversion>().ToTable("CuotaInversiones");
        modelBuilder.Entity<CuotaPrestamo>().ToTable("CuotaPrestamos");
        modelBuilder.Entity<Garantia>().ToTable("Garantias");
    }
}