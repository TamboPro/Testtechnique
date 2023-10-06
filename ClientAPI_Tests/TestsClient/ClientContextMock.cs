using ClientAPI.DAL;
using ClientAPI.Models;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Common;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientAPI_Tests.TestsClient
{
    internal class ClientContextMock
    {
        private DbConnection _connexion;
        private DbContextOptions<ClientContext> _contextOptions;
        public ClientContext Context { get; }


        public ClientContextMock() {

            _connexion = new SqliteConnection("Filename=:memory:");
            _connexion.Open();
            _contextOptions = new DbContextOptionsBuilder<ClientContext>().UseSqlite(_connexion).Options;


            //Pour lancer les tests unitaires, il faut décommenter un ligne dans le ClientContext et recommenter après les tests
            Context = new ClientContext(_contextOptions);
            Context.Database.EnsureCreated();

            // Jeu de données
            Client C1 = new Client { IdClient = new Guid("c674f805-92e8-498d-864b-da1f9c0f12cd"), DateNaissance = DateTime.Parse("2023-10-03T15:52:02.418", new CultureInfo("fr-FR")), Nom = "Gédéon", Prenom = "NFONGYELE", Adresse = "NKOLBISSON", Email = "g.nfongyele@gmail.com" };
            Client C2 = new Client { IdClient = new Guid("ca600fc3-876a-4f36-958c-00c8e8e38d1c"), DateNaissance = DateTime.Parse("2023-10-03T17:16:26.058", new CultureInfo("fr-FR")), Nom = "Tambo", Prenom = "Gédéon", Adresse = "Logbessou", Email = "innovalab237@gmail.com" };
            Context.Clients.Add(C1);
            Context.Clients.Add(C2);
        }

        public void Dispose() => _connexion.Dispose();


    }
}

/*
[
  {
    "idClient": "c674f805-92e8-498d-864b-da1f9c0f12cd",
    "nom": "Gédéon",
    "prenom": "NFONGYELE",
    "dateNaissance": "2023-10-03T15:52:02.418",
    "adresse": "NKOLBISSON",
    "email": "g.nfongyele@gmail.com"
  },
  {
    "idClient": "ca600fc3-876a-4f36-958c-00c8e8e38d1c",
    "nom": "Tambo",
    "prenom": "Gédéon",
    "dateNaissance": "2023-10-03T17:16:26.058",
    "adresse": "Logbessou",
    "email": "innovalab237@gmail.com"
  }
]
*/