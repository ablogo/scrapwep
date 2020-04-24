using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Entities.Models
{
    public class Genre
    {
        [JsonIgnore]
        public int GenreId { get; set; }
        [JsonIgnore]
        public string Name { get; set; }
        [JsonPropertyName("Name")]
        public string ShortCut { get; set; }
        [JsonIgnore]
        public Nullable<int> ParentId { get; set; }
        [NotMapped]
        public List<string> SubGenre { get; set; }

        //NP
        [JsonIgnore]
        public virtual List<ArtistGenre> ArtistGenres { get; set; }
    }
}
