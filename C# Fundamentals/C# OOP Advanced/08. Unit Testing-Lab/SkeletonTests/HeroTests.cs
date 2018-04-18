namespace SkeletonTests
{
    using Moq;
    using NUnit.Framework;
    public class HeroTests
    {
        [Test]
        public void HeroGainsExpirienceAfterTargetDies()
        {

            var target = new Mock<ITarget>();
            target.Setup(t => t.IsDead()).Returns(true);
            target.Setup(t => t.GiveExperience()).Returns(5);

            var weapon = new Mock<IWeapon>();
           
            var hero = new Hero("Superman", weapon.Object);
            hero.Attack(target.Object);
             weapon.Verify(w => w.Attack(target.Object));
            Assert.That(hero.Experience, Is.EqualTo(5));
        }
    }
}
