using Mono.Cecil;
using System;

public static class TypeReferenceExtensions
{
    public static bool Is<T>(this TypeReference reference) where T : class
    {
        return String.Equals(reference.FullName, typeof(T).FullName, StringComparison.OrdinalIgnoreCase);
    }
}

