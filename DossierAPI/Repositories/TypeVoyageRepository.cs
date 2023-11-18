using DossierAPI.Data;
using DossierAPI.DTOs;
using DossierAPI.IRepositories;
using DossierAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace DossierAPI.Repositories
{
    public class TypeVoyageRepository: ITypeVoyageRepository
    {

        private readonly DossierDbContext _dbContext;

        public TypeVoyageRepository(DossierDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<TypeVoyage?> Add(TypeVoyage typeVoyage)
        {
            _dbContext.TypeVoyages.Add(typeVoyage);
            await _dbContext.SaveChangesAsync();
            return typeVoyage;
        }

        public async Task<List<TypeVoyage>> DeleteAsync(int TypeVoyageId)
        {
            var TypeVoyage = await _dbContext.TypeVoyages.FindAsync(TypeVoyageId);
            if (TypeVoyage != null)
            {
                TypeVoyage.Actif = false;
                await _dbContext.SaveChangesAsync();
            }

            return await _dbContext.TypeVoyages.Where(TypeVoyage => TypeVoyage.Actif).ToListAsync();
        }

        public async Task<IEnumerable<TypeVoyage>> GetAllAsync()
        {
            return await _dbContext.TypeVoyages.Where(TypeVoyage => TypeVoyage.Actif).ToListAsync();
        }

        public async Task<TypeVoyage?> GetById(int TypeVoyageId)
        {
            return await _dbContext.TypeVoyages.FindAsync(TypeVoyageId);
        }

        public async Task<List<TypeVoyage>> RestoreAsync(int TypeVoyageId)
        {
            var TypeVoyage = await _dbContext.TypeVoyages.FindAsync(TypeVoyageId);
            if (TypeVoyage != null)
            {
                TypeVoyage.Actif = true;
                await _dbContext.SaveChangesAsync();
            }

            return await _dbContext.TypeVoyages.Where(TypeVoyage => TypeVoyage.Actif).ToListAsync();
        }

        public async Task<TypeVoyage?> UpdateAsync(TypeVoyage TypeVoyage)
        {
             _dbContext.Entry(TypeVoyage).State = EntityState.Modified;

            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return null;
            }

            return TypeVoyage;
        }
    }
}
