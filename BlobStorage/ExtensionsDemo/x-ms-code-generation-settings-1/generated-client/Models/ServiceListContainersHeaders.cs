// Our custom header

namespace blob-storage.Models
{
    using Newtonsoft.Json;
    using System.Linq;
    using System.Xml;
    using System.Xml.Linq;

    /// <summary>
    /// Defines headers for ListContainers operation.
    /// </summary>
    public partial class ServiceListContainersHeaders
    {
        /// <summary>
        /// Initializes a new instance of the ServiceListContainersHeaders
        /// class.
        /// </summary>
        public ServiceListContainersHeaders() { }

        /// <summary>
        /// Initializes a new instance of the ServiceListContainersHeaders
        /// class.
        /// </summary>
        /// <param name="xMsRequestId">This header uniquely identifies the
        /// request that was made and can be used for troubleshooting the
        /// request.</param>
        /// <param name="xMsVersion">Indicates the version of the Blob service
        /// used to execute the request. This header is returned for requests
        /// made against version 2009-09-19 and above.</param>
        public ServiceListContainersHeaders(string xMsRequestId = default(string), string xMsVersion = default(string))
        {
            XMsRequestId = xMsRequestId;
            XMsVersion = xMsVersion;
        }

        /// <summary>
        /// Gets or sets this header uniquely identifies the request that was
        /// made and can be used for troubleshooting the request.
        /// </summary>
        [JsonProperty(PropertyName = "x-ms-request-id")]
        public string XMsRequestId { get; set; }

        /// <summary>
        /// Gets or sets indicates the version of the Blob service used to
        /// execute the request. This header is returned for requests made
        /// against version 2009-09-19 and above.
        /// </summary>
        [JsonProperty(PropertyName = "x-ms-version")]
        public string XMsVersion { get; set; }

        /// <summary>
        /// Serializes the object to an XML node
        /// </summary>
        internal XElement XmlSerialize(XElement result)
        {
            if( null != XMsRequestId )
            {
                result.Add(new XElement("x-ms-request-id", XMsRequestId) );
            }
            if( null != XMsVersion )
            {
                result.Add(new XElement("x-ms-version", XMsVersion) );
            }
            return result;
        }
        /// <summary>
        /// Deserializes an XML node to an instance of ServiceListContainersHeaders
        /// </summary>
        internal static ServiceListContainersHeaders XmlDeserialize(string payload)
        {
            // deserialize to xml and use the overload to do the work
            return XmlDeserialize( XElement.Parse( payload ) );
        }
        internal static ServiceListContainersHeaders XmlDeserialize(XElement payload)
        {
            var result = new ServiceListContainersHeaders();
            var deserializeXMsRequestId = XmlSerialization.ToDeserializer(e => (string)e);
            string resultXMsRequestId;
            if (deserializeXMsRequestId(payload, "x-ms-request-id", out resultXMsRequestId))
            {
                result.XMsRequestId = resultXMsRequestId;
            }
            var deserializeXMsVersion = XmlSerialization.ToDeserializer(e => (string)e);
            string resultXMsVersion;
            if (deserializeXMsVersion(payload, "x-ms-version", out resultXMsVersion))
            {
                result.XMsVersion = resultXMsVersion;
            }
            return result;
        }
    }
}

