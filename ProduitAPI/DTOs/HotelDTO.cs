namespace ProduitAPI.DTOs
{
    public class HotelDTO
    {
        public int HotelId { get; set; }
        public string Nom { get; set; }
        public string Description { get; set; }
        public decimal Prix { get; set; }
        public string Fabricant { get; set; }
        public int NombreEtoiles { get; set; }
        public string Ville { get; set; }
        public string Pays { get; set; }
        public string Adresse { get; set; }
        public bool Actif { get; set; } = true;
    }

    public class NewHotelDTO
    {
        public string Nom { get; set; }
        public string Description { get; set; }
        public decimal Prix { get; set; }
        public string Fabricant { get; set; }
        public int NombreEtoiles { get; set; }
        public string Ville { get; set; }
        public string Pays { get; set; }
        public string Adresse { get; set; }
        public bool Actif { get; set; } = true;
    }
}



