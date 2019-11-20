﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Movies.Pages
{
    public class IndexModel : PageModel
    {
        MovieDatabase movieDatabase = new MovieDatabase();
        public List<Movie> Movies;
        [BindProperty]
        public string search { get; set; }
        [BindProperty]

        public List<string> mpaa { get; set; } = new List<string>();
        [BindProperty]

        public float? minIMDB { get; set; }
        [BindProperty]

        public float? maxIMDB { get; set; }

        public void OnGet()
        {
            Movies = MovieDatabase.All;
        }

        public void OnPost(string search, List<string> mpaa, float? minIMDB, float? maxIMDB)
        {
            Movies = MovieDatabase.All;
            if(search != null)
            {
                Movies = MovieDatabase.Search(search, Movies);
            }
            if(mpaa.Count != 0)
            {
                Movies = MovieDatabase.FilterByMPAA(Movies, mpaa);
            }
            if(minIMDB != null)
            {
                Movies = MovieDatabase.FilterByMinIMDB(Movies, (float)minIMDB);
            }
        }
    }
}
