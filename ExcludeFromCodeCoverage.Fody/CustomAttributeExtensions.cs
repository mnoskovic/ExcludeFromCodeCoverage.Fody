using System;
using Mono.Cecil;

public static class CustomAttributeExtensions
{
    public static bool Is<T>(this CustomAttribute attribute) where T : class
    {
        return String.Equals(attribute.AttributeType.Name, typeof(T).Name, StringComparison.OrdinalIgnoreCase);
    }

    public static Definition AsDefinition(this CustomAttribute attribute)
    {
        var definition = new Definition();

        var first = attribute.ConstructorArguments[0];
        if (first.Type.Is<Type>())
        {
            var type = (TypeDefinition)first.Value;
            definition.Namespace = type.Namespace;
            definition.Type = type.Name;

            if (attribute.ConstructorArguments.Count == 2)
            {
                definition.Member = (string)attribute.ConstructorArguments[1].Value;
            }
        }
        else
        {
            definition.Namespace = (string)attribute.ConstructorArguments[0].Value;

            if (attribute.ConstructorArguments.Count > 1)
            {
                definition.Type = (string)attribute.ConstructorArguments[1].Value;
            }

            if (attribute.ConstructorArguments.Count > 2)
            {
                definition.Member = (string)attribute.ConstructorArguments[2].Value;
            }
        }

        return definition;
    }
}




