using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MarvelPhases.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        [DisplayName("Collection Number")]
        public int CollectionNumber { get; set; }
        [DisplayName("Release Date")]
        public DateTime ReleaseDate { get; set; }
        public string Description { get; set; }
        [DisplayName("Program ID")]
        public int PhaseId { get; set; }
        public decimal Rating { get; set; }
        [DisplayName("Box Office")]
        public decimal BoxOffice { get; set; }

        public virtual Phase Phase { get; set; }
    }
}