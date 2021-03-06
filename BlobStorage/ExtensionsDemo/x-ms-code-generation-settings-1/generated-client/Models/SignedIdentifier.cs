// Our custom header

namespace blob-storage.Models
{
    using Microsoft.Rest;
    using Newtonsoft.Json;
    using System.Linq;
    using System.Xml;
    using System.Xml.Linq;

    /// <summary>
    /// signed identifier
    /// </summary>
    public partial class SignedIdentifier
    {
        /// <summary>
        /// Initializes a new instance of the SignedIdentifier class.
        /// </summary>
        public SignedIdentifier() { }

        /// <summary>
        /// Initializes a new instance of the SignedIdentifier class.
        /// </summary>
        /// <param name="id">a unique id</param>
        /// <param name="accessPolicy">The access policy</param>
        public SignedIdentifier(string id, AccessPolicy accessPolicy)
        {
            Id = id;
            AccessPolicy = accessPolicy;
        }

        /// <summary>
        /// Gets or sets a unique id
        /// </summary>
        [JsonProperty(PropertyName = "Id")]
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the access policy
        /// </summary>
        [JsonProperty(PropertyName = "AccessPolicy")]
        public AccessPolicy AccessPolicy { get; set; }

        /// <summary>
        /// Validate the object.
        /// </summary>
        /// <exception cref="ValidationException">
        /// Thrown if validation fails
        /// </exception>
        public virtual void Validate()
        {
            if (Id == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "Id");
            }
            if (AccessPolicy == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "AccessPolicy");
            }
        }
        /// <summary>
        /// Serializes the object to an XML node
        /// </summary>
        internal XElement XmlSerialize(XElement result)
        {
            if( null != Id )
            {
                result.Add(new XElement("Id", Id) );
            }
            if( null != AccessPolicy )
            {
                result.Add(AccessPolicy.XmlSerialize(new XElement( "AccessPolicy" )));
            }
            return result;
        }
        /// <summary>
        /// Deserializes an XML node to an instance of SignedIdentifier
        /// </summary>
        internal static SignedIdentifier XmlDeserialize(string payload)
        {
            // deserialize to xml and use the overload to do the work
            return XmlDeserialize( XElement.Parse( payload ) );
        }
        internal static SignedIdentifier XmlDeserialize(XElement payload)
        {
            var result = new SignedIdentifier();
            var deserializeId = XmlSerialization.ToDeserializer(e => (string)e);
            string resultId;
            if (deserializeId(payload, "Id", out resultId))
            {
                result.Id = resultId;
            }
            var deserializeAccessPolicy = XmlSerialization.ToDeserializer(e => AccessPolicy.XmlDeserialize(e));
            AccessPolicy resultAccessPolicy;
            if (deserializeAccessPolicy(payload, "AccessPolicy", out resultAccessPolicy))
            {
                result.AccessPolicy = resultAccessPolicy;
            }
            return result;
        }
    }
}

