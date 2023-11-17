using ProduitAPI.DTOs;

namespace ProduitAPI.Services
{
    public interface IHotelService
    {
        public bool IdExist(int ID);
        public bool HotelExist(NewHotelDTO Hotel);
        public Task<List<HotelDTO>> GetHotels();
        public Task<HotelDTO> GetHotel(int ID);

        public Task<HotelDTO?> AddHotel(NewHotelDTO newHotelDTO);

        public Task<HotelDTO> UpdateHotel(HotelDTO Hotel);
        public Task<List<HotelDTO>> DeleteHotel(int ID);
    }
}
