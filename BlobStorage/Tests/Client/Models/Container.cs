// MIT

namespace BlobStorageTest.Client.Models
{
    using Client;
    using Newtonsoft.Json;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml;
    using System.Xml.Linq;

    /// <summary>
    /// An Azure Storage container
    /// </summary>
    public partial class Container
    {
        /// <summary>
        /// Initializes a new instance of the Container class.
        /// </summary>
        public Container() { }

        /// <summary>
        /// Initializes a new instance of the Container class.
        /// </summary>
        public Container(string name = default(string), ContainerProperties properties = default(ContainerProperties), IDictionary<string, string> metadata = default(IDictionary<string, string>))
        {
            Name = name;
            Properties = properties;
            Metadata = metadata;
        }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "Name")]
        public string Name { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "Properties")]
        public ContainerProperties Properties { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "Metadata")]
        public IDictionary<string, string> Metadata { get; set; }

        /// <summary>
        /// Serializes the object to an XML node
        /// </summary>
        internal XElement XmlSerialize(XElement result)
        {
            if( null != Name )
            {
                result.Add(new XElement("Name", Name) );
            }
            if( null != Properties )
            {
                result.Add(Properties.XmlSerialize(new XElement( "Properties" )));
            }
            if( null != Metadata )
            {
                var dict = new XElement("Metadata");
                foreach( var key in Metadata.Keys ){
                    dict.Add(new XElement( key, Metadata[key] ) );
                }
                result.Add(dict);
            }
            return result;
        }
        /// <summary>
        /// Deserializes an XML node to an instance of Container
        /// </summary>
        internal static Container XmlDeserialize(string payload)
        {
            // deserialize to xml and use the overload to do the work
            return XmlDeserialize( XElement.Parse( payload ) );
        }
        internal static Container XmlDeserialize(XElement payload)
        {
            var result = new Container();
            var deserializeName = XmlSerialization.ToDeserializer(e => (string)e);
            string resultName;
            if (deserializeName(payload, "Name", out resultName))
            {
                result.Name = resultName;
            }
            var deserializeProperties = XmlSerialization.ToDeserializer(e => ContainerProperties.XmlDeserialize(e));
            ContainerProperties resultProperties;
            if (deserializeProperties(payload, "Properties", out resultProperties))
            {
                result.Properties = resultProperties;
            }
            var deserializeMetadata = XmlSerialization.CreateDictionaryXmlDeserializer(XmlSerialization.ToDeserializer(e => (string)e));
            IDictionary<string, string> resultMetadata;
            if (deserializeMetadata(payload, "Metadata", out resultMetadata))
            {
                result.Metadata = resultMetadata;
            }
            return result;
        }
    }
}

