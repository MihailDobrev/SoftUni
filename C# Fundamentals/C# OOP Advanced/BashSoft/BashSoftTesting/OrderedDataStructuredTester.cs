namespace BashSoftTesting
{
    using BashSoftProgram.Contracts;
    using BashSoftProgram.DataStructures;
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;

    public class OrderedDataStructuredTester
    {

        public ISimpleOrderedBag<string> names;

        [Test]
        public void TestEmptyCtor()
        {
            this.names = new SimpleSortedList<string>();
            Assert.AreEqual(this.names.Capacity, 16);
            Assert.AreEqual(this.names.Size, 0);
        }

        [Test]
        public void TestCtorWithinInitialCapacity()
        {
            this.names = new SimpleSortedList<string>(20);
            Assert.AreEqual(this.names.Capacity, 20);
            Assert.AreEqual(this.names.Size, 0);
        }

        [Test]
        public void TestCtorWithAllParams()
        {
            this.names = new SimpleSortedList<string>(StringComparer.OrdinalIgnoreCase, 30);
            Assert.AreEqual(this.names.Capacity, 30);
            Assert.AreEqual(this.names.Size, 0);
        }

        [Test]
        public void TestCtorWithInitialComparer()
        {
            this.names = new SimpleSortedList<string>(StringComparer.OrdinalIgnoreCase);
            Assert.AreEqual(this.names.Capacity, 16);
            Assert.AreEqual(this.names.Size, 0);
        }

        [Test]
        public void TestAddIncreasesSize()
        {
            this.names = new SimpleSortedList<string>();
            this.names.Add("Nasko");
            Assert.AreEqual(1, this.names.Size);
        }

        [Test]
        public void TestAddNullThrowsException()
        {
            Assert.Throws<ArgumentNullException>(() => names.Add(null));
        }

        [Test]
        public void TestAddUnsortedDataIsHeldSorted()
        {
            this.names = new SimpleSortedList<string>();
            this.names.Add("Rosen");
            this.names.Add("Georgi");
            this.names.Add("Balkan");
            List<string> sorted = new List<string>() { "Balkan", "Georgi", "Rosen" };
            CollectionAssert.AreEqual(sorted, names);
        }

        [Test]
        public void TestAddingMoreThanInitialCapacity()
        {
            int capacity = 16;
            this.names = new SimpleSortedList<string>();

            for (int i = 0; i < capacity + 1; i++)
            {
                names.Add($"{i.ToString()}");
            }
            Assert.That(names.Size == 17);
            Assert.That(names.Capacity != 16);
        }

        [Test]
        public void TestAddingAllFromCollectionIncreasesSize()
        {
            this.names = new SimpleSortedList<string>();
            names.AddAll(new[] { "Georgi", "Rosen" });
            Assert.That(names.Size, Is.EqualTo(2));
        }

        [Test]
        public void TestAddingAllFromNullThrowsException()
        {
            this.names = new SimpleSortedList<string>();
            Assert.Throws<ArgumentNullException>(() => names.AddAll(null));
        }

        [Test]
        public void TestAddAllKeepsSorted()
        {
            this.names = new SimpleSortedList<string>();
            this.names.AddAll(new string[] { "Rosen", "Georgi", "Balkan" });
            List<string> sorted = new List<string>() { "Balkan", "Georgi", "Rosen" };
            CollectionAssert.AreEqual(sorted, names);
        }


        [Test]
        public void TestRemoveValidElementDecreasesSize()
        {
            this.names = new SimpleSortedList<string>();
            this.names.AddAll(new string[] { "Rosen", "Georgi", "Balkan" });
            names.Remove("Rosen");
            Assert.That(names.Size, Is.EqualTo(2));
        }

        [Test]
        public void TestRemoveValidElementRemovesSelectedOne()
        {
            this.names = new SimpleSortedList<string>();
            this.names.AddAll(new string[] { "ivan", "nasko" });
            names.Remove("ivan");
            CollectionAssert.DoesNotContain(names, "ivan");
        }

        [Test]
        public void TestRemovingNullThrowsException()
        {
            this.names = new SimpleSortedList<string>();
            this.names.AddAll(new string[] { "ivan", "nasko" });
            Assert.Throws<ArgumentNullException>(() => names.Remove(null));
        }

        [Test]
        public void TestJoinWithNull()
        {
            this.names = new SimpleSortedList<string>();
            this.names.AddAll(new string[] { "ivan", "nasko" });
            Assert.Throws<ArgumentNullException>(() => names.JoinWith(null));
        }

        [Test]
        public void TestJoinWorksFine()
        {
            this.names = new SimpleSortedList<string>();
            this.names.AddAll(new string[] { "ivan", "nasko" });
            string joinedNames = names.JoinWith(", ");
            Assert.That(joinedNames,Is.EqualTo("ivan, nasko"));
        }
    }
}
