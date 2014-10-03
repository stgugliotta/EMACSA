using System;

using System.Collections.Generic;

using System.Text;

using System.Xml.Serialization;

namespace ar.com.telecom.eva.CoreServices.Logging
{
    /// <summary>
    /// Es un Diccionario que a su vez es puede ser serializado a xml.
    /// </summary>
    /// <typeparam name="TKey"><see cref="Type"/> de la clave.</typeparam>
    /// <typeparam name="TValue"><see cref="Type"/> de valor a contener.</typeparam>
    [XmlRoot("dictionary")]
    public class SerializableDictionary<TKey, TValue>
        : Dictionary<TKey, TValue>, IXmlSerializable
    {
        /// <summary>
        /// Inicializa la instancia.
        /// </summary>
        public SerializableDictionary()
            : base()
        {
        }
        /// <summary>
        /// Inicializa la instancia a partir de otro Diccionario Serializable.
        /// </summary>
        /// <param name="serializableDictionary">Diccionario de referencia.</param>
        public SerializableDictionary(SerializableDictionary<TKey, TValue> serializableDictionary)
            :base(serializableDictionary)
        {
        }

        #region IXmlSerializable Members

        /// <summary>
        /// Retorna el esquema de xml del diccionario.
        /// </summary>
        /// <returns>esquema de xml.</returns>
        public System.Xml.Schema.XmlSchema GetSchema()
        {
            return null;
        }

        /// <summary>
        /// Deserializa el diccionario.
        /// </summary>
        /// <param name="reader">Lector del xml del diccionario.</param>
        public void ReadXml(System.Xml.XmlReader reader)
        {
            XmlSerializer keySerializer = new XmlSerializer(typeof(TKey));
            XmlSerializer valueSerializer = new XmlSerializer(typeof(TValue));
            bool wasEmpty = reader.IsEmptyElement;
            reader.Read();
            if (wasEmpty)
                return;
            while (reader.NodeType != System.Xml.XmlNodeType.EndElement)
            {
                reader.ReadStartElement("propiedad");
                reader.ReadStartElement("clave");
                TKey key = (TKey)keySerializer.Deserialize(reader);
                reader.ReadEndElement();
                reader.ReadStartElement("valor");
                TValue value = (TValue)valueSerializer.Deserialize(reader);
                reader.ReadEndElement();
                this.Add(key, value);
                reader.ReadEndElement();
                reader.MoveToContent();
            }
            reader.ReadEndElement();
        }

        /// <summary>
        /// Escribe las entradas del diccionario al <see cref="System.Xml.XmlWriter"/>.
        /// </summary>
        /// <param name="writer">Escritor de xml.</param>
        public void WriteXml(System.Xml.XmlWriter writer)
        {
            XmlSerializer keySerializer = new XmlSerializer(typeof(TKey));
            XmlSerializer valueSerializer = new XmlSerializer(typeof(TValue));
            foreach (TKey key in this.Keys)
            {
                writer.WriteStartElement("propiedad");
                writer.WriteStartElement("clave");
                keySerializer.Serialize(writer, key);
                writer.WriteEndElement();
                writer.WriteStartElement("valor");
                TValue value = this[key];
                valueSerializer.Serialize(writer, value);
                writer.WriteEndElement();
                writer.WriteEndElement();
            }
        }
        #endregion
    }
}

