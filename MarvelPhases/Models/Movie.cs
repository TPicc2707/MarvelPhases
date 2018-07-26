using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
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
        public string Description { get; set; }
        [DisplayName("Phase ID")]
        public int PhaseId { get; set; }
        public decimal Rating { get; set; }
        [DisplayName("Box Office")]
        [DisplayFormat(DataFormatString = "{0:C0}")]
        public decimal BoxOffice { get; set; }

        public virtual Phase Phase { get; set; }
    }
}