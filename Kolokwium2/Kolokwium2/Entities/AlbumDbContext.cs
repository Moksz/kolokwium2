using Kolokwium2.Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kolokwium2.Entities
{
    public class AlbumDbContext : DbContext
    {
        public AlbumDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Album> Album { get; set; }
        public DbSet<Musican> Musican { get; set; }
        public DbSet<MusicanTrack> MusicanTrack { get; set; }
        public DbSet<MusicLabel> MusicLabel { get; set; }
        public DbSet<Track> Track { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Album>(e =>
            {
                e.ToTable("Album");
                e.HasKey(e => e.IdAlbum);

                e.Property(e => e.AlbumName).HasMaxLength(30).IsRequired(true);
                e.Property(e => e.PublishDate).IsRequired(true);

                e.HasOne(e => e.MusicLabel).WithMany(e => e.Albums).HasForeignKey(e => e.IdMusicLabel).OnDelete(DeleteBehavior.Cascade);

                e.HasData(new Album
                {
                    IdAlbum = 1,
                    AlbumName = "aaa",
                    PublishDate = DateTime.Now,
                    IdMusicLabel = 1
                });
            });

            modelBuilder.Entity<Musican>(e =>
            {
                e.ToTable("Musican");
                e.HasKey(e => e.IdMusican);

                e.Property(e => e.FirstName).HasMaxLength(30).IsRequired(true);
                e.Property(e => e.LastName).HasMaxLength(50).IsRequired(true);
                e.Property(e => e.Nickname).HasMaxLength(20).IsRequired(false);

                e.HasData(new Musican
                {
                    IdMusican = 1,
                    FirstName = "aaa",
                    LastName = "bbb",
                    Nickname = "ccc"
                });
            });

            modelBuilder.Entity<MusicanTrack>(e =>
            {
                e.ToTable("Musican_Track");
                e.HasKey(e => new { e.IdTrack, e.IdMusican });

                e.HasOne(e => e.Musican).WithMany(e => e.MusicanTracks).HasForeignKey(e => e.IdMusican).OnDelete(DeleteBehavior.Cascade);
                e.HasOne(e => e.Track).WithMany(e => e.MusicanTracks).HasForeignKey(e => e.IdTrack).OnDelete(DeleteBehavior.Cascade);

                e.HasData(new MusicanTrack
                {
                    IdMusican = 1,
                    IdTrack = 1
                });
            });

            modelBuilder.Entity<MusicLabel>(e =>
            {
                e.ToTable("MusicLabel");
                e.HasKey(e => e.IdMusicLabel);

                e.Property(e => e.Name).HasMaxLength(50).IsRequired(true);

                e.HasData(new MusicLabel
                {
                    IdMusicLabel = 1,
                    Name = "label"
                });
            });

            modelBuilder.Entity<Track>(e =>
            {
                e.ToTable("Track");
                e.HasKey(e => e.IdTrack);

                e.Property(e => e.TrackName).HasMaxLength(20).IsRequired(true);
                e.Property(e => e.Duration).IsRequired(true);
                e.Property(e => e.IdMusicAlbum).IsRequired(false);

                e.HasOne(e => e.Album).WithMany(e => e.Tracks).HasForeignKey(e => e.IdMusicAlbum).OnDelete(DeleteBehavior.Cascade);

                e.HasData(new Track
                {
                    IdTrack = 1,
                    TrackName = "track",
                    Duration = 1.5,
                    IdMusicAlbum = 1
                });
            });
        }
    }
}
