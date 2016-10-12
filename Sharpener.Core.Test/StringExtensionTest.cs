using NUnit.Framework;
using Sharpener.Core;

namespace Sharpener.Core.Test
{
    [TestFixture]
    public class StringExtensionTest
    {
        [Test]
        public void FormatWithTest()
        {
            var format = "number: {0}, word: {1}";
            var args = new object[] { 1, "hello" };

            var actual = format.FormatWith(args);
            var expected = "number: 1, word: hello";

            Assert.That(expected, Is.EqualTo(actual));
        }

    }
}