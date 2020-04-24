using Dal;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository
{
    public class AlbumRepo
    {
        private UnitWork unitWork;

        public AlbumRepo() { unitWork = new UnitWork(); }

        public Album GetById(int id)
        {
            var albums = unitWork.AlbumRepository.GetByID(id);
            return albums;
        }

        public Album GetByName(string name)
        {
            var albums = unitWork.AlbumRepository.Get(x => x.Name == name).FirstOrDefault();
            return albums;
        }

        public List<Album> GetByArtist(string artist)
        {
            var artistId = unitWork.ArtistRepository.Get(x => x.ShortCut == artist).FirstOrDefault().ArtistId;
            var albums = unitWork.AlbumRepository.Get(x => x.ArtistId == artistId);
            return albums.ToList();
        }

        public List<Album> GetAll()
        {
            var albums = unitWork.AlbumRepository.Get();
            return albums.ToList();
        }

        public void Save(Album album)
        {
            try
            {
                unitWork.AlbumRepository.Insert(album);
                unitWork.Save();
            }
            catch (Exception ex) { }
        }

        public void Save(List<Album> albums)
        {
            try
            {
                unitWork.AlbumRepository.Insert(albums);
                unitWork.Save();
            }
            catch (Exception ex) { }
        }

    }
}
