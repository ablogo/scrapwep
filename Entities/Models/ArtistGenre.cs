using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Models
{
    public class ArtistGenre
    {
        public int ArtistId { get; set; }
        public Artist Artist { get; set; }

        public int GenreId { get; set; }
        public Genre Genre { get; set; }
    }
}
