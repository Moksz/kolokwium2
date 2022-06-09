using Kolokwium2.Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kolokwium2.DTOs
{
    public class AlbumGet
    {
        public string AlbumName { get; set; }
        public DateTime PublishDate { get; set; }

        public List<TrackGet> Tracks { get; set; }
    }

    public class TrackGet
    {
        public int IdTrack { get; set; }
        public string TrackName { get; set; }
        public double Duration { get; set; }
    }
}
