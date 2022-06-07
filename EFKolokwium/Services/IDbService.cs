using System.Collections.Generic;
using System.Threading.Tasks;

namespace EFKolokwium.Services
{
    public interface IDbService
    {
        Task<IEnumerable<object>> GetAlbum(int idAlbum);
        Task<bool> RemoveMusician(int idMusician);
    }
}