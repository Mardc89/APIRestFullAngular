using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

using SistemaPedidos.Model;

namespace SistemaPedidos.DAL.DBContext;

public partial class DbspaneContext : DbContext
{
    public DbspaneContext()
    {
    }

    public DbspaneContext(DbContextOptions<DbspaneContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Categoria> Categorias { get; set; }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Configuracion> Configuracions { get; set; }

    public virtual DbSet<DestinatarioMensaje> DestinatarioMensajes { get; set; }

    public virtual DbSet<DetalleDevolucion> DetalleDevolucions { get; set; }

    public virtual DbSet<DetallePago> DetallePagos { get; set; }

    public virtual DbSet<DetallePedido> DetallePedidos { get; set; }

    public virtual DbSet<Devolucione> Devoluciones { get; set; }

    public virtual DbSet<Distrito> Distritos { get; set; }

    public virtual DbSet<Mensaje> Mensajes { get; set; }

    public virtual DbSet<NumeroDocumento> NumeroDocumentos { get; set; }

    public virtual DbSet<Pago> Pagos { get; set; }

    public virtual DbSet<Pedido> Pedidos { get; set; }

    public virtual DbSet<Producto> Productos { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Token> Tokens { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Categoria>(entity =>
        {
            entity.HasKey(e => e.IdCategoria);

            entity.Property(e => e.FechaRegistro).HasColumnType("datetime");
            entity.Property(e => e.TipoDeCategoria)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.IdCliente);

            entity.HasIndex(e => e.Correo, "IX_Clientes").IsUnique();

            entity.HasIndex(e => e.NombreUsuario, "IX_Clientes_1").IsUnique();

            entity.Property(e => e.Apellidos)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Clave)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Correo)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Direccion)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Dni)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.FechaRegistro).HasColumnType("datetime");
            entity.Property(e => e.NombreFoto)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.NombreUsuario)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Nombres)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Telefono)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.TipoCliente)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.UrlFoto)
                .HasMaxLength(500)
                .IsUnicode(false);

            entity.HasOne(d => d.IdDistritoNavigation).WithMany(p => p.Clientes)
                .HasForeignKey(d => d.IdDistrito)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Clientes_Distritos");
        });

        modelBuilder.Entity<Configuracion>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Configuracion");

            entity.Property(e => e.Propiedad)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Recurso)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Valor)
                .HasMaxLength(80)
                .IsUnicode(false);
        });

        modelBuilder.Entity<DestinatarioMensaje>(entity =>
        {
            entity.HasKey(e => e.IdMensaje);

            entity.ToTable("DestinatarioMensaje");

            entity.Property(e => e.IdMensaje).ValueGeneratedNever();
            entity.Property(e => e.Destinatario)
                .HasMaxLength(30)
                .IsUnicode(false);

            entity.HasOne(d => d.IdMensajeNavigation).WithOne(p => p.DestinatarioMensaje)
                .HasForeignKey<DestinatarioMensaje>(d => d.IdMensaje)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DestinatarioMensaje_Mensajes");
        });

        modelBuilder.Entity<DetalleDevolucion>(entity =>
        {
            entity.HasKey(e => e.IdDetalleDevolucion);

            entity.ToTable("DetalleDevolucion");

            entity.Property(e => e.Categoria)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Descripcion)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Precio).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Total).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.IdDevolucionNavigation).WithMany(p => p.DetalleDevolucions)
                .HasForeignKey(d => d.IdDevolucion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DetalleDevolucion_Devoluciones");
        });

        modelBuilder.Entity<DetallePago>(entity =>
        {
            entity.HasKey(e => e.IdDetallePago);

            entity.ToTable("DetallePago");

            entity.Property(e => e.CambioDelCliente).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.DeudaDelCliente).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.FechaDetallePago).HasColumnType("datetime");
            entity.Property(e => e.MontoApagar)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("MontoAPagar");
            entity.Property(e => e.PagoDelCliente).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.IdPagoNavigation).WithMany(p => p.DetallePagos)
                .HasForeignKey(d => d.IdPago)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DetallePago_Pagos");
        });

        modelBuilder.Entity<DetallePedido>(entity =>
        {
            entity.HasKey(e => e.IdDetallePedido);

            entity.ToTable("DetallePedido");

            entity.Property(e => e.Total).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.IdPedidoNavigation).WithMany(p => p.DetallePedidos)
                .HasForeignKey(d => d.IdPedido)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DetallePedido_Pedidos");

            entity.HasOne(d => d.IdProductoNavigation).WithMany(p => p.DetallePedidos)
                .HasForeignKey(d => d.IdProducto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DetallePedido_Productos");
        });

        modelBuilder.Entity<Devolucione>(entity =>
        {
            entity.HasKey(e => e.IdDevolucion);

            entity.Property(e => e.CodigoDevolucion)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.CodigoPedido)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.Descuento).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.FechaDevolucion).HasColumnType("datetime");
            entity.Property(e => e.MontoApagar)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("MontoAPagar");
            entity.Property(e => e.MontoDePedido).HasColumnType("decimal(10, 2)");
        });

        modelBuilder.Entity<Distrito>(entity =>
        {
            entity.HasKey(e => e.IdDistrito);

            entity.Property(e => e.NombreDistrito)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Mensaje>(entity =>
        {
            entity.HasKey(e => e.IdMensaje);

            entity.Property(e => e.Asunto)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Cuerpo)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.FechaDeMensaje).HasColumnType("datetime");
            entity.Property(e => e.Remitente)
                .HasMaxLength(30)
                .IsUnicode(false);
        });

        modelBuilder.Entity<NumeroDocumento>(entity =>
        {
            entity.HasKey(e => e.IdNumeroDocumento);

            entity.ToTable("NumeroDocumento");

            entity.Property(e => e.FechaActualizacion).HasColumnType("datetime");
            entity.Property(e => e.Gestion)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Pago>(entity =>
        {
            entity.HasKey(e => e.IdPago);

            entity.Property(e => e.Descuento).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Estado)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.FechaDePago).HasColumnType("datetime");
            entity.Property(e => e.MontoDePedido).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.MontoDeuda).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.MontoTotalDePago).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.IdPedidoNavigation).WithMany(p => p.Pagos)
                .HasForeignKey(d => d.IdPedido)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Pagos_Pedidos");
        });

        modelBuilder.Entity<Pedido>(entity =>
        {
            entity.HasKey(e => e.IdPedido);

            entity.Property(e => e.Codigo)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.Estado)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.FechaPedido).HasColumnType("datetime");
            entity.Property(e => e.MontoTotal).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.Pedidos)
                .HasForeignKey(d => d.IdCliente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Pedidos_Clientes");
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.IdProducto);

            entity.Property(e => e.Descripcion)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.FechaRegistro).HasColumnType("datetime");
            entity.Property(e => e.NombreImagen)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Precio).HasColumnType("decimal(10, 4)");
            entity.Property(e => e.UrlImagen)
                .HasMaxLength(500)
                .IsUnicode(false);

            entity.HasOne(d => d.IdCategoriaNavigation).WithMany(p => p.Productos)
                .HasForeignKey(d => d.IdCategoria)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Productos_Categorias");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.IdRol);

            entity.Property(e => e.NombreRol)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Token>(entity =>
        {
            entity.HasKey(e => e.IdToken).HasName("PK__Tokens__D6332447E72F6986");

            entity.Property(e => e.Creacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Expiracion).HasColumnType("datetime");
            entity.Property(e => e.Perfil)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.Token1)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("Token");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario);

            entity.HasIndex(e => e.Correo, "IX_Usuarios").IsUnique();

            entity.HasIndex(e => e.NombreUsuario, "IX_Usuarios_1").IsUnique();

            entity.Property(e => e.Apellidos)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Clave)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Correo)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Dni)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.FechaRegistro).HasColumnType("datetime");
            entity.Property(e => e.NombreFoto)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.NombreUsuario)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Nombres)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.UrlFoto)
                .HasMaxLength(500)
                .IsUnicode(false);

            entity.HasOne(d => d.IdRolNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.IdRol)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Usuarios_Roles");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
