using System;
using System.Collections.Generic;
using GestionFormation.Entity;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GestionFormation.Models
{
    public class FormationViewModel
    {
        public Guid Id { get; set; }
        public string code { get; set; }
        public string Categorie { get; set; }
        public string module { get; set; }
        public  int Nombre_de_periode { get; set; }
        public  DateTime? Date_debut { get; set; }
        public DateTime? Date_fin { get; set; }
        
        public Guid? FormateurId { get; set; }
        
        public List<SelectListItem> SliFormateurs{ get; set; }

    }
}