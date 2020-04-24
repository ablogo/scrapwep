using System;
using HtmlAgilityPack;
using ScrapySharp.Extensions;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Entities.Models;
using Dal;
using Repository;

namespace Service
{
    public class Genres
    {
        private GenreRepo repo;
        private Artists artists;
        private List<Genre> genresDb;
        private IEnumerable<HtmlNode> htmlNodes;

        public Genres() { repo = new GenreRepo(); artists = new Artists(); }

        public void SearchGenres(string url) 
        {
            LookGenres(url);
        }

        public void SearcSubsGenres(string url)
        {
            genresDb = repo.GetAllGenres();

            foreach (var item in genresDb) 
            {
                LookSubGenres(url, item.ShortCut, item.GenreId);
            }
        }


        private void LookGenres(string url)
        {
            try
            {
                var html = Helpers.GetHtml(url);
                htmlNodes = html.CssSelect("div.column.genre-item > a");

                foreach (var item in htmlNodes) 
                {
                    string shortcut = item.GetAttributeValue("href");
                    shortcut = shortcut.Substring(shortcut.LastIndexOf("/") + 1);
                    var name = item.CssSelect("span.genre-name-text").Single().InnerText.TrimStart().TrimEnd();

                    var genre = new Genre() { Name = name, ShortCut = shortcut };
                    repo.Save(genre);

                    artists.SearchArtist("https://us.napster.com/genre/" + shortcut, genre.GenreId);
                }

            }
            catch (Exception ex) { }
        }

        private void LookSubGenres(string url, string genre, int genreId)
        {
            try
            {
                Genre tempGenre;
                var html = Helpers.GetHtml(url + "/" + genre);
                var haveSubGenre = html.CssSelect("#subgenres");

                if (haveSubGenre.Any())
                {
                    htmlNodes = html.CssSelect("ul.genre-list > li.genre-item > span > a");

                    foreach (var item in htmlNodes)
                    {
                        string shortcut = item.GetAttributeValue("href");
                        shortcut = shortcut.Substring(shortcut.LastIndexOf("/") + 1);
                        string name = item.InnerText.TrimStart().TrimEnd();

                        tempGenre = new Genre() { Name = name, ShortCut = shortcut, ParentId = genreId };
                        repo.Save(tempGenre);
                        //Se uso recursion para obtener los sub generos anidados.
                        LookSubGenres(url, (genre + "/" + shortcut), tempGenre.GenreId);
                    }
                }

            }
            catch (Exception ex) { }
        }

    }
}
