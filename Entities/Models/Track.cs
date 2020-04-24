using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Entities.Models
{
    public class Track
    {
        [JsonIgnore]
        public int TrackId { get; set; }
        [JsonIgnore]
        public string Name { get; set; }
        [JsonPropertyName("Name")]
        public string ShortCut { get; set; }

        //NP
        [JsonIgnore]
        public int AlbumId { get; set; }
        [JsonIgnore]
        public Album Album { get; set; }
        [JsonIgnore]
        public int ArtistId { get; set; }
        [JsonIgnore]
        public Artist Artist { get; set; }
    }
}
