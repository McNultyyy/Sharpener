using System;
using NUnit.Framework;

namespace Sharpener.Core.Test.ClassExtension
{
    [TestFixture]
    public class ClassThrowIfNullTest
    {
        [Test]
        public void ThrowWhenNull()
        {
            object nullObj = null;
            Assert.Throws<NullReferenceException>(() => nullObj.ThrowIfNull());
        }

        [Test]
        public void DoNothingWhenNotNull()
        {
            var nonNullObject = new object();
            Assert.DoesNotThrow(() => nonNullObject.ThrowIfNull());
        }

    }
}