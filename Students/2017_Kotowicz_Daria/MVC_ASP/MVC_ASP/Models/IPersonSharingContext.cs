using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_ASP.Models
{
    public interface IPersonSharingContext
    {
        IQueryable<Person> Persons { get; }
        IQueryable<Person> PersonOfPeselNull();
        IQueryable<Adres> Adreses { get; }
        T Add<T>(T entity) where T : class;
        T Delete<T>(T entity) where T : class;
        int SaveChanges();
        Person FindPersonById(int id);
        Adres FindAdresById(int id);
    }
}
