using System;

/// <summary>
/// Attaches ExcludeFromCodeCoverage to public members of all matching types
/// </summary>
[AttributeUsage(AttributeTargets.Assembly, AllowMultiple = true)]
public class AttachExcludeFromCodeCoverageAttribute : Attribute
{
    /// <summary>
    /// Namespace regex
    /// </summary>
    protected string Namespace { get; private set; }

    /// <summary>
    /// Type regex
    /// </summary>
    protected string Type { get; private set; }


    /// <summary>
    /// Member regex
    /// </summary>
    protected string Member { get; private set; }


    /// <summary>
    /// Attaches ExcludeFromCodeCoverage to all public members of all types in specific namespace(s)
    /// </summary>
    /// <param name="namespace">use namespace name or regex e.g. "namespace" or "namespace.*"</param>
    public AttachExcludeFromCodeCoverageAttribute(string @namespace)
    {
        Namespace = @namespace;
    }

    /// <summary>
    ///  Attaches ExcludeFromCodeCoverage to all public members of all matching types in specific namespace(s)
    /// </summary>
    /// <param name="namespace">use namespace name or regex e.g. "namespace" or "namespace.*"</param>
    /// <param name="type">use type name or regex e.g. "MyController" or ".*Controller"</param>
    public AttachExcludeFromCodeCoverageAttribute(string @namespace, string type) : this(@namespace)
    {
        Type = type;
    }

    /// <summary>
    ///  Attaches ExcludeFromCodeCoverage to public members of all matching types in specific namespace(s)
    /// </summary>
    /// <param name="namespace">use namespace name or regex e.g. "namespace" or "namespace.*"</param>
    /// <param name="type">use type name or regex e.g. "MyController" or ".*Controller"</param>
    /// <param name="member">use member name or regex e.g. "Format" or "Format.*"</param>
    public AttachExcludeFromCodeCoverageAttribute(string @namespace, string type, string member) : this(@namespace, type)
    {
        Member = member;
    }

    /// <summary>
    ///  Attaches ExcludeFromCodeCoverage to public members of specific type
    /// </summary>
    /// <param name="type">Type where you want to attach the attribue on all public members e.g. typeof(MyClass)</param>
    public AttachExcludeFromCodeCoverageAttribute(Type type)
    {
        if (type == null)
        {
            throw new ArgumentNullException(nameof(type));
        }

        Namespace = type.Namespace;
        Type = type.Name;
    }

    /// <summary>
    ///  Attaches ExcludeFromCodeCoverage to public members of specific type
    /// </summary>
    /// <param name="type">Type where you want to attach the attribue on all public members e.g. typeof(MyClass)</param>
    /// <param name="member">use member name or regex e.g. "Format" or "Format.*"</param>
    public AttachExcludeFromCodeCoverageAttribute(Type type, string member) : this(type)
    {
        Member = member;
    }
}
