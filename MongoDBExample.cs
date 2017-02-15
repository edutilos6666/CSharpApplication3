using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver; 


namespace CSharpApplication3
{
    class MongoDBExample
    {
        public void RunMongoDBExample()
        {
            Connect();
            Save(new Person(1, "foo", 10, 100.0));
            Save(new Person(2, "bar", 20, 200.0));
            FindAll();
            Console.WriteLine("<<FindById>>");
            FindById(1);
            Update(1, new Person(1, "newfoo", 66, 666.6));
            Console.WriteLine("<<After update>>"); 
            FindAll();
            Delete(1);
            Console.WriteLine("<<After delete>>");
            FindAll(); 
            DeleteAll(); 
        }


        private MongoClient client;
        private IMongoDatabase db;
        private IMongoCollection<BsonDocument> collPerson;

        //props 
        private const String host = "localhost";
        private const int port = 27017; 
        private void Connect()
        {
            client = new MongoClient();
            db = client.GetDatabase("test2");
            collPerson = db.GetCollection<BsonDocument>("person"); 
            
        }

        private void Disconnect()
        {
            
        }

        private void Save(Person p)
        {

            BsonDocument doc = new BsonDocument
            {
                { "id", p.Id },
                {"name", p.Name },
                {"age", p.Age },
                {"wage", p.Wage }
            };

            collPerson.InsertOne(doc); 
        }

        private void FindAll()
        {
            var res = collPerson.Find(new BsonDocument()).ToCursor();
            var list = res.ToList<BsonDocument>();
            foreach (var el in list)
                Console.WriteLine(BsonToPerson(el));  
        }

        private Person BsonToPerson(BsonDocument doc)
        {
            long  id = doc[1].AsInt64;
            string name = doc[2].AsString;
            int age = doc[3].AsInt32;
            double wage = doc[4].AsDouble;
            return new Person(id, name, age, wage); 
        }


        private BsonDocument PersonToBson(Person p)
        {
            BsonDocument doc = new BsonDocument
            {
                {"id",  p.Id },
                {"name", p.Name },
                {"age", p.Age },
                {"wage", p.Wage }
            };
            return doc; 
        }

        private void Update(long id, Person p)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("id", id);
            var doc = PersonToBson(p);
            collPerson.ReplaceOne(filter, doc); 
        }

        private void Delete(long id)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("id", id);
            collPerson.DeleteOne(filter); 
        }

        private void FindById(long id)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("id", id); 
            var doc = collPerson.Find(filter).ToCursor().ToList<BsonDocument>()[0];
            Console.WriteLine(doc);
            Console.WriteLine(BsonToPerson(doc)); 
        }


        private void DeleteAll()
        {
            collPerson.DeleteMany(new BsonDocument()); 
        }

    }
}
