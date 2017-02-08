// MIT

namespace BlobStorageTest.Client
{
    using Microsoft.Rest;
    using Microsoft.Rest.Azure;
    using Microsoft.Rest.Serialization;
    using Models;
    using Newtonsoft.Json;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Xml;
    using System.Xml.Linq;

    /// <summary>
    /// ContainerOperations operations.
    /// </summary>
    internal partial class ContainerOperations : IServiceOperations<AzureStorageClient>, IContainerOperations
    {
        /// <summary>
        /// Initializes a new instance of the ContainerOperations class.
        /// </summary>
        /// <param name='client'>
        /// Reference to the service client.
        /// </param>
        /// <exception cref="System.ArgumentNullException">
        /// Thrown when a required parameter is null
        /// </exception>
        internal ContainerOperations(AzureStorageClient client)
        {
            if (client == null)
            {
                throw new System.ArgumentNullException("client");
            }
            Client = client;
        }

        /// <summary>
        /// Gets a reference to the AzureStorageClient
        /// </summary>
        public AzureStorageClient Client { get; private set; }

        /// <summary>
        /// creates a new container under the specified account. If the container with
        /// the same name already exists, the operation fails
        /// </summary>
        /// <param name='accountName'>
        /// The Azure storage account to use.
        /// </param>
        /// <param name='container'>
        /// The container name.
        /// </param>
        /// <param name='timeout'>
        /// The timeout parameter is expressed in seconds. For more information, see
        /// &lt;a
        /// href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations"&gt;Setting
        /// Timeouts for Blob Service Operations.&lt;/a&gt;
        /// </param>
        /// <param name='xMsMeta'>
        /// Optional. Specifies a user-defined name-value pair associated with the
        /// blob. If no name-value pairs are specified, the operation will copy the
        /// metadata from the source blob or file to the destination blob. If one or
        /// more name-value pairs are specified, the destination blob is created with
        /// the specified metadata, and metadata is not copied from the source blob or
        /// file. Note that beginning with version 2009-09-19, metadata names must
        /// adhere to the naming rules for C# identifiers. See Naming and Referencing
        /// Containers, Blobs, and Metadata for more information.
        /// </param>
        /// <param name='access'>
        /// Specifies whether data in the container may be accessed publicly and the
        /// level of access. Possible values include: 'container', 'blob'
        /// </param>
        /// <param name='customHeaders'>
        /// Headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        /// <exception cref="CloudException">
        /// Thrown when the operation returned an invalid status code
        /// </exception>
        /// <exception cref="ValidationException">
        /// Thrown when a required parameter is null
        /// </exception>
        /// <exception cref="System.ArgumentNullException">
        /// Thrown when a required parameter is null
        /// </exception>
        /// <return>
        /// A response object containing the response body and response headers.
        /// </return>
        public async Task<AzureOperationHeaderResponse<ContainerCreateHeaders>> CreateWithHttpMessagesAsync(string accountName, string container, int? timeout = default(int?), IDictionary<string, string> xMsMeta = default(IDictionary<string, string>), string access = default(string), Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (accountName == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "accountName");
            }
            if (container == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "container");
            }
            if (container != null)
            {
                if (!System.Text.RegularExpressions.Regex.IsMatch(container, "^(?!.*--)^(?!.*\\-$)(^[a-z0-9][a-z0-9-]{3,63}$)"))
                {
                    throw new ValidationException(ValidationRules.Pattern, "container", "^(?!.*--)^(?!.*\\-$)(^[a-z0-9][a-z0-9-]{3,63}$)");
                }
            }
            if (timeout < 0)
            {
                throw new ValidationException(ValidationRules.InclusiveMinimum, "timeout", 0);
            }
            if (xMsMeta != null)
            {
                if (!System.Linq.Enumerable.All(xMsMeta.Values, value => System.Text.RegularExpressions.Regex.IsMatch(value, "^(?:((?!\\d)\\w+(?:\\.(?!\\d)\\w+)*)\\.)?((?!\\d)\\w+)$")))
                {
                    throw new ValidationException(ValidationRules.Pattern, "xMsMeta", "^(?:((?!\\d)\\w+(?:\\.(?!\\d)\\w+)*)\\.)?((?!\\d)\\w+)$");
                }
            }
            string restype = "container";
            // Tracing
            bool _shouldTrace = ServiceClientTracing.IsEnabled;
            string _invocationId = null;
            if (_shouldTrace)
            {
                _invocationId = ServiceClientTracing.NextInvocationId.ToString();
                Dictionary<string, object> tracingParameters = new Dictionary<string, object>();
                tracingParameters.Add("accountName", accountName);
                tracingParameters.Add("container", container);
                tracingParameters.Add("timeout", timeout);
                tracingParameters.Add("xMsMeta", xMsMeta);
                tracingParameters.Add("access", access);
                tracingParameters.Add("restype", restype);
                tracingParameters.Add("cancellationToken", cancellationToken);
                ServiceClientTracing.Enter(_invocationId, this, "Create", tracingParameters);
            }
            // Construct URL
            var _baseUrl = Client.BaseUri;
            var _url = _baseUrl + (_baseUrl.EndsWith("/") ? "" : "/") + "{container}";
            _url = _url.Replace("{accountName}", accountName);
            _url = _url.Replace("{container}", System.Uri.EscapeDataString(container));
            List<string> _queryParameters = new List<string>();
            if (timeout != null)
            {
                _queryParameters.Add(string.Format("timeout={0}", System.Uri.EscapeDataString(SafeJsonConvert.SerializeObject(timeout, Client.SerializationSettings).Trim('"'))));
            }
            if (restype != null)
            {
                _queryParameters.Add(string.Format("restype={0}", System.Uri.EscapeDataString(restype)));
            }
            if (_queryParameters.Count > 0)
            {
                _url += (_url.Contains("?") ? "&" : "?") + string.Join("&", _queryParameters);
            }
            // Create HTTP transport objects
            var _httpRequest = new System.Net.Http.HttpRequestMessage();
            System.Net.Http.HttpResponseMessage _httpResponse = null;
            _httpRequest.Method = new System.Net.Http.HttpMethod("PUT");
            _httpRequest.RequestUri = new System.Uri(_url);
            // Set Headers
            if (Client.GenerateClientRequestId != null && Client.GenerateClientRequestId.Value)
            {
                _httpRequest.Headers.TryAddWithoutValidation("x-ms-client-request-id", System.Guid.NewGuid().ToString());
            }
            if (access != null)
            {
                if (_httpRequest.Headers.Contains("x-ms-blob-public-access"))
                {
                    _httpRequest.Headers.Remove("x-ms-blob-public-access");
                }
                _httpRequest.Headers.TryAddWithoutValidation("x-ms-blob-public-access", access);
            }
            if (Client.Version != null)
            {
                if (_httpRequest.Headers.Contains("x-ms-version"))
                {
                    _httpRequest.Headers.Remove("x-ms-version");
                }
                _httpRequest.Headers.TryAddWithoutValidation("x-ms-version", Client.Version);
            }
            if (Client.RequestId != null)
            {
                if (_httpRequest.Headers.Contains("x-ms-client-request-id"))
                {
                    _httpRequest.Headers.Remove("x-ms-client-request-id");
                }
                _httpRequest.Headers.TryAddWithoutValidation("x-ms-client-request-id", Client.RequestId);
            }
            if (Client.AcceptLanguage != null)
            {
                if (_httpRequest.Headers.Contains("accept-language"))
                {
                    _httpRequest.Headers.Remove("accept-language");
                }
                _httpRequest.Headers.TryAddWithoutValidation("accept-language", Client.AcceptLanguage);
            }

            if (xMsMeta != null)
            {
                foreach (var _header in xMsMeta)
                {
                    var key = "x-ms-meta-" + _header.Key;
                    if (_httpRequest.Headers.Contains(key))
                    {
                        _httpRequest.Headers.Remove(key);
                    }
                    _httpRequest.Headers.TryAddWithoutValidation(key, _header.Value);
                }
            }

            if (customHeaders != null)
            {
                foreach(var _header in customHeaders)
                {
                    if (_httpRequest.Headers.Contains(_header.Key))
                    {
                        _httpRequest.Headers.Remove(_header.Key);
                    }
                    _httpRequest.Headers.TryAddWithoutValidation(_header.Key, _header.Value);
                }
            }

