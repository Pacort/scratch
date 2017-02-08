// MIT

namespace BlobStorageTest.Client.Models
{
    using Client;
    using Newtonsoft.Json;
    using System.Linq;
    using System.Xml;
    using System.Xml.Linq;

    /// <summary>
    /// An Access policy
    /// </summary>
    public partial class AccessPolicy
    {
        /// <summary>
        /// Initializes a new instance of the AccessPolicy class.
        /// </summary>
        public AccessPolicy() { }

        /// <summary>
        /// Initializes a new instance of the AccessPolicy class.
        /// </summary>
        /// <param name="start">the date-time the policy is active</param>
        /// <param name="expiry">the date-time the policy expires</param>
        /// <param name="permission">the permissions for the acl policy</param>
        public AccessPolicy(System.DateTime? start = default(System.DateTime?), System.DateTime? expiry = default(System.DateTime?), string permission = default(string))
        {
            Start = start;
            Expiry = expiry;
            Permission = permission;
        }

        /// <summary>
        /// Gets or sets the date-time the policy is active
        /// </summary>
        [JsonProperty(PropertyName = "Start")]
        public System.DateTime? Start { get; set; }

        /// <summary>
        /// Gets or sets the date-time the policy expires
        /// </summary>
        [JsonProperty(PropertyName = "Expiry")]
        public System.DateTime? Expiry { get; set; }

        /// <summary>
        /// Gets or sets the permissions for the acl policy
        /// </summary>
        [JsonProperty(PropertyName = "Permission")]
        public string Permission { get; set; }

        /// <summary>
        /// Serializes the object to an XML node
        /// </summary>
        internal XElement XmlSerialize(XElement result)
        {
            if( null != Start )
            {
                result.Add(new XElement("Start", Start) );
            }
            if( null != Expiry )
            {
                result.Add(new XElement("Expiry", Expiry) );
            }
            if( null != Permission )
            {
                result.Add(new XElement("Permission", Permission) );
            }
            return result;
        }
        /// <summary>
        /// Deserializes an XML node to an instance of AccessPolicy
        /// </summary>
        internal static AccessPolicy XmlDeserialize(string payload)
        {
            // deserialize to xml and use the overload to do the work
            return XmlDeserialize( XElement.Parse( payload ) );
        }
        internal static AccessPolicy XmlDeserialize(XElement payload)
        {
            var result = new AccessPolicy();
            var deserializeStart = XmlSerialization.ToDeserializer(e => (System.DateTime?)e);
            System.DateTime? resultStart;
            if (deserializeStart(payload, "Start", out resultStart))
            {
                result.Start = resultStart;
            }
            var deserializeExpiry = XmlSerialization.ToDeserializer(e => (System.DateTime?)e);
            System.DateTime? resultExpiry;
            if (deserializeExpiry(payload, "Expiry", out resultExpiry))
            {
                result.Expiry = resultExpiry;
            }
            var deserializePermission = XmlSerialization.ToDeserializer(e => (string)e);
            string resultPermission;
            if (deserializePermission(payload, "Permission", out resultPermission))
            {
                result.Permission = resultPermission;
            }
            return result;
        }
    }
}

