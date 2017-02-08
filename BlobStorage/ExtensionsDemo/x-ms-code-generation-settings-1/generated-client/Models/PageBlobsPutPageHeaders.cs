// Our custom header

namespace blob-storage.Models
{
    using Microsoft.Rest;
    using Microsoft.Rest.Serialization;
    using Newtonsoft.Json;
    using System.Linq;
    using System.Xml;
    using System.Xml.Linq;

    /// <summary>
    /// Defines headers for PutPage operation.
    /// </summary>
    public partial class PageBlobsPutPageHeaders
    {
        /// <summary>
        /// Initializes a new instance of the PageBlobsPutPageHeaders class.
        /// </summary>
        public PageBlobsPutPageHeaders() { }

        /// <summary>
        /// Initializes a new instance of the PageBlobsPutPageHeaders class.
        /// </summary>
        /// <param name="eTag">The ETag contains a value that you can use to
        /// perform operations conditionally. If the request version is
        /// 2011-08-18 or newer, the ETag value will be in quotes.</param>
        /// <param name="lastModified">Returns the date and time the container
        /// was last modified. Any operation that modifies the blob, including
        /// an update of the blob's metadata or properties, changes the
        /// last-modified time of the blob.</param>
        /// <param name="contentMD5">If the blob has an MD5 hash and this
        /// operation is to read the full blob, this response header is
        /// returned so that the client can check for message content
        /// integrity.</param>
        /// <param name="xMsBlobContentLength">The size of the blob in
        /// bytes.</param>
        /// <param name="xMsRequestId">This header uniquely identifies the
        /// request that was made and can be used for troubleshooting the
        /// request.</param>
        /// <param name="xMsVersion">Indicates the version of the Blob service
        /// used to execute the request. This header is returned for requests
        /// made against version 2009-09-19 and above.</param>
        /// <param name="date">UTC date/time value generated by the service
        /// that indicates the time at which the response was initiated</param>
        /// <param name="xMsRequestServerEncrypted">The value of this header is
        /// set to true if the contents of the request are successfully
        /// encrypted using the specified algorithm, and false
        /// otherwise.</param>
        public PageBlobsPutPageHeaders(string eTag = default(string), string lastModified = default(string), string contentMD5 = default(string), int? xMsBlobContentLength = default(int?), string xMsRequestId = default(string), string xMsVersion = default(string), System.DateTime? date = default(System.DateTime?), bool? xMsRequestServerEncrypted = default(bool?))
        {
            ETag = eTag;
            LastModified = lastModified;
            ContentMD5 = contentMD5;
            XMsBlobContentLength = xMsBlobContentLength;
            XMsRequestId = xMsRequestId;
            XMsVersion = xMsVersion;
            Date = date;
            XMsRequestServerEncrypted = xMsRequestServerEncrypted;
        }

        /// <summary>
        /// Gets or sets the ETag contains a value that you can use to perform
        /// operations conditionally. If the request version is 2011-08-18 or
        /// newer, the ETag value will be in quotes.
        /// </summary>
        [JsonProperty(PropertyName = "ETag")]
        public string ETag { get; set; }

        /// <summary>
        /// Gets or sets returns the date and time the container was last
        /// modified. Any operation that modifies the blob, including an update
        /// of the blob's metadata or properties, changes the last-modified
        /// time of the blob.
        /// </summary>
        [JsonProperty(PropertyName = "Last-Modified")]
        public string LastModified { get; set; }

        /// <summary>
        /// Gets or sets if the blob has an MD5 hash and this operation is to
        /// read the full blob, this response header is returned so that the
        /// client can check for message content integrity.
        /// </summary>
        [JsonProperty(PropertyName = "Content-MD5")]
        public string ContentMD5 { get; set; }

        /// <summary>
        /// Gets or sets the size of the blob in bytes.
        /// </summary>
        [JsonProperty(PropertyName = "x-ms-blob-content-length")]
        public int? XMsBlobContentLength { get; set; }

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
        /// Gets or sets UTC date/time value generated by the service that
        /// indicates the time at which the response was initiated
        /// </summary>
        [JsonConverter(typeof(DateTimeRfc1123JsonConverter))]
        [JsonProperty(PropertyName = "Date")]
        public System.DateTime? Date { get; set; }

