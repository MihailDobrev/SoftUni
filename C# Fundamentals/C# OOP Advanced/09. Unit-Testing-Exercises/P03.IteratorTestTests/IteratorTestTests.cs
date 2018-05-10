namespace P03.IteratorTestTests
{
    using NUnit.Framework;
    using P03.IteratorTest;
    using System;

    public class IteratorTestTests
    {
        [Test]
        public void TestInstanciateListWithZeroParameters()
        {
            Assert.Throws<ArgumentNullException>(() => new ListIterator(null));
        }

        [Test]
        public void TestInstanciateListWithSomeParameters()
        {
            ListIterator listIterator = new ListIterator(new string[] {"Gosho", "Pesho"});
            Assert.That(listIterator.Collection[0], Is.EqualTo("Gosho"));
            Assert.That(listIterator.Collection[1], Is.EqualTo("Pesho"));
        }

        [Test]
        public void TestIfMoveReturnsTrue()
        {
            ListIterator listIterator = new ListIterator(new string[] { "Gosho", "Pesho" });
            Assert.AreEqual(listIterator.Move(),true);
        }

        [Test]
        public void TestIfMoveReturnsFasle()
        {
            ListIterator listIterator = new ListIterator(new string[] { "Gosho", "Pesho" });
            listIterator.Move();
            listIterator.Move();
            Assert.AreEqual(listIterator.Move(), false);
        }

        [Test]
        public void TestIfHasNextReturnsTrue()
        {
            ListIterator listIterator = new ListIterator(new string[] { "Gosho", "Pesho" });
            Assert.AreEqual(listIterator.HasNext(), true);
        }

        [Test]
        public void TestIfHasNextReturnsFasle()
        {
            ListIterator listIterator = new ListIterator(new string[] { "Gosho", "Pesho" });
            listIterator.Move();
            listIterator.Move();
            Assert.AreEqual(listIterator.HasNext(), false);
        }

        [Test]
        public void TestPrint()
        {
            ListIterator listIterator = new ListIterator(new string[] { });
            Assert.That(() => listIterator.Print(),Throws.Exception.With.Message.EqualTo("Invalid Operation!"));
        }
    }
}
