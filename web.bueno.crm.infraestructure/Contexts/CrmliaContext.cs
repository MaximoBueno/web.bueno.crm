using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using web.bueno.crm.domain.sql;

namespace web.bueno.crm.infraestructure.Contexts;

public partial class CrmliaContext : DbContext
{
  

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

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {

    }

    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
       //its bd firts
    }

}
