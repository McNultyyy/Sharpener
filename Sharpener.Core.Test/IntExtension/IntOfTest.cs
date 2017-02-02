using System;
using NUnit.Framework;

namespace Sharpener.Core.Test.IntExtension
{
    [TestFixture]
    public class IntForTest
    {

        [Test]
        public void PositiveAmount()
        {
            var instances = 3.Of("hello");

            Assert.That(instances, Is.EquivalentTo(new[] { "hello", "hello", "hello" }));
        }


        [Test]
        public void ZeroAmount()
        {
            var instances = 0.Of("hello");

            Assert.That(instances, Is.Empty);
        }

        [Test]
        public void NegativeAmount()
        {
            Assert.Throws<ArgumentException>(() => (-3).Of("hello"));
        }

    }
}