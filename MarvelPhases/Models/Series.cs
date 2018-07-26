using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace MarvelPhases.Models
{
    public class Series
    {
        //Adding properties to each specific series
        public int Id { get; set; }
        public string Title { get; set; }
        [DisplayName("Series Number")]
        public int SeriesNumber { get; set; }
        public string Description { get; set; }
        [DisplayName("Phase ID")]
        public int PhaseId { get; set; }
        public decimal Rating { get; set; }
        [DisplayName("TV Service")]
        public string TvService { get; set; }

        public virtual Phase Phase { get; set; }
    }
}