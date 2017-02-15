using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework; 


namespace CSharpApplication3
{
    [TestFixture]
    class TestPersonDAOMongoImpl
    {
        private PersonDAO dao = new PersonDAOMongoImpl(); 

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
            var list = dao.FindAll();
            Assert.AreEqual(2, list.Count);
            var p1 = list[0];
            Assert.AreEqual("foo", p1.Name);
            Assert.AreEqual(10, p1.Age); 
            Clean(); 
        }


        [Test]
        public void TestUpdate()
        {
            Insert();
            dao.Update(1, new Person(1, "newfoo", 66, 666.6));
            var p = dao.FindById(1);
            Assert.AreEqual(1, p.Id);
            Assert.AreEqual(66, p.Age);
            Assert.AreEqual(666.6, p.Wage);
            Assert.AreEqual("newfoo", p.Name); 
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


