using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment.Models.DAO
{
    public class MovieDAO
    {
        public static List<Movie> GetMoviesByName(string searchtxt)
        {
            List<Movie> movies;
            try
            {
                using (CinemaDBContext context = new CinemaDBContext())
                {
                    if (string.IsNullOrEmpty(searchtxt))
                    {
                        movies = context.Movies.Include(s => s.Gernes).ToList();
                    }
                    else
                    {
                        movies = context.Movies.Include(s => s.Gernes).Where(e => e.Title.Contains(searchtxt)).ToList();
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            return movies;
        }
    }
}
