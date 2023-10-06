using DossierAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace DossierAPI.DAL
{
    public class DossierContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public DossierContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// A décommenter pour faire les tests unitaires et commenter pour lancer l'API
        /// </summary>
        /// <param name="options"></param>
        /*
        public DossierContext(DbContextOptions options) : base(options)
        {
        }*/




        // 800e8c07-cbab-4e73-9535-9c0df16fdde0 a53ebe29-2923-43f1-b486-f66ec90a89c3
        /*
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categorie>().HasData(
                new Categorie
                {
                   IdCategorie = new Guid("811e8c07-cbab-4e73-9535-9c0df16fdde7"),
                   TypeCategorie = "First class",                   
                    Vols = new[]
                    {
                                new Vol
                        {
                           IdVol = new Guid("844e8c07-cbab-4e73-9535-9c0df16fdde7"),
                           Numero = 1000,
                           Prix = 500,
                           Categorie = new Categorie
                           {
                               IdCategorie = new Guid("822e8c07-cbab-4e73-9535-9c0df16fdde8"),
                               TypeCategorie = "International",
                           },
                           Compagnie = new Compagnie
                           {
                               IdCompagnie = new Guid("833e8c07-cbab-4e73-9535-9c0df16fdde7"),
                               NomCompagnie = "TuiFly",
                               Pays = "Belgique",
                               Ville = "Brussels",

                           },
                           Reference = "TUI235"
                            
                        }
                    }
                }                 
            );
            modelBuilder.Entity<Compagnie>().HasData(
                new Compagnie
                {
                    IdCompagnie = new Guid("833e8c07-cbab-4e73-9535-9c0df16fdde7"),
                    NomCompagnie = "TuiFly",
                    Pays = "Belgique",
                    Ville = "Brussels",
                    Vols = new[]
                    {
                        new Vol
                        {
                           IdVol = new Guid("844e8c07-cbab-4e73-9535-9c0df16fdde7"),
                           Numero = 1000,
                           Prix = 500,
                           Categorie = new Categorie
                           {
                               IdCategorie = new Guid("822e8c07-cbab-4e73-9535-9c0df16fdde8"),
                               TypeCategorie = "International",
                           },
                           Compagnie = new Compagnie
                           {
                               IdCompagnie = new Guid("833e8c07-cbab-4e73-9535-9c0df16fdde7"),
                               NomCompagnie = "TuiFly",
                               Pays = "Belgique",
                               Ville = "Brussels",

                           },
                           Reference = "TUI235"
                            
                        }
                    }
                }
            );
            modelBuilder.Entity<Client>().HasData(
                new Client
                {
                    IdClient  = new Guid("800e8c07-cbab-4e73-9535-9c0df16fdde0"),
                }
            );
                     

            modelBuilder.Entity<Billet>().HasData(
               new Billet
               {
                   IdBillet = new Guid("822e8c07-cbab-4e73-9535-9c0df16fdde8"),
                   Prix = 500,
                   Quantite = 2,
                   Vol = new Vol
                   {
                       IdVol = new Guid("844e8c07-cbab-4e73-9535-9c0df16fdde7"),
                       Numero = 1000,
                       Prix = 500,
                       Categorie = new Categorie
                       {
                           IdCategorie = new Guid("822e8c07-cbab-4e73-9535-9c0df16fdde8"),
                           TypeCategorie = "International",
                       },
                       Compagnie = new Compagnie
                       {
                           IdCompagnie = new Guid("833e8c07-cbab-4e73-9535-9c0df16fdde7"),
                           NomCompagnie = "TuiFly",
                           Pays = "Belgique",
                           Ville = "Brussels",

                       },
                       Reference = "TUI235"
                         
                   },
                   DateReservation = DateTime.UtcNow.ToLocalTime(),
                   Reservation = new Reservation
                   {
                       IdReservation = new Guid("855e8c07-cbab-4e73-9535-9c0df16fdde7"),
                       Numero = "2000",
                       DateReservationVol = DateTime.UtcNow.ToLocalTime(),
                       client = new Client
                       {
                           IdClient = new Guid("800e8c07-cbab-4e73-9535-9c0df16fdde0"),
                       }
                   }
                     
               }
           );
            modelBuilder.Entity<Reservation>().HasData(
            new Reservation
            {
                IdReservation = new Guid("855e8c07-cbab-4e73-9535-9c0df16fdde7"),
                Numero = "2000",
                DateReservationVol = DateTime.UtcNow.ToLocalTime(),
                client = new Client
                {
                    IdClient = new Guid("800e8c07-cbab-4e73-9535-9c0df16fdde0"),
                },
                Billets = new List<Billet> {


                       new Billet
                       {
                           IdBillet = new Guid("822e8c07-cbab-4e73-9535-9c0df16fdde8"),
                           Prix = 500,
                           Quantite = 2,
                           Vol = new Vol
                           {
                               IdVol = new Guid("844e8c07-cbab-4e73-9535-9c0df16fdde7"),
                               Numero = 1000,
                               Prix = 500,
                               Categorie = new Categorie
                               {
                                   IdCategorie = new Guid("822e8c07-cbab-4e73-9535-9c0df16fdde8"),
                                   TypeCategorie = "International",
                               },
                               Compagnie = new Compagnie
                               {
                                   IdCompagnie = new Guid("833e8c07-cbab-4e73-9535-9c0df16fdde7"),
                                   NomCompagnie = "TuiFly",
                                   Pays = "Belgique",
                                   Ville = "Brussels",

                               },
                               Reference = "TUI235"

                           },
                           DateReservation = DateTime.UtcNow.ToLocalTime(),
                           Reservation = new Reservation
                           {
                               IdReservation = new Guid("855e8c07-cbab-4e73-9535-9c0df16fdde7"),
                               Numero = "2000",
                               DateReservationVol = DateTime.UtcNow.ToLocalTime(),
                               client = new Client
                               {
                                   IdClient = new Guid("800e8c07-cbab-4e73-9535-9c0df16fdde0"),
                               }
                           }

                       }

                }
                
            }
          );
            modelBuilder.Entity<Vol>().HasData(
                new Vol
                {
                   IdVol = new Guid("844e8c07-cbab-4e73-9535-9c0df16fdde7"),
                   Numero = 1000,
                   Prix = 500,
                   Categorie = new Categorie
                   {
                       IdCategorie = new Guid("822e8c07-cbab-4e73-9535-9c0df16fdde8"),
                       TypeCategorie = "International",                        
                   },
                   Compagnie = new Compagnie
                   {
                       IdCompagnie = new Guid("833e8c07-cbab-4e73-9535-9c0df16fdde7"),
                       NomCompagnie = "TuiFly",
                       Pays = "Belgique",
                       Ville = "Brussels",

                   },
                   Reference = "TUI235"
                     
                }
            );

        }*/

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // connect to sqlite database
            options.UseSqlite(Configuration.GetConnectionString("DefaultConnection"));
        }

        public DbSet<Vol> Vols { get; set; }
        public DbSet<Categorie> Categories { get; set; }
        public DbSet<Compagnie> Compagnies { get; set; }
        public DbSet<Billet> Billets { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Client> Clients { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Vol>().Property(v => v.IdVol).HasMaxLength(50);
            modelBuilder.Entity<Vol>().Property(v => v.Reference).HasMaxLength(50);

            
            /*
            modelBuilder.Entity<Vol>().HasMany(v => v.Billets)
                                      .WithOne(b => b.Vol)
                                      .HasForeignKey(e => e.VolId)
                                      .IsRequired();
            */

            /*
            modelBuilder.Entity<Reservation>().HasMany<Billet>(b => b.Billets)
                                              .WithOne(r => r.Reservation)
                                              .HasForeignKey(b => b.ReservationId)
                                              .IsRequired();
            */

            /*
            modelBuilder.Entity<Client>().HasMany<Reservation>(r => r.reservations)
                                         .WithOne(c => c.client)
                                         .HasForeignKey(e => e.ClientId)
                                         .IsRequired();
            */

            /*
            modelBuilder.Entity<Compagnie>().HasMany<Vol>(v => v.Vols)
                                            .WithOne(c => c.Compagnie)
                                            .HasForeignKey(e => e.CompanieId)
                                            .IsRequired();
            */

            /*
            modelBuilder.Entity<Categorie>().HasMany<Vol>(v => v.Vols)
                                            .WithOne(c => c.Categorie)
                                            .HasForeignKey(v => v.CategorieId)
                                            .IsRequired();
            */
           


        }
    }
}
