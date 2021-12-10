using System;

namespace GestionFormation.Entity
{
    public class Formation
    {
        public Guid Id { get; set; }
        public string code { get; set; }
        public string Categorie { get; set; }
        public string module { get; set; }
        public  int Nombre_de_periode { get; set; }
        public  DateTime? Date_debut { get; set; }
        public DateTime? Date_fin { get; set; }
        public virtual Formateur  Formateur { get; set; }
    }
}