using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Entities.Models
{
    public class Album
    {
        [JsonIgnore]
        public int AlbumId { get; set; }
        [JsonIgnore]
        public string Name { get; set; }
        [JsonPropertyName("Name")]
        public string ShortCut { get; set; }

        //NP
        [JsonIgnore]
        public int ArtistId { get; set; }
        [JsonIgnore]
        public Artist Artist { get; set; }

        [JsonIgnore]
        public virtual List<Track> Tracks { get; set; }
    }
}
