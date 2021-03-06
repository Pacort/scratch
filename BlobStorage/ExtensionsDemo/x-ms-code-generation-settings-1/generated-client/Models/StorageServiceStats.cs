// Our custom header

namespace blob-storage.Models
{
    using Newtonsoft.Json;
    using System.Linq;
    using System.Xml;
    using System.Xml.Linq;

    /// <summary>
    /// Stats for the storage service.
    /// </summary>
    public partial class StorageServiceStats
    {
        /// <summary>
        /// Initializes a new instance of the StorageServiceStats class.
        /// </summary>
        public StorageServiceStats() { }

        /// <summary>
        /// Initializes a new instance of the StorageServiceStats class.
        /// </summary>
        /// <param name="geoReplication">Geo-Replication information for the
        /// Secondary Storage Service</param>
        public StorageServiceStats(GeoReplication geoReplication = default(GeoReplication))
        {
            GeoReplication = geoReplication;
        }

        /// <summary>
        /// Gets or sets geo-Replication information for the Secondary Storage
        /// Service
        /// </summary>
        [JsonProperty(PropertyName = "GeoReplication")]
        public GeoReplication GeoReplication { get; set; }

        /// <summary>
        /// Serializes the object to an XML node
        /// </summary>
        internal XElement XmlSerialize(XElement result)
        {
            if( null != GeoReplication )
            {
                result.Add(GeoReplication.XmlSerialize(new XElement( "GeoReplication" )));
            }
            return result;
        }
        /// <summary>
        /// Deserializes an XML node to an instance of StorageServiceStats
        /// </summary>
        internal static StorageServiceStats XmlDeserialize(string payload)
        {
            // deserialize to xml and use the overload to do the work
            return XmlDeserialize( XElement.Parse( payload ) );
        }
        internal static StorageServiceStats XmlDeserialize(XElement payload)
        {
            var result = new StorageServiceStats();
            var deserializeGeoReplication = XmlSerialization.ToDeserializer(e => GeoReplication.XmlDeserialize(e));
            GeoReplication resultGeoReplication;
            if (deserializeGeoReplication(payload, "GeoReplication", out resultGeoReplication))
            {
                result.GeoReplication = resultGeoReplication;
            }
            return result;
        }
    }
}