            // Serialize Request
            string _requestContent = null;
            // Set Credentials
            if (Client.Credentials != null)
            {
                cancellationToken.ThrowIfCancellationRequested();
                await Client.Credentials.ProcessHttpRequestAsync(_httpRequest, cancellationToken).ConfigureAwait(false);
            }
            // Send Request
            if (_shouldTrace)
            {
                ServiceClientTracing.SendRequest(_invocationId, _httpRequest);
            }
            cancellationToken.ThrowIfCancellationRequested();
            _httpResponse = await Client.HttpClient.SendAsync(_httpRequest, cancellationToken).ConfigureAwait(false);
            if (_shouldTrace)
            {
                ServiceClientTracing.ReceiveResponse(_invocationId, _httpResponse);
            }
            HttpStatusCode _statusCode = _httpResponse.StatusCode;
            cancellationToken.ThrowIfCancellationRequested();
            string _responseContent = null;
            if ((int)_statusCode != 201)
            {
                var ex = new CloudException(string.Format("Operation returned an invalid status code '{0}'", _statusCode));
                if (_httpResponse.Content != null) {
                    _responseContent = await _httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                }
                else {
                    _responseContent = string.Empty;
                }
                ex.Request = new HttpRequestMessageWrapper(_httpRequest, _requestContent);
                ex.Response = new HttpResponseMessageWrapper(_httpResponse, _responseContent);
                if (_httpResponse.Headers.Contains("x-ms-request-id"))
                {
                    ex.RequestId = _httpResponse.Headers.GetValues("x-ms-request-id").FirstOrDefault();
                }
                if (_shouldTrace)
                {
                    ServiceClientTracing.Error(_invocationId, ex);
                }
                _httpRequest.Dispose();
                if (_httpResponse != null)
                {
                    _httpResponse.Dispose();
                }
                throw ex;
            }
            // Create Result
            var _result = new AzureOperationHeaderResponse<ContainerCreateHeaders>();
            _result.Request = _httpRequest;
            _result.Response = _httpResponse;
            if (_httpResponse.Headers.Contains("x-ms-request-id"))
            {
                _result.RequestId = _httpResponse.Headers.GetValues("x-ms-request-id").FirstOrDefault();
            }
            try
            {
                _result.Headers = _httpResponse.GetHeadersAsJson().ToObject<ContainerCreateHeaders>(JsonSerializer.Create(Client.DeserializationSettings));
            }
            catch (JsonException ex)
            {
                _httpRequest.Dispose();
                if (_httpResponse != null)
                {
                    _httpResponse.Dispose();
                }
                throw new SerializationException("Unable to deserialize the headers.", _httpResponse.GetHeadersAsJson().ToString(), ex);
            }
            if (_shouldTrace)
            {
                ServiceClientTracing.Exit(_invocationId, _result);
            }
            return _result;
        }

        /// <summary>
        /// returns all user-defined metadata and system properties for the specified
        /// container. The data returned does not include the container's list of blobs
        /// </summary>
        /// <param name='accountName'>
        /// The Azure storage account to use.
        /// </param>
        /// <param name='container'>
        /// The container name.
        /// </param>
        /// <param name='timeout'>
        /// The timeout parameter is expressed in seconds. For more information, see
        /// &lt;a
        /// href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations"&gt;Setting
        /// Timeouts for Blob Service Operations.&lt;/a&gt;
        /// </param>
        /// <param name='leaseId'>
        /// If specified, the operation only succeeds if the container's lease is
        /// active and matches this ID.
        /// </param>
        /// <param name='customHeaders'>
        /// Headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        /// <exception cref="CloudException">
        /// Thrown when the operation returned an invalid status code
        /// </exception>
        /// <exception cref="ValidationException">
        /// Thrown when a required parameter is null
        /// </exception>
        /// <exception cref="System.ArgumentNullException">
        /// Thrown when a required parameter is null
        /// </exception>
        /// <return>
        /// A response object containing the response body and response headers.
        /// </return>
        public async Task<AzureOperationHeaderResponse<ContainerGetPropertiesHeaders>> GetPropertiesWithHttpMessagesAsync(string accountName, string container, int? timeout = default(int?), string leaseId = default(string), Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (accountName == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "accountName");
            }
            if (container == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "container");
            }
            if (container != null)
            {
                if (!System.Text.RegularExpressions.Regex.IsMatch(container, "^(?!.*--)^(?!.*\\-$)(^[a-z0-9][a-z0-9-]{3,63}$)"))
                {
                    throw new ValidationException(ValidationRules.Pattern, "container", "^(?!.*--)^(?!.*\\-$)(^[a-z0-9][a-z0-9-]{3,63}$)");
                }
            }
            if (timeout < 0)
            {
                throw new ValidationException(ValidationRules.InclusiveMinimum, "timeout", 0);
            }
            string restype = "container";
            // Tracing
            bool _shouldTrace = ServiceClientTracing.IsEnabled;
            string _invocationId = null;
            if (_shouldTrace)
            {
                _invocationId = ServiceClientTracing.NextInvocationId.ToString();
                Dictionary<string, object> tracingParameters = new Dictionary<string, object>();
                tracingParameters.Add("accountName", accountName);
                tracingParameters.Add("container", container);
                tracingParameters.Add("timeout", timeout);
                tracingParameters.Add("leaseId", leaseId);
                tracingParameters.Add("restype", restype);
                tracingParameters.Add("cancellationToken", cancellationToken);
                ServiceClientTracing.Enter(_invocationId, this, "GetProperties", tracingParameters);
            }
            // Construct URL
            var _baseUrl = Client.BaseUri;
            var _url = _baseUrl + (_baseUrl.EndsWith("/") ? "" : "/") + "{container}";
            _url = _url.Replace("{accountName}", accountName);
            _url = _url.Replace("{container}", System.Uri.EscapeDataString(container));
            List<string> _queryParameters = new List<string>();
            if (timeout != null)
            {
                _queryParameters.Add(string.Format("timeout={0}", System.Uri.EscapeDataString(SafeJsonConvert.SerializeObject(timeout, Client.SerializationSettings).Trim('"'))));
            }
            if (restype != null)
            {
                _queryParameters.Add(string.Format("restype={0}", System.Uri.EscapeDataString(restype)));
            }
            if (_queryParameters.Count > 0)
            {
                _url += (_url.Contains("?") ? "&" : "?") + string.Join("&", _queryParameters);
            }
            // Create HTTP transport objects
            var _httpRequest = new System.Net.Http.HttpRequestMessage();
            System.Net.Http.HttpResponseMessage _httpResponse = null;
            _httpRequest.Method = new System.Net.Http.HttpMethod("GET");
            _httpRequest.RequestUri = new System.Uri(_url);
            // Set Headers
            if (Client.GenerateClientRequestId != null && Client.GenerateClientRequestId.Value)
            {
                _httpRequest.Headers.TryAddWithoutValidation("x-ms-client-request-id", System.Guid.NewGuid().ToString());
            }
            if (leaseId != null)
            {
                if (_httpRequest.Headers.Contains("x-ms-lease-id"))
                {
                    _httpRequest.Headers.Remove("x-ms-lease-id");
                }
                _httpRequest.Headers.TryAddWithoutValidation("x-ms-lease-id", leaseId);
            }
            if (Client.Version != null)
            {
                if (_httpRequest.Headers.Contains("x-ms-version"))
                {
                    _httpRequest.Headers.Remove("x-ms-version");
                }
                _httpRequest.Headers.TryAddWithoutValidation("x-ms-version", Client.Version);
            }
            if (Client.RequestId != null)
            {
                if (_httpRequest.Headers.Contains("x-ms-client-request-id"))
                {
                    _httpRequest.Headers.Remove("x-ms-client-request-id");
                }
                _httpRequest.Headers.TryAddWithoutValidation("x-ms-client-request-id", Client.RequestId);
            }
            if (Client.AcceptLanguage != null)
            {
                if (_httpRequest.Headers.Contains("accept-language"))
                {
                    _httpRequest.Headers.Remove("accept-language");
                }
                _httpRequest.Headers.TryAddWithoutValidation("accept-language", Client.AcceptLanguage);
            }


            if (customHeaders != null)
            {
                foreach(var _header in customHeaders)
                {
                    if (_httpRequest.Headers.Contains(_header.Key))
                    {
                        _httpRequest.Headers.Remove(_header.Key);
                    }
                    _httpRequest.Headers.TryAddWithoutValidation(_header.Key, _header.Value);
                }
            }

            // Serialize Request
            string _requestContent = null;
            // Set Credentials
            if (Client.Credentials != null)
            {
                cancellationToken.ThrowIfCancellationRequested();
                await Client.Credentials.ProcessHttpRequestAsync(_httpRequest, cancellationToken).ConfigureAwait(false);
            }
            // Send Request
            if (_shouldTrace)
            {
                ServiceClientTracing.SendRequest(_invocationId, _httpRequest);
            }
            cancellationToken.ThrowIfCancellationRequested();
            _httpResponse = await Client.HttpClient.SendAsync(_httpRequest, cancellationToken).ConfigureAwait(false);
            if (_shouldTrace)
            {
                ServiceClientTracing.ReceiveResponse(_invocationId, _httpResponse);
            }
            HttpStatusCode _statusCode = _httpResponse.StatusCode;
            cancellationToken.ThrowIfCancellationRequested();
            string _responseContent = null;
            if ((int)_statusCode != 200)
            {
                var ex = new CloudException(string.Format("Operation returned an invalid status code '{0}'", _statusCode));
                if (_httpResponse.Content != null) {
                    _responseContent = await _httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                }
                else {
                    _responseContent = string.Empty;
                }
                ex.Request = new HttpRequestMessageWrapper(_httpRequest, _requestContent);
                ex.Response = new HttpResponseMessageWrapper(_httpResponse, _responseContent);
                if (_httpResponse.Headers.Contains("x-ms-request-id"))
                {
                    ex.RequestId = _httpResponse.Headers.GetValues("x-ms-request-id").FirstOrDefault();
                }
                if (_shouldTrace)
                {
                    ServiceClientTracing.Error(_invocationId, ex);
                }
                _httpRequest.Dispose();
                if (_httpResponse != null)
                {
                    _httpResponse.Dispose();
                }
                throw ex;
            }
            // Create Result
            var _result = new AzureOperationHeaderResponse<ContainerGetPropertiesHeaders>();
            _result.Request = _httpRequest;
            _result.Response = _httpResponse;
            if (_httpResponse.Headers.Contains("x-ms-request-id"))
            {
                _result.RequestId = _httpResponse.Headers.GetValues("x-ms-request-id").FirstOrDefault();
            }
            try
            {
                _result.Headers = _httpResponse.GetHeadersAsJson().ToObject<ContainerGetPropertiesHeaders>(JsonSerializer.Create(Client.DeserializationSettings));
                _result.Headers.Metadata = new Dictionary<string, string>();
                foreach (var header in _httpResponse.Headers)
                {
                    if (header.Key.StartsWith("x-ms-meta-"))
                    {
                        _result.Headers.Metadata[header.Key.Replace("x-ms-meta-", "")] = header.Value.FirstOrDefault() as string;
                    }
                }
            }
            catch (JsonException ex)
            {
                _httpRequest.Dispose();
                if (_httpResponse != null)
                {
                    _httpResponse.Dispose();
                }
                throw new SerializationException("Unable to deserialize the headers.", _httpResponse.GetHeadersAsJson().ToString(), ex);
            }
            if (_shouldTrace)
            {
                ServiceClientTracing.Exit(_invocationId, _result);
            }
            return _result;
        }

        /// <summary>
        /// operation marks the specified container for deletion. The container and any
        /// blobs contained within it are later deleted during garbage collection
        /// </summary>
        /// <param name='accountName'>
        /// The Azure storage account to use.
        /// </param>
        /// <param name='container'>
        /// The container name.
        /// </param>
        /// <param name='timeout'>
        /// The timeout parameter is expressed in seconds. For more information, see
        /// &lt;a
        /// href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations"&gt;Setting
        /// Timeouts for Blob Service Operations.&lt;/a&gt;
        /// </param>
        /// <param name='leaseId'>
        /// If specified, the operation only succeeds if the container's lease is
        /// active and matches this ID.
        /// </param>
        /// <param name='ifModifiedSince'>
        /// Specify this header value to operate only on a blob if it has been modified
        /// since the specified date/time.
        /// </param>
        /// <param name='ifUnmodifiedSince'>
        /// Specify this header value to operate only on a blob if it has not been
        /// modified since the specified date/time.
        /// </param>
        /// <param name='customHeaders'>
        /// Headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        /// <exception cref="CloudException">
        /// Thrown when the operation returned an invalid status code
        /// </exception>
        /// <exception cref="ValidationException">
        /// Thrown when a required parameter is null
        /// </exception>
        /// <exception cref="System.ArgumentNullException">
        /// Thrown when a required parameter is null
        /// </exception>
        /// <return>
        /// A response object containing the response body and response headers.
        /// </return>
        public async Task<AzureOperationResponse> DeleteWithHttpMessagesAsync(string accountName, string container, int? timeout = default(int?), string leaseId = default(string), System.DateTime? ifModifiedSince = default(System.DateTime?), System.DateTime? ifUnmodifiedSince = default(System.DateTime?), Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (accountName == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "accountName");
            }
            if (container == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "container");
            }
            if (container != null)
            {
                if (!System.Text.RegularExpressions.Regex.IsMatch(container, "^(?!.*--)^(?!.*\\-$)(^[a-z0-9][a-z0-9-]{3,63}$)"))
                {
                    throw new ValidationException(ValidationRules.Pattern, "container", "^(?!.*--)^(?!.*\\-$)(^[a-z0-9][a-z0-9-]{3,63}$)");
                }
            }
            if (timeout < 0)
            {
                throw new ValidationException(ValidationRules.InclusiveMinimum, "timeout", 0);
            }
            string restype = "container";
            // Tracing
            bool _shouldTrace = ServiceClientTracing.IsEnabled;
            string _invocationId = null;
            if (_shouldTrace)
            {
                _invocationId = ServiceClientTracing.NextInvocationId.ToString();
                Dictionary<string, object> tracingParameters = new Dictionary<string, object>();
                tracingParameters.Add("accountName", accountName);
                tracingParameters.Add("container", container);
                tracingParameters.Add("timeout", timeout);
                tracingParameters.Add("leaseId", leaseId);
                tracingParameters.Add("ifModifiedSince", ifModifiedSince);
                tracingParameters.Add("ifUnmodifiedSince", ifUnmodifiedSince);
                tracingParameters.Add("restype", restype);
                tracingParameters.Add("cancellationToken", cancellationToken);
                ServiceClientTracing.Enter(_invocationId, this, "Delete", tracingParameters);
            }
            // Construct URL
            var _baseUrl = Client.BaseUri;
            var _url = _baseUrl + (_baseUrl.EndsWith("/") ? "" : "/") + "{container}";
            _url = _url.Replace("{accountName}", accountName);
            _url = _url.Replace("{container}", System.Uri.EscapeDataString(container));
            List<string> _queryParameters = new List<string>();
            if (timeout != null)
            {
                _queryParameters.Add(string.Format("timeout={0}", System.Uri.EscapeDataString(SafeJsonConvert.SerializeObject(timeout, Client.SerializationSettings).Trim('"'))));
            }
            if (restype != null)
            {
                _queryParameters.Add(string.Format("restype={0}", System.Uri.EscapeDataString(restype)));
            }
            if (_queryParameters.Count > 0)
            {
                _url += (_url.Contains("?") ? "&" : "?") + string.Join("&", _queryParameters);
            }
            // Create HTTP transport objects
            var _httpRequest = new System.Net.Http.HttpRequestMessage();
            System.Net.Http.HttpResponseMessage _httpResponse = null;
            _httpRequest.Method = new System.Net.Http.HttpMethod("DELETE");
            _httpRequest.RequestUri = new System.Uri(_url);
            // Set Headers
            if (Client.GenerateClientRequestId != null && Client.GenerateClientRequestId.Value)
            {
                _httpRequest.Headers.TryAddWithoutValidation("x-ms-client-request-id", System.Guid.NewGuid().ToString());
            }
            if (leaseId != null)
            {
                if (_httpRequest.Headers.Contains("x-ms-lease-id"))
                {
                    _httpRequest.Headers.Remove("x-ms-lease-id");
                }
                _httpRequest.Headers.TryAddWithoutValidation("x-ms-lease-id", leaseId);
            }
            if (ifModifiedSince != null)
            {
                if (_httpRequest.Headers.Contains("If-Modified-Since"))
                {
                    _httpRequest.Headers.Remove("If-Modified-Since");
                }
                _httpRequest.Headers.TryAddWithoutValidation("If-Modified-Since", SafeJsonConvert.SerializeObject(ifModifiedSince, new DateTimeRfc1123JsonConverter()).Trim('"'));
            }
            if (ifUnmodifiedSince != null)
            {
                if (_httpRequest.Headers.Contains("If-Unmodified-Since"))
                {
                    _httpRequest.Headers.Remove("If-Unmodified-Since");
                }
                _httpRequest.Headers.TryAddWithoutValidation("If-Unmodified-Since", SafeJsonConvert.SerializeObject(ifUnmodifiedSince, new DateTimeRfc1123JsonConverter()).Trim('"'));
            }
            if (Client.Version != null)
            {
                if (_httpRequest.Headers.Contains("x-ms-version"))
                {
                    _httpRequest.Headers.Remove("x-ms-version");
                }
                _httpRequest.Headers.TryAddWithoutValidation("x-ms-version", Client.Version);
            }
            if (Client.RequestId != null)
            {
                if (_httpRequest.Headers.Contains("x-ms-client-request-id"))
                {
                    _httpRequest.Headers.Remove("x-ms-client-request-id");
                }
                _httpRequest.Headers.TryAddWithoutValidation("x-ms-client-request-id", Client.RequestId);
            }
            if (Client.AcceptLanguage != null)
            {
                if (_httpRequest.Headers.Contains("accept-language"))
                {
                    _httpRequest.Headers.Remove("accept-language");
                }
                _httpRequest.Headers.TryAddWithoutValidation("accept-language", Client.AcceptLanguage);
            }


            if (customHeaders != null)
            {
                foreach(var _header in customHeaders)
                {
                    if (_httpRequest.Headers.Contains(_header.Key))
                    {
                        _httpRequest.Headers.Remove(_header.Key);
                    }
                    _httpRequest.Headers.TryAddWithoutValidation(_header.Key, _header.Value);
                }
            }

            // Serialize Request
            string _requestContent = null;
            // Set Credentials
            if (Client.Credentials != null)
            {
                cancellationToken.ThrowIfCancellationRequested();
                await Client.Credentials.ProcessHttpRequestAsync(_httpRequest, cancellationToken).ConfigureAwait(false);
            }
            // Send Request
            if (_shouldTrace)
            {
                ServiceClientTracing.SendRequest(_invocationId, _httpRequest);
            }
            cancellationToken.ThrowIfCancellationRequested();
            _httpResponse = await Client.HttpClient.SendAsync(_httpRequest, cancellationToken).ConfigureAwait(false);
            if (_shouldTrace)
            {
                ServiceClientTracing.ReceiveResponse(_invocationId, _httpResponse);
            }
            HttpStatusCode _statusCode = _httpResponse.StatusCode;
            cancellationToken.ThrowIfCancellationRequested();
            string _responseContent = null;
            if ((int)_statusCode != 202)
            {
                var ex = new CloudException(string.Format("Operation returned an invalid status code '{0}'", _statusCode));
                if (_httpResponse.Content != null) {
                    _responseContent = await _httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                }
                else {
                    _responseContent = string.Empty;
                }
                ex.Request = new HttpRequestMessageWrapper(_httpRequest, _requestContent);
                ex.Response = new HttpResponseMessageWrapper(_httpResponse, _responseContent);
                if (_httpResponse.Headers.Contains("x-ms-request-id"))
                {
                    ex.RequestId = _httpResponse.Headers.GetValues("x-ms-request-id").FirstOrDefault();
                }
                if (_shouldTrace)
                {
                    ServiceClientTracing.Error(_invocationId, ex);
                }
                _httpRequest.Dispose();
                if (_httpResponse != null)
                {
                    _httpResponse.Dispose();
                }
                throw ex;
            }
            // Create Result
            var _result = new AzureOperationResponse();
            _result.Request = _httpRequest;
            _result.Response = _httpResponse;
            if (_httpResponse.Headers.Contains("x-ms-request-id"))
            {
                _result.RequestId = _httpResponse.Headers.GetValues("x-ms-request-id").FirstOrDefault();
            }
            if (_shouldTrace)
            {
                ServiceClientTracing.Exit(_invocationId, _result);
            }
            return _result;
        }

        /// <summary>
        /// returns all user-defined metadata for the container
        /// </summary>
        /// <param name='accountName'>
        /// The Azure storage account to use.
        /// </param>
        /// <param name='container'>
        /// The container name.
        /// </param>
        /// <param name='timeout'>
        /// The timeout parameter is expressed in seconds. For more information, see
        /// &lt;a
        /// href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations"&gt;Setting
        /// Timeouts for Blob Service Operations.&lt;/a&gt;
        /// </param>
        /// <param name='leaseId'>
        /// If specified, the operation only succeeds if the container's lease is
        /// active and matches this ID.
        /// </param>
        /// <param name='customHeaders'>
        /// Headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        /// <exception cref="CloudException">
        /// Thrown when the operation returned an invalid status code
        /// </exception>
        /// <exception cref="ValidationException">
        /// Thrown when a required parameter is null
        /// </exception>
        /// <exception cref="System.ArgumentNullException">
        /// Thrown when a required parameter is null
        /// </exception>
        /// <return>
        /// A response object containing the response body and response headers.
        /// </return>
        public async Task<AzureOperationHeaderResponse<ContainerGetMetadataHeaders>> GetMetadataWithHttpMessagesAsync(string accountName, string container, int? timeout = default(int?), string leaseId = default(string), Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (accountName == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "accountName");
            }
            if (container == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "container");
            }
            if (container != null)
            {
                if (!System.Text.RegularExpressions.Regex.IsMatch(container, "^(?!.*--)^(?!.*\\-$)(^[a-z0-9][a-z0-9-]{3,63}$)"))
                {
                    throw new ValidationException(ValidationRules.Pattern, "container", "^(?!.*--)^(?!.*\\-$)(^[a-z0-9][a-z0-9-]{3,63}$)");
                }
            }
            if (timeout < 0)
            {
                throw new ValidationException(ValidationRules.InclusiveMinimum, "timeout", 0);
            }
            string restype = "container";
            string comp = "metadata";
            // Tracing
            bool _shouldTrace = ServiceClientTracing.IsEnabled;
            string _invocationId = null;
            if (_shouldTrace)
            {
                _invocationId = ServiceClientTracing.NextInvocationId.ToString();
                Dictionary<string, object> tracingParameters = new Dictionary<string, object>();
                tracingParameters.Add("accountName", accountName);
                tracingParameters.Add("container", container);
                tracingParameters.Add("timeout", timeout);
                tracingParameters.Add("leaseId", leaseId);
                tracingParameters.Add("restype", restype);
                tracingParameters.Add("comp", comp);
                tracingParameters.Add("cancellationToken", cancellationToken);
                ServiceClientTracing.Enter(_invocationId, this, "GetMetadata", tracingParameters);
            }
            // Construct URL
            var _baseUrl = Client.BaseUri;
            var _url = _baseUrl + (_baseUrl.EndsWith("/") ? "" : "/") + "{container}";
            _url = _url.Replace("{accountName}", accountName);
            _url = _url.Replace("{container}", System.Uri.EscapeDataString(container));
            List<string> _queryParameters = new List<string>();
            if (timeout != null)
            {
                _queryParameters.Add(string.Format("timeout={0}", System.Uri.EscapeDataString(SafeJsonConvert.SerializeObject(timeout, Client.SerializationSettings).Trim('"'))));
            }
            if (restype != null)
            {
                _queryParameters.Add(string.Format("restype={0}", System.Uri.EscapeDataString(restype)));
            }
            if (comp != null)
            {
                _queryParameters.Add(string.Format("comp={0}", System.Uri.EscapeDataString(comp)));
            }
            if (_queryParameters.Count > 0)
            {
                _url += (_url.Contains("?") ? "&" : "?") + string.Join("&", _queryParameters);
            }
            // Create HTTP transport objects
            var _httpRequest = new System.Net.Http.HttpRequestMessage();
            System.Net.Http.HttpResponseMessage _httpResponse = null;
            _httpRequest.Method = new System.Net.Http.HttpMethod("GET");
            _httpRequest.RequestUri = new System.Uri(_url);
            // Set Headers
            if (Client.GenerateClientRequestId != null && Client.GenerateClientRequestId.Value)
            {
                _httpRequest.Headers.TryAddWithoutValidation("x-ms-client-request-id", System.Guid.NewGuid().ToString());
            }
            if (leaseId != null)
            {
                if (_httpRequest.Headers.Contains("x-ms-lease-id"))
                {
                    _httpRequest.Headers.Remove("x-ms-lease-id");
                }
                _httpRequest.Headers.TryAddWithoutValidation("x-ms-lease-id", leaseId);
            }
            if (Client.Version != null)
            {
                if (_httpRequest.Headers.Contains("x-ms-version"))
                {
                    _httpRequest.Headers.Remove("x-ms-version");
                }
                _httpRequest.Headers.TryAddWithoutValidation("x-ms-version", Client.Version);
            }
            if (Client.RequestId != null)
            {
                if (_httpRequest.Headers.Contains("x-ms-client-request-id"))
                {
                    _httpRequest.Headers.Remove("x-ms-client-request-id");
                }
                _httpRequest.Headers.TryAddWithoutValidation("x-ms-client-request-id", Client.RequestId);
            }
            if (Client.AcceptLanguage != null)
            {
                if (_httpRequest.Headers.Contains("accept-language"))
                {
                    _httpRequest.Headers.Remove("accept-language");
                }
                _httpRequest.Headers.TryAddWithoutValidation("accept-language", Client.AcceptLanguage);
            }


            if (customHeaders != null)
            {
                foreach(var _header in customHeaders)
                {
                    if (_httpRequest.Headers.Contains(_header.Key))
                    {
                        _httpRequest.Headers.Remove(_header.Key);
                    }
                    _httpRequest.Headers.TryAddWithoutValidation(_header.Key, _header.Value);
                }
            }

            // Serialize Request
            string _requestContent = null;
            // Set Credentials
            if (Client.Credentials != null)
            {
                cancellationToken.ThrowIfCancellationRequested();
                await Client.Credentials.ProcessHttpRequestAsync(_httpRequest, cancellationToken).ConfigureAwait(false);
            }
            // Send Request
            if (_shouldTrace)
            {
                ServiceClientTracing.SendRequest(_invocationId, _httpRequest);
            }
            cancellationToken.ThrowIfCancellationRequested();
            _httpResponse = await Client.HttpClient.SendAsync(_httpRequest, cancellationToken).ConfigureAwait(false);
            if (_shouldTrace)
            {
                ServiceClientTracing.ReceiveResponse(_invocationId, _httpResponse);
            }
            HttpStatusCode _statusCode = _httpResponse.StatusCode;
            cancellationToken.ThrowIfCancellationRequested();
            string _responseContent = null;
            if ((int)_statusCode != 200)
            {
                var ex = new CloudException(string.Format("Operation returned an invalid status code '{0}'", _statusCode));
                if (_httpResponse.Content != null) {
                    _responseContent = await _httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                }
                else {
                    _responseContent = string.Empty;
                }
                ex.Request = new HttpRequestMessageWrapper(_httpRequest, _requestContent);
                ex.Response = new HttpResponseMessageWrapper(_httpResponse, _responseContent);
                if (_httpResponse.Headers.Contains("x-ms-request-id"))
                {
                    ex.RequestId = _httpResponse.Headers.GetValues("x-ms-request-id").FirstOrDefault();
                }
                if (_shouldTrace)
                {
                    ServiceClientTracing.Error(_invocationId, ex);
                }
                _httpRequest.Dispose();
                if (_httpResponse != null)
                {
                    _httpResponse.Dispose();
                }
                throw ex;
            }
            // Create Result
            var _result = new AzureOperationHeaderResponse<ContainerGetMetadataHeaders>();
            _result.Request = _httpRequest;
            _result.Response = _httpResponse;
            if (_httpResponse.Headers.Contains("x-ms-request-id"))
            {
                _result.RequestId = _httpResponse.Headers.GetValues("x-ms-request-id").FirstOrDefault();
            }
            try
            {
                _result.Headers = _httpResponse.GetHeadersAsJson().ToObject<ContainerGetMetadataHeaders>(JsonSerializer.Create(Client.DeserializationSettings));
                _result.Headers.Metadata = new Dictionary<string, string>();
                foreach (var header in _httpResponse.Headers)
                {
                    if (header.Key.StartsWith("x-ms-meta-"))
                    {
                        _result.Headers.Metadata[header.Key.Replace("x-ms-meta-", "")] = header.Value.FirstOrDefault() as string;
                    }
                }
            }
            catch (JsonException ex)
            {
                _httpRequest.Dispose();
                if (_httpResponse != null)
                {
                    _httpResponse.Dispose();
                }
                throw new SerializationException("Unable to deserialize the headers.", _httpResponse.GetHeadersAsJson().ToString(), ex);
            }
            if (_shouldTrace)
            {
                ServiceClientTracing.Exit(_invocationId, _result);
            }
            return _result;
        }

        /// <summary>
        /// operation sets one or more user-defined name-value pairs for the specified
        /// container.
        /// </summary>
        /// <param name='accountName'>
        /// The Azure storage account to use.
        /// </param>
        /// <param name='container'>
        /// The container name.
        /// </param>
        /// <param name='timeout'>
        /// The timeout parameter is expressed in seconds. For more information, see
        /// &lt;a
        /// href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations"&gt;Setting
        /// Timeouts for Blob Service Operations.&lt;/a&gt;
        /// </param>
        /// <param name='leaseId'>
        /// If specified, the operation only succeeds if the container's lease is
        /// active and matches this ID.
        /// </param>
        /// <param name='xMsMeta'>
        /// Optional. Specifies a user-defined name-value pair associated with the
        /// blob. If no name-value pairs are specified, the operation will copy the
        /// metadata from the source blob or file to the destination blob. If one or
        /// more name-value pairs are specified, the destination blob is created with
        /// the specified metadata, and metadata is not copied from the source blob or
        /// file. Note that beginning with version 2009-09-19, metadata names must
        /// adhere to the naming rules for C# identifiers. See Naming and Referencing
        /// Containers, Blobs, and Metadata for more information.
        /// </param>
        /// <param name='ifModifiedSince'>
        /// Specify this header value to operate only on a blob if it has been modified
        /// since the specified date/time.
        /// </param>
        /// <param name='customHeaders'>
        /// Headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        /// <exception cref="CloudException">
        /// Thrown when the operation returned an invalid status code
        /// </exception>
        /// <exception cref="ValidationException">
        /// Thrown when a required parameter is null
        /// </exception>
        /// <exception cref="System.ArgumentNullException">
        /// Thrown when a required parameter is null
        /// </exception>
        /// <return>
        /// A response object containing the response body and response headers.
        /// </return>
        public async Task<AzureOperationHeaderResponse<ContainerSetMetadataHeaders>> SetMetadataWithHttpMessagesAsync(string accountName, string container, int? timeout = default(int?), string leaseId = default(string), IDictionary<string, string> xMsMeta = default(IDictionary<string, string>), System.DateTime? ifModifiedSince = default(System.DateTime?), Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (accountName == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "accountName");
            }
            if (container == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "container");
            }
            if (container != null)
            {
                if (!System.Text.RegularExpressions.Regex.IsMatch(container, "^(?!.*--)^(?!.*\\-$)(^[a-z0-9][a-z0-9-]{3,63}$)"))
                {
                    throw new ValidationException(ValidationRules.Pattern, "container", "^(?!.*--)^(?!.*\\-$)(^[a-z0-9][a-z0-9-]{3,63}$)");
                }
            }
            if (timeout < 0)
            {
                throw new ValidationException(ValidationRules.InclusiveMinimum, "timeout", 0);
            }
            if (xMsMeta != null)
            {
                if (!System.Linq.Enumerable.All(xMsMeta.Values, value => System.Text.RegularExpressions.Regex.IsMatch(value, "^(?:((?!\\d)\\w+(?:\\.(?!\\d)\\w+)*)\\.)?((?!\\d)\\w+)$")))
                {
                    throw new ValidationException(ValidationRules.Pattern, "xMsMeta", "^(?:((?!\\d)\\w+(?:\\.(?!\\d)\\w+)*)\\.)?((?!\\d)\\w+)$");
                }
            }
            string restype = "container";
            string comp = "metadata";
            // Tracing
            bool _shouldTrace = ServiceClientTracing.IsEnabled;
            string _invocationId = null;
            if (_shouldTrace)
            {
                _invocationId = ServiceClientTracing.NextInvocationId.ToString();
                Dictionary<string, object> tracingParameters = new Dictionary<string, object>();
                tracingParameters.Add("accountName", accountName);
                tracingParameters.Add("container", container);
                tracingParameters.Add("timeout", timeout);
                tracingParameters.Add("leaseId", leaseId);
                tracingParameters.Add("xMsMeta", xMsMeta);
                tracingParameters.Add("ifModifiedSince", ifModifiedSince);
                tracingParameters.Add("restype", restype);
                tracingParameters.Add("comp", comp);
                tracingParameters.Add("cancellationToken", cancellationToken);
                ServiceClientTracing.Enter(_invocationId, this, "SetMetadata", tracingParameters);
            }
            // Construct URL
            var _baseUrl = Client.BaseUri;
            var _url = _baseUrl + (_baseUrl.EndsWith("/") ? "" : "/") + "{container}";
            _url = _url.Replace("{accountName}", accountName);
            _url = _url.Replace("{container}", System.Uri.EscapeDataString(container));
            List<string> _queryParameters = new List<string>();
            if (timeout != null)
            {
                _queryParameters.Add(string.Format("timeout={0}", System.Uri.EscapeDataString(SafeJsonConvert.SerializeObject(timeout, Client.SerializationSettings).Trim('"'))));
            }
            if (restype != null)
            {
                _queryParameters.Add(string.Format("restype={0}", System.Uri.EscapeDataString(restype)));
            }
            if (comp != null)
            {
                _queryParameters.Add(string.Format("comp={0}", System.Uri.EscapeDataString(comp)));
            }
            if (_queryParameters.Count > 0)
            {
                _url += (_url.Contains("?") ? "&" : "?") + string.Join("&", _queryParameters);
            }
            // Create HTTP transport objects
            var _httpRequest = new System.Net.Http.HttpRequestMessage();
            System.Net.Http.HttpResponseMessage _httpResponse = null;
            _httpRequest.Method = new System.Net.Http.HttpMethod("PUT");
            _httpRequest.RequestUri = new System.Uri(_url);
            // Set Headers
            if (Client.GenerateClientRequestId != null && Client.GenerateClientRequestId.Value)
            {
                _httpRequest.Headers.TryAddWithoutValidation("x-ms-client-request-id", System.Guid.NewGuid().ToString());
            }
            if (leaseId != null)
            {
                if (_httpRequest.Headers.Contains("x-ms-lease-id"))
                {
                    _httpRequest.Headers.Remove("x-ms-lease-id");
                }
                _httpRequest.Headers.TryAddWithoutValidation("x-ms-lease-id", leaseId);
            }
            if (ifModifiedSince != null)
            {
                if (_httpRequest.Headers.Contains("If-Modified-Since"))
                {
                    _httpRequest.Headers.Remove("If-Modified-Since");
                }
                _httpRequest.Headers.TryAddWithoutValidation("If-Modified-Since", SafeJsonConvert.SerializeObject(ifModifiedSince, new DateTimeRfc1123JsonConverter()).Trim('"'));
            }
            if (Client.Version != null)
            {
                if (_httpRequest.Headers.Contains("x-ms-version"))
                {
                    _httpRequest.Headers.Remove("x-ms-version");
                }
                _httpRequest.Headers.TryAddWithoutValidation("x-ms-version", Client.Version);
            }
            if (Client.RequestId != null)
            {
                if (_httpRequest.Headers.Contains("x-ms-client-request-id"))
                {
                    _httpRequest.Headers.Remove("x-ms-client-request-id");
                }
                _httpRequest.Headers.TryAddWithoutValidation("x-ms-client-request-id", Client.RequestId);
            }
            if (Client.AcceptLanguage != null)
            {
                if (_httpRequest.Headers.Contains("accept-language"))
                {
                    _httpRequest.Headers.Remove("accept-language");
                }
                _httpRequest.Headers.TryAddWithoutValidation("accept-language", Client.AcceptLanguage);
            }

            if (xMsMeta != null)
            {
                foreach (var _header in xMsMeta)
                {
                    var key = "x-ms-meta-" + _header.Key;
                    if (_httpRequest.Headers.Contains(key))
                    {
                        _httpRequest.Headers.Remove(key);
                    }
                    _httpRequest.Headers.TryAddWithoutValidation(key, _header.Value);
                }
            }

            if (customHeaders != null)
            {
                foreach(var _header in customHeaders)
                {
                    if (_httpRequest.Headers.Contains(_header.Key))
                    {
                        _httpRequest.Headers.Remove(_header.Key);
                    }
                    _httpRequest.Headers.TryAddWithoutValidation(_header.Key, _header.Value);
                }
            }

            // Serialize Request
            string _requestContent = null;
            // Set Credentials
            if (Client.Credentials != null)
            {
                cancellationToken.ThrowIfCancellationRequested();
                await Client.Credentials.ProcessHttpRequestAsync(_httpRequest, cancellationToken).ConfigureAwait(false);
            }
            // Send Request
            if (_shouldTrace)
            {
                ServiceClientTracing.SendRequest(_invocationId, _httpRequest);
            }
            cancellationToken.ThrowIfCancellationRequested();
            _httpResponse = await Client.HttpClient.SendAsync(_httpRequest, cancellationToken).ConfigureAwait(false);
            if (_shouldTrace)
            {
                ServiceClientTracing.ReceiveResponse(_invocationId, _httpResponse);
            }
            HttpStatusCode _statusCode = _httpResponse.StatusCode;
            cancellationToken.ThrowIfCancellationRequested();
            string _responseContent = null;
            if ((int)_statusCode != 200)
            {
                var ex = new CloudException(string.Format("Operation returned an invalid status code '{0}'", _statusCode));
                if (_httpResponse.Content != null) {
                    _responseContent = await _httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                }
                else {
                    _responseContent = string.Empty;
                }
                ex.Request = new HttpRequestMessageWrapper(_httpRequest, _requestContent);
                ex.Response = new HttpResponseMessageWrapper(_httpResponse, _responseContent);
                if (_httpResponse.Headers.Contains("x-ms-request-id"))
                {
                    ex.RequestId = _httpResponse.Headers.GetValues("x-ms-request-id").FirstOrDefault();
                }
                if (_shouldTrace)
                {
                    ServiceClientTracing.Error(_invocationId, ex);
                }
                _httpRequest.Dispose();
                if (_httpResponse != null)
                {
                    _httpResponse.Dispose();
                }
                throw ex;
            }
            // Create Result
            var _result = new AzureOperationHeaderResponse<ContainerSetMetadataHeaders>();
            _result.Request = _httpRequest;
            _result.Response = _httpResponse;
            if (_httpResponse.Headers.Contains("x-ms-request-id"))
            {
                _result.RequestId = _httpResponse.Headers.GetValues("x-ms-request-id").FirstOrDefault();
            }
            try
            {
                _result.Headers = _httpResponse.GetHeadersAsJson().ToObject<ContainerSetMetadataHeaders>(JsonSerializer.Create(Client.DeserializationSettings));
            }
            catch (JsonException ex)
            {
                _httpRequest.Dispose();
                if (_httpResponse != null)
                {
                    _httpResponse.Dispose();
                }
                throw new SerializationException("Unable to deserialize the headers.", _httpResponse.GetHeadersAsJson().ToString(), ex);
            }
            if (_shouldTrace)
            {
                ServiceClientTracing.Exit(_invocationId, _result);
            }
            return _result;
        }

        /// <param name='accountName'>
        /// The Azure storage account to use.
        /// </param>
        /// <param name='container'>
        /// The container name.
        /// </param>
        /// <param name='timeout'>
        /// The timeout parameter is expressed in seconds. For more information, see
        /// &lt;a
        /// href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations"&gt;Setting
        /// Timeouts for Blob Service Operations.&lt;/a&gt;
        /// </param>
        /// <param name='leaseId'>
        /// If specified, the operation only succeeds if the container's lease is
        /// active and matches this ID.
        /// </param>
        /// <param name='customHeaders'>
        /// Headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        /// <exception cref="CloudException">
        /// Thrown when the operation returned an invalid status code
        /// </exception>
        /// <exception cref="SerializationException">
        /// Thrown when unable to deserialize the response
        /// </exception>
        /// <exception cref="ValidationException">
        /// Thrown when a required parameter is null
        /// </exception>
        /// <exception cref="System.ArgumentNullException">
        /// Thrown when a required parameter is null
        /// </exception>
        /// <return>
        /// A response object containing the response body and response headers.
        /// </return>
        public async Task<AzureOperationResponse<IList<SignedIdentifier>,ContainerGetAclHeaders>> GetAclWithHttpMessagesAsync(string accountName, string container, int? timeout = default(int?), string leaseId = default(string), Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (accountName == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "accountName");
            }
            if (container == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "container");
            }
            if (container != null)
            {
                if (!System.Text.RegularExpressions.Regex.IsMatch(container, "^(?!.*--)^(?!.*\\-$)(^[a-z0-9][a-z0-9-]{3,63}$)"))
                {
                    throw new ValidationException(ValidationRules.Pattern, "container", "^(?!.*--)^(?!.*\\-$)(^[a-z0-9][a-z0-9-]{3,63}$)");
                }
            }
            if (timeout < 0)
            {
                throw new ValidationException(ValidationRules.InclusiveMinimum, "timeout", 0);
            }
            string restype = "container";
            string comp = "acl";
            // Tracing
            bool _shouldTrace = ServiceClientTracing.IsEnabled;
            string _invocationId = null;
            if (_shouldTrace)
            {
                _invocationId = ServiceClientTracing.NextInvocationId.ToString();
                Dictionary<string, object> tracingParameters = new Dictionary<string, object>();
                tracingParameters.Add("accountName", accountName);
                tracingParameters.Add("container", container);
                tracingParameters.Add("timeout", timeout);
                tracingParameters.Add("leaseId", leaseId);
                tracingParameters.Add("restype", restype);
                tracingParameters.Add("comp", comp);
                tracingParameters.Add("cancellationToken", cancellationToken);
                ServiceClientTracing.Enter(_invocationId, this, "GetAcl", tracingParameters);
            }
            // Construct URL
            var _baseUrl = Client.BaseUri;
            var _url = _baseUrl + (_baseUrl.EndsWith("/") ? "" : "/") + "{container}";
            _url = _url.Replace("{accountName}", accountName);
            _url = _url.Replace("{container}", System.Uri.EscapeDataString(container));
            List<string> _queryParameters = new List<string>();
            if (timeout != null)
            {
                _queryParameters.Add(string.Format("timeout={0}", System.Uri.EscapeDataString(SafeJsonConvert.SerializeObject(timeout, Client.SerializationSettings).Trim('"'))));
            }
            if (restype != null)
            {
                _queryParameters.Add(string.Format("restype={0}", System.Uri.EscapeDataString(restype)));
            }
            if (comp != null)
            {
                _queryParameters.Add(string.Format("comp={0}", System.Uri.EscapeDataString(comp)));
            }
            if (_queryParameters.Count > 0)
            {
                _url += (_url.Contains("?") ? "&" : "?") + string.Join("&", _queryParameters);
            }
            // Create HTTP transport objects
            var _httpRequest = new System.Net.Http.HttpRequestMessage();
            System.Net.Http.HttpResponseMessage _httpResponse = null;
            _httpRequest.Method = new System.Net.Http.HttpMethod("GET");
            _httpRequest.RequestUri = new System.Uri(_url);
            // Set Headers
            if (Client.GenerateClientRequestId != null && Client.GenerateClientRequestId.Value)
            {
                _httpRequest.Headers.TryAddWithoutValidation("x-ms-client-request-id", System.Guid.NewGuid().ToString());
            }
            if (leaseId != null)
            {
                if (_httpRequest.Headers.Contains("x-ms-lease-id"))
                {
                    _httpRequest.Headers.Remove("x-ms-lease-id");
                }
                _httpRequest.Headers.TryAddWithoutValidation("x-ms-lease-id", leaseId);
            }
            if (Client.Version != null)
            {
                if (_httpRequest.Headers.Contains("x-ms-version"))
                {
                    _httpRequest.Headers.Remove("x-ms-version");
                }
                _httpRequest.Headers.TryAddWithoutValidation("x-ms-version", Client.Version);
            }
            if (Client.RequestId != null)
            {
                if (_httpRequest.Headers.Contains("x-ms-client-request-id"))
                {
                    _httpRequest.Headers.Remove("x-ms-client-request-id");
                }
                _httpRequest.Headers.TryAddWithoutValidation("x-ms-client-request-id", Client.RequestId);
            }
            if (Client.AcceptLanguage != null)
            {
                if (_httpRequest.Headers.Contains("accept-language"))
                {
                    _httpRequest.Headers.Remove("accept-language");
                }
                _httpRequest.Headers.TryAddWithoutValidation("accept-language", Client.AcceptLanguage);
            }


            if (customHeaders != null)
            {
                foreach(var _header in customHeaders)
                {
                    if (_httpRequest.Headers.Contains(_header.Key))
                    {
                        _httpRequest.Headers.Remove(_header.Key);
                    }
                    _httpRequest.Headers.TryAddWithoutValidation(_header.Key, _header.Value);
                }
            }

            // Serialize Request
            string _requestContent = null;
            // Set Credentials
            if (Client.Credentials != null)
            {
                cancellationToken.ThrowIfCancellationRequested();
                await Client.Credentials.ProcessHttpRequestAsync(_httpRequest, cancellationToken).ConfigureAwait(false);
            }
            // Send Request
            if (_shouldTrace)
            {
                ServiceClientTracing.SendRequest(_invocationId, _httpRequest);
            }
            cancellationToken.ThrowIfCancellationRequested();
            _httpResponse = await Client.HttpClient.SendAsync(_httpRequest, cancellationToken).ConfigureAwait(false);
            if (_shouldTrace)
            {
                ServiceClientTracing.ReceiveResponse(_invocationId, _httpResponse);
            }
            HttpStatusCode _statusCode = _httpResponse.StatusCode;
            cancellationToken.ThrowIfCancellationRequested();
            string _responseContent = null;
            if ((int)_statusCode != 200)
            {
                var ex = new CloudException(string.Format("Operation returned an invalid status code '{0}'", _statusCode));
                try
                {
                    _responseContent = await _httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                    CloudError _errorBody =  SafeJsonConvert.DeserializeObject<CloudError>(_responseContent, Client.DeserializationSettings);
                    if (_errorBody != null)
                    {
                        ex = new CloudException(_errorBody.Message);
                        ex.Body = _errorBody;
                    }
                }
                catch (JsonException)
                {
                    // Ignore the exception
                }
                ex.Request = new HttpRequestMessageWrapper(_httpRequest, _requestContent);
                ex.Response = new HttpResponseMessageWrapper(_httpResponse, _responseContent);
                if (_httpResponse.Headers.Contains("x-ms-request-id"))
                {
                    ex.RequestId = _httpResponse.Headers.GetValues("x-ms-request-id").FirstOrDefault();
                }
                if (_shouldTrace)
                {
                    ServiceClientTracing.Error(_invocationId, ex);
                }
                _httpRequest.Dispose();
                if (_httpResponse != null)
                {
                    _httpResponse.Dispose();
                }
                throw ex;
            }
            // Create Result
            var _result = new AzureOperationResponse<IList<SignedIdentifier>,ContainerGetAclHeaders>();
            _result.Request = _httpRequest;
            _result.Response = _httpResponse;
            if (_httpResponse.Headers.Contains("x-ms-request-id"))
            {
                _result.RequestId = _httpResponse.Headers.GetValues("x-ms-request-id").FirstOrDefault();
            }
            // Deserialize Response
            if ((int)_statusCode == 200)
            {
                _responseContent = await _httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                try
                {
                    IList<SignedIdentifier> _tmp_ = null;
                    if (_httpResponse.Content.Headers.ContentType.MediaType == "application/xml" &&
                        XmlSerialization.Root(XmlSerialization.CreateListXmlDeserializer(XmlSerialization.ToDeserializer(e => SignedIdentifier.XmlDeserialize(e)), "SignedIdentifier"))(XElement.Parse(_responseContent), out _tmp_))
                    {
                        _result.Body = _tmp_;
                    }else
                    {
                        _result.Body = SafeJsonConvert.DeserializeObject<IList<SignedIdentifier>>(_responseContent, Client.DeserializationSettings);
                    }
                }
                catch (JsonException ex)
                {
                    _httpRequest.Dispose();
                    if (_httpResponse != null)
                    {
                        _httpResponse.Dispose();
                    }
                    throw new SerializationException("Unable to deserialize the response.", _responseContent, ex);
                }
            }
            try
            {
                _result.Headers = _httpResponse.GetHeadersAsJson().ToObject<ContainerGetAclHeaders>(JsonSerializer.Create(Client.DeserializationSettings));
            }
            catch (JsonException ex)
            {
                _httpRequest.Dispose();
                if (_httpResponse != null)
                {
                    _httpResponse.Dispose();
                }
                throw new SerializationException("Unable to deserialize the headers.", _httpResponse.GetHeadersAsJson().ToString(), ex);
            }
            if (_shouldTrace)
            {
                ServiceClientTracing.Exit(_invocationId, _result);
            }
            return _result;
        }

        /// <param name='accountName'>
        /// The Azure storage account to use.
        /// </param>
        /// <param name='container'>
        /// The container name.
        /// </param>
        /// <param name='containerAcl'>
        /// the acls for the container
        /// </param>
        /// <param name='timeout'>
        /// The timeout parameter is expressed in seconds. For more information, see
        /// &lt;a
        /// href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations"&gt;Setting
        /// Timeouts for Blob Service Operations.&lt;/a&gt;
        /// </param>
        /// <param name='leaseId'>
        /// If specified, the operation only succeeds if the container's lease is
        /// active and matches this ID.
        /// </param>
        /// <param name='access'>
        /// Specifies whether data in the container may be accessed publicly and the
        /// level of access. Possible values include: 'container', 'blob'
        /// </param>
        /// <param name='ifModifiedSince'>
        /// Specify this header value to operate only on a blob if it has been modified
        /// since the specified date/time.
        /// </param>
        /// <param name='ifUnmodifiedSince'>
        /// Specify this header value to operate only on a blob if it has not been
        /// modified since the specified date/time.
        /// </param>
        /// <param name='customHeaders'>
        /// Headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        /// <exception cref="CloudException">
        /// Thrown when the operation returned an invalid status code
        /// </exception>
        /// <exception cref="ValidationException">
        /// Thrown when a required parameter is null
        /// </exception>
        /// <exception cref="System.ArgumentNullException">
        /// Thrown when a required parameter is null
        /// </exception>
        /// <return>
        /// A response object containing the response body and response headers.
        /// </return>
        public async Task<AzureOperationHeaderResponse<ContainerSetAclHeaders>> SetAclWithHttpMessagesAsync(string accountName, string container, IList<SignedIdentifier> containerAcl = default(IList<SignedIdentifier>), int? timeout = default(int?), string leaseId = default(string), string access = default(string), System.DateTime? ifModifiedSince = default(System.DateTime?), System.DateTime? ifUnmodifiedSince = default(System.DateTime?), Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (accountName == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "accountName");
            }
            if (container == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "container");
            }
            if (container != null)
            {
                if (!System.Text.RegularExpressions.Regex.IsMatch(container, "^(?!.*--)^(?!.*\\-$)(^[a-z0-9][a-z0-9-]{3,63}$)"))
                {
                    throw new ValidationException(ValidationRules.Pattern, "container", "^(?!.*--)^(?!.*\\-$)(^[a-z0-9][a-z0-9-]{3,63}$)");
                }
            }
            if (containerAcl != null)
            {
                foreach (var element in containerAcl)
                {
                    if (element != null)
                    {
                        element.Validate();
                    }
                }
            }
            if (timeout < 0)
            {
                throw new ValidationException(ValidationRules.InclusiveMinimum, "timeout", 0);
            }
            string restype = "container";
            string comp = "acl";
            // Tracing
            bool _shouldTrace = ServiceClientTracing.IsEnabled;
            string _invocationId = null;
            if (_shouldTrace)
            {
                _invocationId = ServiceClientTracing.NextInvocationId.ToString();
                Dictionary<string, object> tracingParameters = new Dictionary<string, object>();
                tracingParameters.Add("accountName", accountName);
                tracingParameters.Add("container", container);
                tracingParameters.Add("containerAcl", containerAcl);
                tracingParameters.Add("timeout", timeout);
                tracingParameters.Add("leaseId", leaseId);
                tracingParameters.Add("access", access);
                tracingParameters.Add("ifModifiedSince", ifModifiedSince);
                tracingParameters.Add("ifUnmodifiedSince", ifUnmodifiedSince);
                tracingParameters.Add("restype", restype);
                tracingParameters.Add("comp", comp);
                tracingParameters.Add("cancellationToken", cancellationToken);
                ServiceClientTracing.Enter(_invocationId, this, "SetAcl", tracingParameters);
            }
            // Construct URL
            var _baseUrl = Client.BaseUri;
            var _url = _baseUrl + (_baseUrl.EndsWith("/") ? "" : "/") + "{container}";
            _url = _url.Replace("{accountName}", accountName);
            _url = _url.Replace("{container}", System.Uri.EscapeDataString(container));
            List<string> _queryParameters = new List<string>();
            if (timeout != null)
            {
                _queryParameters.Add(string.Format("timeout={0}", System.Uri.EscapeDataString(SafeJsonConvert.SerializeObject(timeout, Client.SerializationSettings).Trim('"'))));
            }
            if (restype != null)
            {
                _queryParameters.Add(string.Format("restype={0}", System.Uri.EscapeDataString(restype)));
            }
            if (comp != null)
            {
                _queryParameters.Add(string.Format("comp={0}", System.Uri.EscapeDataString(comp)));
            }
            if (_queryParameters.Count > 0)
            {
                _url += (_url.Contains("?") ? "&" : "?") + string.Join("&", _queryParameters);
            }
            // Create HTTP transport objects
            var _httpRequest = new System.Net.Http.HttpRequestMessage();
            System.Net.Http.HttpResponseMessage _httpResponse = null;
            _httpRequest.Method = new System.Net.Http.HttpMethod("PUT");
            _httpRequest.RequestUri = new System.Uri(_url);
            // Set Headers
            if (Client.GenerateClientRequestId != null && Client.GenerateClientRequestId.Value)
            {
                _httpRequest.Headers.TryAddWithoutValidation("x-ms-client-request-id", System.Guid.NewGuid().ToString());
            }
            if (leaseId != null)
            {
                if (_httpRequest.Headers.Contains("x-ms-lease-id"))
                {
                    _httpRequest.Headers.Remove("x-ms-lease-id");
                }
                _httpRequest.Headers.TryAddWithoutValidation("x-ms-lease-id", leaseId);
            }
            if (access != null)
            {
                if (_httpRequest.Headers.Contains("x-ms-blob-public-access"))
                {
                    _httpRequest.Headers.Remove("x-ms-blob-public-access");
                }
                _httpRequest.Headers.TryAddWithoutValidation("x-ms-blob-public-access", access);
            }
            if (ifModifiedSince != null)
            {
                if (_httpRequest.Headers.Contains("If-Modified-Since"))
                {
                    _httpRequest.Headers.Remove("If-Modified-Since");
                }
                _httpRequest.Headers.TryAddWithoutValidation("If-Modified-Since", SafeJsonConvert.SerializeObject(ifModifiedSince, new DateTimeRfc1123JsonConverter()).Trim('"'));
            }
            if (ifUnmodifiedSince != null)
            {
                if (_httpRequest.Headers.Contains("If-Unmodified-Since"))
                {
                    _httpRequest.Headers.Remove("If-Unmodified-Since");
                }
                _httpRequest.Headers.TryAddWithoutValidation("If-Unmodified-Since", SafeJsonConvert.SerializeObject(ifUnmodifiedSince, new DateTimeRfc1123JsonConverter()).Trim('"'));
            }
            if (Client.Version != null)
            {
                if (_httpRequest.Headers.Contains("x-ms-version"))
                {
                    _httpRequest.Headers.Remove("x-ms-version");
                }
                _httpRequest.Headers.TryAddWithoutValidation("x-ms-version", Client.Version);
            }
            if (Client.RequestId != null)
            {
                if (_httpRequest.Headers.Contains("x-ms-client-request-id"))
                {
                    _httpRequest.Headers.Remove("x-ms-client-request-id");
                }
                _httpRequest.Headers.TryAddWithoutValidation("x-ms-client-request-id", Client.RequestId);
            }
            if (Client.AcceptLanguage != null)
            {
                if (_httpRequest.Headers.Contains("accept-language"))
                {
                    _httpRequest.Headers.Remove("accept-language");
                }
                _httpRequest.Headers.TryAddWithoutValidation("accept-language", Client.AcceptLanguage);
            }


            if (customHeaders != null)
            {
                foreach(var _header in customHeaders)
                {
                    if (_httpRequest.Headers.Contains(_header.Key))
                    {
                        _httpRequest.Headers.Remove(_header.Key);
                    }
                    _httpRequest.Headers.TryAddWithoutValidation(_header.Key, _header.Value);
                }
            }

            // Serialize Request
            string _requestContent = null;
            if(containerAcl != null)
            {
                _requestContent = new XElement("SignedIdentifiers", System.Linq.Enumerable.Select(containerAcl, x => x.XmlSerialize(new XElement("SignedIdentifier")))).ToString();
                _httpRequest.Content = new System.Net.Http.StringContent(_requestContent, System.Text.Encoding.UTF8);
                _httpRequest.Content.Headers.ContentType =System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/xml; charset=utf-8");
            }
            // Set Credentials
            if (Client.Credentials != null)
            {
                cancellationToken.ThrowIfCancellationRequested();
                await Client.Credentials.ProcessHttpRequestAsync(_httpRequest, cancellationToken).ConfigureAwait(false);
            }
            // Send Request
            if (_shouldTrace)
            {
                ServiceClientTracing.SendRequest(_invocationId, _httpRequest);
            }
            cancellationToken.ThrowIfCancellationRequested();
            _httpResponse = await Client.HttpClient.SendAsync(_httpRequest, cancellationToken).ConfigureAwait(false);
            if (_shouldTrace)
            {
                ServiceClientTracing.ReceiveResponse(_invocationId, _httpResponse);
            }
            HttpStatusCode _statusCode = _httpResponse.StatusCode;
            cancellationToken.ThrowIfCancellationRequested();
            string _responseContent = null;
            if ((int)_statusCode != 200)
            {
                var ex = new CloudException(string.Format("Operation returned an invalid status code '{0}'", _statusCode));
                if (_httpResponse.Content != null) {
                    _responseContent = await _httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                }
                else {
                    _responseContent = string.Empty;
                }
                ex.Request = new HttpRequestMessageWrapper(_httpRequest, _requestContent);
                ex.Response = new HttpResponseMessageWrapper(_httpResponse, _responseContent);
                if (_httpResponse.Headers.Contains("x-ms-request-id"))
                {
                    ex.RequestId = _httpResponse.Headers.GetValues("x-ms-request-id").FirstOrDefault();
                }
                if (_shouldTrace)
                {
                    ServiceClientTracing.Error(_invocationId, ex);
                }
                _httpRequest.Dispose();
                if (_httpResponse != null)
                {
                    _httpResponse.Dispose();
                }
                throw ex;
            }
            // Create Result
            var _result = new AzureOperationHeaderResponse<ContainerSetAclHeaders>();
            _result.Request = _httpRequest;
            _result.Response = _httpResponse;
            if (_httpResponse.Headers.Contains("x-ms-request-id"))
            {
                _result.RequestId = _httpResponse.Headers.GetValues("x-ms-request-id").FirstOrDefault();
            }
            try
            {
                _result.Headers = _httpResponse.GetHeadersAsJson().ToObject<ContainerSetAclHeaders>(JsonSerializer.Create(Client.DeserializationSettings));
            }
            catch (JsonException ex)
            {
                _httpRequest.Dispose();
                if (_httpResponse != null)
                {
                    _httpResponse.Dispose();
                }
                throw new SerializationException("Unable to deserialize the headers.", _httpResponse.GetHeadersAsJson().ToString(), ex);
            }
            if (_shouldTrace)
            {
                ServiceClientTracing.Exit(_invocationId, _result);
            }
            return _result;
        }

        /// <summary>
        /// establishes and manages a lock on a container for delete operations. The
        /// lock duration can be 15 to 60 seconds, or can be infinite
        /// </summary>
        /// <param name='accountName'>
        /// The Azure storage account to use.
        /// </param>
        /// <param name='container'>
        /// The container name.
        /// </param>
        /// <param name='action'>
        /// Describes what lease action to take. Possible values include: 'acquire',
        /// 'renew', 'change', 'release', 'break'
        /// </param>
        /// <param name='timeout'>
        /// The timeout parameter is expressed in seconds. For more information, see
        /// &lt;a
        /// href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations"&gt;Setting
        /// Timeouts for Blob Service Operations.&lt;/a&gt;
        /// </param>
        /// <param name='leaseId'>
        /// If specified, the operation only succeeds if the container's lease is
        /// active and matches this ID.
        /// </param>
        /// <param name='breakPeriod'>
        /// For a break operation, proposed duration the lease should continue before
        /// it is broken, in seconds, between 0 and 60. This break period is only used
        /// if it is shorter than the time remaining on the lease. If longer, the time
        /// remaining on the lease is used. A new lease will not be available before
        /// the break period has expired, but the lease may be held for longer than the
        /// break period. If this header does not appear with a break operation, a
        /// fixed-duration lease breaks after the remaining lease period elapses, and
        /// an infinite lease breaks immediately.
        /// </param>
        /// <param name='duration'>
        /// Specifies the duration of the lease, in seconds, or negative one (-1) for a
        /// lease that never expires. A non-infinite lease can be between 15 and 60
        /// seconds. A lease duration cannot be changed using renew or change.
        /// </param>
        /// <param name='proposedLeaseId'>
        /// Proposed lease ID, in a GUID string format. The Blob service returns 400
        /// (Invalid request) if the proposed lease ID is not in the correct format.
        /// See Guid Constructor (String) for a list of valid GUID string formats.
        /// </param>
        /// <param name='origin'>
        /// Specifies the origin from which the request is issued. The presence of this
        /// header results in cross-origin resource sharing (CORS) headers on the
        /// response.
        /// </param>
        /// <param name='ifModifiedSince'>
        /// Specify this header value to operate only on a blob if it has been modified
        /// since the specified date/time.
        /// </param>
        /// <param name='ifUnmodifiedSince'>
        /// Specify this header value to operate only on a blob if it has not been
        /// modified since the specified date/time.
        /// </param>
        /// <param name='customHeaders'>
        /// Headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        /// <exception cref="CloudException">
        /// Thrown when the operation returned an invalid status code
        /// </exception>
        /// <exception cref="ValidationException">
        /// Thrown when a required parameter is null
        /// </exception>
        /// <exception cref="System.ArgumentNullException">
        /// Thrown when a required parameter is null
        /// </exception>
        /// <return>
        /// A response object containing the response body and response headers.
        /// </return>
        public async Task<AzureOperationHeaderResponse<ContainerLeaseHeaders>> LeaseWithHttpMessagesAsync(string accountName, string container, string action, int? timeout = default(int?), string leaseId = default(string), int? breakPeriod = default(int?), int? duration = default(int?), string proposedLeaseId = default(string), string origin = default(string), System.DateTime? ifModifiedSince = default(System.DateTime?), System.DateTime? ifUnmodifiedSince = default(System.DateTime?), Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (accountName == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "accountName");
            }
            if (container == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "container");
            }
            if (container != null)
            {
                if (!System.Text.RegularExpressions.Regex.IsMatch(container, "^(?!.*--)^(?!.*\\-$)(^[a-z0-9][a-z0-9-]{3,63}$)"))
                {
                    throw new ValidationException(ValidationRules.Pattern, "container", "^(?!.*--)^(?!.*\\-$)(^[a-z0-9][a-z0-9-]{3,63}$)");
                }
            }
            if (timeout < 0)
            {
                throw new ValidationException(ValidationRules.InclusiveMinimum, "timeout", 0);
            }
            if (action == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "action");
            }
            string comp = "lease";
            string restype = "container";
            // Tracing
            bool _shouldTrace = ServiceClientTracing.IsEnabled;
            string _invocationId = null;
            if (_shouldTrace)
            {
                _invocationId = ServiceClientTracing.NextInvocationId.ToString();
                Dictionary<string, object> tracingParameters = new Dictionary<string, object>();
                tracingParameters.Add("accountName", accountName);
                tracingParameters.Add("container", container);
                tracingParameters.Add("timeout", timeout);
                tracingParameters.Add("leaseId", leaseId);
                tracingParameters.Add("action", action);
                tracingParameters.Add("breakPeriod", breakPeriod);
                tracingParameters.Add("duration", duration);
                tracingParameters.Add("proposedLeaseId", proposedLeaseId);
                tracingParameters.Add("origin", origin);
                tracingParameters.Add("ifModifiedSince", ifModifiedSince);
                tracingParameters.Add("ifUnmodifiedSince", ifUnmodifiedSince);
                tracingParameters.Add("comp", comp);
                tracingParameters.Add("restype", restype);
                tracingParameters.Add("cancellationToken", cancellationToken);
                ServiceClientTracing.Enter(_invocationId, this, "Lease", tracingParameters);
            }
            // Construct URL
            var _baseUrl = Client.BaseUri;
            var _url = _baseUrl + (_baseUrl.EndsWith("/") ? "" : "/") + "{container}";
            _url = _url.Replace("{accountName}", accountName);
            _url = _url.Replace("{container}", System.Uri.EscapeDataString(container));
            List<string> _queryParameters = new List<string>();
            if (timeout != null)
            {
                _queryParameters.Add(string.Format("timeout={0}", System.Uri.EscapeDataString(SafeJsonConvert.SerializeObject(timeout, Client.SerializationSettings).Trim('"'))));
            }
            if (comp != null)
            {
                _queryParameters.Add(string.Format("comp={0}", System.Uri.EscapeDataString(comp)));
            }
            if (restype != null)
            {
                _queryParameters.Add(string.Format("restype={0}", System.Uri.EscapeDataString(restype)));
            }
            if (_queryParameters.Count > 0)
            {
                _url += (_url.Contains("?") ? "&" : "?") + string.Join("&", _queryParameters);
            }
            // Create HTTP transport objects
            var _httpRequest = new System.Net.Http.HttpRequestMessage();
            System.Net.Http.HttpResponseMessage _httpResponse = null;
            _httpRequest.Method = new System.Net.Http.HttpMethod("PUT");
            _httpRequest.RequestUri = new System.Uri(_url);
            // Set Headers
            if (Client.GenerateClientRequestId != null && Client.GenerateClientRequestId.Value)
            {
                _httpRequest.Headers.TryAddWithoutValidation("x-ms-client-request-id", System.Guid.NewGuid().ToString());
            }
            if (leaseId != null)
            {
                if (_httpRequest.Headers.Contains("x-ms-lease-id"))
                {
                    _httpRequest.Headers.Remove("x-ms-lease-id");
                }
                _httpRequest.Headers.TryAddWithoutValidation("x-ms-lease-id", leaseId);
            }
            if (action != null)
            {
                if (_httpRequest.Headers.Contains("x-ms-lease-action"))
                {
                    _httpRequest.Headers.Remove("x-ms-lease-action");
                }
                _httpRequest.Headers.TryAddWithoutValidation("x-ms-lease-action", action);
            }
            if (breakPeriod != null)
            {
                if (_httpRequest.Headers.Contains("x-ms-lease-break-period"))
                {
                    _httpRequest.Headers.Remove("x-ms-lease-break-period");
                }
                _httpRequest.Headers.TryAddWithoutValidation("x-ms-lease-break-period", SafeJsonConvert.SerializeObject(breakPeriod, Client.SerializationSettings).Trim('"'));
            }
            if (duration != null)
            {
                if (_httpRequest.Headers.Contains("x-ms-lease-duration"))
                {
                    _httpRequest.Headers.Remove("x-ms-lease-duration");
                }
                _httpRequest.Headers.TryAddWithoutValidation("x-ms-lease-duration", SafeJsonConvert.SerializeObject(duration, Client.SerializationSettings).Trim('"'));
            }
            if (proposedLeaseId != null)
            {
                if (_httpRequest.Headers.Contains("x-ms-proposed-lease-id"))
                {
                    _httpRequest.Headers.Remove("x-ms-proposed-lease-id");
                }
                _httpRequest.Headers.TryAddWithoutValidation("x-ms-proposed-lease-id", proposedLeaseId);
            }
            if (origin != null)
            {
                if (_httpRequest.Headers.Contains("Origin"))
                {
                    _httpRequest.Headers.Remove("Origin");
                }
                _httpRequest.Headers.TryAddWithoutValidation("Origin", origin);
            }
            if (ifModifiedSince != null)
            {
                if (_httpRequest.Headers.Contains("If-Modified-Since"))
                {
                    _httpRequest.Headers.Remove("If-Modified-Since");
                }
                _httpRequest.Headers.TryAddWithoutValidation("If-Modified-Since", SafeJsonConvert.SerializeObject(ifModifiedSince, new DateTimeRfc1123JsonConverter()).Trim('"'));
            }
            if (ifUnmodifiedSince != null)
            {
                if (_httpRequest.Headers.Contains("If-Unmodified-Since"))
                {
                    _httpRequest.Headers.Remove("If-Unmodified-Since");
                }
                _httpRequest.Headers.TryAddWithoutValidation("If-Unmodified-Since", SafeJsonConvert.SerializeObject(ifUnmodifiedSince, new DateTimeRfc1123JsonConverter()).Trim('"'));
            }
            if (Client.Version != null)
            {
                if (_httpRequest.Headers.Contains("x-ms-version"))
                {
                    _httpRequest.Headers.Remove("x-ms-version");
                }
                _httpRequest.Headers.TryAddWithoutValidation("x-ms-version", Client.Version);
            }
            if (Client.RequestId != null)
            {
                if (_httpRequest.Headers.Contains("x-ms-client-request-id"))
                {
                    _httpRequest.Headers.Remove("x-ms-client-request-id");
                }
                _httpRequest.Headers.TryAddWithoutValidation("x-ms-client-request-id", Client.RequestId);
            }
            if (Client.AcceptLanguage != null)
            {
                if (_httpRequest.Headers.Contains("accept-language"))
                {
                    _httpRequest.Headers.Remove("accept-language");
                }
                _httpRequest.Headers.TryAddWithoutValidation("accept-language", Client.AcceptLanguage);
            }


            if (customHeaders != null)
            {
                foreach(var _header in customHeaders)
                {
                    if (_httpRequest.Headers.Contains(_header.Key))
                    {
                        _httpRequest.Headers.Remove(_header.Key);
                    }
                    _httpRequest.Headers.TryAddWithoutValidation(_header.Key, _header.Value);
                }
            }

            // Serialize Request
            string _requestContent = null;
            // Set Credentials
            if (Client.Credentials != null)
            {
                cancellationToken.ThrowIfCancellationRequested();
                await Client.Credentials.ProcessHttpRequestAsync(_httpRequest, cancellationToken).ConfigureAwait(false);
            }
            // Send Request
            if (_shouldTrace)
            {
                ServiceClientTracing.SendRequest(_invocationId, _httpRequest);
            }
            cancellationToken.ThrowIfCancellationRequested();
            _httpResponse = await Client.HttpClient.SendAsync(_httpRequest, cancellationToken).ConfigureAwait(false);
            if (_shouldTrace)
            {
                ServiceClientTracing.ReceiveResponse(_invocationId, _httpResponse);
            }
            HttpStatusCode _statusCode = _httpResponse.StatusCode;
            cancellationToken.ThrowIfCancellationRequested();
            string _responseContent = null;
            if ((int)_statusCode != 200 && (int)_statusCode != 201 && (int)_statusCode != 202)
            {
                var ex = new CloudException(string.Format("Operation returned an invalid status code '{0}'", _statusCode));
                if (_httpResponse.Content != null) {
                    _responseContent = await _httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                }
                else {
                    _responseContent = string.Empty;
                }
                ex.Request = new HttpRequestMessageWrapper(_httpRequest, _requestContent);
                ex.Response = new HttpResponseMessageWrapper(_httpResponse, _responseContent);
                if (_httpResponse.Headers.Contains("x-ms-request-id"))
                {
                    ex.RequestId = _httpResponse.Headers.GetValues("x-ms-request-id").FirstOrDefault();
                }
                if (_shouldTrace)
                {
                    ServiceClientTracing.Error(_invocationId, ex);
                }
                _httpRequest.Dispose();
                if (_httpResponse != null)
                {
                    _httpResponse.Dispose();
                }
                throw ex;
            }
            // Create Result
            var _result = new AzureOperationHeaderResponse<ContainerLeaseHeaders>();
            _result.Request = _httpRequest;
            _result.Response = _httpResponse;
            if (_httpResponse.Headers.Contains("x-ms-request-id"))
            {
                _result.RequestId = _httpResponse.Headers.GetValues("x-ms-request-id").FirstOrDefault();
            }
            try
            {
                _result.Headers = _httpResponse.GetHeadersAsJson().ToObject<ContainerLeaseHeaders>(JsonSerializer.Create(Client.DeserializationSettings));
            }
            catch (JsonException ex)
            {
                _httpRequest.Dispose();
                if (_httpResponse != null)
                {
                    _httpResponse.Dispose();
                }
                throw new SerializationException("Unable to deserialize the headers.", _httpResponse.GetHeadersAsJson().ToString(), ex);
            }
            if (_shouldTrace)
            {
                ServiceClientTracing.Exit(_invocationId, _result);
            }
            return _result;
        }

        /// <summary>
        /// The List Blobs operation returns a list of the blobs under the specified
        /// container
        /// </summary>
        /// <param name='accountName'>
        /// The Azure storage account to use.
        /// </param>
        /// <param name='container'>
        /// The container name.
        /// </param>
        /// <param name='prefix'>
        /// Filters the results to return only containers whose name begins with the
        /// specified prefix.
        /// </param>
        /// <param name='delimiter'>
        /// When the request includes this parameter, the operation returns a
        /// BlobPrefix element in the response body that acts as a placeholder for all
        /// blobs whose names begin with the same substring up to the appearance of the
        /// delimiter character. The delimiter may be a single character or a string.
        /// </param>
        /// <param name='marker'>
        /// A string value that identifies the portion of the list of containers to be
        /// returned with the next listing operation. The operation returns the
        /// NextMarker value within the response body if the listing operation did not
        /// return all containers remaining to be listed with the current page. The
        /// NextMarker value can be used as the value for the marker parameter in a
        /// subsequent call to request the next page of list items. The marker value is
        /// opaque to the client.
        /// </param>
        /// <param name='maxresults'>
        /// Specifies the maximum number of containers to return. If the request does
        /// not specify maxresults, or specifies a value greater than 5000, the server
        /// will return up to 5000 items. Note that if the listing operation crosses a
        /// partition boundary, then the service will return a continuation token for
        /// retrieving the remainder of the results. For this reason, it is possible
        /// that the service will return fewer results than specified by maxresults, or
        /// than the default of 5000.
        /// </param>
        /// <param name='include'>
        /// Include this parameter to specify that the container's metadata be returned
        /// as part of the response body. Possible values include: 'metadata'
        /// </param>
        /// <param name='timeout'>
        /// The timeout parameter is expressed in seconds. For more information, see
        /// &lt;a
        /// href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations"&gt;Setting
        /// Timeouts for Blob Service Operations.&lt;/a&gt;
        /// </param>
        /// <param name='customHeaders'>
        /// Headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        /// <exception cref="CloudException">
        /// Thrown when the operation returned an invalid status code
        /// </exception>
        /// <exception cref="SerializationException">
        /// Thrown when unable to deserialize the response
        /// </exception>
        /// <exception cref="ValidationException">
        /// Thrown when a required parameter is null
        /// </exception>
        /// <exception cref="System.ArgumentNullException">
        /// Thrown when a required parameter is null
        /// </exception>
        /// <return>
        /// A response object containing the response body and response headers.
        /// </return>
        public async Task<AzureOperationResponse<BlobEnumerationResults,ContainerListBlobsHeaders>> ListBlobsWithHttpMessagesAsync(string accountName, string container, string prefix = default(string), string delimiter = default(string), string marker = default(string), int? maxresults = default(int?), string include = default(string), int? timeout = default(int?), Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (accountName == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "accountName");
            }
            if (container == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "container");
            }
            if (container != null)
            {
                if (!System.Text.RegularExpressions.Regex.IsMatch(container, "^(?!.*--)^(?!.*\\-$)(^[a-z0-9][a-z0-9-]{3,63}$)"))
                {
                    throw new ValidationException(ValidationRules.Pattern, "container", "^(?!.*--)^(?!.*\\-$)(^[a-z0-9][a-z0-9-]{3,63}$)");
                }
            }
            if (maxresults < 0)
            {
                throw new ValidationException(ValidationRules.InclusiveMinimum, "maxresults", 0);
            }
            if (timeout < 0)
            {
                throw new ValidationException(ValidationRules.InclusiveMinimum, "timeout", 0);
            }
            string restype = "container";
            string comp = "list";
            // Tracing
            bool _shouldTrace = ServiceClientTracing.IsEnabled;
            string _invocationId = null;
            if (_shouldTrace)
            {
                _invocationId = ServiceClientTracing.NextInvocationId.ToString();
                Dictionary<string, object> tracingParameters = new Dictionary<string, object>();
                tracingParameters.Add("accountName", accountName);
                tracingParameters.Add("container", container);
                tracingParameters.Add("prefix", prefix);
                tracingParameters.Add("delimiter", delimiter);
                tracingParameters.Add("marker", marker);
                tracingParameters.Add("maxresults", maxresults);
                tracingParameters.Add("include", include);
                tracingParameters.Add("timeout", timeout);
                tracingParameters.Add("restype", restype);
                tracingParameters.Add("comp", comp);
                tracingParameters.Add("cancellationToken", cancellationToken);
                ServiceClientTracing.Enter(_invocationId, this, "ListBlobs", tracingParameters);
            }
            // Construct URL
            var _baseUrl = Client.BaseUri;
            var _url = _baseUrl + (_baseUrl.EndsWith("/") ? "" : "/") + "{container}";
            _url = _url.Replace("{accountName}", accountName);
            _url = _url.Replace("{container}", System.Uri.EscapeDataString(container));
            List<string> _queryParameters = new List<string>();
            if (prefix != null)
            {
                _queryParameters.Add(string.Format("prefix={0}", System.Uri.EscapeDataString(prefix)));
            }
            if (delimiter != null)
            {
                _queryParameters.Add(string.Format("delimiter={0}", System.Uri.EscapeDataString(delimiter)));
            }
            if (marker != null)
            {
                _queryParameters.Add(string.Format("marker={0}", System.Uri.EscapeDataString(marker)));
            }
            if (maxresults != null)
            {
                _queryParameters.Add(string.Format("maxresults={0}", System.Uri.EscapeDataString(SafeJsonConvert.SerializeObject(maxresults, Client.SerializationSettings).Trim('"'))));
            }
            if (include != null)
            {
                _queryParameters.Add(string.Format("include={0}", System.Uri.EscapeDataString(include)));
            }
            if (timeout != null)
            {
                _queryParameters.Add(string.Format("timeout={0}", System.Uri.EscapeDataString(SafeJsonConvert.SerializeObject(timeout, Client.SerializationSettings).Trim('"'))));
            }
            if (restype != null)
            {
                _queryParameters.Add(string.Format("restype={0}", System.Uri.EscapeDataString(restype)));
            }
            if (comp != null)
            {
                _queryParameters.Add(string.Format("comp={0}", System.Uri.EscapeDataString(comp)));
            }
            if (_queryParameters.Count > 0)
            {
                _url += (_url.Contains("?") ? "&" : "?") + string.Join("&", _queryParameters);
            }
            // Create HTTP transport objects
            var _httpRequest = new System.Net.Http.HttpRequestMessage();
            System.Net.Http.HttpResponseMessage _httpResponse = null;
            _httpRequest.Method = new System.Net.Http.HttpMethod("GET");
            _httpRequest.RequestUri = new System.Uri(_url);
            // Set Headers
            if (Client.GenerateClientRequestId != null && Client.GenerateClientRequestId.Value)
            {
                _httpRequest.Headers.TryAddWithoutValidation("x-ms-client-request-id", System.Guid.NewGuid().ToString());
            }
            if (Client.Version != null)
            {
                if (_httpRequest.Headers.Contains("x-ms-version"))
                {
                    _httpRequest.Headers.Remove("x-ms-version");
                }
                _httpRequest.Headers.TryAddWithoutValidation("x-ms-version", Client.Version);
            }
            if (Client.RequestId != null)
            {
                if (_httpRequest.Headers.Contains("x-ms-client-request-id"))
                {
                    _httpRequest.Headers.Remove("x-ms-client-request-id");
                }
                _httpRequest.Headers.TryAddWithoutValidation("x-ms-client-request-id", Client.RequestId);
            }
            if (Client.AcceptLanguage != null)
            {
                if (_httpRequest.Headers.Contains("accept-language"))
                {
                    _httpRequest.Headers.Remove("accept-language");
                }
                _httpRequest.Headers.TryAddWithoutValidation("accept-language", Client.AcceptLanguage);
            }


            if (customHeaders != null)
            {
                foreach(var _header in customHeaders)
                {
                    if (_httpRequest.Headers.Contains(_header.Key))
                    {
                        _httpRequest.Headers.Remove(_header.Key);
                    }
                    _httpRequest.Headers.TryAddWithoutValidation(_header.Key, _header.Value);
                }
            }

            // Serialize Request
            string _requestContent = null;
            // Set Credentials
            if (Client.Credentials != null)
            {
                cancellationToken.ThrowIfCancellationRequested();
                await Client.Credentials.ProcessHttpRequestAsync(_httpRequest, cancellationToken).ConfigureAwait(false);
            }
            // Send Request
            if (_shouldTrace)
            {
                ServiceClientTracing.SendRequest(_invocationId, _httpRequest);
            }
            cancellationToken.ThrowIfCancellationRequested();
            _httpResponse = await Client.HttpClient.SendAsync(_httpRequest, cancellationToken).ConfigureAwait(false);
            if (_shouldTrace)
            {
                ServiceClientTracing.ReceiveResponse(_invocationId, _httpResponse);
            }
            HttpStatusCode _statusCode = _httpResponse.StatusCode;
            cancellationToken.ThrowIfCancellationRequested();
            string _responseContent = null;
            if ((int)_statusCode != 200)
            {
                var ex = new CloudException(string.Format("Operation returned an invalid status code '{0}'", _statusCode));
                try
                {
                    _responseContent = await _httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                    CloudError _errorBody =  SafeJsonConvert.DeserializeObject<CloudError>(_responseContent, Client.DeserializationSettings);
                    if (_errorBody != null)
                    {
                        ex = new CloudException(_errorBody.Message);
                        ex.Body = _errorBody;
                    }
                }
                catch (JsonException)
                {
                    // Ignore the exception
                }
                ex.Request = new HttpRequestMessageWrapper(_httpRequest, _requestContent);
                ex.Response = new HttpResponseMessageWrapper(_httpResponse, _responseContent);
                if (_httpResponse.Headers.Contains("x-ms-request-id"))
                {
                    ex.RequestId = _httpResponse.Headers.GetValues("x-ms-request-id").FirstOrDefault();
                }
                if (_shouldTrace)
                {
                    ServiceClientTracing.Error(_invocationId, ex);
                }
                _httpRequest.Dispose();
                if (_httpResponse != null)
                {
                    _httpResponse.Dispose();
                }
                throw ex;
            }
            // Create Result
            var _result = new AzureOperationResponse<BlobEnumerationResults,ContainerListBlobsHeaders>();
            _result.Request = _httpRequest;
            _result.Response = _httpResponse;
            if (_httpResponse.Headers.Contains("x-ms-request-id"))
            {
                _result.RequestId = _httpResponse.Headers.GetValues("x-ms-request-id").FirstOrDefault();
            }
            // Deserialize Response
            if ((int)_statusCode == 200)
            {
                _responseContent = await _httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                try
                {
                    BlobEnumerationResults _tmp_ = null;
                    if (_httpResponse.Content.Headers.ContentType.MediaType == "application/xml" &&
                        XmlSerialization.Root(XmlSerialization.ToDeserializer(e => BlobEnumerationResults.XmlDeserialize(e)))(XElement.Parse(_responseContent), out _tmp_))
                    {
                        _result.Body = _tmp_;
                    }else
                    {
                        _result.Body = SafeJsonConvert.DeserializeObject<BlobEnumerationResults>(_responseContent, Client.DeserializationSettings);
                    }
                }
                catch (JsonException ex)
                {
                    _httpRequest.Dispose();
                    if (_httpResponse != null)
                    {
                        _httpResponse.Dispose();
                    }
                    throw new SerializationException("Unable to deserialize the response.", _responseContent, ex);
                }
            }
            try
            {
                _result.Headers = _httpResponse.GetHeadersAsJson().ToObject<ContainerListBlobsHeaders>(JsonSerializer.Create(Client.DeserializationSettings));
            }
            catch (JsonException ex)
            {
                _httpRequest.Dispose();
                if (_httpResponse != null)
                {
                    _httpResponse.Dispose();
                }
                throw new SerializationException("Unable to deserialize the headers.", _httpResponse.GetHeadersAsJson().ToString(), ex);
            }
            if (_shouldTrace)
            {
                ServiceClientTracing.Exit(_invocationId, _result);
            }
            return _result;
        }

    }
}

