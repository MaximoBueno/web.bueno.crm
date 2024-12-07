using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace web.bueno.crm.infraestructure.Contexts;

public partial class CrmliaContext : DbContext
{
    public CrmliaContext()
    {
    }

    public CrmliaContext(DbContextOptions<CrmliaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Campana> Campanas { get; set; }

    public virtual DbSet<CampanaGestor> CampanaGestors { get; set; }

    public virtual DbSet<CampanaProducto> CampanaProductos { get; set; }

    public virtual DbSet<Contacto> Contactos { get; set; }

    public virtual DbSet<ContactoAtencion> ContactoAtencions { get; set; }

    public virtual DbSet<ContactoCorreo> ContactoCorreos { get; set; }

    public virtual DbSet<ContactoDireccion> ContactoDireccions { get; set; }

    public virtual DbSet<ContactoResuman> ContactoResumen { get; set; }

    public virtual DbSet<ContactoTelefono> ContactoTelefonos { get; set; }

    public virtual DbSet<Gestor> Gestors { get; set; }

    public virtual DbSet<Persona> Personas { get; set; }

    public virtual DbSet<Producto> Productos { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-91LF3T8\\SQLEXPRESS; DataBase=CRMLia; Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Campana>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Campana__3214EC0740837D5B");

            entity.ToTable("Campana");

            entity.Property(e => e.Descripcion)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
            entity.Property(e => e.FechaFin).HasColumnType("datetime");
            entity.Property(e => e.FechaInicio).HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");
            entity.Property(e => e.NombreCampana)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<CampanaGestor>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__CampanaG__3214EC070F6BBA68");

            entity.ToTable("CampanaGestor");

            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");

            entity.HasOne(d => d.IdCampanaNavigation).WithMany(p => p.CampanaGestors)
                .HasForeignKey(d => d.IdCampana)
                .HasConstraintName("FK_Campana_01_Temp");
        });

        modelBuilder.Entity<CampanaProducto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__CampanaP__3214EC076C4C1C50");

            entity.ToTable("CampanaProducto");

            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");

            entity.HasOne(d => d.IdCampanaNavigation).WithMany(p => p.CampanaProductos)
                .HasForeignKey(d => d.IdCampana)
                .HasConstraintName("FK_Campana_02_Temp");

            entity.HasOne(d => d.IdProductoNavigation).WithMany(p => p.CampanaProductos)
                .HasForeignKey(d => d.IdProducto)
                .HasConstraintName("FK_Producto_01_Temp");
        });

        modelBuilder.Entity<Contacto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Contacto__3214EC0708EF84EA");

            entity.ToTable("Contacto");

            entity.Property(e => e.ApellidoMaterno)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.ApellidoPaterno)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");
            entity.Property(e => e.Nombres)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.NumeroDocumento)
                .HasMaxLength(60)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ContactoAtencion>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Contacto__3214EC0730B36DAB");

            entity.ToTable("ContactoAtencion");

            entity.Property(e => e.FechaAtencion).HasColumnType("datetime");
            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");
            entity.Property(e => e.Observacion)
                .HasMaxLength(200)
                .IsUnicode(false);

            entity.HasOne(d => d.IdContactoNavigation).WithMany(p => p.ContactoAtencions)
                .HasForeignKey(d => d.IdContacto)
                .HasConstraintName("FK_Contacto_04_Temp");
        });

        modelBuilder.Entity<ContactoCorreo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Contacto__3214EC07DF39AF58");

            entity.ToTable("ContactoCorreo");

            entity.Property(e => e.Correo)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");

            entity.HasOne(d => d.IdContactoNavigation).WithMany(p => p.ContactoCorreos)
                .HasForeignKey(d => d.IdContacto)
                .HasConstraintName("FK_Contacto_02_Temp");
        });

        modelBuilder.Entity<ContactoDireccion>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Contacto__3214EC071E1EAA71");

            entity.ToTable("ContactoDireccion");

            entity.Property(e => e.Ciudad)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Direccion)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");
            entity.Property(e => e.Referencia)
                .HasMaxLength(150)
                .IsUnicode(false);

            entity.HasOne(d => d.IdContactoNavigation).WithMany(p => p.ContactoDireccions)
                .HasForeignKey(d => d.IdContacto)
                .HasConstraintName("FK_Contacto_03_Temp");
        });

        modelBuilder.Entity<ContactoResuman>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Contacto__3214EC07A9C270DD");

            entity.Property(e => e.FechaAtencion).HasColumnType("datetime");
            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");
            entity.Property(e => e.Precio).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.IdContactoNavigation).WithMany(p => p.ContactoResumen)
                .HasForeignKey(d => d.IdContacto)
                .HasConstraintName("FK_Contacto_05_Temp");
        });

        modelBuilder.Entity<ContactoTelefono>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Contacto__3214EC07C3812550");

            entity.ToTable("ContactoTelefono");

            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");
            entity.Property(e => e.NumeroTelefono)
                .HasMaxLength(60)
                .IsUnicode(false);

            entity.HasOne(d => d.IdContactoNavigation).WithMany(p => p.ContactoTelefonos)
                .HasForeignKey(d => d.IdContacto)
                .HasConstraintName("FK_Contacto_01_Temp");
        });

        modelBuilder.Entity<Gestor>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Gestor__3214EC07596BB40C");

            entity.ToTable("Gestor");

            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Gestors)
                .HasForeignKey(d => d.IdUsuario)
                .HasConstraintName("FK_Usuario_01_Temp");
        });

        modelBuilder.Entity<Persona>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Persona__3214EC07860DC9BC");

            entity.ToTable("Persona");

            entity.Property(e => e.ApellidoMaterno)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.ApellidoPaterno)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");
            entity.Property(e => e.Nombres)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.NumeroDocumento)
                .HasMaxLength(60)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Producto__3214EC071EAC27A3");

            entity.ToTable("Producto");

            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");
            entity.Property(e => e.NombreProducto)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Precio).HasColumnType("decimal(10, 2)");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Usuario__3214EC076AE9CD73");

            entity.ToTable("Usuario");

            entity.Property(e => e.Clave)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.Correo)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");
            entity.Property(e => e.NombreCompleto)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.IdPersonaNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.IdPersona)
                .HasConstraintName("FK_Persona_01_Temp");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
