using Entities.Models;
using HtmlAgilityPack;
using Repository;
using ScrapySharp.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Service
{
    public class Albums
    {
        private AlbumRepo repo;
        private Tracks tracks;
        private ArtistRepo repoArtist;
        private IEnumerable<HtmlNode> htmlNodes;

        public Albums() { repo = new AlbumRepo(); repoArtist = new ArtistRepo(); tracks = new Tracks(); }

        public void SearchAlbums(string url)
        {
            var artists = repoArtist.GetAll();

            foreach (var item in artists)
            {
                LookAlbum(url + item.ShortCut + "/album", item.ArtistId);
            }
        }

        private void LookAlbum(string url, int artistId)
        {
            try
            {
                var html = Helpers.GetHtml(url + "s");
                htmlNodes = html.CssSelect("[feature|='Albums, Main Releases'] > div.row.album-list.js-album-list > div.column.album-item.js-album-item");

                foreach (var item in htmlNodes)
                {
                    string shortcut = item.GetAttributeValue("album_shortcut");
                    var name = item.GetAttributeValue("album_name");

                    var album = new Album() { Name = name, ShortCut = shortcut, ArtistId = artistId };
                    repo.Save(album);
                    tracks.SearchTracks(url + "/" + shortcut, artistId, album.AlbumId);
                }

            }
            catch (Exception ex) { }
        }

    }
}
