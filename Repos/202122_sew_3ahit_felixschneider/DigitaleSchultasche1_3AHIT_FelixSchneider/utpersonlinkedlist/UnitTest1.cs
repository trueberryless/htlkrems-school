using Microsoft.VisualStudio.TestTools.UnitTesting;
using PersonLinkedList;
using System;

namespace utpersonlinkedlist
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestSearch()
        {
            PersonLinkedList.PersonLinkedList l = new PersonLinkedList.PersonLinkedList();
            l.InsertFront("Clemens");
            l.InsertFront("Felix");
            l.InsertFront("Lorenz");
            l.InsertFront("Matthias");

            PersonNode n = l.Search("Lorenz");
            Assert.AreEqual(n.Name, "Lorenz");
        }

        [TestMethod]
        public void TestContains()
        {
            string value = "Clemens";
            PersonLinkedList.PersonLinkedList l = new PersonLinkedList.PersonLinkedList();
            l.InsertFront(value);
            Assert.IsTrue(l.Contains(value));
        }

        [TestMethod]
        public void TestInsertFront()
        {
            PersonLinkedList.PersonLinkedList l = new PersonLinkedList.PersonLinkedList();
            l.InsertFront("Clemens");
            Assert.AreEqual("Clemens", l.Head.Name);
            l.InsertFront(new PersonNode("Felix"));
            l.InsertFront("Lorenz");
            Assert.AreEqual("Lorenz", l.Head.Name);
            l.InsertFront(new PersonNode("Matthias"));
            Assert.AreEqual("Matthias", l.Head.Name);
        }

        [TestMethod]
        public void TestInsertLast()
        {
            PersonLinkedList.PersonLinkedList l = new PersonLinkedList.PersonLinkedList();
            l.InsertLast("Clemens");
            Assert.AreEqual("Clemens", l.Head.Name);
            l.InsertLast(new PersonNode("Felix"));
            l.InsertLast("Lorenz");
            Assert.AreEqual("Lorenz", l.Head.Next.Next.Name);
            l.InsertLast(new PersonNode("Matthias"));
            Assert.AreEqual("Matthias", l.Head.Next.Next.Next.Name);
        }

        [TestMethod]
        public void TestInsertBefore()
        {
            PersonLinkedList.PersonLinkedList l = new PersonLinkedList.PersonLinkedList();
            l.InsertLast("Clemens");
            //Alex
            l.InsertLast(new PersonNode("Felix"));
            //Manfred
            //Bernhard
            l.InsertLast("Lorenz");
            //Lukas
            l.InsertLast(new PersonNode("Matthias"));

            l.InsertBefore("Lukas", "Matthias");
            Assert.AreEqual("Lukas", l.Head.Next.Next.Next.Name);
            l.InsertBefore(new PersonNode("Manfred"), "Lorenz");
            l.InsertBefore("Alex", l.Head.Next);
            Assert.AreEqual("Alex", l.Head.Next.Name);
            l.InsertBefore(new PersonNode("Bernhard"), l.Head.Next.Next.Next.Next);
            Assert.AreEqual("Bernhard", l.Head.Next.Next.Next.Next.Name);
        }

        [TestMethod]
        public void TestInsertAfter()
        {
            PersonLinkedList.PersonLinkedList l = new PersonLinkedList.PersonLinkedList();
            l.InsertLast("Clemens");
            l.InsertLast(new PersonNode("Felix"));
            //Alex
            l.InsertLast("Lorenz");
            //Manfred
            //Bernhard
            l.InsertLast(new PersonNode("Matthias"));
            //Lukas

            l.InsertAfter("Lukas", "Matthias");
            Assert.AreEqual("Lukas", l.Head.Next.Next.Next.Next.Name);
            l.InsertAfter(new PersonNode("Manfred"), "Lorenz");
            l.InsertAfter("Alex", l.Head.Next);
            Assert.AreEqual("Alex", l.Head.Next.Next.Name);
            l.InsertAfter(new PersonNode("Bernhard"), l.Head.Next.Next.Next.Next);
            Assert.AreEqual("Bernhard", l.Head.Next.Next.Next.Next.Next.Name);
        }

        [TestMethod]
        public void TestLength()
        {
            PersonLinkedList.PersonLinkedList l = new PersonLinkedList.PersonLinkedList();
            l.InsertLast("Clemens");
            l.InsertLast(new PersonNode("Felix"));
            l.InsertLast("Lorenz");
            l.InsertLast(new PersonNode("Matthias"));

            Assert.AreEqual(4, l.Length);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void TestRemove()
        {
            PersonLinkedList.PersonLinkedList l = new PersonLinkedList.PersonLinkedList();
            l.InsertLast("Clemens");
            l.InsertLast(new PersonNode("Felix"));
            l.InsertLast("Lorenz");
            l.InsertLast(new PersonNode("Matthias"));

            l.Remove("Lorenz");
            Assert.IsFalse(l.Contains("Lorenz"));

            l.Remove("Lukas");
            Assert.IsFalse(l.Contains("Lukas"));
        }
    }
}
