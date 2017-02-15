using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Windows.Forms; 
 
namespace CSharpApplication3
{
    class Program
    {
        static void Main(string[] args)
        {
            //TestInput();

            //TestPersonDAOConsole(); 
            // TestMysqlExample1(); 
            //Application.Run(new PersonDAOForm()); 
            new MongoDBExample().RunMongoDBExample(); 
        }



        private static void TestMysqlExample1()
        {
            MysqlExample1 example = new MysqlExample1();
            example.RunMysql(); 
        }
        private static void TestPersonDAOConsole()
        {
            PersonDAOConsole c = new PersonDAOConsole(new PersonDAOImpl());
            c.RunConsole(); 
        }

        private static void TestInput()
        {
            String name;
            int age;
            double wage;
            Console.WriteLine("insert name, age, wage(sep by comma):");
            String input = Console.ReadLine();
            String pattern = "\\s*,\\s*";
            String [] splitted = Regex.Split(input, pattern);
               
            try
            {
                name = splitted[0];
                age = Convert.ToInt32(splitted[1]);
                wage = Convert.ToDouble(splitted[2]);
                Console.WriteLine("name = {0}, age = {1}, wage = {2}", name, age, wage); 
            } catch(Exception ex)
            {
                Console.WriteLine(ex.Message); 
            }
        }
    }
}
