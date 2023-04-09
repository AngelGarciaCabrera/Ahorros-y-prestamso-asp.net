using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SistemaDeAhorroYPrestamos.Models;

public partial class AhorrosPrestamosContext : DbContext
{
    public AhorrosPrestamosContext()
    {
    }

    public AhorrosPrestamosContext(DbContextOptions<AhorrosPrestamosContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<CuentaBanco> CuentaBancos { get; set; }

    public virtual DbSet<CuotaInversion> CuotaInversions { get; set; }

    public virtual DbSet<CuotaPrestamo> CuotaPrestamos { get; set; }

    public virtual DbSet<Garantium> Garantia { get; set; }

    public virtual DbSet<Inversione> Inversiones { get; set; }

    public virtual DbSet<Prestamo> Prestamos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=ANGEL;Database=AhorrosPrestamos;Trusted_Connection=True;Encrypt=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.Cedula).HasName("PK__Clientes__415B7BE4BF9245AA");

            entity.Property(e => e.Cedula)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("cedula");
            entity.Property(e => e.Apellido)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("apellido");
            entity.Property(e => e.Direccion)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("direccion");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.Telefono)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("telefono");
        });

        modelBuilder.Entity<CuentaBanco>(entity =>
        {
            entity.HasKey(e => e.Numero).HasName("PK__CuentaBa__FC77F210B76F1A06");

            entity.ToTable("CuentaBanco");

            entity.HasIndex(e => e.ClienteCedula, "UQ_CuentaBanco_ClienteCedula").IsUnique();

            entity.HasIndex(e => e.ClienteCedula, "UQ__CuentaBa__6AA154E3C6D0E192").IsUnique();

            entity.Property(e => e.Numero)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("numero");
            entity.Property(e => e.Banco)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("banco");
            entity.Property(e => e.ClienteCedula)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("clienteCedula");
            entity.Property(e => e.Tipo)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("tipo");

            entity.HasOne(d => d.ClienteCedulaNavigation).WithOne(p => p.CuentaBanco)
                .HasForeignKey<CuentaBanco>(d => d.ClienteCedula)
                .HasConstraintName("FK__CuentaBan__clien__276EDEB3");
        });

        modelBuilder.Entity<CuotaInversion>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("CuotaInversion");

            entity.Property(e => e.CodigoComprobante).HasColumnName("codigoComprobante");
            entity.Property(e => e.CodigoInversion).HasColumnName("codigoInversion");
            entity.Property(e => e.CuentaBancoNumero)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("cuentaBancoNumero");
            entity.Property(e => e.FechaPlanificada)
                .HasColumnType("date")
                .HasColumnName("fechaPlanificada");
            entity.Property(e => e.FechaRealizada)
                .HasColumnType("date")
                .HasColumnName("fechaRealizada");
            entity.Property(e => e.Tipo)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("tipo");

            entity.HasOne(d => d.CodigoInversionNavigation).WithMany()
                .HasForeignKey(d => d.CodigoInversion)
                .HasConstraintName("FK__CuotaInve__codig__37A5467C");

            entity.HasOne(d => d.CuentaBancoNumeroNavigation).WithMany()
                .HasForeignKey(d => d.CuentaBancoNumero)
                .HasConstraintName("FK__CuotaInve__cuent__2A4B4B5E");
        });

        modelBuilder.Entity<CuotaPrestamo>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.CodigoComprobante).HasColumnName("codigoComprobante");
            entity.Property(e => e.FechaPlanificacion)
                .HasColumnType("date")
                .HasColumnName("fechaPlanificacion");
            entity.Property(e => e.FechaRealizado)
                .HasColumnType("date")
                .HasColumnName("fechaRealizado");
            entity.Property(e => e.Monto)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("monto");
            entity.Property(e => e.PrestamoCodigo).HasColumnName("prestamoCodigo");
            entity.Property(e => e.Tipo)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("tipo");

            entity.HasOne(d => d.PrestamoCodigoNavigation).WithMany()
                .HasForeignKey(d => d.PrestamoCodigo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CuotaPres__prest__33D4B598");
        });

        modelBuilder.Entity<Garantium>(entity =>
        {
            entity.HasKey(e => e.Codigo).HasName("PK__Garantia__40F9A2078A513EF8");

            entity.Property(e => e.Codigo)
                .ValueGeneratedNever()
                .HasColumnName("codigo");
            entity.Property(e => e.PrestamoCodigo).HasColumnName("prestamoCodigo");
            entity.Property(e => e.Tipo)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("tipo");
            entity.Property(e => e.Ubicacion)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("ubicacion");
            entity.Property(e => e.Valor)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("valor");

            entity.HasOne(d => d.PrestamoCodigoNavigation).WithMany(p => p.Garantia)
                .HasForeignKey(d => d.PrestamoCodigo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Garantia__presta__36B12243");
        });

        modelBuilder.Entity<Inversione>(entity =>
        {
            entity.HasKey(e => e.Codigo).HasName("PK__Inversio__40F9A20726A6A8D6");

            entity.HasIndex(e => e.CuentaBancoNumero, "UQ__Inversio__C34CF9AFC733114C").IsUnique();

            entity.Property(e => e.Codigo)
                .ValueGeneratedNever()
                .HasColumnName("codigo");
            entity.Property(e => e.ClienteCedula)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("clienteCedula");
            entity.Property(e => e.CuentaBancoNumero)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("cuentaBancoNumero");
            entity.Property(e => e.FechaBeg)
                .HasColumnType("date")
                .HasColumnName("fechaBeg");
            entity.Property(e => e.FechaEnd)
                .HasColumnType("date")
                .HasColumnName("fechaEnd");
            entity.Property(e => e.Monto)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("monto");

            entity.HasOne(d => d.ClienteCedulaNavigation).WithMany(p => p.Inversiones)
                .HasForeignKey(d => d.ClienteCedula)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Inversion__clien__2F10007B");

            entity.HasOne(d => d.CuentaBancoNumeroNavigation).WithOne(p => p.Inversione)
                .HasForeignKey<Inversione>(d => d.CuentaBancoNumero)
                .HasConstraintName("FK__Inversion__cuent__2E1BDC42");
        });

        modelBuilder.Entity<Prestamo>(entity =>
        {
            entity.HasKey(e => e.Codigo).HasName("PK__Prestamo__40F9A207350AE2E5");

            entity.Property(e => e.Codigo)
                .ValueGeneratedNever()
                .HasColumnName("codigo");
            entity.Property(e => e.ClienteCedula)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("clienteCedula");
            entity.Property(e => e.FechaBeg)
                .HasColumnType("date")
                .HasColumnName("fechaBeg");
            entity.Property(e => e.FechaEnd)
                .HasColumnType("date")
                .HasColumnName("fechaEnd");
            entity.Property(e => e.Interes)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("interes");
            entity.Property(e => e.Monto)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("monto");

            entity.HasOne(d => d.ClienteCedulaNavigation).WithMany(p => p.Prestamos)
                .HasForeignKey(d => d.ClienteCedula)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Prestamos__clien__31EC6D26");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
