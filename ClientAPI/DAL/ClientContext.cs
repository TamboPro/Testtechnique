using ClientAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ClientAPI.DAL
{
    public class ClientContext : DbContext
    {
        protected readonly IConfiguration Configuration;


        public ClientContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }



        /// <summary>
        /// A décommenter pour faire les tests unitaires et commenter pour lancer l'API
        /// </summary>
        /// <param name="options"></param>
        /*
        public ClientContext(DbContextOptions options) : base(options)
        {
        }
        */

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>().HasData(
                new Client
                {
                    IdClient = Guid.NewGuid(),
                    Adresse = "Yaounde Nkolbisson",
                    DateNaissance = DateTime.UtcNow.ToLocalTime(),
                    Email = "g.nfongyele@gmail.com",
                    Nom = "tambo",
                    Prenom = "Gédéon"
                },
                 new Client
                {
                    IdClient = Guid.NewGuid(),
                    Adresse = "Douala Logbessou",
                    DateNaissance = DateTime.UtcNow.ToLocalTime(),
                    Email = "innovalab237@gmail.com",
                    Nom = "tambo",
                    Prenom = "Gédéon"
                }
            );
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // connect to sqlite database
            options.UseSqlite(Configuration.GetConnectionString("DefaultConnection"));
        }

        public DbSet<Client> Clients { get; set; }

        
    }
}
