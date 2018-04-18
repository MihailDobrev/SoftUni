namespace SkeletonTests
{
    using NUnit.Framework;

    public class AxeTests
    {
        private const int axeAttack = 5;
        private const int axeDurability = 2;
        private const int dummyHealth = 20;
        private const int dummyExpirience = 20;

        private Axe axe;
        private Dummy dummy;

        [SetUp]
        public void TestAxe()
        {
            this.axe = new Axe(axeAttack, axeDurability);
            this.dummy = new Dummy(dummyHealth, dummyExpirience);
        }
        [Test]
        public void AxeLosesDurabilityAfterAttack()
        {
           
            axe.Attack(dummy);
            Assert.That(axe.DurabilityPoints, Is.EqualTo(1));
        }

        [Test]
        public void BrokenAxeCannotAttack()
        {
            axe.Attack(dummy);
            axe.Attack(dummy);
            Assert.That(() => axe.Attack(dummy), Throws.InvalidOperationException.With.Message.EqualTo("Axe is broken."));
        }

    }
}
