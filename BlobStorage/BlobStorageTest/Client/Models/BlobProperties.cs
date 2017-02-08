// MIT

namespace BlobStorageTest.Client.Models
{
    using Client;
    using Microsoft.Rest;
    using Microsoft.Rest.Serialization;
    using Newtonsoft.Json;
    using System.Linq;
    using System.Xml;
    using System.Xml.Linq;

    /// <summary>
    /// Properties of a blob
    /// </summary>
    public partial class BlobProperties
    {
        /// <summary>
        /// Initializes a new instance of the BlobProperties class.
        /// </summary>
        public BlobProperties() { }

        /// <summary>
        /// Initializes a new instance of the BlobProperties class.
        /// </summary>
        /// <param name="contentLength">Size in bytes</param>
        /// <param name="leaseStatus">Possible values include: 'locked',
        /// 'unlocked'</param>
        /// <param name="leaseState">Possible values include: 'available',
        /// 'leased', 'expired', 'breaking', 'broken'</param>
        /// <param name="leaseDuration">Possible values include: 'infinite',
        /// 'fixed'</param>
        /// <param name="copyStatus">Possible values include: 'pending',
        /// 'success', 'aborted', 'failed'</param>
        public BlobProperties(System.DateTime? lastModified = default(System.DateTime?), string etag = default(string), int? contentLength = default(int?), string contentType = default(string), string contentEncoding = default(string), string contentLanguage = default(string), string contentMD5 = default(string), string contentDisposition = default(string), string cacheControl = default(string), string xMsBlobSequenceNumber = default(string), string blobType = default(string), LeaseStatusType? leaseStatus = default(LeaseStatusType?), LeaseStateType? leaseState = default(LeaseStateType?), LeaseDurationType? leaseDuration = default(LeaseDurationType?), string copyId = default(string), CopyStatusType? copyStatus = default(CopyStatusType?), string copySource = default(string), string copyProgress = default(string), System.DateTime? copyCompletionTime = default(System.DateTime?), string copyStatusDescription = default(string), bool? serverEncrypted = default(bool?), bool? incrementalCopy = default(bool?))
        {
            LastModified = lastModified;
            Etag = etag;
            ContentLength = contentLength;
            ContentType = contentType;
            ContentEncoding = contentEncoding;
            ContentLanguage = contentLanguage;
            ContentMD5 = contentMD5;
            ContentDisposition = contentDisposition;
            CacheControl = cacheControl;
            XMsBlobSequenceNumber = xMsBlobSequenceNumber;
            BlobType = blobType;
            LeaseStatus = leaseStatus;
            LeaseState = leaseState;
            LeaseDuration = leaseDuration;
            CopyId = copyId;
            CopyStatus = copyStatus;
            CopySource = copySource;
            CopyProgress = copyProgress;
            CopyCompletionTime = copyCompletionTime;
            CopyStatusDescription = copyStatusDescription;
            ServerEncrypted = serverEncrypted;
            IncrementalCopy = incrementalCopy;
        }

        /// <summary>
        /// </summary>
        [JsonConverter(typeof(DateTimeRfc1123JsonConverter))]
        [JsonProperty(PropertyName = "Last-Modified")]
        public System.DateTime? LastModified { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "Etag")]
        public string Etag { get; set; }

