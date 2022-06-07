using System;
using Microsoft.EntityFrameworkCore;

namespace EFKolokwium.Models
{
    public class MainDbContext : DbContext
    {
        protected MainDbContext()
        {
        }

        public DbSet<Musician> Musicians { get; set; }
        public DbSet<MusicLabel> MusicLabels { get; set; }
        public DbSet<Album> Albums { get; set; }
        public DbSet<Track> Tracks { get; set; }
        public DbSet<MusicianTrack> MusicianTracks { get; set; }

        public MainDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Musician>(m =>
            {
                m.HasKey(e => e.IdMusician);
                m.Property(e => e.FirstName).IsRequired().HasMaxLength(30);
                m.Property(e => e.LastName).IsRequired().HasMaxLength(50);
                m.Property(e => e.Nickname).HasMaxLength(20);

                m.HasData(
                    new Musician { IdMusician = 1, FirstName = "Jan", LastName = "Kowalski", Nickname = "Geniusz" },
                    new Musician { IdMusician = 2, FirstName = "Alicja", LastName = "Nowakowska", Nickname = "Piłka" }
                );
            });
            modelBuilder.Entity<MusicLabel>(ml =>
            {
                ml.HasKey(e => e.IdMusicLabel);
                ml.Property(e => e.Name).IsRequired().HasMaxLength(50);



                ml.HasData(
                    new MusicLabel { IdMusicLabel = 1, Name = "DMC" }
                );
            });
            modelBuilder.Entity<Album>(a =>
            {
                a.HasKey(e => e.IdAlbum);
                a.Property(e => e.AlbumName).IsRequired().HasMaxLength(30);
                a.Property(e => e.PublishDate).IsRequired();
                a.HasOne(e => e.MusicLabel).WithMany(e => e.Albums).HasForeignKey(e => e.IdMusicLabel);

                a.HasData(
                    new Album { IdAlbum = 1, AlbumName = "Prop", PublishDate = DateTime.Parse("2022-06-20"), IdMusicLabel = 1},
                    new Album { IdAlbum = 2, AlbumName = "Prop2", PublishDate = DateTime.Parse("2023-06-20"), IdMusicLabel = 1}
                   
                );
            });
            modelBuilder.Entity<Track>(t =>
            {
                t.HasKey(e => e.IdTrack);
                t.Property(e => e.TrackName).IsRequired().HasMaxLength(20);
                t.Property(e => e.Duration).IsRequired();
                t.HasOne(e => e.Album).WithMany(e => e.Tracks).HasForeignKey(e => e.IdAlbum);

                t.HasData(
                    new Track { IdTrack = 1, TrackName = "groa", Duration = 223, IdAlbum = 1 },
                    new Track { IdTrack = 2, TrackName = "eafg", Duration = 214, IdAlbum = 1 },
                    new Track { IdTrack = 3, TrackName = "fea", Duration = 41, IdAlbum = 1 },
                    new Track { IdTrack = 4, TrackName = "peapf", Duration = 415, IdAlbum = 2 });
            });
            modelBuilder.Entity<MusicianTrack>(t =>
            {

                t.HasOne(e => e.Track).WithMany(e => e.MusicianTracks).HasForeignKey(e => e.IdTrack);
                t.HasOne(e => e.Musician).WithMany(e => e.MusicianTracks).HasForeignKey(e => e.IdMusician);
                //t.HasKey(e => e.IdMusician);
               // t.HasKey(e => e.IdTrack);
                
                t.HasData(
                    new MusicianTrack { IdMusician = 1, IdTrack = 1 },
                    new MusicianTrack { IdMusician = 1, IdTrack = 1 },
                    new MusicianTrack { IdMusician = 2, IdTrack = 2 },
                    new MusicianTrack { IdMusician = 2, IdTrack = 2 });


            });



        }
    }
}

