using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace AdminTurismoERP;

public partial class AdminToursContext : DbContext
{
    public AdminToursContext()
    {
    }

    public AdminToursContext(DbContextOptions<AdminToursContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Capacidad> Capacidads { get; set; }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Descuento> Descuentos { get; set; }

    public virtual DbSet<EstadosReserva> EstadosReservas { get; set; }

    public virtual DbSet<Guia> Guias { get; set; }

    public virtual DbSet<Reserva> Reservas { get; set; }

    public virtual DbSet<RolesUsuario> RolesUsuarios { get; set; }

    public virtual DbSet<Tour> Tours { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
// #warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=localhost;user=root;password=PHP.Laravel;port=3307;database=AdminTours", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.33-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Capacidad>(entity =>
        {
            entity.HasKey(e => e.CapacidadId).HasName("PRIMARY");

            entity.ToTable("capacidad");

            entity.Property(e => e.CapacidadId).HasColumnName("capacidadID");
            entity.Property(e => e.CapacidadTour).HasColumnName("capacidadTour");
        });

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.ClienteId).HasName("PRIMARY");

            entity.ToTable("clientes");

            entity.HasIndex(e => e.CorreoElectronico, "correoElectronico").IsUnique();

            entity.Property(e => e.ClienteId).HasColumnName("clienteID");
            entity.Property(e => e.Comentarios)
                .HasColumnType("text")
                .HasColumnName("comentarios");
            entity.Property(e => e.CorreoElectronico).HasColumnName("correoElectronico");
            entity.Property(e => e.Nombre)
                .HasMaxLength(255)
                .HasColumnName("nombre");
            entity.Property(e => e.Telefono).HasColumnName("telefono");
        });

        modelBuilder.Entity<Descuento>(entity =>
        {
            entity.HasKey(e => e.DescuentoId).HasName("PRIMARY");

            entity.ToTable("descuentos");

            entity.Property(e => e.DescuentoId).HasColumnName("descuentoID");
            entity.Property(e => e.CantidadDescuento)
                .HasPrecision(10, 2)
                .HasColumnName("cantidadDescuento");
            entity.Property(e => e.Codigo)
                .HasMaxLength(255)
                .HasColumnName("codigo");
            entity.Property(e => e.NombreDescuento)
                .HasMaxLength(255)
                .HasColumnName("nombreDescuento");
        });

        modelBuilder.Entity<EstadosReserva>(entity =>
        {
            entity.HasKey(e => e.EstadoId).HasName("PRIMARY");

            entity.ToTable("estadosReserva");

            entity.Property(e => e.EstadoId).HasColumnName("estadoID");
            entity.Property(e => e.NombreEstado)
                .HasMaxLength(255)
                .HasColumnName("nombreEstado");
        });

        modelBuilder.Entity<Guia>(entity =>
        {
            entity.HasKey(e => e.GuiaId).HasName("PRIMARY");

            entity.ToTable("guias");

            entity.Property(e => e.GuiaId).HasColumnName("guiaID");
            entity.Property(e => e.Nombre)
                .HasMaxLength(255)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Reserva>(entity =>
        {
            entity.HasKey(e => e.ReservaId).HasName("PRIMARY");

            entity.ToTable("reservas");

            entity.HasIndex(e => e.ClienteId, "clienteID");

            entity.HasIndex(e => e.DescuentoId, "descuentoID");

            entity.HasIndex(e => e.EstadoId, "estadoID");

            entity.HasIndex(e => e.TourId, "tourID");

            entity.Property(e => e.ReservaId).HasColumnName("reservaID");
            entity.Property(e => e.ClienteId).HasColumnName("clienteID");
            entity.Property(e => e.DescuentoId).HasColumnName("descuentoID");
            entity.Property(e => e.EstadoId).HasColumnName("estadoID");
            entity.Property(e => e.NumeroPersonas).HasColumnName("numeroPersonas");
            entity.Property(e => e.Pagado).HasColumnName("pagado");
            entity.Property(e => e.TourId).HasColumnName("tourID");

            entity.HasOne(d => d.Cliente).WithMany(p => p.Reservas)
                .HasForeignKey(d => d.ClienteId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("reservas_ibfk_1");

            entity.HasOne(d => d.Descuento).WithMany(p => p.Reservas)
                .HasForeignKey(d => d.DescuentoId)
                .HasConstraintName("reservas_ibfk_3");

            entity.HasOne(d => d.Estado).WithMany(p => p.Reservas)
                .HasForeignKey(d => d.EstadoId)
                .HasConstraintName("reservas_ibfk_4");

            entity.HasOne(d => d.Tour).WithMany(p => p.Reservas)
                .HasForeignKey(d => d.TourId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("reservas_ibfk_2");
        });

        modelBuilder.Entity<RolesUsuario>(entity =>
        {
            entity.HasKey(e => e.RolId).HasName("PRIMARY");

            entity.ToTable("rolesUsuarios");

            entity.Property(e => e.RolId).HasColumnName("rolID");
            entity.Property(e => e.NombreRol)
                .HasMaxLength(25)
                .HasColumnName("nombreRol");
        });

        modelBuilder.Entity<Tour>(entity =>
        {
            entity.HasKey(e => e.TourId).HasName("PRIMARY");

            entity.ToTable("tours");

            entity.HasIndex(e => e.CapacidadId, "capacidadID");

            entity.HasIndex(e => e.GuiaId, "guiaID");

            entity.Property(e => e.TourId).HasColumnName("tourID");
            entity.Property(e => e.CapacidadId).HasColumnName("capacidadID");
            entity.Property(e => e.CapacidadMaxima).HasColumnName("capacidadMaxima");
            entity.Property(e => e.Costo)
                .HasPrecision(10, 2)
                .HasColumnName("costo");
            entity.Property(e => e.Fecha)
                .HasColumnType("datetime")
                .HasColumnName("fecha");
            entity.Property(e => e.GuiaId).HasColumnName("guiaID");
            entity.Property(e => e.NombreTour)
                .HasMaxLength(255)
                .HasColumnName("nombreTour");

            entity.HasOne(d => d.Capacidad).WithMany(p => p.Tours)
                .HasForeignKey(d => d.CapacidadId)
                .HasConstraintName("tours_ibfk_2");

            entity.HasOne(d => d.Guia).WithMany(p => p.Tours)
                .HasForeignKey(d => d.GuiaId)
                .HasConstraintName("tours_ibfk_1");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.UsuarioId).HasName("PRIMARY");

            entity.ToTable("usuarios");

            entity.HasIndex(e => e.Email, "email").IsUnique();

            entity.HasIndex(e => e.NombreUsuario, "nombreUsuario").IsUnique();

            entity.HasIndex(e => e.RolId, "rolID");

            entity.Property(e => e.UsuarioId).HasColumnName("usuarioID");
            entity.Property(e => e.Contrasena)
                .HasMaxLength(64)
                .IsFixedLength()
                .HasColumnName("contrasena");
            entity.Property(e => e.Email).HasColumnName("email");
            entity.Property(e => e.Expiracion)
                .HasColumnType("datetime")
                .HasColumnName("expiracion");
            entity.Property(e => e.NombreUsuario)
                .HasMaxLength(100)
                .HasColumnName("nombreUsuario");
            entity.Property(e => e.RolId).HasColumnName("rolID");
            entity.Property(e => e.Token)
                .HasMaxLength(64)
                .IsFixedLength()
                .HasColumnName("token");

            entity.HasOne(d => d.Rol).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.RolId)
                .HasConstraintName("usuarios_ibfk_1");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
