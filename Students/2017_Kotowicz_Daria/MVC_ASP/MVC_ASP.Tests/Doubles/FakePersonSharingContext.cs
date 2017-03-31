using MVC_ASP.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_ASP.Tests.Doubles
{
    class FakePersonSharingContext : IPersonSharingContext
    {
        SetMap _map = new SetMap();

        public IQueryable<Person> Persons
        {
            get { return _map.Get<Person>().AsQueryable(); }
            set { _map.Use<Person>(value); }
        }

        public IQueryable<Adres> Adreses
        {
            get { return _map.Get<Adres>().AsQueryable(); }
            set { _map.Use<Adres>(value); }
        }

        public bool ChangesSaved { get; set; }

        public int SaveChanges()
        {
            ChangesSaved = true;
            return 0;
        }

        public T Add<T>(T entity) where T : class
        {
            _map.Get<T>().Add(entity);
            return entity;
        }

        public T Delete<T>(T entity) where T : class
        {
            _map.Get<T>().Remove(entity);
            return entity;
        }

        public Person FindPersonById(int id)
        {
            Person item = (from p in this.Persons
                           where p.personId == id
                           select p).FirstOrDefault();
            return item;
        }

        public Adres FindAdresById(int id)
        {
            Adres adres = (from a in this.Adreses
                           where a.adresId == id
                           select a).FirstOrDefault();
            return adres;
        }

        public IQueryable<Person> PersonOfPeselNull()
        {
            IQueryable<Person> persons = Persons.Where(p => p.pesel == null);
            return persons;
        }

        class SetMap : KeyedCollection<Type, object>
        {
            public HashSet<T> Use<T>(IEnumerable<T> sourceData)
            {
                var set = new HashSet<T>(sourceData);
                if (Contains(typeof(T)))
                {
                    Remove(typeof(T));
                }
                Add(set);
                return set;
            }

            public HashSet<T> Get<T>()
            {
                return (HashSet<T>)this[typeof(T)];
            }

            protected override Type GetKeyForItem(object item)
            {
                return item.GetType().GetGenericArguments().Single();
            }
        }
    }
}
