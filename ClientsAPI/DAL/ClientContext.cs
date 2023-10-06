using ClientsAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ClientsAPI.DAL
{
    public class ClientsContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public ClientsContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // connect to sqlite database
            options.UseSqlite(Configuration.GetConnectionString("DefaultConnection"));
        }

        public DbSet<Client> Clients { get; set; }
    }
}
