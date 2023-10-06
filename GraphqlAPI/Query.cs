using GraphqlAPI.BO;
using GraphqlAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;

namespace GraphqlAPI
{
    public class Query
    {

        private string _baseUrlAPIClient = "http://localhost:5212";
        private string _baseUrlAPIProduit = "http://localhost:5214";
        private string _baseUrlAPIDossierVoyage = "http://localhost:5174";

        //RequestAPI(string uri, string path)
        /// <summary>
        /// Obtenir tous les clients
        /// </summary>
        /// <returns></returns>
        public async Task<List<Client>> GetAllClients()
        {
            List<Client> ListClients = new List<Client>();
            RequestAPI<Client> Clients = new RequestAPI<Client>(_baseUrlAPIClient, "/api/Clients");
            ListClients = (List<Client>)await Clients.GetDataAsync();
            return ListClients;
        }

        /// <summary>
        /// Obtenir la liste de produits
        /// API Produits
        /// </summary>
        /// <returns></returns>
        public async Task<List<Produit>> GetAllProduits()
        {
            List<Produit> ListProduits = new List<Produit>();
            RequestAPI<Produit> Produits = new RequestAPI<Produit>(_baseUrlAPIProduit, "/api/Produits");
            ListProduits = (List<Produit>)await Produits.GetDataAsync();
            return ListProduits;
        }

        public async Task<List<Ligne>> GetAllLignes()
        {
            List<Ligne> ListLignes = new List<Ligne>();
            RequestAPI<Ligne> Lignes = new RequestAPI<Ligne>(_baseUrlAPIProduit, "/api/Lignes");
            ListLignes = (List<Ligne>)await Lignes.GetDataAsync();
            return ListLignes;
        }

        /// <summary>
        /// Obtenir toutes les reservations
        /// </summary>
        /// <returns></returns>
        public async Task<List<Reservation>> GetAllReservations()
        {
            List<Reservation> ListReservations = new List<Reservation>();
            RequestAPI<Reservation> Reservations = new RequestAPI<Reservation>(_baseUrlAPIProduit, "/api/Reservations");
            ListReservations = (List<Reservation>)await Reservations.GetDataAsync();
            return ListReservations;
        }

        public async Task<List<Hotel>> GetAllHotels()
        {
            List<Hotel> ListHotels = new List<Hotel>();
            RequestAPI<Hotel> Hotels = new RequestAPI<Hotel>(_baseUrlAPIProduit, "/api/Hotels");
            ListHotels = (List<Hotel>)await Hotels.GetDataAsync();
            return ListHotels;
        }

        /// <summary>
        /// Reservations vols
        /// </summary>
        /// <returns></returns>
        public async Task<List<ReservationVol>> GetAllReservationsVols()
        {
            List<ReservationVol> ListReservations = new List<ReservationVol>();
            RequestAPI<ReservationVol> Reservations = new RequestAPI<ReservationVol>(_baseUrlAPIDossierVoyage, "/api/Reservations");
            ListReservations = (List<ReservationVol>)await Reservations.GetDataAsync();
            return ListReservations;
        }


        /// <summary>
        /// Obtenir la liste de produits
        /// API Produits
        /// </summary>
        /// <returns></returns>

        public async Task<List<DossierVoyage>> GetAllDossierVoyages(string Nom, string Prenom)
        {

            ///
            List<Reservation> ListReservations = await GetAllReservations();            
            Client clientRequest = await GetClientParNomAndPrenom(Nom, Prenom);
            Reservation reservation = ListReservations.Where(r => r.ClientId == clientRequest.IdClient).FirstOrDefault();

            /////////
            List<ReservationVol> ListReservationsVol = await GetAllReservationsVols();
            ReservationVol reservationVol = ListReservationsVol.Where(r => r.ClientId == clientRequest?.IdClient).FirstOrDefault();

            //////////////////////////////
            List<Ligne> ListLigneReservation = await GetAllLignes();
            Ligne ligneProduit = ListLigneReservation.Where(r => r.ReservationId == reservation.IdReservation).FirstOrDefault();

            //////////////////////////////
            List<Produit> ListProduit = await GetAllProduits();
            Produit produit = ListProduit.Where(p => p.IdProduit == ligneProduit.ProduitId).FirstOrDefault();

            //////////////////////////////
            List<Hotel> ListHotel = await GetAllHotels();
            Hotel Hotel = ListHotel.Where(p => p.IdHotel == produit.Hotelid).FirstOrDefault();





            List<DossierVoyage> DossierVoyages = new List<DossierVoyage>()
            {
                new DossierVoyage()
                {
                    Client = clientRequest,
                    ReservationHotel = reservation,
                    ReservationVol = reservationVol,
                    Ligne = ligneProduit,
                    Produit =  produit,
                    Hotel = Hotel

                }
            };
           
            

            return DossierVoyages;   //ListProduits;
        }


        /// <summary>
        /// Rechercher un client par Nom et Prénom
        /// API Clients
        /// </summary>
        /// <param name="Nom"></param>
        /// <param name="Prenom"></param>
        /// <returns></returns>
        public async Task<Client> GetClientParNomAndPrenom(string Nom, string Prenom)
        {
            List<Client> ListClients = new List<Client>();
            RequestAPI<Client> Clients = new RequestAPI<Client>(_baseUrlAPIClient, "/api/Clients");
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
