using NUnit.Framework;

namespace ExcludeFromCodeCoverage.Tests
{
    public static class ExclusionAssert
    {
        public static void IsExcluded<T>(bool method = true, bool property = true)
        {
            IsExcluded(typeof(T), method, property);
        }

        public static void IsExcluded(System.Type type, bool method = true, bool property = true)
        {
            Assert.AreEqual(type.Method().IsExcluded(), method);
            Assert.AreEqual(type.Property().IsExcluded(), property);
            Assert.IsFalse(type.Field().IsExcluded());
        }
    }
}
