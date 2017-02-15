using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions; 

namespace CSharpApplication3
{
    class PersonDAOConsole
    {
        private PersonDAO dao; 
        public PersonDAOConsole(PersonDAO dao)
        {
            this.dao = dao; 
        }

        public void RunConsole()
        {
            String item1 = "1 -> Save Person",
                item2 = "2 -> Update Person",
                item3 = "3 -> Delete Person",
                item4 = "4 -> FindAll People",
                item5 = "5 -> Find One Person",
                item6 = "6 -> break",
                nl = "\r\n";

            String menu = String.Format("{0}{1}{2}{1}{3}{1}{4}{1}{5}{1}{6}{1}",
                item1, nl, item2, item3, item4, item5, item6); 

            while(true)
            {
                Console.WriteLine(menu);
                int answer = Convert.ToInt32(Console.ReadLine()); 
                switch(answer)
                {
                    case 1: Save(); break;
                    case 2: Update(); break;
                    case 3: Delete(); break;
                    case 4: FindAll(); break;
                    case 5: FindById(); break;
                    case 6: System.Environment.Exit(0) ; break;  
                }
            }
        }

        public void Save()
        {
            long id;
            string name;
            int age;
            double wage;
            Console.WriteLine("insert id, name, age, wage sep by comma: ");
            String input = Console.ReadLine();
            String[] splitted = Regex.Split(input, "\\s*,\\s*"); 
            try
            {
                id = Convert.ToInt64(splitted[0]);
                name = splitted[1];
                age = Convert.ToInt32(splitted[2]);
                wage = Convert.ToDouble(splitted[3]);
                dao.Save(new Person(id, name, age, wage)); 
            } catch(Exception ex)
            {
                Console.WriteLine(ex.Message); 
            }
        }

        public void Update()
        {
            long id;
            string name;
            int age;
            double wage;
            Console.WriteLine("insert id , name, age, wage sep by comma: ");
            String input = Console.ReadLine();
            String[] splitted = Regex.Split(input, "\\s*,\\s*"); 
            try
            {
                id = Convert.ToInt64(splitted[0]);
                name = splitted[1];
                age = Convert.ToInt32(splitted[2]);
                wage = Convert.ToDouble(splitted[3]);
                dao.Update(id, new Person(id, name, age, wage)); 
            } catch(Exception ex)
            {
                Console.WriteLine(ex.Message); 
            }
        }

        public void Delete()
        {
            long id;
            Console.WriteLine("Insert id of person to be deleted:");
            String input = Console.ReadLine();
              
            try
            {
                id = Convert.ToInt64(input);
                dao.Delete(id); 
            } catch(Exception ex)
            {
                Console.WriteLine(ex.Message); 
            }
        }

        public void FindAll()
        {
            var list = dao.FindAll(); 
            foreach(var el in list)
            {
                Console.WriteLine(el); 
            }
        }

        public void FindById()
        {
            long id;
            Console.WriteLine("insert id of person to be found: ");
            String input = Console.ReadLine(); 
            try
            {
                id = Convert.ToInt64(input);
                Person p = dao.FindById(id);
                Console.WriteLine(p); 
            } catch(Exception ex)
            {
                Console.WriteLine(ex.Message); 
            }
        }
    }
}
