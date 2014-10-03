using System.Reflection;

namespace Entidades.Mapping
{
    internal class PropertyMapper
    {
        private PropertyInfo inputProperty;
        private PropertyInfo outputProperty;

        protected PropertyInfo InputProperty
        {
            get { return this.inputProperty; }
            set { this.inputProperty = value; }
        }

        protected PropertyInfo OutputProperty
        {
            get { return this.outputProperty; }
            set { this.outputProperty = value; }
        }

        public PropertyMapper(PropertyInfo inputProperty, PropertyInfo outputProperty)
        {
            this.inputProperty = inputProperty;
            this.outputProperty = outputProperty;
        }

        public virtual void MapProperty(object inputInstance, object outputInstance)
        {
            this.OutputProperty.SetValue(outputInstance, this.InputProperty.GetValue(inputInstance, null), null);
        }
    }
}
