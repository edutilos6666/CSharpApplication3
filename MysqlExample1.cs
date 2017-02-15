using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient; 


namespace CSharpApplication3
{
    class MysqlExample1
    {

        public void RunMysql()
        {
            DropCreateTable();
            SavePerson(new Person(1, "foo", 10, 100.0));
            SavePerson(new Person(2, "bar", 20, 200.0));
            FindAll(); 
        }

        private String connString = "server= localhost; userId = root; database = test";
        private MySqlConnection conn;
        private MySqlCommand command;
        private MySqlDataReader reader; 

        private void Connect()
        {
            conn = new MySqlConnection(connString);
            conn.Open();
           // Console.WriteLine("Connection successful."); 
        }

        private void Disconnect()
        {
            conn.Close(); 
        }

        private void DropCreateTable()
        {
            Connect(); 
            String cmd = @"
drop table if exists Person 
";
            command = new MySqlCommand(cmd, conn);
            command.ExecuteNonQuery();

            cmd = @"
create table if not exists Person (
id bigint not null primary key , 
name varchar(50) not null, 
age int not null , 
wage double not null 
)
";
            command.CommandText = cmd;
            command.ExecuteNonQuery();
            Disconnect(); 

        }
        private void SavePerson(Person p)
        {
            Connect(); 
            String cmd = @"insert into Person VALUES(@id, @name, @age, @wage)";
            command = new MySqlCommand(cmd, conn);
            command.Prepare();
            command.Parameters.AddWithValue("@id", p.Id);
            command.Parameters.AddWithValue("@name", p.Name); 
            command.Parameters.AddWithValue("@age", p.Age);
            command.Parameters.AddWithValue("@wage", p.Wage);
            command.ExecuteNonQuery();
            Disconnect();   
        }

        private void FindAll()
        {
            Connect();
            String cmd = @"select * from Person";
            command = new MySqlCommand(cmd, conn);
            reader = command.ExecuteReader(); 
            while(reader.Read())
            {
                long id = reader.GetInt64(0);
                String name = reader.GetString(1);
                int age = reader.GetInt32(2);
                double wage = reader.GetDouble(3);
                Console.WriteLine("{0}, {1}, {2}, {3}", id, name, age, wage); 
            }
            reader.Close(); 
            Disconnect(); 
        }
    }
}
