using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Repository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class NapsterController : ControllerBase
    {
        private readonly ArtistRepo artistRepo;
        private readonly AlbumRepo albumRepo;
        private readonly GenreRepo genreRepo;
        private readonly TrackRepo trackRepo;

        public NapsterController() 
        {
            artistRepo = new ArtistRepo();
            albumRepo = new AlbumRepo();
            genreRepo = new GenreRepo();
            trackRepo = new TrackRepo();
        }

        // GET: api/napster/AlbumsByArtist/name
        [HttpGet("AlbumsByArtist/{name}")]
        public ActionResult<List<string>> AlbumsByArtist(string name)
        {
            var artist = albumRepo.GetByArtist(name).Select(x => x.ShortCut).ToList();
            if (artist == null)
            {
                NotFound();
            }
            return Ok(artist);

        }

        // GET: api/napster/TracksByAlbum/name
        [HttpGet("TracksByAlbum/{name}")]
        public ActionResult<List<string>> TracksByAlbum(string name)
        {
            var album = trackRepo.GetByAlbum(name).Select(x => x.ShortCut).ToList();
            if (album == null)
            {
                NotFound();
            }
            return Ok(album);

        }

        // GET: api/napster/ArtistByTrack/track
        [HttpGet("ArtistByTrack/{track}")]
        public ActionResult<List<string>> ArtistByTrack(string track)
        {
            var artist = artistRepo.GetByTrack(track);
            if (artist == null)
            {
                NotFound();
            }
            return Ok(artist);

        }

        // GET: api/napster/ArtistByGenre/genre
        [HttpGet("ArtistByGenre/{genre}")]
        public ActionResult<List<string>> ArtistByGenre(string genre)
        {
            var artist = artistRepo.GetByGenre(genre).Select(x => x.ShortCut).ToList();
            if (artist == null)
            {
                NotFound();
            }
            return Ok(artist);

        }

        // GET: api/napster/Genre
        [HttpGet("Genres")]
        public ActionResult<Genre> Genres()
        {
            var genre = genreRepo.GetAllGenres();
            for (int j = 0; j < genre.Count; j++)
            {
                genre[j].SubGenre = genreRepo.GetSubGenreByGenre(genre[j].GenreId).Select(x => x.ShortCut).ToList();
            }

            if (genre == null)
            {
                NotFound();
            }
            return Ok(genre);

        }
    }
}
