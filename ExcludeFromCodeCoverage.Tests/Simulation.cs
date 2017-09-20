using ExcludeFromCodeCoverage.Tests.Type.Only;

[assembly: AttachExcludeFromCodeCoverage("ExcludeFromCodeCoverage.Tests.Namespace.Only")]
[assembly: AttachExcludeFromCodeCoverage("ExcludeFromCodeCoverage.Tests.Namespace.Hierarchy.*")]

[assembly: AttachExcludeFromCodeCoverage(typeof(TypeOnlyClass))]
[assembly: AttachExcludeFromCodeCoverage(typeof(TypeOnlyFilteredClass), "Property")]

[assembly: AttachExcludeFromCodeCoverage("ExcludeFromCodeCoverage.Tests.Type", "TypeClass")]
[assembly: AttachExcludeFromCodeCoverage("ExcludeFromCodeCoverage.Tests.Type.Dynamic", "Dynamic.*")]

[assembly: AttachExcludeFromCodeCoverage("ExcludeFromCodeCoverage.Tests.Type.Hierarchy.Child", "TypeChild.*", "Prop.*")]

namespace ExcludeFromCodeCoverage.Tests
{
    namespace Namespace
    {
        namespace Only
        {
            public class NamespaceOnlyClass : IClass
            {
                private string Field = string.Empty;

                public string Property { get; set; }

                public string Method()
                {
                    return Field;
                }
            }
        }

        namespace Hierarchy
        {
            namespace Child
            {

                public class NamespaceHierarchyChildClass : IClass
                {
                    private string Field;

                    public string Property { get; set; }

                    public string Method()
                    {
                        return Field;
                    }
                }
            }
        }
    }

    namespace Type
    {

        public class TypeClass : IClass
        {
            private string Field = string.Empty;

            public string Property { get; set; }

            public string Method()
            {
                return Field;
            }
        }

        public class TypeIgnoredClass : IClass
        {
            private string Field = string.Empty;

            public string Property { get; set; }

            public string Method()
            {
                return Field;
            }
        }

        namespace Only
        {
            public class TypeOnlyClass : IClass
            {
                private string Field = string.Empty;

                public string Property { get; set; }

                public string Method()
                {
                    return Field;
                }
            }

            public class TypeOnlyFilteredClass : IClass
            {
                private string Field = string.Empty;

                public string Property { get; set; }

                public string Method()
                {
                    return Field;
                }
            }
        }

        namespace Dynamic
        {
            public class DynamicFirstClass : IClass
            {
                private string Field = string.Empty;

                public string Property { get; set; }

                public string Method()
                {
                    return Field;
                }
            }

            public class DynamicOtherClass : IClass
            {
                private string Field = string.Empty;

                public string Property { get; set; }

                public string Method()
                {
                    return Field;
                }
            }
        }

        namespace Hierarchy
        {
            namespace Child
            {
                public class TypeChildClass : IClass
                {
                    private string Field = string.Empty;

                    public string Property { get; set; }

                    public string Method()
                    {
                        return Field;
                    }
                }

                public class TypeChildOtherClass : IClass
                {
                    private string Field = string.Empty;

                    public string Property { get; set; }

                    public string Method()
                    {
                        return Field;
                    }
                }

                public class TypeHierarchyIgnoredClass : IClass
                {
                    private string Field = string.Empty;

                    public string Property { get; set; }

                    public string Method()
                    {
                        return Field;
                    }
                }
            }
        }
    }
}