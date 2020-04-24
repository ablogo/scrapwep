using Dal;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository
{
    public class ArtistGenreRepo
    {
        private UnitWork unitWork;

        public ArtistGenreRepo() { unitWork = new UnitWork(); }

        public List<ArtistGenre> GetByArtist(int artistId)
        {
            var artistGenre = unitWork.ArtistGenreRepository.Get(x => x.ArtistId == artistId);
            return artistGenre.ToList();
        }

        public List<ArtistGenre> GetByGenre(int genreId)
        {
            var artistGenre = unitWork.ArtistGenreRepository.Get(x => x.GenreId == genreId);
            return artistGenre.ToList();
        }

        public void Save(ArtistGenre artistGenre)
        {
            try
            {
                unitWork.ArtistGenreRepository.Insert(artistGenre);
                unitWork.Save();
            }
            catch (Exception ex) { }
        }

        public void Save(List<ArtistGenre> artistGenre)
        {
            try
            {
                unitWork.ArtistGenreRepository.Insert(artistGenre);
                unitWork.Save();
            }
            catch (Exception ex) { }
        }
    }
}
