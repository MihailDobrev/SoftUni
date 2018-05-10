namespace P02.ExtendedDatabaseTests
{
    using NUnit.Framework;
    using P02.ExtendedDatabase;
    using System;

    public class ExtendedDatabaseTests
    {
        [Test]
        public void AddPersonTest()
        {
            Database db = new Database();
            Person person = new Person(01, "Gosho");
            db.Add(person);
            Assert.That(db.People[0], Is.EqualTo(person));
        }

        [Test]
        public void RemovePersonTest()
        {
            Database db = new Database();
            Person person = new Person(01, "Gosho");
            db.Add(person);
            db.Remove("Gosho");
            Assert.That(db.People.Count, Is.EqualTo(0));
        }

        [Test]
        public void AddPersonWithSameId()
        {
            Database db = new Database();
            Person personOne = new Person(01, "Gosho");
            Person personTwo = new Person(01, "Pesho");
            db.Add(personOne);
            Assert.Throws<InvalidOperationException>(() => db.Add(personTwo));
        }
        [Test]
        public void AddPersonWithSameUsername()
        {
            Database db = new Database();
            Person personOne = new Person(01, "Gosho");
            Person personTwo = new Person(02, "Gosho");
            db.Add(personOne);
            Assert.Throws<InvalidOperationException>(() => db.Add(personTwo));
        }

        [Test]
        public void RemovePersonWithNonExistingUsernameTest()
        {
            Database db = new Database();
            Person person = new Person(01, "Gosho");
            db.Add(person);
            Assert.Throws<InvalidOperationException>(() => db.Remove("pesho"));
        }

        [Test]
        public void RemovePersonWithNonExistingIdTest()
        {
            Database db = new Database();
            Person person = new Person(01, "Gosho");
            db.Add(person);
            Assert.Throws<InvalidOperationException>(() => db.Remove(02));
        }

        [Test]
        public void FindPersonByNullUsernameTest()
        {
            Database db = new Database();
            Person person = new Person(01, "Gosho");
            db.Add(person);
            Assert.Throws<ArgumentException>(() => db.FindByUsername(null));
        }

        [Test]
        public void FindPersonByIncorrectUsernameTest()
        {
            Database db = new Database();
            Person person = new Person(01, "Gosho");
            db.Add(person);
            Assert.Throws<InvalidOperationException>(() => db.FindByUsername("Pesho"));
        }

        [Test]
        public void FindPersonByIdTest()
        {
            Database db = new Database();
            Person person = new Person(01, "Gosho");
            db.Add(person);
            Assert.That(db.FindById(01), Is.EqualTo(person));
        }

        [Test]
        public void FindPersonByNegativeId()
        {
            Database db = new Database();
            Person person = new Person(01, "Gosho");
            db.Add(person);
            Assert.Throws<ArgumentOutOfRangeException>(() => db.FindById(-01));
        }

        [Test]
        public void FindPersonByIncorrectId()
        {
            Database db = new Database();
            Person person = new Person(01, "Gosho");
            db.Add(person);
            Assert.Throws<InvalidOperationException>(() => db.FindById(02));
        }

    }
}
