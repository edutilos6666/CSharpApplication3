using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient; 

namespace CSharpApplication3
{
    public class PersonDAOMyslqImpl : PersonDAO
    {
        //properties 
        private String connString = "server = localhost ; userId = root; database = test";
        private MySqlConnection conn;
        private MySqlCommand command; 
        private MySqlDataReader reader;
        private String cmd; 


        private void Connect()
        {
            conn = new MySqlConnection(connString);
            conn.Open(); 
        }

        private void Disconnect()
        {
            conn.Close(); 
        }

        public void CreateTable()
        {
            cmd = @"create table if not exists Person (
id bigint not null primary key , 
name varchar(50) not null , 
age int not null, 
wage double not null 
)";
            Connect();
            command = new MySqlCommand(cmd, conn);
            command.ExecuteNonQuery(); 
            Disconnect(); 
        }

        public void Delete(long id)
        {
            Connect();
            cmd = @"delete  from Person where id = @id";
            command = new MySqlCommand(cmd, conn);
            command.Prepare();
            command.Parameters.AddWithValue("@id", id);
            command.ExecuteNonQuery(); 
            Disconnect(); 
        }

        public void DeleteAll()
        {
            Connect();
            cmd = @"delete from Person";
            command = new MySqlCommand(cmd, conn);
            command.ExecuteNonQuery(); 
            Disconnect(); 
        }

        public List<Person> FindAll()
        {
            List<Person> list = new List<Person>(); 
            Connect();
            cmd = @"select * from Person";
            command = new MySqlCommand(cmd, conn);
            reader = command.ExecuteReader(); 
            while(reader.Read())
            {
                list.Add(ReaderToPerson()); 
            }
            reader.Close(); 
            Disconnect();
            return list; 
        }

        private Person ReaderToPerson()
        {
            long id = reader.GetInt64(0);
            string name = reader.GetString(1);
            int age = reader.GetInt32(2);
            double wage = reader.GetDouble(3);
            return new Person(id, name, age, wage); 
        }

        public Person FindById(long id)
        {
            Connect();
            cmd = @"select * from Person where id = @id";
            command = new MySqlCommand(cmd, conn);
            command.Prepare();
            command.Parameters.AddWithValue("@id", id);
            reader = command.ExecuteReader();
            reader.Read();
            Person p = ReaderToPerson();
            reader.Close(); 
            Disconnect();
            return p; 
            
        }

        public void Save(Person p)
        {
            Connect();
            cmd = @"insert into Person VALUES(@id, @name, @age, @wage)";
            command = new MySqlCommand(cmd, conn);
            command.Prepare();
            command.Parameters.AddWithValue("@id", p.Id); 
            command.Parameters.AddWithValue("@name", p.Name);
            command.Parameters.AddWithValue("@age", p.Age);
            command.Parameters.AddWithValue("@wage", p.Wage);
            command.ExecuteNonQuery(); 
            Disconnect(); 
        }

        public void Update(long id, Person p)
        {
            Connect();
            cmd = @"update Person set name = @name , age = @age, wage = @wage where id = @id";
            command = new MySqlCommand(cmd, conn);
            command.Prepare();
            command.Parameters.AddWithValue("@name", p.Name);
            command.Parameters.AddWithValue("@age", p.Age);
            command.Parameters.AddWithValue("@wage", p.Wage);
            command.Parameters.AddWithValue("@id", id);
            command.ExecuteNonQuery(); 
            Disconnect(); 
        }
    }
}
