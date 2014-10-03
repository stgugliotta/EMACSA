using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace Gobbi.CoreServices.Configuration
{
    /// <summary>
    /// Representa una Colección de elementos de configuración genérica.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class GenericConfigurationElementCollection<T> : ConfigurationElementCollection, IXmlSerializable
    where T: ConfigurationNamedElement, new ()
    {
        /// <summary>
        /// Inicializa una nueva instancia.
        /// </summary>
        public GenericConfigurationElementCollection()
        {
           
        }

        #region Public Properties
        /// <summary>
        /// Retorna el item identificado por el indice.
        /// </summary>
        /// <param name="index">Número de ítems.</param>
        /// <returns>La instancia de <see cref="ConfigurationSourceElement"/>.</returns>
        public T this[int index]
        {
            get
            {
                return (T)base.BaseGet(index);
            }
            set
            {
                if (base.BaseGet(index) != null)
                    base.BaseRemoveAt(index);
                this.BaseAdd(index, value);
            }
        }

        /// <summary>
        /// Retorna el item identificado por el nombre.
        /// </summary>
        /// <param name="name">Nombre del ítem.</param>
        /// <returns></returns>
        public new T this[string name]
        {
            get
            {
                return (T)base.BaseGet(name);
            }
        }

        #endregion

                #region Methods
        /// <summary>
        /// Agrega un nuevo elemento configuración de proveedores.
        /// </summary>
        /// <param name="element">Una instancia de <see cref="ConfigurationSourceElement"/> a agregar.</param>
        public void Add(T element)
        {
            if(element != null)
                this.BaseAdd(element);
        }
        /// <summary>
        /// Quita todos los objetos de elemento de configuración de la colección.
        /// </summary>
        public void Clear()
        {
            base.BaseClear();
        }

        /// <summary>
        /// Quita un objeto <see cref="ConfigurationSourceElement"/> de la colección.
        /// </summary>
        /// <param name="name">Nombre de la configuración</param>
        public void Remove(string name)
        {
            base.BaseRemove(name);
        }

        /// <summary>
        /// Crea un nuevo objeto <see cref="ConfigurationSourceElement"/>.
        /// </summary>
        /// <returns>Un nuevo <see cref="ConfigurationSourceElement"/>.</returns>
        protected override ConfigurationElement CreateNewElement()
        {
            return new T();
        }
        /// <summary>
        /// Obtiene la clave de una instancia de <see cref="ConfigurationSourceElement"/>.
        /// </summary>
        /// <param name="element">La instancia de <see cref="ConfigurationSourceElement"/>.</param>
        /// <returns>La clave del objeto.</returns>
        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((ConfigurationNamedElement)element).Name;
        }
        #endregion

        #region IXmlSerializable Members

        /// <summary>
        /// Retorna el esquema de xml de la configuración.
        /// </summary>
        /// <returns>esquema de xml.</returns>
        public System.Xml.Schema.XmlSchema GetSchema()
        {
            return null;
        }

        /// <summary>
        /// Deserializa la colección de configuración.
        /// </summary>
        /// <param name="reader">Lector de la colección.</param>
        public void ReadXml(XmlReader reader)
        {
            reader.Read();
            this.DeserializeElement(reader, false);
        }

        /// <summary>
        /// Escribe la colección al <see cref="XmlWriter"/>.
        /// </summary>
        /// <param name="writer">Escritor de xml.</param>
        public void WriteXml(XmlWriter writer)
        {
            throw new NotImplementedException("The method or operation is not implemented.");
        }

        #endregion
    }
}
