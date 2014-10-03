using System;
using System.Reflection;

namespace Entidades.Mapping
{
    internal interface IMappingPolicy
    {
        bool UseEntityMapper(Type inputPropertyType, Type outputPropertyType);
        
        bool UseListMapper(Type inputPropertyType, Type outputPropertyType);
        
        MethodInfo GetConverter(Type inputPropertyType, Type outputPropertyType);
    }
}
