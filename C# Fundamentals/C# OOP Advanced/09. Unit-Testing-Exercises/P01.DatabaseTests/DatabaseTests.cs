namespace DatabaseTests
{
    using NUnit.Framework;
    using P01.Database;
    using System;

    public class DatabaseTests
    {
        [Test]
        public void TestArrayCapacity()
        {
            Assert.Throws<InvalidOperationException>(() => new Database(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17 }));
        }
        [Test]
        public void TestAddElement()
        {
            Database db = new Database(new int[] { 1, 2, 3 });
            db.Add(4);
            Assert.That(db.Numbers[3], Is.EqualTo(4));
        }

        [Test]
        public void TestRemoveElement()
        {
            Database db = new Database(new int[] { 1, 2, 3 });
            db.Remove();
            Assert.That(db.Numbers[2], Is.EqualTo(0));
        }

        [Test]
        public void TestAddElementInFullArray()
        {
            Database db = new Database(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 });
            Assert.Throws<InvalidOperationException>(() => db.Add(17));
        }
        [Test]
        public void TestRemoveElementInEmptyArray()
        {
            Database db = new Database(new int[] { });
            Assert.Throws<InvalidOperationException>(() => db.Remove());
        }
    }
}
