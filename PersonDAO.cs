using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpApplication3
{
    public interface PersonDAO
    {
         void Save(Person p);
        void Update(long id, Person p);
        void Delete(long id);
        Person FindById(long id);
        List<Person> FindAll();
        void DeleteAll(); 
    }
}
