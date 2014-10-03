using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Configuration;
using System.Xml;
using System.Xml.Serialization;


namespace ar.com.telecom.eva.CoreServices.Configuration
{
    /// <summary>
    /// Es un elemento de configuración que almacena automaticamente en Diccionarios los elementos de configuración>
    /// </summary>
    public class DynamicConfigurationElement : ConfigurationNamedElement, IXmlSerializable
    {

        #region Private Fields

        Dictionary<string, XmlNode> unrecognizedNodes = new Dictionary<string, XmlNode>();
        Dictionary<string, object> unrecognizedElements = new Dictionary<string, object>();
        private object syncObject = new object();

        #endregion

        /// <summary>
        /// Inicializa una nueva instancia.
        /// </summary>
        public DynamicConfigurationElement()
        {

        }
        
        /// <summary>
        /// Obtiene el valor de una propiedad de configuración.
        /// </summary>
        /// <param name="name">Nombre de la propiedad.</param>
        /// <returns>Valor de la propiedad.</returns>
        public string GetPropertyValue(string name)
        {
                    string value = null;

            if(this.Properties.Contains(name))
            {

                ConfigurationProperty property = this.Properties[name];
                if (property != null)
                {
                    value = base[property] as string;
                }
            }

            return value;
        }

        /// <summary>
        /// Retorna el elemento de configuración deserializado.
        /// </summary>
        /// <param name="elementName">El nombre del elemento pasado en la configuración.</param>
        /// <param name="type">Un <see cref="Type"/> que hereda de DynamicConfigurationElement y sabe como deserializar al <see cref="XmlNode"/></param>
        /// <returns>Un elemento de configuración deserializado.</returns>
        public object GetElement(string elementName, Type type)
        {
            if(!unrecognizedNodes.ContainsKey(elementName))
                return null;

            lock(syncObject)
            {
                if(unrecognizedElements.ContainsKey(elementName))
                    return unrecognizedElements[elementName];

                XmlNode node = unrecognizedNodes[elementName];
                object elementObject = node;

                Type[] types =
                    type.FindInterfaces(
                        delegate(Type iType, object criteriaObj) { return iType == typeof(IXmlSerializable); },
                        null);

                if (types != null && types.Length > 0)
                {
                    IXmlSerializable elementObjectXmlSerializable = (IXmlSerializable)Activator.CreateInstance(type);
                    elementObjectXmlSerializable.ReadXml(new XmlNodeReader(node));
                    elementObject = elementObjectXmlSerializable;
                }

                unrecognizedElements.Add(elementName, elementObject);

                return elementObject;
            }
        }

        /// <summary>
        /// <para> Recibe atributos de configuración no reconocidos.</para>
        /// </summary>
        /// <param name="name">Nombre del atributo no reconocido.</param>
        /// <param name="value">Valor del atributo no reconocido.</param>
        /// <returns>True si el atributo fue agregado correctamente.</returns>
        protected override bool OnDeserializeUnrecognizedAttribute(string name, string value)
        {
            ConfigurationProperty property = new ConfigurationProperty(name, typeof(string), value);
            Properties.Add(property);
            base[property] = value;

            return true;
        }

        /// <summary>
        /// Nombre del elemento de configuración no reconocido.
        /// </summary>
        /// <param name="name">Nombre del elemenento.</param>
        /// <param name="reader">El lector de Xml que lee el elemento.</param>
        /// <returns>True si el atributo fue agregado correctamente.</returns>
        protected override bool OnDeserializeUnrecognizedElement(string name, System.Xml.XmlReader reader)
        {
            XmlDocument elementDoc = new XmlDocument();
            elementDoc.Load(reader);

            unrecognizedNodes.Add(name, elementDoc.DocumentElement);

            return true;
        }

        #region IXmlSerializable Members

        ///<summary>
        /// Retorna el esquema xml.
        ///</summary>
        ///<returns>el esquema xml.</returns>
        public System.Xml.Schema.XmlSchema GetSchema()
        {
            return null;
        }

        /// <summary>
        /// Carga la instancia desde el <see cref="XmlReader"/>.
        /// </summary>
        /// <param name="reader">Lector de xml de configuración.</param>
        public void ReadXml(XmlReader reader)
        {
            reader.Read();
            this.DeserializeElement(reader, false);
        }

        /// <summary>
        /// Escribe la instancia al <see cref="XmlWriter"/>
        /// </summary>
        /// <param name="writer">Escritor de xml de configuración.</param>
        /// <remarks>Este método no está implementado. No necesita ser llamado.</remarks>
        public void WriteXml(XmlWriter writer)
        {
            throw new NotImplementedException("The method or operation is not implemented.");
        }

        #endregion
    }
}
