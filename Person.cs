using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpApplication3
{

    public class Person
    {
        public long Id { get; set;  }
        public String Name { get; set;  }
        public int Age { get; set;  }
        public Double Wage { get; set;  }

        public Person(long id ,String name , int age, double wage)
        {
            this.Id = id; 
            this.Name = name;
            this.Age = age;
            this.Wage = wage; 
        }

        public override string ToString()
        {
            return String.Format("{0}, {1}, {2}, {3}", Id , Name, Age, Wage); 
        }
    }
}
