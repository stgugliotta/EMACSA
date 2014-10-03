using System;
using System.Collections.Generic;
using System.Reflection;

namespace Entidades.Mapping
{
    internal class DataContractMappingPolicy : IMappingPolicy
    {
        public bool UseEntityMapper(Type inputPropertyType, Type outputPropertyType)
        {
            return ReflectionUtils.IsGenericType(inputPropertyType, typeof(Entity<,>));
        }

        public bool UseListMapper(Type inputPropertyType, Type outputPropertyType)
        {
            return ReflectionUtils.IsGenericType(inputPropertyType, typeof(List<>)) &&
                   ReflectionUtils.IsGenericType(outputPropertyType, typeof(List<>)) &&
                   ReflectionUtils.IsGenericType(inputPropertyType.GetGenericArguments()[0], typeof(Entity<,>));
        }

        public MethodInfo GetConverter(Type inputPropertyType, Type outputPropertyType)
        {
            Type genericEntityType = 
                typeof(Entity<,>).MakeGenericType(inputPropertyType, outputPropertyType);

            return genericEntityType.GetMethod("op_Explicit", new Type[] { genericEntityType });
        }
    }
}
