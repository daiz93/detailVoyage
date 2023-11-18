using ProduitAPI.Models;

namespace ProduitAPI.IRepositories
{
    public interface IHotelRepository
    {
        Task<Hotel?> GetById(int HotelId);
        Task<IEnumerable<Hotel>> GetAllAsync();
        Task<Hotel?> Add(Hotel Hotel);
        Task<Hotel?> UpdateAsync(Hotel Hotel);
        Task<List<Hotel>> DeleteAsync(int HotelId);
        Task<List<Hotel>> RestoreAsync(int HotelId);
    }
}
