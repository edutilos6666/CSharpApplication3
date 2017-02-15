using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework; 

namespace CSharpApplication3
{
    [TestFixture]
    class TestPersonDAOImpl
    {
        private PersonDAO dao = new PersonDAOImpl(); 

        private void Insert()
        {
            dao.Save(new Person(1, "foo", 10, 100.0));
            dao.Save(new Person(2, "bar", 20, 200.0)); 
        }
        private void Clean()
        {
            dao.DeleteAll(); 
        }

        [Test]
        public void TestSave()
        {
            Insert();
            List<Person> personList = dao.FindAll();
            Assert.AreEqual(2, personList.Count);
            Person p = personList[0];
            Assert.AreEqual(1, p.Id);
            Assert.AreEqual("foo", p.Name);
            Assert.AreEqual(10, p.Age);
            Assert.AreEqual(100.0, p.Wage); 
            Clean(); 
        }


        [Test]
        public void TestUpdate()
        {
            Insert();
            dao.Update(2, new Person(2, "newbar", 66, 666.6));
            Person p = dao.FindAll()[1];
            Assert.AreEqual(2, p.Id);
            Assert.AreEqual("newbar", p.Name);
            Assert.AreEqual(66, p.Age);
            Assert.AreEqual(666.6, p.Wage); 
            Clean();   
          
        }

        [Test]
        public void TestDelete()
        {
            Insert();
            var list = dao.FindAll();
            Assert.AreEqual(2, list.Count);
            dao.Delete(1);
            list = dao.FindAll();
            Assert.AreEqual(1, list.Count);
            dao.Delete(2);
            list = dao.FindAll();
            Assert.AreEqual(0, list.Count); 
            Clean(); 
        }
    }
}
