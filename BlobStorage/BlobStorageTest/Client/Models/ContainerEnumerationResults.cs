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
    /// An enumaration of containers
    /// </summary>
    public partial class ContainerEnumerationResults
    {
        /// <summary>
        /// Initializes a new instance of the ContainerEnumerationResults
        /// class.
        /// </summary>
        public ContainerEnumerationResults() { }

        /// <summary>
        /// Initializes a new instance of the ContainerEnumerationResults
        /// class.
        /// </summary>
        public ContainerEnumerationResults(string serviceEndpoint = default(string), string prefix = default(string), string marker = default(string), int? maxResults = default(int?), IList<Container> containers = default(IList<Container>), string nextMarker = default(string))
        {
            ServiceEndpoint = serviceEndpoint;
            Prefix = prefix;
            Marker = marker;
            MaxResults = maxResults;
            Containers = containers;
            NextMarker = nextMarker;
        }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "ServiceEndpoint")]
        public string ServiceEndpoint { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "Prefix")]
        public string Prefix { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "Marker")]
        public string Marker { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "MaxResults")]
        public int? MaxResults { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "Containers")]
        public IList<Container> Containers { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "NextMarker")]
        public string NextMarker { get; set; }

        /// <summary>
        /// Serializes the object to an XML node
        /// </summary>
        internal XElement XmlSerialize(XElement result)
        {
            if( null != ServiceEndpoint )
            {
                result.Add(new XAttribute("ServiceEndpoint", ServiceEndpoint) );
            }
            if( null != Prefix )
            {
                result.Add(new XElement("Prefix", Prefix) );
            }
            if( null != Marker )
            {
                result.Add(new XElement("Marker", Marker) );
            }
            if( null != MaxResults )
            {
                result.Add(new XElement("MaxResults", MaxResults) );
            }
            if( null != Containers )
            {
                var seq = new XElement("Containers");
                foreach( var value in Containers ){
                    seq.Add(value.XmlSerialize( new XElement( "Container") ) );
                }
                result.Add(seq);
            }
            if( null != NextMarker )
            {
                result.Add(new XElement("NextMarker", NextMarker) );
            }
            return result;
        }
        /// <summary>
        /// Deserializes an XML node to an instance of ContainerEnumerationResults
        /// </summary>
        internal static ContainerEnumerationResults XmlDeserialize(string payload)
        {
            // deserialize to xml and use the overload to do the work
            return XmlDeserialize( XElement.Parse( payload ) );
        }
        internal static ContainerEnumerationResults XmlDeserialize(XElement payload)
        {
            var result = new ContainerEnumerationResults();
            XAttribute attribute;
            if( null != (attribute = payload.Attribute("ServiceEndpoint")))
            {
                result.ServiceEndpoint = (string)attribute;
            }
            var deserializePrefix = XmlSerialization.ToDeserializer(e => (string)e);
            string resultPrefix;
            if (deserializePrefix(payload, "Prefix", out resultPrefix))
            {
                result.Prefix = resultPrefix;
            }
            var deserializeMarker = XmlSerialization.ToDeserializer(e => (string)e);
            string resultMarker;
            if (deserializeMarker(payload, "Marker", out resultMarker))
            {
                result.Marker = resultMarker;
            }
            var deserializeMaxResults = XmlSerialization.ToDeserializer(e => (int?)e);
            int? resultMaxResults;
            if (deserializeMaxResults(payload, "MaxResults", out resultMaxResults))
            {
                result.MaxResults = resultMaxResults;
            }
            var deserializeContainers = XmlSerialization.CreateListXmlDeserializer(XmlSerialization.ToDeserializer(e => Container.XmlDeserialize(e)), "Container");
            IList<Container> resultContainers;
            if (deserializeContainers(payload, "Containers", out resultContainers))
            {
                result.Containers = resultContainers;
            }
            var deserializeNextMarker = XmlSerialization.ToDeserializer(e => (string)e);
            string resultNextMarker;
            if (deserializeNextMarker(payload, "NextMarker", out resultNextMarker))
            {
                result.NextMarker = resultNextMarker;
            }
            return result;
        }
    }
}

