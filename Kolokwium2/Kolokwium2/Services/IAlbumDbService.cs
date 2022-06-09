using Kolokwium2.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kolokwium2.Services
{
    public interface IAlbumDbService
    {
        public IQueryable<AlbumGet> GetAlbum(int id);
        public Task<bool> CheckMusicanForDeletion(int idMusican);
        public Task DeleteMusican(int id);
    }
}
