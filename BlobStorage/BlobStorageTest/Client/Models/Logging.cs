// MIT

namespace BlobStorageTest.Client.Models
{
    using Client;
    using Microsoft.Rest;
    using Newtonsoft.Json;
    using System.Linq;
    using System.Xml;
    using System.Xml.Linq;

    /// <summary>
    /// Azure Analytics Logging settings.
    /// </summary>
    public partial class Logging
    {
        /// <summary>
        /// Initializes a new instance of the Logging class.
        /// </summary>
        public Logging() { }

        /// <summary>
        /// Initializes a new instance of the Logging class.
        /// </summary>
        /// <param name="version">The version of Storage Analytics to
        /// configure.</param>
        /// <param name="delete">Indicates whether all delete requests should
        /// be logged.</param>
        /// <param name="read">Indicates whether all read requests should be
        /// logged.</param>
        /// <param name="write">Indicates whether all write requests should be
        /// logged.</param>
        public Logging(string version, bool delete, bool read, bool write, RetentionPolicy retentionPolicy)
        {
            Version = version;
            Delete = delete;
            Read = read;
            Write = write;
            RetentionPolicy = retentionPolicy;
        }

        /// <summary>
        /// Gets or sets the version of Storage Analytics to configure.
        /// </summary>
        [JsonProperty(PropertyName = "Version")]
        public string Version { get; set; }

        /// <summary>
        /// Gets or sets indicates whether all delete requests should be
        /// logged.
        /// </summary>
        [JsonProperty(PropertyName = "Delete")]
        public bool Delete { get; set; }

        /// <summary>
        /// Gets or sets indicates whether all read requests should be logged.
        /// </summary>
        [JsonProperty(PropertyName = "Read")]
        public bool Read { get; set; }

        /// <summary>
        /// Gets or sets indicates whether all write requests should be logged.
        /// </summary>
        [JsonProperty(PropertyName = "Write")]
        public bool Write { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "RetentionPolicy")]
        public RetentionPolicy RetentionPolicy { get; set; }

        /// <summary>
        /// Validate the object.
        /// </summary>
        /// <exception cref="ValidationException">
        /// Thrown if validation fails
        /// </exception>
        public virtual void Validate()
        {
            if (Version == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "Version");
            }
            if (RetentionPolicy == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "RetentionPolicy");
            }
            if (RetentionPolicy != null)
            {
                RetentionPolicy.Validate();
            }
        }
        /// <summary>
        /// Serializes the object to an XML node
        /// </summary>
        internal XElement XmlSerialize(XElement result)
        {
            if( null != Version )
            {
                result.Add(new XElement("Version", Version) );
            }
                result.Add(new XElement("Delete", Delete) );
                result.Add(new XElement("Read", Read) );
                result.Add(new XElement("Write", Write) );
            if( null != RetentionPolicy )
            {
                result.Add(RetentionPolicy.XmlSerialize(new XElement( "RetentionPolicy" )));
            }
            return result;
        }
        /// <summary>
        /// Deserializes an XML node to an instance of Logging
        /// </summary>
        internal static Logging XmlDeserialize(string payload)
        {
            // deserialize to xml and use the overload to do the work
            return XmlDeserialize( XElement.Parse( payload ) );
        }
        internal static Logging XmlDeserialize(XElement payload)
        {
            var result = new Logging();
            var deserializeVersion = XmlSerialization.ToDeserializer(e => (string)e);
            string resultVersion;
            if (deserializeVersion(payload, "Version", out resultVersion))
            {
                result.Version = resultVersion;
            }
            var deserializeDelete = XmlSerialization.ToDeserializer(e => (bool)e);
            bool resultDelete;
            if (deserializeDelete(payload, "Delete", out resultDelete))
            {
                result.Delete = resultDelete;
            }
            var deserializeRead = XmlSerialization.ToDeserializer(e => (bool)e);
            bool resultRead;
            if (deserializeRead(payload, "Read", out resultRead))
            {
                result.Read = resultRead;
            }
            var deserializeWrite = XmlSerialization.ToDeserializer(e => (bool)e);
            bool resultWrite;
            if (deserializeWrite(payload, "Write", out resultWrite))
            {
                result.Write = resultWrite;
            }
            var deserializeRetentionPolicy = XmlSerialization.ToDeserializer(e => RetentionPolicy.XmlDeserialize(e));
            RetentionPolicy resultRetentionPolicy;
            if (deserializeRetentionPolicy(payload, "RetentionPolicy", out resultRetentionPolicy))
            {
                result.RetentionPolicy = resultRetentionPolicy;
            }
            return result;
        }
    }
}

