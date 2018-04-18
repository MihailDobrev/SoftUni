namespace SkeletonTests
{
    using NUnit.Framework;
    using System;

    public class DummyTests
    {
        private const int dummyHealth = 10;
        private const int dummyXP = 10;
        private Dummy dummy;

        [SetUp]
        public void TestDummy()
        {
           this.dummy = new Dummy(dummyHealth, dummyXP);
        }
        [Test]
        public void DummyLosesHealthAfterAttack()
        {
            dummy.TakeAttack(5);
            Assert.That(dummy.Health, Is.EqualTo(5));
        }

        [Test]
        public void DummyThrowsExceptionIfAttacked()
        {
            dummy.TakeAttack(10);
            Assert.Throws<InvalidOperationException>(() => dummy.TakeAttack(1));
        }

        [Test]
        public void DeadDummyCanGiveXP()
        {
            dummy.TakeAttack(10);
            int xp = dummy.GiveExperience();
            Assert.That(xp, Is.EqualTo(10));
        }

        [Test]
        public void AliveDummyCantGiveXP()
        {
            Assert.Throws<InvalidOperationException>(() => dummy.GiveExperience());
        }

    }
}
