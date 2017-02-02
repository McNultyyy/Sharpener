using NUnit.Framework;

namespace Sharpener.Core.Test.IntExtension
{
    [TestFixture]
    public class IntToTest
    {

        [Test]
        public void EnumerateForward()
        {
            var expected = new[] { 1, 2, 3, 4, 5 };
            var actual = 1.To(5);

            Assert.That(actual, Is.EquivalentTo(expected));
        }


        [Test]
        public void EnumerateBackwards()
        {
            var expected = new[] { 5, 4, 3, 2, 1 };
            var actual = 5.To(1);

            Assert.That(actual, Is.EquivalentTo(expected));
        }

    }
}