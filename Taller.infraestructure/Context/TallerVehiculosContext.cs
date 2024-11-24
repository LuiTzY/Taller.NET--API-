using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Taller.Domain.Entities;

namespace Taller.infraestructure;

public partial class TallerVehiculosContext : DbContext
{
    public TallerVehiculosContext()
    {
    }

    public TallerVehiculosContext(DbContextOptions<TallerVehiculosContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Empleado> Empleados { get; set; }

    public virtual DbSet<HistorialMantenimiento> HistorialMantenimientos { get; set; }

    public virtual DbSet<OrdenPieza> OrdenPiezas { get; set; }

    public virtual DbSet<OrdenesTrabajo> OrdenesTrabajos { get; set; }

    public virtual DbSet<Pieza> Piezas { get; set; }

    public virtual DbSet<Vehiculo> Vehiculos { get; set; }

 
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.ClienteId).HasName("PK__Clientes__71ABD0A700D0A353");

            entity.Property(e => e.ClienteId).HasColumnName("ClienteID");
            entity.Property(e => e.Apellido).HasMaxLength(100);
            entity.Property(e => e.Direccion).HasMaxLength(200);
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.Nombre).HasMaxLength(100);
            entity.Property(e => e.Telefono).HasMaxLength(15);
        });

        modelBuilder.Entity<Empleado>(entity =>
        {
            entity.HasKey(e => e.EmpleadoId).HasName("PK__Empleado__958BE6F09B816D75");

            entity.Property(e => e.EmpleadoId).HasColumnName("EmpleadoID");
            entity.Property(e => e.Apellido).HasMaxLength(100);
            entity.Property(e => e.Cargo).HasMaxLength(50);
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.Nombre).HasMaxLength(100);
            entity.Property(e => e.Telefono).HasMaxLength(15);
        });

        modelBuilder.Entity<HistorialMantenimiento>(entity =>
        {
            entity.HasKey(e => e.HistorialId).HasName("PK__Historia__975206EF4EF5A403");

            entity.ToTable("HistorialMantenimiento");

            entity.Property(e => e.HistorialId).HasColumnName("HistorialID");
            entity.Property(e => e.Descripcion).HasMaxLength(500);
            entity.Property(e => e.Fecha).HasColumnType("datetime");
            entity.Property(e => e.OrdenId).HasColumnName("OrdenID");
            entity.Property(e => e.VehiculoId).HasColumnName("VehiculoID");

            entity.HasOne(d => d.Orden).WithMany(p => p.HistorialMantenimientos)
                .HasForeignKey(d => d.OrdenId)
                .HasConstraintName("FK__Historial__Orden__47DBAE45");

            entity.HasOne(d => d.Vehiculo).WithMany(p => p.HistorialMantenimientos)
                .HasForeignKey(d => d.VehiculoId)
                .HasConstraintName("FK__Historial__Vehic__46E78A0C");
        });

        modelBuilder.Entity<OrdenPieza>(entity =>
        {
            entity.HasKey(e => new { e.OrdenId, e.PiezaId }).HasName("PK__OrdenPie__8B358862F61DC9B2");

            entity.Property(e => e.OrdenId).HasColumnName("OrdenID");
            entity.Property(e => e.PiezaId).HasColumnName("PiezaID");
            entity.Property(e => e.Costo).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.Orden).WithMany(p => p.OrdenPiezas)
                .HasForeignKey(d => d.OrdenId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__OrdenPiez__Orden__4316F928");

            entity.HasOne(d => d.Pieza).WithMany(p => p.OrdenPiezas)
                .HasForeignKey(d => d.PiezaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__OrdenPiez__Pieza__440B1D61");
        });

        modelBuilder.Entity<OrdenesTrabajo>(entity =>
        {
            entity.HasKey(e => e.OrdenId).HasName("PK__OrdenesT__C088A4E4E23D3745");

            entity.ToTable("OrdenesTrabajo");

            entity.Property(e => e.OrdenId).HasColumnName("OrdenID");
            entity.Property(e => e.Descripcion).HasMaxLength(500);
            entity.Property(e => e.EmpleadoId).HasColumnName("EmpleadoID");
            entity.Property(e => e.Estado).HasMaxLength(50);
            entity.Property(e => e.FechaEntrada).HasColumnType("datetime");
            entity.Property(e => e.FechaSalida).HasColumnType("datetime");
            entity.Property(e => e.TotalCosto).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.VehiculoId).HasColumnName("VehiculoID");

            entity.HasOne(d => d.Empleado).WithMany(p => p.OrdenesTrabajos)
                .HasForeignKey(d => d.EmpleadoId)
                .HasConstraintName("FK__OrdenesTr__Emple__3E52440B");

            entity.HasOne(d => d.Vehiculo).WithMany(p => p.OrdenesTrabajos)
                .HasForeignKey(d => d.VehiculoId)
                .HasConstraintName("FK__OrdenesTr__Vehic__3D5E1FD2");
        });

        modelBuilder.Entity<Pieza>(entity =>
        {
            entity.HasKey(e => e.PiezaId).HasName("PK__Piezas__BBD2C865B997773B");

            entity.Property(e => e.PiezaId).HasColumnName("PiezaID");
            entity.Property(e => e.Descripcion).HasMaxLength(200);
            entity.Property(e => e.Nombre).HasMaxLength(100);
            entity.Property(e => e.Precio).HasColumnType("decimal(18, 2)");
        });

        modelBuilder.Entity<Vehiculo>(entity =>
        {
            entity.HasKey(e => e.VehiculoId).HasName("PK__Vehiculo__AA0886209AD916A3");

            entity.Property(e => e.VehiculoId).HasColumnName("VehiculoID");
            entity.Property(e => e.ClienteId).HasColumnName("ClienteID");
            entity.Property(e => e.Color).HasMaxLength(30);
            entity.Property(e => e.Marca).HasMaxLength(50);
            entity.Property(e => e.Modelo).HasMaxLength(50);
            entity.Property(e => e.Placa).HasMaxLength(15);

            entity.HasOne(d => d.Cliente).WithMany(p => p.Vehiculos)
                .HasForeignKey(d => d.ClienteId)
                .HasConstraintName("FK__Vehiculos__Clien__38996AB5");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
