﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MarvelPhases.Models
{
    public class Phase
    {
        // Properties for each specific phase
        [DisplayName("Phase")]  //display name
        public int Id { get; set; }
        [DisplayName("Phase Name")]
        public string PhaseName { get; set; }
    }
}