using DossierAPI.DTOs;
using System.ComponentModel.DataAnnotations;

namespace DossierAPI.DTOs
{
    public class TypeVoyageDTO
    {
        public int TypeVoyageId { get; set; }

        [Required]
        public string Libelle { get; set; } = string.Empty;
        public bool Actif { get; set; } = true;
    }

    public class NewTypeVoyageDTO
    {
       
        [Required]
        public string Libelle { get; set; } = string.Empty;
        public bool Actif { get; set; } = true;

        IEnumerable<DossierDTO> Dossiers { get; set; } =  new List<DossierDTO>();
    }
}
