using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections; 

namespace CSharpApplication3
{
    class PersonDAOImpl : PersonDAO
    {
        private Dictionary<long , Person> personContainer  = new Dictionary<long, Person>(); 
        
        public void Delete(long id)
        {
            personContainer.Remove(id); 
        }

        public void DeleteAll()
        {
            personContainer.Clear(); 
        }

        public List<Person> FindAll()
        {
            return personContainer.Values.ToList<Person>(); 
        }

        public Person FindById(long id)
        {
            return personContainer[id]; 
        }

        public void Save(Person p)
        {
            personContainer.Add(p.Id, p); 
        }

        public void Update(long id, Person p)
        {
            personContainer.Remove(id);
            personContainer.Add(id, p); 
        }
    }
}
