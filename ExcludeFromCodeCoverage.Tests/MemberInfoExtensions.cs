using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;

namespace ExcludeFromCodeCoverage.Tests
{
    public static class MemberInfoExtensions
    {
        public static bool IsExcluded(this MemberInfo member)
        {
            return member.GetCustomAttributes(false).OfType<ExcludeFromCodeCoverageAttribute>().Any();
        }
    }

}
