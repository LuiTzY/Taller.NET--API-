using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Taller.Domain.entities;

public partial class TallerBdContext : DbContext
{
    public TallerBdContext()
    {
    }

    public TallerBdContext(DbContextOptions<TallerBdContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Empleado> Empleados { get; set; }

    public virtual DbSet<OrdenesPieza> OrdenesPiezas { get; set; }

    public virtual DbSet<OrdenesTrabajo> OrdenesTrabajos { get; set; }

    public virtual DbSet<Pieza> Piezas { get; set; }

    public virtual DbSet<Vehiculo> Vehiculos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-72T1KEQ\\SQLEXPRESS;Database=tallerBD;Integrated Security=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.ClienteId).HasName("PK__Clientes__71ABD0A773FD9A78");

            entity.Property(e => e.ClienteId).HasColumnName("ClienteID");
            entity.Property(e => e.Direccion).HasMaxLength(200);
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.Nombre).HasMaxLength(100);
            entity.Property(e => e.Telefono).HasMaxLength(15);
        });

        modelBuilder.Entity<Empleado>(entity =>
        {
            entity.HasKey(e => e.EmpleadoId).HasName("PK__Empleado__958BE6F0ED7DE4F4");

            entity.Property(e => e.EmpleadoId).HasColumnName("EmpleadoID");
            entity.Property(e => e.Cargo).HasMaxLength(50);
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.Nombre).HasMaxLength(100);
            entity.Property(e => e.Telefono).HasMaxLength(15);
        });

        modelBuilder.Entity<OrdenesPieza>(entity =>
        {
            entity.HasKey(e => new { e.OrdenId, e.PiezaId }).HasName("PK__Ordenes___8B35886258710FC8");

            entity.ToTable("Ordenes_Piezas");

            entity.Property(e => e.OrdenId).HasColumnName("OrdenID");
            entity.Property(e => e.PiezaId).HasColumnName("PiezaID");

            entity.HasOne(d => d.Orden).WithMany(p => p.OrdenesPiezas)
                .HasForeignKey(d => d.OrdenId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Ordenes_P__Orden__45F365D3");

            entity.HasOne(d => d.Pieza).WithMany(p => p.OrdenesPiezas)
                .HasForeignKey(d => d.PiezaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Ordenes_P__Pieza__46E78A0C");
        });

        modelBuilder.Entity<OrdenesTrabajo>(entity =>
        {
            entity.HasKey(e => e.OrdenId).HasName("PK__OrdenesT__C088A4E4DC9D182C");

            entity.ToTable("OrdenesTrabajo");

            entity.Property(e => e.OrdenId).HasColumnName("OrdenID");
            entity.Property(e => e.Costo).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.EmpleadoId).HasColumnName("EmpleadoID");
            entity.Property(e => e.Estado).HasMaxLength(20);
            entity.Property(e => e.VehiculoId).HasColumnName("VehiculoID");

            entity.HasOne(d => d.Empleado).WithMany(p => p.OrdenesTrabajos)
                .HasForeignKey(d => d.EmpleadoId)
                .HasConstraintName("FK__OrdenesTr__Emple__403A8C7D");

            entity.HasOne(d => d.Vehiculo).WithMany(p => p.OrdenesTrabajos)
                .HasForeignKey(d => d.VehiculoId)
                .HasConstraintName("FK__OrdenesTr__Vehic__3F466844");
        });

        modelBuilder.Entity<Pieza>(entity =>
        {
            entity.HasKey(e => e.PiezaId).HasName("PK__Piezas__BBD2C865343F05F6");

            entity.Property(e => e.PiezaId).HasColumnName("PiezaID");
            entity.Property(e => e.Descripcion).HasMaxLength(255);
            entity.Property(e => e.Nombre).HasMaxLength(100);
            entity.Property(e => e.Precio).HasColumnType("decimal(10, 2)");
        });

        modelBuilder.Entity<Vehiculo>(entity =>
        {
            entity.HasKey(e => e.VehiculoId).HasName("PK__Vehiculo__AA08862077B9B006");

            entity.HasIndex(e => e.Placa, "UQ__Vehiculo__8310F99DCD52F457").IsUnique();

            entity.HasIndex(e => e.NumeroSerie, "UQ__Vehiculo__C5455177FD726233").IsUnique();

            entity.Property(e => e.VehiculoId).HasColumnName("VehiculoID");
            entity.Property(e => e.ClienteId).HasColumnName("ClienteID");
            entity.Property(e => e.Marca).HasMaxLength(50);
            entity.Property(e => e.Modelo).HasMaxLength(50);
            entity.Property(e => e.NumeroSerie).HasMaxLength(50);
            entity.Property(e => e.Placa).HasMaxLength(10);

            entity.HasOne(d => d.Cliente).WithMany(p => p.Vehiculos)
                .HasForeignKey(d => d.ClienteId)
                .HasConstraintName("FK__Vehiculos__Clien__3A81B327");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
