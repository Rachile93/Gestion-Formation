using System;
using System.Collections.Generic;
using GestionFormation.Entity;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GestionFormation.Models
{
    public class FormateurViewModel
    {
        public Guid Id { get; set; }
        public string code { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Adress { get; set; }
        public string Tel { get; set; }
        
        public List<Formation> SliFormations{ get; set; }
    }
}