using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Software2.Models;
namespace Software2.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Vecinos> DataVecinos { get; set; }
    public DbSet<Eventos> DataEventos { get; set; }
    public DbSet<Logos> DataLogos { get; set; }
    public DbSet<Firmas> DataFirmas { get; set; }
    //public DbSet<Pago> DataPago { get; set; }
}
