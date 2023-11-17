using System.ComponentModel.DataAnnotations;

namespace ClientAPI.DTOs
{
    public class ClientDTO
    {
 
        public int ClientId { get; set; }
        [Required]
        public string Nom { get; set; } = string.Empty;
        [Required]
        public string Prenom { get; set; } = string.Empty;
        [Required]
        public string Adresse { get; set; } = string.Empty;
        [DataType(DataType.Date)]
        public DateTime? DateDeNaissance { get; set; }
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
        [Phone]
        public string NumeroTelephone { get; set; } = string.Empty;
        public string Nationalite { get; set; } = string.Empty;
        public bool Actif { get; set; } = true;
    }


    public class NewClientDTO
    {

        [Required]
        public string Nom { get; set; } = string.Empty;
        [Required]
        public string Prenom { get; set; } = string.Empty;
        [Required]
        public string Adresse { get; set; } = string.Empty;
        [DataType(DataType.Date)]
        public DateTime? DateDeNaissance { get; set; }
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
        [Phone]
        public string NumeroTelephone { get; set; } = string.Empty;
        public string Nationalite { get; set; } = string.Empty;
        public bool Actif { get; set; } = true;
    }
}
