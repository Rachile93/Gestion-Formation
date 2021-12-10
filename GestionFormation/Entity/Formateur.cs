using System;
using System.Collections.Generic;

namespace GestionFormation.Entity
{
    public class Formateur
    {
        public Guid Id { get; set; }
        public string code { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Adress { get; set; }
        public string Tel { get; set; }
        public virtual ICollection<Formation> ListFormations { get; set; }
    }
}