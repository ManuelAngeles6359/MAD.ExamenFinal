﻿using Dapper.Contrib.Extensions;

namespace MAD.Chinook.Models
{
    public class Track
    {

        [Key]
        public int TrackId { get; set; }
        public string Name { get; set; }
        public int AlbumId { get; set; }
        public int MediaTypeId { get; set; }
        public int GenreId { get; set; }
        public string Composer { get; set; }
        public int Milliseconds { get; set; }
        public decimal UnitPrice { get; set; }


    }
}