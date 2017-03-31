using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVC_ASP.Models
{
    public class PersonSharingContext : DbContext, IPersonSharingContext
    {
        public DbSet<Person> Persons { get; set; }
        public DbSet<Adres> Adreses { get; set; }

        IQueryable<Person> IPersonSharingContext.Persons
        {
            get { return Persons; }
        }

        IQueryable<Adres> IPersonSharingContext.Adreses
        {
            get { return Adreses; }
        }


        IQueryable<Person> IPersonSharingContext.PersonOfPeselNull()
        {
            IQueryable<Person> persons = Persons.Where(p => p.pesel == null);
            return persons;
        }
        int IPersonSharingContext.SaveChanges()
        {
            return SaveChanges();
        }
        T IPersonSharingContext.Add<T>(T entity)
        {
            return Set<T>().Add(entity);
        }
        T IPersonSharingContext.Delete<T>(T entity)
        {
            return Set<T>().Remove(entity);
        }
        Person IPersonSharingContext.FindPersonById(int id)
        {
            Person person = (from p in Set<Person>()
                             where p.personId == id
                             select p).FirstOrDefault();
            return person;
        }
        Adres IPersonSharingContext.FindAdresById(int id)
        {
            Adres adres = (from a in Set<Adres>()
                           where a.adresId == id
                           select a).FirstOrDefault();
            return adres;
        }
    }
}