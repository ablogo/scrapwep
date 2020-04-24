using Dal;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository
{
    public class GenreRepo
    {
        private UnitWork unitWork;

        public GenreRepo() { unitWork = new UnitWork(); }

        public Genre GetById(int id)
        {
            var genres = unitWork.GenreRepository.GetByID(id);
            return genres;
        }

        public Genre GetByName(string name)
        {
            var genres = unitWork.GenreRepository.Get(x => x.Name == name).FirstOrDefault();
            return genres;
        }

        public List<Genre> Get(int genreId)
        {
            var genres = unitWork.GenreRepository.Get(x => x.GenreId > genreId);
            return genres.ToList();
        }

        public List<Genre> GetAllGenres()
        {
            var genres = unitWork.GenreRepository.Get(x => x.ParentId == null);
            return genres.ToList();
        }

        public List<Genre> GetAllSubGenres()
        {
            var genres = unitWork.GenreRepository.Get(x => x.ParentId != null);
            return genres.ToList();
        }

        public List<Genre> GetSubGenreByGenre(int genreId)
        {
            var genres = unitWork.GenreRepository.Get(x => x.ParentId == genreId);
            return genres.ToList();
        }

        public void Save(Genre genre)
        {
            unitWork.GenreRepository.Insert(genre);
            unitWork.Save();
        }

        public void Save(List<Genre> genres)
        {
            unitWork.GenreRepository.Insert(genres);
            unitWork.Save();
        }

    }
}
