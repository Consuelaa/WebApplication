using EntityFrameworkCore.Triggered;
using EntityFrameworkCore.Triggers;
using Microsoft.Azure.Documents;
using Microsoft.Azure.KeyVault.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Application.Models
{
    public class Activity
    {
        [Key]
        public Guid Id { get; set; }

        public DateTime Amprentare { get; set; }

        public string Medic { get; set; }

        public string  Pacient { get; set; }

        public string Manopera { get; set; }

        public string Componente { get; set; }

        public int Elemente { get; set; }

        [Display(Name ="Pret/Element")]
        public decimal Pret_Element { get; set; }


        [Display(Name = "Pret/Manopera")]
        public decimal Pret_Manopera { get {return Elemente * Pret_Element; } }

        public decimal Adaos { get; set; }


        [Display(Name = "Total Pret")]
        public decimal Pret_Final { get { return Pret_Manopera + Adaos; } }


        [Display(Name = "Status Plata")]
        public string Status_plata { get; set; }

        public DateTime Livrare { get; set; }


        [Display(Name = "Data Incasarii")]
        public DateTime Data_incasarii { get; set; }

        public string Mentiuni { get; set; }

      

    }
}
