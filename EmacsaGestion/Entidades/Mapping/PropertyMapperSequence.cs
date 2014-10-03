using System.Collections.Generic;

namespace Entidades.Mapping
{
    internal class PropertyMapperSequence<TInput, TOutput> : List<PropertyMapper>
    {
        public void MapProperties(TInput inputInstance, TOutput outputInstance)
        {
            ForEach(delegate(PropertyMapper mapper) { mapper.MapProperty(inputInstance, outputInstance); });
        }
    }
}