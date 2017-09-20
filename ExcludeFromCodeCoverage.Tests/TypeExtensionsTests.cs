using NUnit.Framework;
using System.Linq;

namespace ExcludeFromCodeCoverage.Tests
{
    [TestFixture]
    public class TypeExtensionsTests
    {
        [Test]
        public void TypeExtensionsShouldResolveMembers()
        {
            var types = typeof(IClass).Assembly.GetTypes().Where(t => typeof(IClass).IsAssignableFrom(t) && t.FullName != typeof(IClass).FullName);

            foreach (var type in types)
            {
                Assert.IsNotNull(type.Method());
                Assert.IsNotNull(type.Property());
                Assert.IsNotNull(type.Field());
            }
        }
    }

}
