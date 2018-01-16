using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Assignment6.Controllers
{
    public class PlaylistBase
    {
        public PlaylistBase()
        {

        }
        [Key]
        public int PlaylistId { get; set; }

        [StringLength(120)]
        public string Name { get; set; }

        public int TracksCount { get; set; }
    }


    public class PlaylistWithTracks : PlaylistBase
    {

        public IEnumerable<TrackBase> Tracks { get; set; }
    }

    public class PlaylistEditTracksForm : PlaylistBase
    {
        public PlaylistEditTracksForm()
        {
            Tracks = new List<TrackBase>();

        }

        public IEnumerable<TrackBase> Tracks { get; set; }



        [Key]
        public int PlaylistId { get; set; }

        [Required, StringLength(120)]
        [Display(Name = "Track name")]
        public string Name { get; set; }

        [Display(Name = "Tracks")]
        public MultiSelectList TrackList { get; set; }

    }

    public class PlaylistEditTracks
    {
        public PlaylistEditTracks()
        {
            TrackIds = new List<int>();
        }

        public int Id { get; set; }
        public IEnumerable<int> TrackIds { get; set; }
    }


}