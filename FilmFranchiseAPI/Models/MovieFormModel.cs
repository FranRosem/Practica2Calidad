﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmFranchiseAPI.Models
{
    public class MovieFormModel : MovieModel
    {
        public IFormFile Image { get; set; }
    }
}
