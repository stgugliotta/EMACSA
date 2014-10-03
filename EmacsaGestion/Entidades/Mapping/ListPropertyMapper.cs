using System;
using System.Collections;
using System.Reflection;

namespace Entidades.Mapping
{
    internal class ListPropertyMapper : EntityPropertyMapper
    {
        public ListPropertyMapper(PropertyInfo inputProperty, PropertyInfo outputProperty, MethodInfo converter)
            : base(inputProperty, outputProperty, converter)
        {
        }

        public override void MapProperty(object inputInstance, object outputInstance)
        {
            IList inputList = (IList)InputProperty.GetValue(inputInstance, null);
            IList outputList = (IList)Activator.CreateInstance(OutputProperty.PropertyType);

            if (inputList != null)
            {
                foreach (object inputItem in inputList)
                {
                    object outputItem = ReflectionUtils.Invoke(Converter, null, new object[] { inputItem });
                    outputList.Add(outputItem);
                }
            }

            OutputProperty.SetValue(outputInstance, outputList, null);
        }
    }
}
