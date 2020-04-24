using Entities.Models;
using HtmlAgilityPack;
using Repository;
using ScrapySharp.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Service
{
    public class Tracks
    {
        private TrackRepo repo;
        private List<Track> tracks;
        private IEnumerable<HtmlNode> htmlNodes;

        public Tracks() { repo = new TrackRepo(); }

        public void SearchTracks(string url, int artistId, int albumId)
        {
            LookTrack(url, artistId, albumId);
            if (tracks.Count > 0) repo.Save(tracks);
        }

        private void LookTrack(string url, int artistId, int albumId)
        {
            try
            {
                tracks = new List<Track>();
                var html = Helpers.GetHtml(url);
                htmlNodes = html.CssSelect("li.track-item.js-track-item");

                foreach (var item in htmlNodes)
                {
                    string shortcut = item.GetAttributeValue("track_shortcut");
                    string name = item.GetAttributeValue("track_name");
                    
                    tracks.Add(new Track() { Name = name, ShortCut = shortcut, ArtistId = artistId, AlbumId = albumId });
                }

            }
            catch (Exception ex) { }
        }

    }
}
