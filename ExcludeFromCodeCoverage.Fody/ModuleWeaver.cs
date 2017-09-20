using System;
using System.Collections.Generic;
using System.Linq;
using Mono.Cecil;
using System.Diagnostics.CodeAnalysis;
using System.Text.RegularExpressions;


public class ModuleWeaver
{
    private static readonly string SYSTEM = "System";
    private static readonly string ALL = ".*";


    public Action<string> LogInfo { get; set; }
    public Action<string> LogError { get; set; }
    public ModuleDefinition ModuleDefinition { get; set; }
    public IAssemblyResolver AssemblyResolver { get; set; }

    public ModuleWeaver()
    {
        LogInfo = s => { };
        LogError = s => { };
    }

    public void Execute()
    {

        var definitions = new List<Definition>();
        var attributes = new List<CustomAttribute>();

        foreach (var customAttribute in ModuleDefinition.Assembly.CustomAttributes)
        {
            if (customAttribute.Is<AttachExcludeFromCodeCoverageAttribute>())
            {
                definitions.Add(customAttribute.AsDefinition());
                attributes.Add(customAttribute);
            }
        }

        foreach (var attribute in attributes)
        {
            ModuleDefinition.Assembly.CustomAttributes.Remove(attribute);
        }

        var types = ModuleDefinition.Types.Where(t => t.IsEnum == false && !t.CustomAttributes.Any(a => a.Is<ExcludeFromCodeCoverageAttribute>()));

        var excludeFromCodeCoverageConstructor = FindExcludeFromCodeCoverageConstructor(AssemblyResolver, ModuleDefinition);
        var excludeFromCodeCoverageAttribute = new CustomAttribute(excludeFromCodeCoverageConstructor);

        foreach (var definition in definitions)
        {
            if (String.IsNullOrEmpty(definition.Namespace))
            {
                continue;
            }

            AddAttribute(types, definition, excludeFromCodeCoverageAttribute);
        }
    }

    private MethodReference FindExcludeFromCodeCoverageConstructor(IAssemblyResolver assemblyResolver, ModuleDefinition moduleDefinition)
    {
        var reference = assemblyResolver.Resolve(new AssemblyNameReference(SYSTEM, null));
        var excludeFromCodeCoverageAttribute = reference.MainModule.Types.First(t => t.Is<ExcludeFromCodeCoverageAttribute>());
        return moduleDefinition.ImportReference(excludeFromCodeCoverageAttribute.Methods.First(x => x.IsConstructor));
    }


    private void AddAttribute(IEnumerable<TypeDefinition> types, Definition definition, CustomAttribute excludeFromCodeCoverageAttribute)
    {
        var namespaceRegex = new Regex(definition.Namespace);

        var filteredTypes = types.Where(t => namespaceRegex.IsMatch(t.Namespace));

        var typeFilter = String.IsNullOrEmpty(definition.Type) ? ALL : definition.Type;
        var typeRegex = new Regex(typeFilter);

        filteredTypes = filteredTypes.Where(t => typeRegex.IsMatch(t.Name));

        var memberFilter = String.IsNullOrEmpty(definition.Member) ? ALL : definition.Member;
        var memberRegex = new Regex(memberFilter);

        foreach (var type in filteredTypes)
        {
            foreach (var prop in type.Properties.Where(p => p.GetMethod != null && p.GetMethod.IsPublic && memberRegex.IsMatch(p.GetMethod.Name)))
            {
                AddAttribute(prop, excludeFromCodeCoverageAttribute);
            }

            foreach (var method in type.Methods.Where(m => m.IsPublic && memberRegex.IsMatch(m.Name)))
            {
                AddAttribute(method, excludeFromCodeCoverageAttribute);
            }
        }
    }
    
    private void AddAttribute(ICustomAttributeProvider provider, CustomAttribute attribute)
    {
        if (!provider.CustomAttributes.Any(c => c.Is<ExcludeFromCodeCoverageAttribute>()))
        {
            provider.CustomAttributes.Add(attribute);
        }
    }
}