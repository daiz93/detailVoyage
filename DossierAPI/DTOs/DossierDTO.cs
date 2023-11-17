using DossierAPI.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DossierAPI.DTOs
{
    public class DossierDTO
    {
        [Key]
        public int DossierId { get; set; }

        // Clé étrangère vers TypeVoyage        
        public int TypeVoyageId { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DateArrivee { get; set; }

        public int DureeSejourJours { get; set; }

        public string NumeroVol { get; set; } = string.Empty;

        public string Lieu { get; set; } = string.Empty;
        public bool Actif { get; set; } = true;
    }


    


        public class NewDossierDTO
    {
     
        // Clé étrangère vers TypeVoyage        
        public int TypeVoyageId { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DateArrivee { get; set; }

        public int DureeSejourJours { get; set; }

        public string NumeroVol { get; set; } = string.Empty;

        public string Lieu { get; set; } = string.Empty;
        public bool Actif { get; set; } = true;
    }
}
