using Graph.BO;
using Graph.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;

namespace Graph
{
    public class Query
    {

        //RequestAPI(string uri, string path)

        public async Task<List<Client>> GetAllClients()
        {
            List<Client> ListClients = new List<Client>();
            RequestAPI<Client> Clients = new RequestAPI<Client>("http://localhost:5212", "/api/Clients");
            ListClients = (List<Client>)await Clients.GetDataAsync();
            return ListClients;
        }
        public async Task<List<Produit>> GetAllProduits()
        {
            List<Produit> ListProduits = new List<Produit>();
            RequestAPI<Produit> Produits = new RequestAPI<Produit>("http://localhost:5214", "/api/Produits");
            ListProduits = (List<Produit>)await Produits.GetDataAsync();
            return ListProduits;
        }

        public async Task<Client> GetClientParNomAndPrenom(string Nom, string Prenom)
        {
            List<Client> ListClients = new List<Client>();
            RequestAPI<Client> Clients = new RequestAPI<Client>("http://localhost:5212", "/api/Clients");
            ListClients = (List<Client>)await Clients.GetDataAsync();
            Client cl = ListClients.Where(p => p.Nom == Nom && p.Prenom == Prenom).FirstOrDefault();
            return cl;
        }

        /*
        public async Task<Client> GetClientByNameAndPrenom(string Nom, string Prenom)
        {
            Client Client = new Client();
          
            return Client;
        }
        */

        /*
        public async Task<List<Client>> GetAllClients()
        {
            List<Client> ListClients = new List<Client>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("http://localhost:5212/api/Clients"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    ListClients = JsonConvert.DeserializeObject<List<Client>>(apiResponse);
                }
            }
            return ListClients;
        }

        public async Task<Client> GetClientById(Guid Id)
        {
            Client Client = new Client();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("http://localhost:5212/api/Clients/" + Id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    Client = JsonConvert.DeserializeObject<Client>(apiResponse);
                }
            }
            return Client;
        }

        public async Task<Client> GetClientByNameAndPrenom(string Nom, string Prenom)
        {
            Client Client = new Client();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync($"http://localhost:5212/api/Clients/Params?Nom={Nom}&Prenom={Prenom}"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    Client = JsonConvert.DeserializeObject<Client>(apiResponse);
                }
            }
            return Client;
        }
        */

        /*
        public Book GetBook() =>
        new Book
        {
            Title = "C# in depth.",
            Author = new Author
            {
                Name = "Jon Skeet"
            }
        };
        */
    }
}
