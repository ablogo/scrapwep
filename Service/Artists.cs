using Entities.Models;
using HtmlAgilityPack;
using Microsoft.EntityFrameworkCore.Internal;
using Repository;
using ScrapySharp.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Service
{
    public class Artists
    {
        private ArtistRepo repo;
        private ArtistGenreRepo repo2;
        private HashSet<Artist> artists;
        private List<ArtistGenre> artistGenre;
        private IEnumerable<HtmlNode> htmlNodes;

        public Artists() { repo = new ArtistRepo(); repo2 = new ArtistGenreRepo(); }

        public void SearchArtist(string url, int genreId)
        {
            LookArtist(url, genreId);
            if (artistGenre.Count > 0) repo2.Save(artistGenre);
        }

        private void LookArtist(string url, int genreId)
        {
            try
            {
                artists = repo.GetAll().ToHashSet();
                artistGenre = new List<ArtistGenre>();

                var html = Helpers.GetHtml(url);
                htmlNodes = html.CssSelect("div.column.artist-item > div.name > a");

                foreach (var item in htmlNodes)
                {
                    string shortcut = item.GetAttributeValue("href");
                    shortcut = shortcut.Substring(shortcut.LastIndexOf("/") + 1);
                    var name = item.InnerText.TrimStart().TrimEnd();

                    if (!artists.Where(x => x.ShortCut == shortcut).Any())
                    {
                        var artist = new Artist() { Name = name, ShortCut = shortcut };
                        repo.Save(artist);
                        artistGenre.Add(new ArtistGenre() { ArtistId = artist.ArtistId, GenreId = genreId });
                    }
                }

            }
            catch (Exception ex) { }
        }

    }
}
