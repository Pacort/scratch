// MIT

namespace BlobStorageTest.Client.Models
{
    using Client;
    using Microsoft.Rest;
    using Newtonsoft.Json;
    using System.Linq;
    using System.Xml;
    using System.Xml.Linq;

    public partial class Error
    {
        /// <summary>
        /// Initializes a new instance of the Error class.
        /// </summary>
        public Error() { }

        /// <summary>
        /// Initializes a new instance of the Error class.
        /// </summary>
        public Error(string code, string message, ErrorExceptionDetails exceptionDetails = default(ErrorExceptionDetails))
        {
            Code = code;
            Message = message;
            ExceptionDetails = exceptionDetails;
        }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "Code")]
        public string Code { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "Message")]
        public string Message { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "ExceptionDetails")]
        public ErrorExceptionDetails ExceptionDetails { get; set; }

        /// <summary>
        /// Validate the object.
        /// </summary>
        /// <exception cref="ValidationException">
        /// Thrown if validation fails
        /// </exception>
        public virtual void Validate()
        {
            if (Code == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "Code");
            }
            if (Message == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "Message");
            }
        }
        /// <summary>
        /// Serializes the object to an XML node
        /// </summary>
        internal XElement XmlSerialize(XElement result)
        {
            if( null != Code )
            {
                result.Add(new XElement("Code", Code) );
            }
            if( null != Message )
            {
                result.Add(new XElement("Message", Message) );
            }
            if( null != ExceptionDetails )
            {
                result.Add(ExceptionDetails.XmlSerialize(new XElement( "ExceptionDetails" )));
            }
            return result;
        }
        /// <summary>
        /// Deserializes an XML node to an instance of Error
        /// </summary>
        internal static Error XmlDeserialize(string payload)
        {
            // deserialize to xml and use the overload to do the work
            return XmlDeserialize( XElement.Parse( payload ) );
        }
        internal static Error XmlDeserialize(XElement payload)
        {
            var result = new Error();
            var deserializeCode = XmlSerialization.ToDeserializer(e => (string)e);
            string resultCode;
            if (deserializeCode(payload, "Code", out resultCode))
            {
                result.Code = resultCode;
            }
            var deserializeMessage = XmlSerialization.ToDeserializer(e => (string)e);
            string resultMessage;
            if (deserializeMessage(payload, "Message", out resultMessage))
            {
                result.Message = resultMessage;
            }
            var deserializeExceptionDetails = XmlSerialization.ToDeserializer(e => ErrorExceptionDetails.XmlDeserialize(e));
            ErrorExceptionDetails resultExceptionDetails;
            if (deserializeExceptionDetails(payload, "ExceptionDetails", out resultExceptionDetails))
            {
                result.ExceptionDetails = resultExceptionDetails;
            }
            return result;
        }
    }
}

