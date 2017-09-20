using ExcludeFromCodeCoverage.Tests.Namespace.Hierarchy.Child;
using ExcludeFromCodeCoverage.Tests.Namespace.Only;
using ExcludeFromCodeCoverage.Tests.Type;
using ExcludeFromCodeCoverage.Tests.Type.Dynamic;
using ExcludeFromCodeCoverage.Tests.Type.Hierarchy.Child;
using ExcludeFromCodeCoverage.Tests.Type.Only;
using NUnit.Framework;

namespace ExcludeFromCodeCoverage.Tests
{

    [TestFixture]
    public class SimulationTests
    {
        [Test]
        public void ClassesShouldBeInjectedCorrectly()
        {
            ExclusionAssert.IsExcluded<NamespaceOnlyClass>();
            ExclusionAssert.IsExcluded<NamespaceHierarchyChildClass>();

            ExclusionAssert.IsExcluded<TypeOnlyClass>();
            ExclusionAssert.IsExcluded<TypeOnlyFilteredClass>(method: false);

            ExclusionAssert.IsExcluded<TypeClass>();
            ExclusionAssert.IsExcluded<TypeIgnoredClass>(method: false, property:false);

            ExclusionAssert.IsExcluded<DynamicFirstClass>();
            ExclusionAssert.IsExcluded<DynamicOtherClass>();

            ExclusionAssert.IsExcluded<TypeChildClass>(method:false);
            ExclusionAssert.IsExcluded<TypeChildOtherClass>(method: false);
            ExclusionAssert.IsExcluded<TypeHierarchyIgnoredClass>(method: false, property: false);
        }
    }
}
