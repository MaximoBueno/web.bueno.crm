using System;
using System.Collections.Generic;

using Microsoft.EntityFrameworkCore;
using web.bueno.crm.domain.sql;

namespace web.bueno.crm.infraestructure.Contexts;

public class CrmLiaContext : DbContext
{
  

    public CrmLiaContext(DbContextOptions<CrmLiaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Campana> Campana { get; set; }

    public virtual DbSet<CampanaGestor> CampanaGestor { get; set; }

    public virtual DbSet<CampanaProducto> CampanaProducto { get; set; }

    public virtual DbSet<Contacto> Contacto { get; set; }

    public virtual DbSet<ContactoAtencion> ContactoAtencion { get; set; }

    public virtual DbSet<ContactoCorreo> ContactoCorreo { get; set; }

    public virtual DbSet<ContactoDireccion> ContactoDireccion { get; set; }

    public virtual DbSet<ContactoResumen> ContactoResumen { get; set; }

    public virtual DbSet<ContactoTelefono> ContactoTelefono { get; set; }

    public virtual DbSet<Gestor> Gestor { get; set; }

    public virtual DbSet<Persona> Persona { get; set; }

    public virtual DbSet<Producto> Producto { get; set; }

    public virtual DbSet<Usuario> Usuario { get; set; }

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
