using Microsoft.EntityFrameworkCore;
using ProduitAPI.Models;

namespace ProduitAPI.DAL
{
    public class ProduitContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public ProduitContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // connect to sqlite database
            options.UseSqlite(Configuration.GetConnectionString("DefaultConnection"));
        }

        public DbSet<Produit> Produits { get; set; }
        public DbSet<Categorie> Categories { get; set; }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Ligne> Lignes { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Client> Clients { get; set; }
    }
}
