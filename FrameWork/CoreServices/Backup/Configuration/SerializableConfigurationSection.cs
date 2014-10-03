using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Xml.Serialization;
using System.Xml.Schema;
using System.Xml;

namespace ar.com.telecom.eva.CoreServices.Configuration
{
    /// <summary>
    /// Representa un <see cref="ConfigurationSection"/> que puede ser serializado y deserializado a XML.
    /// </summary>
    public class SerializableConfigurationSection : ConfigurationSection, IXmlSerializable
    {
        /// <summary>
        /// Inicializa una nueva instancia.
        /// </summary>
        public SerializableConfigurationSection()
        {

        }

        /// <summary>
        /// Returns the XML schema for the configuration section.
        /// </summary>
        /// <returns>Una cadena de texto con el esquema XML, o <see langword="null"/>. Si no hay esquema.</returns>
        public XmlSchema GetSchema()
        {
            return null;
        }

        /// <summary>
        /// Actualiza la <see cref="ConfigurationSection"/> con los valores de un <see cref="XmlReader"/>.
        /// </summary>
        /// <param name="reader"> El <see cref="XmlReader"/> que lee la configuración ubicada en el elemento 
        /// que describe la <see cref="ConfigurationSection"/>. </param>
        /// 
        public void ReadXml(XmlReader reader)
        {
            DeserializeSection(reader);

        }

        /// <summary>
        /// Escribe los valores de la <see cref="ConfigurationSection"/> como elementos XML en un <see cref="XmlWriter"/>.
        /// </summary>
        /// <param name="writer">El <see cref="XmlWriter"/> escribe la configuración.</param>
        public void WriteXml(XmlWriter writer)
        {
            String serialized = SerializeSection(this, "SerializableConfigurationSection", ConfigurationSaveMode.Full);
            writer.WriteRaw(serialized);
        }
    }
}
