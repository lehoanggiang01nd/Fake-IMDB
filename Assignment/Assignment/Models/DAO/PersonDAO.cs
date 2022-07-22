using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment.Models.DAO
{
    public class PersonDAO
    {
        public static Person getCustomerByEmail(string Email)
        {
            Person person = null;
            try
            {
                using (CinemaDBContext context = new CinemaDBContext())
                {
                    person = context.Persons.SingleOrDefault(c => c.Email == Email);
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            return person;
        }
        public static void UpdatePerson(int id,string fullname,string gender)
        {
            try
            {
                
                using (CinemaDBContext context = new CinemaDBContext())
                {
                    Person p = context.Persons.Find(id);
                    p.Fullname = fullname;
                    p.Gender = gender;
                    context.Persons.Update(p);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.InnerException.Message);
            }
        }
        public static void Signup(string email,string fullname, string password,string gender,int type)
        {
            try
            {
                Person p = new Person();
                p.Email = email;
                p.Fullname = fullname;
                p.Password = password;
                p.Gender = gender;
                p.Type = type;
                using (CinemaDBContext context = new CinemaDBContext())
                {
                    context.Persons.Add(p);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.InnerException.Message);
            }
        }
        public static void ChangePassword(int id,string password)
        {
            try
            {
                using (CinemaDBContext context = new CinemaDBContext())
                {
                    Person p = context.Persons.Where(p => p.PersonId == id).FirstOrDefault();
                    p.Password = password;
                    context.Persons.Update(p);
                    //context.Entry<Member>(c).State = EntityState.Modified;
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
