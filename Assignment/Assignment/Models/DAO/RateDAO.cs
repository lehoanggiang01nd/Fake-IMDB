using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment.Models.DAO
{
    public class RateDAO
    {
        public static void AddComment(int mid,int uid,string commnet,float rate)
        {
            try
            {
                Rate r = new Rate();
                r.MovieId = mid;
                r.PersonId = uid;
                r.Comment = commnet;
                r.NumbericRating = rate;
                r.Time = DateTime.Now;
                using (CinemaDBContext context = new CinemaDBContext())
                {
                    context.Rates.Add(r);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.InnerException.Message);
            }
        }
    }
}
