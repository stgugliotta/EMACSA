using System.Reflection;

namespace Entidades.Mapping
{
    internal class EntityPropertyMapper : PropertyMapper
    {
        private MethodInfo converter;

        protected MethodInfo Converter
        {
            get { return this.converter; }
            set { this.converter = value; }
        }

        public EntityPropertyMapper(PropertyInfo inputProperty, PropertyInfo outputProperty, MethodInfo converter)
            : base(inputProperty, outputProperty)
        {
            this.converter = converter;
        }

        public override void MapProperty(object inputInstance, object outputInstance)
        {
            object inputValue = InputProperty.GetValue(inputInstance, null);

            object outputValue = ReflectionUtils.Invoke(this.Converter, null, new object[] { inputValue });
            
            OutputProperty.SetValue(outputInstance, outputValue, null);
        }
    }
}
