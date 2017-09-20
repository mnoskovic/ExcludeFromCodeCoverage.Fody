using NUnit.Framework;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace ExcludeFromCodeCoverage.Tests
{
    [TestFixture]
    public class MemberInfoExtensionsTests
    {
        private class Member
        {
            [ExcludeFromCodeCoverage]
            public string Property { get; set; }
        }


        [Test]
        public void MemberInfoExtensionsShouldResolveAttribute()
        {
            Assert.IsTrue(typeof(Member).GetProperty("Property").IsExcluded());
        }
    }

}
