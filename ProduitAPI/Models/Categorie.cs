﻿using System.ComponentModel.DataAnnotations;

namespace ProduitAPI.Models
{
    public class Categorie
    {
        [Key]
        public Guid IdCategorie { get; set; }
        public string? TypeCategorie { get; set; }
        //public ICollection<Produit>? produits { get; }

    }
}
