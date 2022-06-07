using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFKolokwium.Models;
using EFKolokwium.Models.DTO;
using Microsoft.EntityFrameworkCore;

namespace EFKolokwium.Services
{
    public class DbService : IDbService
    {
        private readonly MainDbContext _dbContext;
        public DbService(MainDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        public async Task<IEnumerable<object>> GetAlbum(int idAlbum)
        {
            {
                return await _dbContext.Albums
                    .Where(e => e.IdAlbum == idAlbum)
                    .Select(e => new SomeAlbum
                    {
                        AlbumName = e.AlbumName,
                        PublishDate = e.PublishDate
                    }).ToListAsync();
            }
        }

        public async Task<bool> RemoveMusician(int idMusician)
        {
            if(_dbContext.Musicians.Any(e => e.IdMusician == idMusician))
            {
                var musician = new Musician() { IdMusician = idMusician };
                _dbContext.Attach(musician);
                _dbContext.Remove(musician);
                await _dbContext.SaveChangesAsync();
                return true;
            } else return false;
        }
    }
}