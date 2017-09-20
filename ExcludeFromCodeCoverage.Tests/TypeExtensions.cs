using System.Reflection;

namespace ExcludeFromCodeCoverage.Tests
{
    public static class TypeExtensions
    {
        public static MethodInfo Method(this System.Type type)
        {
            return type.GetMethod("Method");
        }

        public static FieldInfo Field(this System.Type type)
        {
            return type.GetField("Field", BindingFlags.Instance | BindingFlags.NonPublic);
        }

        public static PropertyInfo Property(this System.Type type)
        {
            return type.GetProperty("Property");
        }
    }

}
