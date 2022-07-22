using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment.Models.DAO
{
    public class GenreDAO
    {
        public static List<Genre> GetGenres()
        {
            List<Genre> categories;
            try
            {
                using (CinemaDBContext context = new CinemaDBContext())
                {
                    categories = context.Genres.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return categories;
        }
    }
}