        /// <summary>
        /// Gets or sets the value of this header is set to true if the
        /// contents of the request are successfully encrypted using the
        /// specified algorithm, and false otherwise.
        /// </summary>
        [JsonProperty(PropertyName = "x-ms-request-server-encrypted")]
        public bool? XMsRequestServerEncrypted { get; set; }

        /// <summary>
        /// Serializes the object to an XML node
        /// </summary>
        internal XElement XmlSerialize(XElement result)
        {
            if( null != ETag )
            {
                result.Add(new XElement("ETag", ETag) );
            }
            if( null != LastModified )
            {
                result.Add(new XElement("Last-Modified", LastModified) );
            }
            if( null != ContentMD5 )
            {
                result.Add(new XElement("Content-MD5", ContentMD5) );
            }
            if( null != XMsBlobContentLength )
            {
                result.Add(new XElement("x-ms-blob-content-length", XMsBlobContentLength) );
            }
            if( null != XMsRequestId )
            {
                result.Add(new XElement("x-ms-request-id", XMsRequestId) );
            }
            if( null != XMsVersion )
            {
                result.Add(new XElement("x-ms-version", XMsVersion) );
            }
            if( null != Date )
            {
                result.Add(new XElement("Date", Date?.ToUniversalTime().ToString("R")) );
            }
            if( null != XMsRequestServerEncrypted )
            {
                result.Add(new XElement("x-ms-request-server-encrypted", XMsRequestServerEncrypted) );
            }
            return result;
        }
        /// <summary>
        /// Deserializes an XML node to an instance of PageBlobsPutPageHeaders
        /// </summary>
        internal static PageBlobsPutPageHeaders XmlDeserialize(string payload)
        {
            // deserialize to xml and use the overload to do the work
            return XmlDeserialize( XElement.Parse( payload ) );
        }
        internal static PageBlobsPutPageHeaders XmlDeserialize(XElement payload)
        {
            var result = new PageBlobsPutPageHeaders();
            var deserializeETag = XmlSerialization.ToDeserializer(e => (string)e);
            string resultETag;
            if (deserializeETag(payload, "ETag", out resultETag))
            {
                result.ETag = resultETag;
            }
            var deserializeLastModified = XmlSerialization.ToDeserializer(e => (string)e);
            string resultLastModified;
            if (deserializeLastModified(payload, "Last-Modified", out resultLastModified))
            {
                result.LastModified = resultLastModified;
            }
            var deserializeContentMD5 = XmlSerialization.ToDeserializer(e => (string)e);
            string resultContentMD5;
            if (deserializeContentMD5(payload, "Content-MD5", out resultContentMD5))
            {
                result.ContentMD5 = resultContentMD5;
            }
            var deserializeXMsBlobContentLength = XmlSerialization.ToDeserializer(e => (int?)e);
            int? resultXMsBlobContentLength;
            if (deserializeXMsBlobContentLength(payload, "x-ms-blob-content-length", out resultXMsBlobContentLength))
            {
                result.XMsBlobContentLength = resultXMsBlobContentLength;
            }
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
            var deserializeDate = XmlSerialization.ToDeserializer(e => (System.DateTime?)e);
            System.DateTime? resultDate;
            if (deserializeDate(payload, "Date", out resultDate))
            {
                result.Date = resultDate;
            }
            var deserializeXMsRequestServerEncrypted = XmlSerialization.ToDeserializer(e => (bool?)e);
            bool? resultXMsRequestServerEncrypted;
            if (deserializeXMsRequestServerEncrypted(payload, "x-ms-request-server-encrypted", out resultXMsRequestServerEncrypted))
            {
                result.XMsRequestServerEncrypted = resultXMsRequestServerEncrypted;
            }
            return result;
        }
    }
}

