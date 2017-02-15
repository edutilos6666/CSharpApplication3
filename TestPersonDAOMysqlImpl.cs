using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework; 


namespace CSharpApplication3
{
    [TestFixture]
    class TestPersonDAOMysqlImpl
    {
        private PersonDAO dao = new PersonDAOMyslqImpl(); 


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
            Assert.AreEqual(1, p1.Id);
            Assert.AreEqual("foo", p1.Name); 
            Clean(); 
        }

        [Test]
        public void TestUpdate()
        {
            Insert();
            dao.Update(2, new Person(2, "newbar", 66, 666.6));
            Person p = dao.FindAll()[1];
            Assert.AreEqual(2,p.Id);
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
            var p = dao.FindById(1);
            Assert.AreEqual("foo", p.Name);
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
