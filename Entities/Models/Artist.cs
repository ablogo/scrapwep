using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Entities.Models
{
    public class Artist
    {
        [JsonIgnore]
        public int ArtistId { get; set; }
        [JsonIgnore]
        public string Name { get; set; }
        [JsonPropertyName("Name")]
        public string ShortCut { get; set; }

        //NP
        [JsonIgnore]
        public virtual List<Album> Albums { get; set; }
        [JsonIgnore]
        public virtual List<Track> Tracks { get; set; }
        [JsonIgnore]
        public virtual List<ArtistGenre> ArtistGenres { get; set; }
    }
}
