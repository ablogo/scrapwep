using Dal;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository
{
    public class TrackRepo
    {
        private UnitWork unitWork;

        public TrackRepo() { unitWork = new UnitWork(); }

        public Track GetById(int id)
        {
            var tracks = unitWork.TrackRepository.GetByID(id);
            return tracks;
        }

        public Track GetByName(string name)
        {
            var tracks = unitWork.TrackRepository.Get(x => x.Name == name).FirstOrDefault();
            return tracks;
        }

        public List<Track> GetByAlbum(string album)
        {
            var albumId = unitWork.AlbumRepository.Get(x => x.ShortCut == album).FirstOrDefault().AlbumId;
            var tracks = unitWork.TrackRepository.Get(x => x.AlbumId == albumId);
            return tracks.ToList();
        }

        public List<Track> GetAll()
        {
            var tracks = unitWork.TrackRepository.Get();
            return tracks.ToList();
        }

        public void Save(Track genre)
        {
            try
            {
                unitWork.TrackRepository.Insert(genre);
                unitWork.Save();
            }
            catch (Exception ex) { }
        }

        public void Save(List<Track> tracks)
        {
            try
            {
                unitWork.TrackRepository.Insert(tracks);
                unitWork.Save();
            }
            catch (Exception ex) { }
        }

    }
}
