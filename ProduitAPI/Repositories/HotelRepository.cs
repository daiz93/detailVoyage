using ProduitAPI.Data;
using ProduitAPI.DTOs;
using ProduitAPI.IRepositories;
using ProduitAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ProduitAPI.Repositories
{
    public class HotelRepository: IHotelRepository
    {

        private readonly ProduitDbContext _dbContext;

        public HotelRepository(ProduitDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Hotel?> Add(Hotel hotel)
        {
            _dbContext.Hotels.Add(hotel);
            await _dbContext.SaveChangesAsync();
            return hotel;
        }

        public async Task<List<Hotel>> DeleteAsync(int HotelId)
        {
            var Hotel = await _dbContext.Hotels.FindAsync(HotelId);
            if (Hotel != null)
            {
                Hotel.Actif = false;
                await _dbContext.SaveChangesAsync();
            }

            return await _dbContext.Hotels.Where(Hotel => Hotel.Actif).ToListAsync();
        }

        public async Task<IEnumerable<Hotel>> GetAllAsync()
        {
            return await _dbContext.Hotels.Where(Hotel => Hotel.Actif).ToListAsync();
        }

        public async Task<Hotel?> GetById(int HotelId)
        {
            return await _dbContext.Hotels.FindAsync(HotelId);
        }

        public async Task<List<Hotel>> RestoreAsync(int HotelId)
        {
            var Hotel = await _dbContext.Hotels.FindAsync(HotelId);
            if (Hotel != null)
            {
                Hotel.Actif = true;
                await _dbContext.SaveChangesAsync();
            }

            return await _dbContext.Hotels.Where(Hotel => Hotel.Actif).ToListAsync();
        }

        public async Task<Hotel?> UpdateAsync(Hotel Hotel)
        {
             _dbContext.Entry(Hotel).State = EntityState.Modified;

            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return null;
            }

            return Hotel;
        }
    }
}