        /// <summary>
        /// Gets or sets size in bytes
        /// </summary>
        [JsonProperty(PropertyName = "Content-Length")]
        public int? ContentLength { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "Content-Type")]
        public string ContentType { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "Content-Encoding")]
        public string ContentEncoding { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "Content-Language")]
        public string ContentLanguage { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "Content-MD5")]
        public string ContentMD5 { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "Content-Disposition")]
        public string ContentDisposition { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "Cache-Control")]
        public string CacheControl { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "x-ms-blob-sequence-number")]
        public string XMsBlobSequenceNumber { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "BlobType")]
        public string BlobType { get; set; }

        /// <summary>
        /// Gets or sets possible values include: 'locked', 'unlocked'
        /// </summary>
        [JsonProperty(PropertyName = "LeaseStatus")]
        public LeaseStatusType? LeaseStatus { get; set; }

        /// <summary>
        /// Gets or sets possible values include: 'available', 'leased',
        /// 'expired', 'breaking', 'broken'
        /// </summary>
        [JsonProperty(PropertyName = "LeaseState")]
        public LeaseStateType? LeaseState { get; set; }

        /// <summary>
        /// Gets or sets possible values include: 'infinite', 'fixed'
        /// </summary>
        [JsonProperty(PropertyName = "LeaseDuration")]
        public LeaseDurationType? LeaseDuration { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "CopyId")]
        public string CopyId { get; set; }

        /// <summary>
        /// Gets or sets possible values include: 'pending', 'success',
        /// 'aborted', 'failed'
        /// </summary>
        [JsonProperty(PropertyName = "CopyStatus")]
        public CopyStatusType? CopyStatus { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "CopySource")]
        public string CopySource { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "CopyProgress")]
        public string CopyProgress { get; set; }

        /// <summary>
        /// </summary>
        [JsonConverter(typeof(DateTimeRfc1123JsonConverter))]
        [JsonProperty(PropertyName = "CopyCompletionTime")]
        public System.DateTime? CopyCompletionTime { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "CopyStatusDescription")]
        public string CopyStatusDescription { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "ServerEncrypted")]
        public bool? ServerEncrypted { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "IncrementalCopy")]
        public bool? IncrementalCopy { get; set; }

        /// <summary>
        /// Serializes the object to an XML node
        /// </summary>
        internal XElement XmlSerialize(XElement result)
        {
            if( null != LastModified )
            {
                result.Add(new XElement("Last-Modified", LastModified?.ToUniversalTime().ToString("R")) );
            }
            if( null != Etag )
            {
                result.Add(new XElement("Etag", Etag) );
            }
            if( null != ContentLength )
            {
                result.Add(new XElement("Content-Length", ContentLength) );
            }
            if( null != ContentType )
            {
                result.Add(new XElement("Content-Type", ContentType) );
            }
            if( null != ContentEncoding )
            {
                result.Add(new XElement("Content-Encoding", ContentEncoding) );
            }
            if( null != ContentLanguage )
            {
                result.Add(new XElement("Content-Language", ContentLanguage) );
            }
            if( null != ContentMD5 )
            {
                result.Add(new XElement("Content-MD5", ContentMD5) );
            }
            if( null != ContentDisposition )
            {
                result.Add(new XElement("Content-Disposition", ContentDisposition) );
            }
            if( null != CacheControl )
            {
                result.Add(new XElement("Cache-Control", CacheControl) );
            }
            if( null != XMsBlobSequenceNumber )
            {
                result.Add(new XElement("x-ms-blob-sequence-number", XMsBlobSequenceNumber) );
            }
            if( null != BlobType )
            {
                result.Add(new XElement("BlobType", BlobType) );
            }
            if( null != LeaseStatus )
            {
                result.Add(new XElement("LeaseStatus", LeaseStatus.ToSerializedValue()) );
            }
            if( null != LeaseState )
            {
                result.Add(new XElement("LeaseState", LeaseState.ToSerializedValue()) );
            }
            if( null != LeaseDuration )
            {
                result.Add(new XElement("LeaseDuration", LeaseDuration.ToSerializedValue()) );
            }
            if( null != CopyId )
            {
                result.Add(new XElement("CopyId", CopyId) );
            }
            if( null != CopyStatus )
            {
                result.Add(new XElement("CopyStatus", CopyStatus.ToSerializedValue()) );
            }
            if( null != CopySource )
            {
                result.Add(new XElement("CopySource", CopySource) );
            }
            if( null != CopyProgress )
            {
                result.Add(new XElement("CopyProgress", CopyProgress) );
            }
            if( null != CopyCompletionTime )
            {
                result.Add(new XElement("CopyCompletionTime", CopyCompletionTime?.ToUniversalTime().ToString("R")) );
            }
            if( null != CopyStatusDescription )
            {
                result.Add(new XElement("CopyStatusDescription", CopyStatusDescription) );
            }
            if( null != ServerEncrypted )
            {
                result.Add(new XElement("ServerEncrypted", ServerEncrypted) );
            }
            if( null != IncrementalCopy )
            {
                result.Add(new XElement("IncrementalCopy", IncrementalCopy) );
            }
            return result;
        }
        /// <summary>
        /// Deserializes an XML node to an instance of BlobProperties
        /// </summary>
        internal static BlobProperties XmlDeserialize(string payload)
        {
            // deserialize to xml and use the overload to do the work
            return XmlDeserialize( XElement.Parse( payload ) );
        }
        internal static BlobProperties XmlDeserialize(XElement payload)
        {
            var result = new BlobProperties();
            var deserializeLastModified = XmlSerialization.ToDeserializer(e => (System.DateTime?)e);
            System.DateTime? resultLastModified;
            if (deserializeLastModified(payload, "Last-Modified", out resultLastModified))
            {
                result.LastModified = resultLastModified;
            }
            var deserializeEtag = XmlSerialization.ToDeserializer(e => (string)e);
            string resultEtag;
            if (deserializeEtag(payload, "Etag", out resultEtag))
            {
                result.Etag = resultEtag;
            }
            var deserializeContentLength = XmlSerialization.ToDeserializer(e => (int?)e);
            int? resultContentLength;
            if (deserializeContentLength(payload, "Content-Length", out resultContentLength))
            {
                result.ContentLength = resultContentLength;
            }
            var deserializeContentType = XmlSerialization.ToDeserializer(e => (string)e);
            string resultContentType;
            if (deserializeContentType(payload, "Content-Type", out resultContentType))
            {
                result.ContentType = resultContentType;
            }
            var deserializeContentEncoding = XmlSerialization.ToDeserializer(e => (string)e);
            string resultContentEncoding;
            if (deserializeContentEncoding(payload, "Content-Encoding", out resultContentEncoding))
            {
                result.ContentEncoding = resultContentEncoding;
            }
            var deserializeContentLanguage = XmlSerialization.ToDeserializer(e => (string)e);
            string resultContentLanguage;
            if (deserializeContentLanguage(payload, "Content-Language", out resultContentLanguage))
            {
                result.ContentLanguage = resultContentLanguage;
            }
            var deserializeContentMD5 = XmlSerialization.ToDeserializer(e => (string)e);
            string resultContentMD5;
            if (deserializeContentMD5(payload, "Content-MD5", out resultContentMD5))
            {
                result.ContentMD5 = resultContentMD5;
            }
            var deserializeContentDisposition = XmlSerialization.ToDeserializer(e => (string)e);
            string resultContentDisposition;
            if (deserializeContentDisposition(payload, "Content-Disposition", out resultContentDisposition))
            {
                result.ContentDisposition = resultContentDisposition;
            }
            var deserializeCacheControl = XmlSerialization.ToDeserializer(e => (string)e);
            string resultCacheControl;
            if (deserializeCacheControl(payload, "Cache-Control", out resultCacheControl))
            {
                result.CacheControl = resultCacheControl;
            }
            var deserializeXMsBlobSequenceNumber = XmlSerialization.ToDeserializer(e => (string)e);
            string resultXMsBlobSequenceNumber;
            if (deserializeXMsBlobSequenceNumber(payload, "x-ms-blob-sequence-number", out resultXMsBlobSequenceNumber))
            {
                result.XMsBlobSequenceNumber = resultXMsBlobSequenceNumber;
            }
            var deserializeBlobType = XmlSerialization.ToDeserializer(e => (string)e);
            string resultBlobType;
            if (deserializeBlobType(payload, "BlobType", out resultBlobType))
            {
                result.BlobType = resultBlobType;
            }
            var deserializeLeaseStatus = XmlSerialization.ToDeserializer(e => e.Value.ParseLeaseStatusType());
            LeaseStatusType? resultLeaseStatus;
            if (deserializeLeaseStatus(payload, "LeaseStatus", out resultLeaseStatus))
            {
                result.LeaseStatus = resultLeaseStatus;
            }
            var deserializeLeaseState = XmlSerialization.ToDeserializer(e => e.Value.ParseLeaseStateType());
            LeaseStateType? resultLeaseState;
            if (deserializeLeaseState(payload, "LeaseState", out resultLeaseState))
            {
                result.LeaseState = resultLeaseState;
            }
            var deserializeLeaseDuration = XmlSerialization.ToDeserializer(e => e.Value.ParseLeaseDurationType());
            LeaseDurationType? resultLeaseDuration;
            if (deserializeLeaseDuration(payload, "LeaseDuration", out resultLeaseDuration))
            {
                result.LeaseDuration = resultLeaseDuration;
            }
            var deserializeCopyId = XmlSerialization.ToDeserializer(e => (string)e);
            string resultCopyId;
            if (deserializeCopyId(payload, "CopyId", out resultCopyId))
            {
                result.CopyId = resultCopyId;
            }
            var deserializeCopyStatus = XmlSerialization.ToDeserializer(e => e.Value.ParseCopyStatusType());
            CopyStatusType? resultCopyStatus;
            if (deserializeCopyStatus(payload, "CopyStatus", out resultCopyStatus))
            {
                result.CopyStatus = resultCopyStatus;
            }
            var deserializeCopySource = XmlSerialization.ToDeserializer(e => (string)e);
            string resultCopySource;
            if (deserializeCopySource(payload, "CopySource", out resultCopySource))
            {
                result.CopySource = resultCopySource;
            }
            var deserializeCopyProgress = XmlSerialization.ToDeserializer(e => (string)e);
            string resultCopyProgress;
            if (deserializeCopyProgress(payload, "CopyProgress", out resultCopyProgress))
            {
                result.CopyProgress = resultCopyProgress;
            }
            var deserializeCopyCompletionTime = XmlSerialization.ToDeserializer(e => (System.DateTime?)e);
            System.DateTime? resultCopyCompletionTime;
            if (deserializeCopyCompletionTime(payload, "CopyCompletionTime", out resultCopyCompletionTime))
            {
                result.CopyCompletionTime = resultCopyCompletionTime;
            }
            var deserializeCopyStatusDescription = XmlSerialization.ToDeserializer(e => (string)e);
            string resultCopyStatusDescription;
            if (deserializeCopyStatusDescription(payload, "CopyStatusDescription", out resultCopyStatusDescription))
            {
                result.CopyStatusDescription = resultCopyStatusDescription;
            }
            var deserializeServerEncrypted = XmlSerialization.ToDeserializer(e => (bool?)e);
            bool? resultServerEncrypted;
            if (deserializeServerEncrypted(payload, "ServerEncrypted", out resultServerEncrypted))
            {
                result.ServerEncrypted = resultServerEncrypted;
            }
            var deserializeIncrementalCopy = XmlSerialization.ToDeserializer(e => (bool?)e);
            bool? resultIncrementalCopy;
            if (deserializeIncrementalCopy(payload, "IncrementalCopy", out resultIncrementalCopy))
            {
                result.IncrementalCopy = resultIncrementalCopy;
            }
            return result;
        }
    }
}

