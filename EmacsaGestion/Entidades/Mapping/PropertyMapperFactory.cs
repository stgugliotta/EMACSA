using System;
using System.Collections.Generic;
using System.Reflection;

namespace Entidades.Mapping
{
    internal static class PropertyMapperFactory
    {
        private static Dictionary<Type, object> mapperSequenceCache = new Dictionary<Type, object>();

        internal static PropertyMapperSequence<TInput, TOutput> GetPropertyMapperSequence<TInput, TOutput>(IMappingPolicy mappingPolicy)
        {
            if (!mapperSequenceCache.ContainsKey(typeof(PropertyMapperSequence<TInput, TOutput>)))
            {
                mapperSequenceCache.Add(
                    typeof(PropertyMapperSequence<TInput, TOutput>),
                    GetPropertyMapperSequenceInternal<TInput, TOutput>(mappingPolicy));
            }

            PropertyMapperSequence<TInput, TOutput> mapperSequence =
                (PropertyMapperSequence<TInput, TOutput>)mapperSequenceCache[typeof(PropertyMapperSequence<TInput, TOutput>)];

            return mapperSequence;
        }

        private static PropertyMapperSequence<TInput, TOutput> GetPropertyMapperSequenceInternal<TInput, TOutput>(IMappingPolicy mappingPolicy)
        {
            Type inputType = typeof(TInput);
            Type outputType = typeof(TOutput);

            PropertyMapperSequence<TInput, TOutput> mapperSequence = new PropertyMapperSequence<TInput, TOutput>();

            PropertyInfo[] inputProperties = inputType.GetProperties();

            foreach (PropertyInfo inputProperty in inputProperties)
            {
                PropertyInfo outputProperty = outputType.GetProperty(inputProperty.Name);

                if (outputProperty != null)
                {
                    if (mappingPolicy.UseEntityMapper(inputProperty.PropertyType, outputProperty.PropertyType))
                    {
                        MethodInfo converter = mappingPolicy.GetConverter(inputProperty.PropertyType, outputProperty.PropertyType);
                        mapperSequence.Add(new EntityPropertyMapper(inputProperty, outputProperty, converter));
                    }
                    else if (mappingPolicy.UseListMapper(inputProperty.PropertyType, outputProperty.PropertyType))
                    {
                        MethodInfo converter = mappingPolicy.GetConverter(inputProperty.PropertyType.GetGenericArguments()[0], outputProperty.PropertyType.GetGenericArguments()[0]);
                        mapperSequence.Add(new ListPropertyMapper(inputProperty, outputProperty, converter));
                    }
                    else
                    {
                        mapperSequence.Add(new PropertyMapper(inputProperty, outputProperty));
                    }
                }
            }

            return mapperSequence;
        }
    }
}