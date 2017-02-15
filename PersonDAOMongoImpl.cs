using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver; 

namespace CSharpApplication3
{
    class PersonDAOMongoImpl : PersonDAO
    {
        private MongoClient client;
        private IMongoDatabase db;
        private IMongoCollection<BsonDocument> collPerson; 
        
        public PersonDAOMongoImpl()
        {
            client = new MongoClient();
            db = client.GetDatabase("test2");
            collPerson = db.GetCollection<BsonDocument>("person"); 
        }
       
        public void Delete(long id)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("id", id);
            collPerson.DeleteOne(filter);
        }

        public void DeleteAll()
        {
            collPerson.DeleteMany(new BsonDocument()); 
        }

        private Person BsonToPerson(BsonDocument doc)
        {
            //doc[0] = ObjectKey 
            long id = doc[1].AsInt64;
            string name = doc[2].AsString;
            int age = doc[3].AsInt32;
            double wage = doc[4].AsDouble;
            return new Person(id, name, age, wage); 
        }

        private BsonDocument PersonToBson(Person p)
        {
            BsonDocument doc = new BsonDocument
            {
                {"id", p.Id },
                {"name" , p.Name},
                {"age", p.Age },
                {"wage", p.Wage }
            };
            return doc; 
        }

        public List<Person> FindAll()
        {
            var list = collPerson.Find<BsonDocument>(new BsonDocument()).ToCursor().ToList<BsonDocument>();
            var personList = new List<Person>(); 
            foreach(var el in list)
            {
                personList.Add(BsonToPerson(el)); 
            }
            return personList; 
        }

        public Person FindById(long id)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("id", id);
            var doc = collPerson.Find<BsonDocument>(filter).ToCursor().ToList<BsonDocument>()[0];
            return BsonToPerson(doc); 
        }

        public void Save(Person p)
        {
            BsonDocument doc = PersonToBson(p);
            collPerson.InsertOne(doc); 
        }

        public void Update(long id, Person p)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("id", id);
            var doc = PersonToBson(p);
            collPerson.ReplaceOne(filter, doc);
        }
    }
}
