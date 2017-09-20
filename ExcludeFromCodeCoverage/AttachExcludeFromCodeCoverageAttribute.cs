using System;

[AttributeUsage(AttributeTargets.Assembly, AllowMultiple = true)]
public class AttachExcludeFromCodeCoverageAttribute : Attribute
{
    protected string Namespace { get; private set; }

    protected string Type { get; private set; }

    protected string Member { get; private set; }


    public AttachExcludeFromCodeCoverageAttribute(string @namespace)
    {
        Namespace = @namespace;
    }
    public AttachExcludeFromCodeCoverageAttribute(string @namespace, string type) : this(@namespace)
    {
        Type = type;
    }
    public AttachExcludeFromCodeCoverageAttribute(string @namespace, string type, string member) : this(@namespace, type)
    {
        Member = member;
    }


    public AttachExcludeFromCodeCoverageAttribute(Type type)
    {
        if (type == null)
        {
            throw new ArgumentNullException(nameof(type));
        }

        Namespace = type.Namespace;
        Type = type.Name;
    }

    public AttachExcludeFromCodeCoverageAttribute(Type type, string member) : this(type)
    {
        Member = member;
    }
}
