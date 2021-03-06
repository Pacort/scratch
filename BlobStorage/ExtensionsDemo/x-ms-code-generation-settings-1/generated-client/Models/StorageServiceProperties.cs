// Our custom header

namespace blob-storage.Models
{
    using Newtonsoft.Json;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml;
    using System.Xml.Linq;

    /// <summary>
    /// Storage Service Properties.
    /// </summary>
    public partial class StorageServiceProperties
    {
        /// <summary>
        /// Initializes a new instance of the StorageServiceProperties class.
        /// </summary>
        public StorageServiceProperties() { }

        /// <summary>
        /// Initializes a new instance of the StorageServiceProperties class.
        /// </summary>
        /// <param name="logging">Azure Analytics Logging settings</param>
        /// <param name="hourMetrics">A summary of request statistics grouped
        /// by API in hourly aggregates for blobs</param>
        /// <param name="minuteMetrics">a summary of request statistics grouped
        /// by API in minute aggregates for blobs</param>
        /// <param name="cors">The set of CORS rules.</param>
        /// <param name="defaultServiceVersion">The default version to use for
        /// requests to the Blob service if an incoming request's version is
        /// not specified. Possible values include version 2008-10-27 and all
        /// more recent versions</param>
        public StorageServiceProperties(Logging logging = default(Logging), Metrics hourMetrics = default(Metrics), Metrics minuteMetrics = default(Metrics), IList<CorsRule> cors = default(IList<CorsRule>), string defaultServiceVersion = default(string))
        {
            Logging = logging;
            HourMetrics = hourMetrics;
            MinuteMetrics = minuteMetrics;
            Cors = cors;
            DefaultServiceVersion = defaultServiceVersion;
        }

        /// <summary>
        /// Gets or sets azure Analytics Logging settings
        /// </summary>
        [JsonProperty(PropertyName = "Logging")]
        public Logging Logging { get; set; }

        /// <summary>
        /// Gets or sets a summary of request statistics grouped by API in
        /// hourly aggregates for blobs
        /// </summary>
        [JsonProperty(PropertyName = "HourMetrics")]
        public Metrics HourMetrics { get; set; }

        /// <summary>
        /// Gets or sets a summary of request statistics grouped by API in
        /// minute aggregates for blobs
        /// </summary>
        [JsonProperty(PropertyName = "MinuteMetrics")]
        public Metrics MinuteMetrics { get; set; }

        /// <summary>
        /// Gets or sets the set of CORS rules.
        /// </summary>
        [JsonProperty(PropertyName = "Cors")]
        public IList<CorsRule> Cors { get; set; }

        /// <summary>
        /// Gets or sets the default version to use for requests to the Blob
        /// service if an incoming request's version is not specified. Possible
        /// values include version 2008-10-27 and all more recent versions
        /// </summary>
        [JsonProperty(PropertyName = "DefaultServiceVersion")]
        public string DefaultServiceVersion { get; set; }

        /// <summary>
        /// Validate the object.
        /// </summary>
        /// <exception cref="Microsoft.Rest.ValidationException">
        /// Thrown if validation fails
        /// </exception>
        public virtual void Validate()
        {
            if (Logging != null)
            {
                Logging.Validate();
            }
            if (HourMetrics != null)
            {
                HourMetrics.Validate();
            }
            if (MinuteMetrics != null)
            {
                MinuteMetrics.Validate();
            }
            if (Cors != null)
            {
                foreach (var element in Cors)
                {
                    if (element != null)
                    {
                        element.Validate();
                    }
                }
            }
        }
        /// <summary>
        /// Serializes the object to an XML node
        /// </summary>
        internal XElement XmlSerialize(XElement result)
        {
            if( null != Logging )
            {
                result.Add(Logging.XmlSerialize(new XElement( "Logging" )));
            }
            if( null != HourMetrics )
            {
                result.Add(HourMetrics.XmlSerialize(new XElement( "HourMetrics" )));
            }
            if( null != MinuteMetrics )
            {
                result.Add(MinuteMetrics.XmlSerialize(new XElement( "MinuteMetrics" )));
            }
            if( null != Cors )
            {
                var seq = new XElement("Cors");
                foreach( var value in Cors ){
                    seq.Add(value.XmlSerialize( new XElement( "CorsRule") ) );
                }
                result.Add(seq);
            }
            if( null != DefaultServiceVersion )
            {
                result.Add(new XElement("DefaultServiceVersion", DefaultServiceVersion) );
            }
            return result;
        }
        /// <summary>
        /// Deserializes an XML node to an instance of StorageServiceProperties
        /// </summary>
        internal static StorageServiceProperties XmlDeserialize(string payload)
        {
            // deserialize to xml and use the overload to do the work
            return XmlDeserialize( XElement.Parse( payload ) );
        }
        internal static StorageServiceProperties XmlDeserialize(XElement payload)
        {
            var result = new StorageServiceProperties();
            var deserializeLogging = XmlSerialization.ToDeserializer(e => Logging.XmlDeserialize(e));
            Logging resultLogging;
            if (deserializeLogging(payload, "Logging", out resultLogging))
            {
                result.Logging = resultLogging;
            }
            var deserializeHourMetrics = XmlSerialization.ToDeserializer(e => Metrics.XmlDeserialize(e));
            Metrics resultHourMetrics;
            if (deserializeHourMetrics(payload, "HourMetrics", out resultHourMetrics))
            {
                result.HourMetrics = resultHourMetrics;
            }
            var deserializeMinuteMetrics = XmlSerialization.ToDeserializer(e => Metrics.XmlDeserialize(e));
            Metrics resultMinuteMetrics;
            if (deserializeMinuteMetrics(payload, "MinuteMetrics", out resultMinuteMetrics))
            {
                result.MinuteMetrics = resultMinuteMetrics;
            }
            var deserializeCors = XmlSerialization.CreateListXmlDeserializer(XmlSerialization.ToDeserializer(e => CorsRule.XmlDeserialize(e)), "CorsRule");
            IList<CorsRule> resultCors;
            if (deserializeCors(payload, "Cors", out resultCors))
            {
                result.Cors = resultCors;
            }
            var deserializeDefaultServiceVersion = XmlSerialization.ToDeserializer(e => (string)e);
            string resultDefaultServiceVersion;
            if (deserializeDefaultServiceVersion(payload, "DefaultServiceVersion", out resultDefaultServiceVersion))
            {
                result.DefaultServiceVersion = resultDefaultServiceVersion;
            }
            return result;
        }
    }
}

