using NUnit.Framework;
using NUnit.Framework.Internal;

namespace Sharpener.Core.Test
{
    [TestFixture()]
    public class IntExtensionTest
    {

        [Test]
        public void IntToTest()
        {
            var expected = new[] { 1, 2, 3, 4, 5 };
            var actual = 1.To(5);

            Assert.That(actual, Is.EquivalentTo(expected));
        }

    }
}