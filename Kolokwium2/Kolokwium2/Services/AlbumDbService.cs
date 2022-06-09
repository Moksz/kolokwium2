using Kolokwium2.DTOs;
using Kolokwium2.Entities;
using Kolokwium2.Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kolokwium2.Services
{
    public class AlbumDbService : IAlbumDbService
    {
        private readonly AlbumDbContext _repository;
        public AlbumDbService(AlbumDbContext repository)
        {
            _repository = repository;
        }

        public IQueryable<AlbumGet> GetAlbum(int id)
        {
            return _repository.Album.Where(e => e.IdAlbum == id)
                .Include(e => e.Tracks).Select(e => new AlbumGet
                {
                    AlbumName = e.AlbumName,
                    PublishDate = e.PublishDate,
                    Tracks = e.Tracks.Select(e => new TrackGet
                    {
                        IdTrack = e.IdTrack,
                        TrackName = e.TrackName,
                        Duration = e.Duration
                    }).OrderBy(e=> e.Duration).ToList()
                });
        }

        public async Task<bool> CheckMusicanForDeletion(int idMusican)
        {
            try
            {
                var a = await _repository.Track
                .Include(e => e.MusicanTracks)
                .Include(e => e.Album)
                .Where(e => e.IdMusicAlbum == null && e.MusicanTracks.Any(e => e.IdMusican == idMusican)).ToArrayAsync();

                if (a.Length > 0)
                {
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
            
            

            return false;
        }

        public async Task DeleteMusican(int id)
        {
            List<MusicanTrack> mt = _repository.MusicanTrack.Where(e => e.IdMusican == id).ToList();

            foreach (var item in mt)
            {
                var entry = _repository.Entry(item);
                entry.State = EntityState.Deleted;
            }
            await _repository.SaveChangesAsync();

            var entry1 = _repository.Entry(new Musican
            {
                IdMusican = id
            });
            entry1.State = EntityState.Deleted;

            await _repository.SaveChangesAsync();
        }

    }
}
