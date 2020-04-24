using Dal.Context;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dal
{
    public class UnitWork : IDisposable
    {
        private BaseContext context = new BaseContext();
        private Repository<Album> albumRepo;
        private Repository<Artist> artistRepo;
        private Repository<ArtistGenre> artistGenreRepo;
        private Repository<Genre> genreRepo;
        private Repository<Track> trackRepo;
        private bool disposed = false;

        public Repository<Album> AlbumRepository
        {
            get
            {
                if (albumRepo == null) { albumRepo = new Repository<Album>(context); }
                return albumRepo;
            }
        }

        public Repository<Artist> ArtistRepository
        {
            get
            {
                if (artistRepo == null) { artistRepo = new Repository<Artist>(context); }
                return artistRepo;
            }
        }

        public Repository<ArtistGenre> ArtistGenreRepository
        {
            get
            {
                if (artistGenreRepo == null) { artistGenreRepo = new Repository<ArtistGenre>(context); }
                return artistGenreRepo;
            }
        }

        public Repository<Genre> GenreRepository
        {
            get
            {
                if (genreRepo == null) { genreRepo = new Repository<Genre>(context); }
                return genreRepo;
            }
        }

        public Repository<Track> TrackRepository
        {
            get
            {
                if (trackRepo == null) { trackRepo = new Repository<Track>(context); }
                return trackRepo;
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}
