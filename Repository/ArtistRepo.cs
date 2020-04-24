using Dal;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository
{
    public class ArtistRepo
    {
        private UnitWork unitWork;

        public ArtistRepo() { unitWork = new UnitWork(); }

        public Artist GetById(int id)
        {
            var artists = unitWork.ArtistRepository.GetByID(id);
            return artists;
        }

        public Artist GetByName(string name)
        {
            var artists = unitWork.ArtistRepository.Get(x => x.Name == name).FirstOrDefault();
            return artists;
        }

        public Artist GetByTrack(string track)
        {
            var artistId = unitWork.TrackRepository.Get(x => x.ShortCut == track).FirstOrDefault().ArtistId;
            var artists = unitWork.ArtistRepository.Get(x => x.ArtistId == artistId).FirstOrDefault();
            return artists;
        }

        public List<Artist> GetByGenre(string genre)
        {
            var genreId = unitWork.GenreRepository.Get(x => x.ShortCut == genre).FirstOrDefault().GenreId;
            var artistId = unitWork.ArtistGenreRepository.Get(x => x.GenreId == genreId).Select(x => x.ArtistId).ToList();
            var artists = unitWork.ArtistRepository.Get(x => artistId.Contains(x.ArtistId));
            return artists.ToList();
        }

        public List<Artist> GetAll()
        {
            var artists = unitWork.ArtistRepository.Get();
            return artists.ToList();
        }

        public void Save(Artist artists)
        {
            try
            {
                unitWork.ArtistRepository.Insert(artists);
                unitWork.Save();
            }
            catch (Exception ex) { }
        }

        public void Save(List<Artist> artists)
        {
            try
            {
                unitWork.ArtistRepository.Insert(artists);
                unitWork.Save();
            }
            catch (Exception ex) { }
        }
    }
}
