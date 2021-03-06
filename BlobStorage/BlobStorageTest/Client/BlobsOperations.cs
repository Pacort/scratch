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
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// BlobsOperations operations.
    /// </summary>
    internal partial class BlobsOperations : IServiceOperations<AzureBlobStorageClient>, IBlobsOperations
    {
        /// <summary>
        /// Initializes a new instance of the BlobsOperations class.
        /// </summary>
        /// <param name='client'>
        /// Reference to the service client.
        /// </param>
        /// <exception cref="System.ArgumentNullException">
        /// Thrown when a required parameter is null
        /// </exception>
        internal BlobsOperations(AzureBlobStorageClient client)
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
        public AzureBlobStorageClient Client { get; private set; }

        /// <summary>
        /// The Get Blob operation reads or downloads a blob from the system, including
        /// its metadata and properties. You can also call Get Blob to read a snapshot.
        /// </summary>
        /// <param name='accountName'>
        /// The Azure storage account to use.
        /// </param>
        /// <param name='container'>
        /// The container name.
        /// </param>
        /// <param name='blob'>
        /// The blob name.
        /// </param>
        /// <param name='snapshot'>
        /// The snapshot parameter is an opaque DateTime value that, when present,
        /// specifies the blob snapshot to retrieve. For more information on working
        /// with blob snapshots, see &lt;a
        /// href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/creating-a-snapshot-of-a-blob"&gt;Creating
        /// a Snapshot of a Blob.&lt;/a&gt;
        /// </param>
        /// <param name='timeout'>
        /// The timeout parameter is expressed in seconds. For more information, see
        /// &lt;a
        /// href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations"&gt;Setting
        /// Timeouts for Blob Service Operations.&lt;/a&gt;
        /// </param>
        /// <param name='range'>
        /// Return only the bytes of the blob in the specified range.
        /// </param>
        /// <param name='leaseId'>
        /// If specified, the operation only succeeds if the container's lease is
        /// active and matches this ID.
        /// </param>
        /// <param name='xMsRangeGetContentMd5'>
        /// When set to true and specified together with the Range, the service returns
        /// the MD5 hash for the range, as long as the range is less than or equal to 4
        /// MB in size.
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
        /// <param name='ifMatches'>
        /// Specify an ETag value to operate only on blobs with a matching value.
        /// </param>
        /// <param name='ifNoneMatch'>
        /// Specify an ETag value to operate only on blobs without a matching value.
        /// </param>
        /// <param name='customHeaders'>
        /// Headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        /// <exception cref="ErrorException">
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
        public async Task<AzureOperationResponse<Stream,BlobsGetHeaders>> GetWithHttpMessagesAsync(string accountName, string container, string blob, System.DateTime? snapshot = default(System.DateTime?), int? timeout = default(int?), string range = default(string), string leaseId = default(string), bool? xMsRangeGetContentMd5 = default(bool?), string origin = default(string), System.DateTime? ifModifiedSince = default(System.DateTime?), System.DateTime? ifUnmodifiedSince = default(System.DateTime?), string ifMatches = default(string), string ifNoneMatch = default(string), Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (accountName == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "accountName");
            }
            if (container == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "container");
            }
            if (blob == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "blob");
            }
            if (blob != null)
            {
                if (!System.Text.RegularExpressions.Regex.IsMatch(blob, "^(?!.*\\/$)^[\\s\\S]{1,1024}$"))
                {
                    throw new ValidationException(ValidationRules.Pattern, "blob", "^(?!.*\\/$)^[\\s\\S]{1,1024}$");
                }
            }
            if (timeout < 0)
            {
                throw new ValidationException(ValidationRules.InclusiveMinimum, "timeout", 0);
            }
            // Tracing
            bool _shouldTrace = ServiceClientTracing.IsEnabled;
            string _invocationId = null;
            if (_shouldTrace)
            {
                _invocationId = ServiceClientTracing.NextInvocationId.ToString();
                Dictionary<string, object> tracingParameters = new Dictionary<string, object>();
                tracingParameters.Add("accountName", accountName);
                tracingParameters.Add("container", container);
                tracingParameters.Add("blob", blob);
                tracingParameters.Add("snapshot", snapshot);
                tracingParameters.Add("timeout", timeout);
                tracingParameters.Add("range", range);
                tracingParameters.Add("leaseId", leaseId);
                tracingParameters.Add("xMsRangeGetContentMd5", xMsRangeGetContentMd5);
                tracingParameters.Add("origin", origin);
                tracingParameters.Add("ifModifiedSince", ifModifiedSince);
                tracingParameters.Add("ifUnmodifiedSince", ifUnmodifiedSince);
                tracingParameters.Add("ifMatches", ifMatches);
                tracingParameters.Add("ifNoneMatch", ifNoneMatch);
                tracingParameters.Add("cancellationToken", cancellationToken);
                ServiceClientTracing.Enter(_invocationId, this, "Get", tracingParameters);
            }
            // Construct URL
            var _baseUrl = Client.BaseUri;
            var _url = _baseUrl + (_baseUrl.EndsWith("/") ? "" : "/") + "{container}/{blob}";
            _url = _url.Replace("{accountName}", accountName);
            _url = _url.Replace("{container}", System.Uri.EscapeDataString(container));
            _url = _url.Replace("{blob}", System.Uri.EscapeDataString(blob));
            List<string> _queryParameters = new List<string>();
            if (snapshot != null)
            {
                _queryParameters.Add(string.Format("snapshot={0}", System.Uri.EscapeDataString(SafeJsonConvert.SerializeObject(snapshot, new DateTimeRfc1123JsonConverter()).Trim('"'))));
            }
            if (timeout != null)
            {
                _queryParameters.Add(string.Format("timeout={0}", System.Uri.EscapeDataString(SafeJsonConvert.SerializeObject(timeout, Client.SerializationSettings).Trim('"'))));
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
            if (range != null)
            {
                if (_httpRequest.Headers.Contains("x-ms-range"))
                {
                    _httpRequest.Headers.Remove("x-ms-range");
                }
                _httpRequest.Headers.TryAddWithoutValidation("x-ms-range", range);
            }
            if (leaseId != null)
            {
                if (_httpRequest.Headers.Contains("x-ms-lease-id"))
                {
                    _httpRequest.Headers.Remove("x-ms-lease-id");
                }
                _httpRequest.Headers.TryAddWithoutValidation("x-ms-lease-id", leaseId);
            }
            if (xMsRangeGetContentMd5 != null)
            {
                if (_httpRequest.Headers.Contains("x-ms-range-get-content-md5"))
                {
                    _httpRequest.Headers.Remove("x-ms-range-get-content-md5");
                }
                _httpRequest.Headers.TryAddWithoutValidation("x-ms-range-get-content-md5", SafeJsonConvert.SerializeObject(xMsRangeGetContentMd5, Client.SerializationSettings).Trim('"'));
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
            if (ifMatches != null)
            {
                if (_httpRequest.Headers.Contains("If-Match"))
                {
                    _httpRequest.Headers.Remove("If-Match");
                }
                _httpRequest.Headers.TryAddWithoutValidation("If-Match", ifMatches);
            }
            if (ifNoneMatch != null)
            {
                if (_httpRequest.Headers.Contains("If-None-Match"))
                {
                    _httpRequest.Headers.Remove("If-None-Match");
                }
                _httpRequest.Headers.TryAddWithoutValidation("If-None-Match", ifNoneMatch);
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
            _httpResponse = await Client.HttpClient.SendAsync(_httpRequest, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
            if (_shouldTrace)
            {
                ServiceClientTracing.ReceiveResponse(_invocationId, _httpResponse);
            }
            HttpStatusCode _statusCode = _httpResponse.StatusCode;
            cancellationToken.ThrowIfCancellationRequested();
            string _responseContent = null;
            if ((int)_statusCode != 200 && (int)_statusCode != 206)
            {
                var ex = new ErrorException(string.Format("Operation returned an invalid status code '{0}'", _statusCode));
                try
                {
                    _responseContent = await _httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                    Error _errorBody =  SafeJsonConvert.DeserializeObject<Error>(_responseContent, Client.DeserializationSettings);
                    if (_errorBody != null)
                    {
                        ex.Body = _errorBody;
                    }
                }
                catch (JsonException)
                {
                    // Ignore the exception
                }
                ex.Request = new HttpRequestMessageWrapper(_httpRequest, _requestContent);
                ex.Response = new HttpResponseMessageWrapper(_httpResponse, _responseContent);
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
            var _result = new AzureOperationResponse<Stream,BlobsGetHeaders>();
            _result.Request = _httpRequest;
            _result.Response = _httpResponse;
            if (_httpResponse.Headers.Contains("x-ms-request-id"))
            {
                _result.RequestId = _httpResponse.Headers.GetValues("x-ms-request-id").FirstOrDefault();
            }
            // Deserialize Response
            if ((int)_statusCode == 200)
            {
                _result.Body = await _httpResponse.Content.ReadAsStreamAsync().ConfigureAwait(false);
            }
            // Deserialize Response
            if ((int)_statusCode == 206)
            {
                _result.Body = await _httpResponse.Content.ReadAsStreamAsync().ConfigureAwait(false);
            }
            try
            {
                _result.Headers = _httpResponse.GetHeadersAsJson().ToObject<BlobsGetHeaders>(JsonSerializer.Create(Client.DeserializationSettings));
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
        /// The Get Blob Properties operation returns all user-defined metadata,
        /// standard HTTP properties, and system properties for the blob. It does not
        /// return the content of the blob.
        /// </summary>
        /// <param name='accountName'>
        /// The Azure storage account to use.
        /// </param>
        /// <param name='container'>
        /// The container name.
        /// </param>
        /// <param name='blob'>
        /// The blob name.
        /// </param>
        /// <param name='snapshot'>
        /// The snapshot parameter is an opaque DateTime value that, when present,
        /// specifies the blob snapshot to retrieve. For more information on working
        /// with blob snapshots, see &lt;a
        /// href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/creating-a-snapshot-of-a-blob"&gt;Creating
        /// a Snapshot of a Blob.&lt;/a&gt;
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
        /// <param name='ifMatches'>
        /// Specify an ETag value to operate only on blobs with a matching value.
        /// </param>
        /// <param name='ifNoneMatch'>
        /// Specify an ETag value to operate only on blobs without a matching value.
        /// </param>
        /// <param name='customHeaders'>
        /// Headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        /// <exception cref="ErrorException">
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
        public async Task<AzureOperationHeaderResponse<BlobsGetPropertiesHeaders>> GetPropertiesWithHttpMessagesAsync(string accountName, string container, string blob, System.DateTime? snapshot = default(System.DateTime?), int? timeout = default(int?), string leaseId = default(string), System.DateTime? ifModifiedSince = default(System.DateTime?), System.DateTime? ifUnmodifiedSince = default(System.DateTime?), string ifMatches = default(string), string ifNoneMatch = default(string), Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (accountName == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "accountName");
            }
            if (container == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "container");
            }
            if (blob == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "blob");
            }
            if (blob != null)
            {
                if (!System.Text.RegularExpressions.Regex.IsMatch(blob, "^(?!.*\\/$)^[\\s\\S]{1,1024}$"))
                {
                    throw new ValidationException(ValidationRules.Pattern, "blob", "^(?!.*\\/$)^[\\s\\S]{1,1024}$");
                }
            }
            if (timeout < 0)
            {
                throw new ValidationException(ValidationRules.InclusiveMinimum, "timeout", 0);
            }
            // Tracing
            bool _shouldTrace = ServiceClientTracing.IsEnabled;
            string _invocationId = null;
            if (_shouldTrace)
            {
                _invocationId = ServiceClientTracing.NextInvocationId.ToString();
                Dictionary<string, object> tracingParameters = new Dictionary<string, object>();
                tracingParameters.Add("accountName", accountName);
                tracingParameters.Add("container", container);
                tracingParameters.Add("blob", blob);
                tracingParameters.Add("snapshot", snapshot);
                tracingParameters.Add("timeout", timeout);
                tracingParameters.Add("leaseId", leaseId);
                tracingParameters.Add("ifModifiedSince", ifModifiedSince);
                tracingParameters.Add("ifUnmodifiedSince", ifUnmodifiedSince);
                tracingParameters.Add("ifMatches", ifMatches);
                tracingParameters.Add("ifNoneMatch", ifNoneMatch);
                tracingParameters.Add("cancellationToken", cancellationToken);
                ServiceClientTracing.Enter(_invocationId, this, "GetProperties", tracingParameters);
            }
            // Construct URL
            var _baseUrl = Client.BaseUri;
            var _url = _baseUrl + (_baseUrl.EndsWith("/") ? "" : "/") + "{container}/{blob}";
            _url = _url.Replace("{accountName}", accountName);
            _url = _url.Replace("{container}", System.Uri.EscapeDataString(container));
            _url = _url.Replace("{blob}", System.Uri.EscapeDataString(blob));
            List<string> _queryParameters = new List<string>();
            if (snapshot != null)
            {
                _queryParameters.Add(string.Format("snapshot={0}", System.Uri.EscapeDataString(SafeJsonConvert.SerializeObject(snapshot, new DateTimeRfc1123JsonConverter()).Trim('"'))));
            }
            if (timeout != null)
            {
                _queryParameters.Add(string.Format("timeout={0}", System.Uri.EscapeDataString(SafeJsonConvert.SerializeObject(timeout, Client.SerializationSettings).Trim('"'))));
            }
            if (_queryParameters.Count > 0)
            {
                _url += (_url.Contains("?") ? "&" : "?") + string.Join("&", _queryParameters);
            }
            // Create HTTP transport objects
            var _httpRequest = new System.Net.Http.HttpRequestMessage();
            System.Net.Http.HttpResponseMessage _httpResponse = null;
            _httpRequest.Method = new System.Net.Http.HttpMethod("HEAD");
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
            if (ifMatches != null)
            {
                if (_httpRequest.Headers.Contains("If-Match"))
                {
                    _httpRequest.Headers.Remove("If-Match");
                }
                _httpRequest.Headers.TryAddWithoutValidation("If-Match", ifMatches);
            }
            if (ifNoneMatch != null)
            {
                if (_httpRequest.Headers.Contains("If-None-Match"))
                {
                    _httpRequest.Headers.Remove("If-None-Match");
                }
                _httpRequest.Headers.TryAddWithoutValidation("If-None-Match", ifNoneMatch);
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
            _httpResponse = await Client.HttpClient.SendAsync(_httpRequest, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
            if (_shouldTrace)
            {
                ServiceClientTracing.ReceiveResponse(_invocationId, _httpResponse);
            }
            HttpStatusCode _statusCode = _httpResponse.StatusCode;
            cancellationToken.ThrowIfCancellationRequested();
            string _responseContent = null;
            if ((int)_statusCode != 200)
            {
                var ex = new ErrorException(string.Format("Operation returned an invalid status code '{0}'", _statusCode));
                try
                {
                    _responseContent = await _httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                    Error _errorBody =  SafeJsonConvert.DeserializeObject<Error>(_responseContent, Client.DeserializationSettings);
                    if (_errorBody != null)
                    {
                        ex.Body = _errorBody;
                    }
                }
                catch (JsonException)
                {
                    // Ignore the exception
                }
                ex.Request = new HttpRequestMessageWrapper(_httpRequest, _requestContent);
                ex.Response = new HttpResponseMessageWrapper(_httpResponse, _responseContent);
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
            var _result = new AzureOperationHeaderResponse<BlobsGetPropertiesHeaders>();
            _result.Request = _httpRequest;
            _result.Response = _httpResponse;
            if (_httpResponse.Headers.Contains("x-ms-request-id"))
            {
                _result.RequestId = _httpResponse.Headers.GetValues("x-ms-request-id").FirstOrDefault();
            }
            try
            {
                _result.Headers = _httpResponse.GetHeadersAsJson().ToObject<BlobsGetPropertiesHeaders>(JsonSerializer.Create(Client.DeserializationSettings));
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
        /// The Delete Blob operation marks the specified blob or snapshot for
        /// deletion. The blob is later deleted during garbage collection. Note that in
        /// order to delete a blob, you must delete all of its snapshots. You can
        /// delete both at the same time with the Delete Blob operation.
        /// </summary>
        /// <param name='accountName'>
        /// The Azure storage account to use.
        /// </param>
        /// <param name='container'>
        /// The container name.
        /// </param>
        /// <param name='blob'>
        /// The blob name.
        /// </param>
        /// <param name='snapshot'>
        /// The snapshot parameter is an opaque DateTime value that, when present,
        /// specifies the blob snapshot to retrieve. For more information on working
        /// with blob snapshots, see &lt;a
        /// href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/creating-a-snapshot-of-a-blob"&gt;Creating
        /// a Snapshot of a Blob.&lt;/a&gt;
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
        /// <param name='deleteSnapshots'>
        /// Required if the blob has associated snapshots. Specify one of the following
        /// two options: include: Delete the base blob and all of its snapshots. only:
        /// Delete only the blob's snapshots and not the blob itself. Possible values
        /// include: 'include', 'only'
        /// </param>
        /// <param name='ifModifiedSince'>
        /// Specify this header value to operate only on a blob if it has been modified
        /// since the specified date/time.
        /// </param>
        /// <param name='ifUnmodifiedSince'>
        /// Specify this header value to operate only on a blob if it has not been
        /// modified since the specified date/time.
        /// </param>
        /// <param name='ifMatches'>
        /// Specify an ETag value to operate only on blobs with a matching value.
        /// </param>
        /// <param name='ifNoneMatch'>
        /// Specify an ETag value to operate only on blobs without a matching value.
        /// </param>
        /// <param name='customHeaders'>
        /// Headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        /// <exception cref="ErrorException">
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
        public async Task<AzureOperationHeaderResponse<BlobsDeleteHeaders>> DeleteWithHttpMessagesAsync(string accountName, string container, string blob, System.DateTime? snapshot = default(System.DateTime?), int? timeout = default(int?), string leaseId = default(string), DeleteSnapshotsOption? deleteSnapshots = default(DeleteSnapshotsOption?), System.DateTime? ifModifiedSince = default(System.DateTime?), System.DateTime? ifUnmodifiedSince = default(System.DateTime?), string ifMatches = default(string), string ifNoneMatch = default(string), Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (accountName == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "accountName");
            }
            if (container == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "container");
            }
            if (blob == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "blob");
            }
            if (blob != null)
            {
                if (!System.Text.RegularExpressions.Regex.IsMatch(blob, "^(?!.*\\/$)^[\\s\\S]{1,1024}$"))
                {
                    throw new ValidationException(ValidationRules.Pattern, "blob", "^(?!.*\\/$)^[\\s\\S]{1,1024}$");
                }
            }
            if (timeout < 0)
            {
                throw new ValidationException(ValidationRules.InclusiveMinimum, "timeout", 0);
            }
            // Tracing
            bool _shouldTrace = ServiceClientTracing.IsEnabled;
            string _invocationId = null;
            if (_shouldTrace)
            {
                _invocationId = ServiceClientTracing.NextInvocationId.ToString();
                Dictionary<string, object> tracingParameters = new Dictionary<string, object>();
                tracingParameters.Add("accountName", accountName);
                tracingParameters.Add("container", container);
                tracingParameters.Add("blob", blob);
                tracingParameters.Add("snapshot", snapshot);
                tracingParameters.Add("timeout", timeout);
                tracingParameters.Add("leaseId", leaseId);
                tracingParameters.Add("deleteSnapshots", deleteSnapshots);
                tracingParameters.Add("ifModifiedSince", ifModifiedSince);
                tracingParameters.Add("ifUnmodifiedSince", ifUnmodifiedSince);
                tracingParameters.Add("ifMatches", ifMatches);
                tracingParameters.Add("ifNoneMatch", ifNoneMatch);
                tracingParameters.Add("cancellationToken", cancellationToken);
                ServiceClientTracing.Enter(_invocationId, this, "Delete", tracingParameters);
            }
            // Construct URL
            var _baseUrl = Client.BaseUri;
            var _url = _baseUrl + (_baseUrl.EndsWith("/") ? "" : "/") + "{container}/{blob}";
            _url = _url.Replace("{accountName}", accountName);
            _url = _url.Replace("{container}", System.Uri.EscapeDataString(container));
            _url = _url.Replace("{blob}", System.Uri.EscapeDataString(blob));
            List<string> _queryParameters = new List<string>();
            if (snapshot != null)
            {
                _queryParameters.Add(string.Format("snapshot={0}", System.Uri.EscapeDataString(SafeJsonConvert.SerializeObject(snapshot, new DateTimeRfc1123JsonConverter()).Trim('"'))));
            }
            if (timeout != null)
            {
                _queryParameters.Add(string.Format("timeout={0}", System.Uri.EscapeDataString(SafeJsonConvert.SerializeObject(timeout, Client.SerializationSettings).Trim('"'))));
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
            if (deleteSnapshots != null)
            {
                if (_httpRequest.Headers.Contains("x-ms-delete-snapshots"))
                {
                    _httpRequest.Headers.Remove("x-ms-delete-snapshots");
                }
                _httpRequest.Headers.TryAddWithoutValidation("x-ms-delete-snapshots", SafeJsonConvert.SerializeObject(deleteSnapshots, Client.SerializationSettings).Trim('"'));
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
            if (ifMatches != null)
            {
                if (_httpRequest.Headers.Contains("If-Match"))
                {
                    _httpRequest.Headers.Remove("If-Match");
                }
                _httpRequest.Headers.TryAddWithoutValidation("If-Match", ifMatches);
            }
            if (ifNoneMatch != null)
            {
                if (_httpRequest.Headers.Contains("If-None-Match"))
                {
                    _httpRequest.Headers.Remove("If-None-Match");
                }
                _httpRequest.Headers.TryAddWithoutValidation("If-None-Match", ifNoneMatch);
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
                var ex = new ErrorException(string.Format("Operation returned an invalid status code '{0}'", _statusCode));
                try
                {
                    _responseContent = await _httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                    Error _errorBody =  SafeJsonConvert.DeserializeObject<Error>(_responseContent, Client.DeserializationSettings);
                    if (_errorBody != null)
                    {
                        ex.Body = _errorBody;
                    }
                }
                catch (JsonException)
                {
                    // Ignore the exception
                }
                ex.Request = new HttpRequestMessageWrapper(_httpRequest, _requestContent);
                ex.Response = new HttpResponseMessageWrapper(_httpResponse, _responseContent);
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
            var _result = new AzureOperationHeaderResponse<BlobsDeleteHeaders>();
            _result.Request = _httpRequest;
            _result.Response = _httpResponse;
            if (_httpResponse.Headers.Contains("x-ms-request-id"))
            {
                _result.RequestId = _httpResponse.Headers.GetValues("x-ms-request-id").FirstOrDefault();
            }
            try
            {
                _result.Headers = _httpResponse.GetHeadersAsJson().ToObject<BlobsDeleteHeaders>(JsonSerializer.Create(Client.DeserializationSettings));
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
        /// The Put Blob operation creates a new block, page, or append blob, or
        /// updates the content of an existing block blob. Updating an existing block
        /// blob overwrites any existing metadata on the blob. Partial updates are not
        /// supported with Put Blob; the content of the existing blob is overwritten
        /// with the content of the new blob. To perform a partial update of the
        /// content of a block blob, use the Put Block List operation.
        /// </summary>
        /// <param name='accountName'>
        /// The Azure storage account to use.
        /// </param>
        /// <param name='container'>
        /// The container name.
        /// </param>
        /// <param name='blob'>
        /// The blob name.
        /// </param>
        /// <param name='blobType'>
        /// Specifies the type of blob to create: block blob, page blob, or append
        /// blob. Possible values include: 'BlockBlob', 'PageBlob', 'AppendBlob'
        /// </param>
        /// <param name='body'>
        /// Initial data
        /// </param>
        /// <param name='timeout'>
        /// The timeout parameter is expressed in seconds. For more information, see
        /// &lt;a
        /// href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations"&gt;Setting
        /// Timeouts for Blob Service Operations.&lt;/a&gt;
        /// </param>
        /// <param name='cacheControl'>
        /// Cache control for given resource
        /// </param>
        /// <param name='xMsBlobContentType'>
        /// Optional. Sets the blob's content type. If specified, this property is
        /// stored with the blob and returned with a read request.
        /// </param>
        /// <param name='xMsBlobContentEncoding'>
        /// Optional. Sets the blob's content encoding. If specified, this property is
        /// stored with the blob and returned with a read request.
        /// </param>
        /// <param name='xMsBlobContentLanguage'>
        /// Optional. Set the blob's content language. If specified, this property is
        /// stored with the blob and returned with a read request.
        /// </param>
        /// <param name='xMsBlobContentMd5'>
        /// Optional. An MD5 hash of the blob content. Note that this hash is not
        /// validated, as the hashes for the individual blocks were validated when each
        /// was uploaded.
        /// </param>
        /// <param name='xMsBlobCacheControl'>
        /// Optional. Sets the blob's cache control. If specified, this property is
        /// stored with the blob and returned with a read request.
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
        /// <param name='leaseId'>
        /// If specified, the operation only succeeds if the container's lease is
        /// active and matches this ID.
        /// </param>
        /// <param name='xMsBlobContentDisposition'>
        /// Optional. Sets the blob's Content-Disposition header.
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
        /// <param name='ifMatches'>
        /// Specify an ETag value to operate only on blobs with a matching value.
        /// </param>
        /// <param name='ifNoneMatch'>
        /// Specify an ETag value to operate only on blobs without a matching value.
        /// </param>
        /// <param name='xMsBlobContentLength'>
        /// This header specifies the maximum size for the page blob, up to 1 TB. The
        /// page blob size must be aligned to a 512-byte boundary.
        /// </param>
        /// <param name='blobSequenceNumber'>
        /// Set for page blobs only. The sequence number is a user-controlled value
        /// that you can use to track requests. The value of the sequence number must
        /// be between 0 and 2^63 - 1.
        /// </param>
        /// <param name='customHeaders'>
        /// Headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        /// <exception cref="ErrorException">
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
        public async Task<AzureOperationHeaderResponse<BlobsPutHeaders>> PutWithHttpMessagesAsync(string accountName, string container, string blob, BlobType blobType, Stream body, int? timeout = default(int?), string cacheControl = default(string), string xMsBlobContentType = default(string), string xMsBlobContentEncoding = default(string), string xMsBlobContentLanguage = default(string), string xMsBlobContentMd5 = default(string), string xMsBlobCacheControl = default(string), IDictionary<string, string> xMsMeta = default(IDictionary<string, string>), string leaseId = default(string), string xMsBlobContentDisposition = default(string), string origin = default(string), System.DateTime? ifModifiedSince = default(System.DateTime?), System.DateTime? ifUnmodifiedSince = default(System.DateTime?), string ifMatches = default(string), string ifNoneMatch = default(string), long? xMsBlobContentLength = default(long?), long? blobSequenceNumber = 0, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (accountName == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "accountName");
            }
            if (container == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "container");
            }
            if (blob == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "blob");
            }
            if (blob != null)
            {
                if (!System.Text.RegularExpressions.Regex.IsMatch(blob, "^(?!.*\\/$)^[\\s\\S]{1,1024}$"))
                {
                    throw new ValidationException(ValidationRules.Pattern, "blob", "^(?!.*\\/$)^[\\s\\S]{1,1024}$");
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
            if (body == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "body");
            }
            // Tracing
            bool _shouldTrace = ServiceClientTracing.IsEnabled;
            string _invocationId = null;
            if (_shouldTrace)
            {
                _invocationId = ServiceClientTracing.NextInvocationId.ToString();
                Dictionary<string, object> tracingParameters = new Dictionary<string, object>();
                tracingParameters.Add("accountName", accountName);
                tracingParameters.Add("container", container);
                tracingParameters.Add("blob", blob);
                tracingParameters.Add("timeout", timeout);
                tracingParameters.Add("cacheControl", cacheControl);
                tracingParameters.Add("xMsBlobContentType", xMsBlobContentType);
                tracingParameters.Add("xMsBlobContentEncoding", xMsBlobContentEncoding);
                tracingParameters.Add("xMsBlobContentLanguage", xMsBlobContentLanguage);
                tracingParameters.Add("xMsBlobContentMd5", xMsBlobContentMd5);
                tracingParameters.Add("xMsBlobCacheControl", xMsBlobCacheControl);
                tracingParameters.Add("blobType", blobType);
                tracingParameters.Add("xMsMeta", xMsMeta);
                tracingParameters.Add("leaseId", leaseId);
                tracingParameters.Add("xMsBlobContentDisposition", xMsBlobContentDisposition);
                tracingParameters.Add("origin", origin);
                tracingParameters.Add("ifModifiedSince", ifModifiedSince);
                tracingParameters.Add("ifUnmodifiedSince", ifUnmodifiedSince);
                tracingParameters.Add("ifMatches", ifMatches);
                tracingParameters.Add("ifNoneMatch", ifNoneMatch);
                tracingParameters.Add("xMsBlobContentLength", xMsBlobContentLength);
                tracingParameters.Add("blobSequenceNumber", blobSequenceNumber);
                tracingParameters.Add("body", body);
                tracingParameters.Add("cancellationToken", cancellationToken);
                ServiceClientTracing.Enter(_invocationId, this, "Put", tracingParameters);
            }
            // Construct URL
            var _baseUrl = Client.BaseUri;
            var _url = _baseUrl + (_baseUrl.EndsWith("/") ? "" : "/") + "{container}/{blob}";
            _url = _url.Replace("{accountName}", accountName);
            _url = _url.Replace("{container}", System.Uri.EscapeDataString(container));
            _url = _url.Replace("{blob}", System.Uri.EscapeDataString(blob));
            List<string> _queryParameters = new List<string>();
            if (timeout != null)
            {
                _queryParameters.Add(string.Format("timeout={0}", System.Uri.EscapeDataString(SafeJsonConvert.SerializeObject(timeout, Client.SerializationSettings).Trim('"'))));
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
            if (cacheControl != null)
            {
                if (_httpRequest.Headers.Contains("Cache-Control"))
                {
                    _httpRequest.Headers.Remove("Cache-Control");
                }
                _httpRequest.Headers.TryAddWithoutValidation("Cache-Control", cacheControl);
            }
            if (xMsBlobContentType != null)
            {
                if (_httpRequest.Headers.Contains("x-ms-blob-content-type"))
                {
                    _httpRequest.Headers.Remove("x-ms-blob-content-type");
                }
                _httpRequest.Headers.TryAddWithoutValidation("x-ms-blob-content-type", xMsBlobContentType);
            }
            if (xMsBlobContentEncoding != null)
            {
                if (_httpRequest.Headers.Contains("x-ms-blob-content-encoding"))
                {
                    _httpRequest.Headers.Remove("x-ms-blob-content-encoding");
                }
                _httpRequest.Headers.TryAddWithoutValidation("x-ms-blob-content-encoding", xMsBlobContentEncoding);
            }
            if (xMsBlobContentLanguage != null)
            {
                if (_httpRequest.Headers.Contains("x-ms-blob-content-language"))
                {
                    _httpRequest.Headers.Remove("x-ms-blob-content-language");
                }
                _httpRequest.Headers.TryAddWithoutValidation("x-ms-blob-content-language", xMsBlobContentLanguage);
            }
            if (xMsBlobContentMd5 != null)
            {
                if (_httpRequest.Headers.Contains("x-ms-blob-content-md5"))
                {
                    _httpRequest.Headers.Remove("x-ms-blob-content-md5");
                }
                _httpRequest.Headers.TryAddWithoutValidation("x-ms-blob-content-md5", xMsBlobContentMd5);
            }
            if (xMsBlobCacheControl != null)
            {
                if (_httpRequest.Headers.Contains("x-ms-blob-cache-control"))
                {
                    _httpRequest.Headers.Remove("x-ms-blob-cache-control");
                }
                _httpRequest.Headers.TryAddWithoutValidation("x-ms-blob-cache-control", xMsBlobCacheControl);
            }
            if (_httpRequest.Headers.Contains("x-ms-blob-type"))
            {
                _httpRequest.Headers.Remove("x-ms-blob-type");
            }
            _httpRequest.Headers.TryAddWithoutValidation("x-ms-blob-type", SafeJsonConvert.SerializeObject(blobType, Client.SerializationSettings).Trim('"'));
            if (leaseId != null)
            {
                if (_httpRequest.Headers.Contains("x-ms-lease-id"))
                {
                    _httpRequest.Headers.Remove("x-ms-lease-id");
                }
                _httpRequest.Headers.TryAddWithoutValidation("x-ms-lease-id", leaseId);
            }
            if (xMsBlobContentDisposition != null)
            {
                if (_httpRequest.Headers.Contains("x-ms-blob-content-disposition"))
                {
                    _httpRequest.Headers.Remove("x-ms-blob-content-disposition");
                }
                _httpRequest.Headers.TryAddWithoutValidation("x-ms-blob-content-disposition", xMsBlobContentDisposition);
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
            if (ifMatches != null)
            {
                if (_httpRequest.Headers.Contains("If-Match"))
                {
                    _httpRequest.Headers.Remove("If-Match");
                }
                _httpRequest.Headers.TryAddWithoutValidation("If-Match", ifMatches);
            }
            if (ifNoneMatch != null)
            {
                if (_httpRequest.Headers.Contains("If-None-Match"))
                {
                    _httpRequest.Headers.Remove("If-None-Match");
                }
                _httpRequest.Headers.TryAddWithoutValidation("If-None-Match", ifNoneMatch);
            }
            if (xMsBlobContentLength != null)
            {
                if (_httpRequest.Headers.Contains("x-ms-blob-content-length"))
                {
                    _httpRequest.Headers.Remove("x-ms-blob-content-length");
                }
                _httpRequest.Headers.TryAddWithoutValidation("x-ms-blob-content-length", SafeJsonConvert.SerializeObject(xMsBlobContentLength, Client.SerializationSettings).Trim('"'));
            }
            if (blobSequenceNumber != null)
            {
                if (_httpRequest.Headers.Contains("x-ms-sequence-number"))
                {
                    _httpRequest.Headers.Remove("x-ms-sequence-number");
                }
                _httpRequest.Headers.TryAddWithoutValidation("x-ms-sequence-number", SafeJsonConvert.SerializeObject(blobSequenceNumber, Client.SerializationSettings).Trim('"'));
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
            if(body == null)
            {
              throw new System.ArgumentNullException("body");
            }
            if (body != null && body != Stream.Null)
            {
              _httpRequest.Content = new System.Net.Http.StreamContent(body);
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
            if ((int)_statusCode != 201)
            {
                var ex = new ErrorException(string.Format("Operation returned an invalid status code '{0}'", _statusCode));
                try
                {
                    _responseContent = await _httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                    Error _errorBody =  SafeJsonConvert.DeserializeObject<Error>(_responseContent, Client.DeserializationSettings);
                    if (_errorBody != null)
                    {
                        ex.Body = _errorBody;
                    }
                }
                catch (JsonException)
                {
                    // Ignore the exception
                }
                ex.Request = new HttpRequestMessageWrapper(_httpRequest, _requestContent);
                ex.Response = new HttpResponseMessageWrapper(_httpResponse, _responseContent);
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
            var _result = new AzureOperationHeaderResponse<BlobsPutHeaders>();
            _result.Request = _httpRequest;
            _result.Response = _httpResponse;
            if (_httpResponse.Headers.Contains("x-ms-request-id"))
            {
                _result.RequestId = _httpResponse.Headers.GetValues("x-ms-request-id").FirstOrDefault();
            }
            try
            {
                _result.Headers = _httpResponse.GetHeadersAsJson().ToObject<BlobsPutHeaders>(JsonSerializer.Create(Client.DeserializationSettings));
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
        /// The Set Blob Properties operation sets system properties on the blob
        /// </summary>
        /// <param name='accountName'>
        /// The Azure storage account to use.
        /// </param>
        /// <param name='container'>
        /// The container name.
        /// </param>
        /// <param name='blob'>
        /// The blob name.
        /// </param>
        /// <param name='timeout'>
        /// The timeout parameter is expressed in seconds. For more information, see
        /// &lt;a
        /// href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations"&gt;Setting
        /// Timeouts for Blob Service Operations.&lt;/a&gt;
        /// </param>
        /// <param name='xMsBlobCacheControl'>
        /// Optional. Sets the blob's cache control. If specified, this property is
        /// stored with the blob and returned with a read request.
        /// </param>
        /// <param name='xMsBlobContentType'>
        /// Optional. Sets the blob's content type. If specified, this property is
        /// stored with the blob and returned with a read request.
        /// </param>
        /// <param name='xMsBlobContentMd5'>
        /// Optional. An MD5 hash of the blob content. Note that this hash is not
        /// validated, as the hashes for the individual blocks were validated when each
        /// was uploaded.
        /// </param>
        /// <param name='xMsBlobContentEncoding'>
        /// Optional. Sets the blob's content encoding. If specified, this property is
        /// stored with the blob and returned with a read request.
        /// </param>
        /// <param name='xMsBlobContentLanguage'>
        /// Optional. Set the blob's content language. If specified, this property is
        /// stored with the blob and returned with a read request.
        /// </param>
        /// <param name='leaseId'>
        /// If specified, the operation only succeeds if the container's lease is
        /// active and matches this ID.
        /// </param>
        /// <param name='xMsBlobContentDisposition'>
        /// Optional. Sets the blob's Content-Disposition header.
        /// </param>
        /// <param name='origin'>
        /// Specifies the origin from which the request is issued. The presence of this
        /// header results in cross-origin resource sharing (CORS) headers on the
        /// response.
        /// </param>
        /// <param name='xMsBlobContentLength'>
        /// This header specifies the maximum size for the page blob, up to 1 TB. The
        /// page blob size must be aligned to a 512-byte boundary.
        /// </param>
        /// <param name='sequenceNumberAction'>
        /// Required if the x-ms-blob-sequence-number header is set for the request.
        /// This property applies to page blobs only. This property indicates how the
        /// service should modify the blob's sequence number. Possible values include:
        /// 'max', 'update', 'increment'
        /// </param>
        /// <param name='blobSequenceNumber'>
        /// Set for page blobs only. The sequence number is a user-controlled value
        /// that you can use to track requests. The value of the sequence number must
        /// be between 0 and 2^63 - 1.
        /// </param>
        /// <param name='customHeaders'>
        /// Headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        /// <exception cref="ErrorException">
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
        public async Task<AzureOperationHeaderResponse<BlobsSetPropertiesHeaders>> SetPropertiesWithHttpMessagesAsync(string accountName, string container, string blob, int? timeout = default(int?), string xMsBlobCacheControl = default(string), string xMsBlobContentType = default(string), string xMsBlobContentMd5 = default(string), string xMsBlobContentEncoding = default(string), string xMsBlobContentLanguage = default(string), string leaseId = default(string), string xMsBlobContentDisposition = default(string), string origin = default(string), long? xMsBlobContentLength = default(long?), SequenceNumberAction? sequenceNumberAction = default(SequenceNumberAction?), long? blobSequenceNumber = 0, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (accountName == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "accountName");
            }
            if (container == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "container");
            }
            if (blob == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "blob");
            }
            if (blob != null)
            {
                if (!System.Text.RegularExpressions.Regex.IsMatch(blob, "^(?!.*\\/$)^[\\s\\S]{1,1024}$"))
                {
                    throw new ValidationException(ValidationRules.Pattern, "blob", "^(?!.*\\/$)^[\\s\\S]{1,1024}$");
                }
            }
            if (timeout < 0)
            {
                throw new ValidationException(ValidationRules.InclusiveMinimum, "timeout", 0);
            }
            string comp = "properties";
            // Tracing
            bool _shouldTrace = ServiceClientTracing.IsEnabled;
            string _invocationId = null;
            if (_shouldTrace)
            {
                _invocationId = ServiceClientTracing.NextInvocationId.ToString();
                Dictionary<string, object> tracingParameters = new Dictionary<string, object>();
                tracingParameters.Add("accountName", accountName);
                tracingParameters.Add("container", container);
                tracingParameters.Add("blob", blob);
                tracingParameters.Add("timeout", timeout);
                tracingParameters.Add("xMsBlobCacheControl", xMsBlobCacheControl);
                tracingParameters.Add("xMsBlobContentType", xMsBlobContentType);
                tracingParameters.Add("xMsBlobContentMd5", xMsBlobContentMd5);
                tracingParameters.Add("xMsBlobContentEncoding", xMsBlobContentEncoding);
                tracingParameters.Add("xMsBlobContentLanguage", xMsBlobContentLanguage);
                tracingParameters.Add("leaseId", leaseId);
                tracingParameters.Add("xMsBlobContentDisposition", xMsBlobContentDisposition);
                tracingParameters.Add("origin", origin);
                tracingParameters.Add("xMsBlobContentLength", xMsBlobContentLength);
                tracingParameters.Add("sequenceNumberAction", sequenceNumberAction);
                tracingParameters.Add("blobSequenceNumber", blobSequenceNumber);
                tracingParameters.Add("comp", comp);
                tracingParameters.Add("cancellationToken", cancellationToken);
                ServiceClientTracing.Enter(_invocationId, this, "SetProperties", tracingParameters);
            }
            // Construct URL
            var _baseUrl = Client.BaseUri;
            var _url = _baseUrl + (_baseUrl.EndsWith("/") ? "" : "/") + "{container}/{blob}";
            _url = _url.Replace("{accountName}", accountName);
            _url = _url.Replace("{container}", System.Uri.EscapeDataString(container));
            _url = _url.Replace("{blob}", System.Uri.EscapeDataString(blob));
            List<string> _queryParameters = new List<string>();
            if (timeout != null)
            {
                _queryParameters.Add(string.Format("timeout={0}", System.Uri.EscapeDataString(SafeJsonConvert.SerializeObject(timeout, Client.SerializationSettings).Trim('"'))));
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
            if (xMsBlobCacheControl != null)
            {
                if (_httpRequest.Headers.Contains("x-ms-blob-cache-control"))
                {
                    _httpRequest.Headers.Remove("x-ms-blob-cache-control");
                }
                _httpRequest.Headers.TryAddWithoutValidation("x-ms-blob-cache-control", xMsBlobCacheControl);
            }
            if (xMsBlobContentType != null)
            {
                if (_httpRequest.Headers.Contains("x-ms-blob-content-type"))
                {
                    _httpRequest.Headers.Remove("x-ms-blob-content-type");
                }
                _httpRequest.Headers.TryAddWithoutValidation("x-ms-blob-content-type", xMsBlobContentType);
            }
            if (xMsBlobContentMd5 != null)
            {
                if (_httpRequest.Headers.Contains("x-ms-blob-content-md5"))
                {
                    _httpRequest.Headers.Remove("x-ms-blob-content-md5");
                }
                _httpRequest.Headers.TryAddWithoutValidation("x-ms-blob-content-md5", xMsBlobContentMd5);
            }
            if (xMsBlobContentEncoding != null)
            {
                if (_httpRequest.Headers.Contains("x-ms-blob-content-encoding"))
                {
                    _httpRequest.Headers.Remove("x-ms-blob-content-encoding");
                }
                _httpRequest.Headers.TryAddWithoutValidation("x-ms-blob-content-encoding", xMsBlobContentEncoding);
            }
            if (xMsBlobContentLanguage != null)
            {
                if (_httpRequest.Headers.Contains("x-ms-blob-content-language"))
                {
                    _httpRequest.Headers.Remove("x-ms-blob-content-language");
                }
                _httpRequest.Headers.TryAddWithoutValidation("x-ms-blob-content-language", xMsBlobContentLanguage);
            }
            if (leaseId != null)
            {
                if (_httpRequest.Headers.Contains("x-ms-lease-id"))
                {
                    _httpRequest.Headers.Remove("x-ms-lease-id");
                }
                _httpRequest.Headers.TryAddWithoutValidation("x-ms-lease-id", leaseId);
            }
            if (xMsBlobContentDisposition != null)
            {
                if (_httpRequest.Headers.Contains("x-ms-blob-content-disposition"))
                {
                    _httpRequest.Headers.Remove("x-ms-blob-content-disposition");
                }
                _httpRequest.Headers.TryAddWithoutValidation("x-ms-blob-content-disposition", xMsBlobContentDisposition);
            }
            if (origin != null)
            {
                if (_httpRequest.Headers.Contains("Origin"))
                {
                    _httpRequest.Headers.Remove("Origin");
                }
                _httpRequest.Headers.TryAddWithoutValidation("Origin", origin);
            }
            if (xMsBlobContentLength != null)
            {
                if (_httpRequest.Headers.Contains("x-ms-blob-content-length"))
                {
                    _httpRequest.Headers.Remove("x-ms-blob-content-length");
                }
                _httpRequest.Headers.TryAddWithoutValidation("x-ms-blob-content-length", SafeJsonConvert.SerializeObject(xMsBlobContentLength, Client.SerializationSettings).Trim('"'));
            }
            if (sequenceNumberAction != null)
            {
                if (_httpRequest.Headers.Contains("x-ms-sequence-number-action"))
                {
                    _httpRequest.Headers.Remove("x-ms-sequence-number-action");
                }
                _httpRequest.Headers.TryAddWithoutValidation("x-ms-sequence-number-action", SafeJsonConvert.SerializeObject(sequenceNumberAction, Client.SerializationSettings).Trim('"'));
            }
            if (blobSequenceNumber != null)
            {
                if (_httpRequest.Headers.Contains("x-ms-sequence-number"))
                {
                    _httpRequest.Headers.Remove("x-ms-sequence-number");
                }
                _httpRequest.Headers.TryAddWithoutValidation("x-ms-sequence-number", SafeJsonConvert.SerializeObject(blobSequenceNumber, Client.SerializationSettings).Trim('"'));
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
                var ex = new ErrorException(string.Format("Operation returned an invalid status code '{0}'", _statusCode));
                try
                {
                    _responseContent = await _httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                    Error _errorBody =  SafeJsonConvert.DeserializeObject<Error>(_responseContent, Client.DeserializationSettings);
                    if (_errorBody != null)
                    {
                        ex.Body = _errorBody;
                    }
                }
                catch (JsonException)
                {
                    // Ignore the exception
                }
                ex.Request = new HttpRequestMessageWrapper(_httpRequest, _requestContent);
                ex.Response = new HttpResponseMessageWrapper(_httpResponse, _responseContent);
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
            var _result = new AzureOperationHeaderResponse<BlobsSetPropertiesHeaders>();
            _result.Request = _httpRequest;
            _result.Response = _httpResponse;
            if (_httpResponse.Headers.Contains("x-ms-request-id"))
            {
                _result.RequestId = _httpResponse.Headers.GetValues("x-ms-request-id").FirstOrDefault();
            }
            try
            {
                _result.Headers = _httpResponse.GetHeadersAsJson().ToObject<BlobsSetPropertiesHeaders>(JsonSerializer.Create(Client.DeserializationSettings));
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
        /// The Get Blob Metadata operation returns all user-defined metadata for the
        /// specified blob or snapshot
        /// </summary>
        /// <param name='accountName'>
        /// The Azure storage account to use.
        /// </param>
        /// <param name='container'>
        /// The container name.
        /// </param>
        /// <param name='blob'>
        /// The blob name.
        /// </param>
        /// <param name='snapshot'>
        /// The snapshot parameter is an opaque DateTime value that, when present,
        /// specifies the blob snapshot to retrieve. For more information on working
        /// with blob snapshots, see &lt;a
        /// href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/creating-a-snapshot-of-a-blob"&gt;Creating
        /// a Snapshot of a Blob.&lt;/a&gt;
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
        /// <param name='ifMatches'>
        /// Specify an ETag value to operate only on blobs with a matching value.
        /// </param>
        /// <param name='ifNoneMatch'>
        /// Specify an ETag value to operate only on blobs without a matching value.
        /// </param>
        /// <param name='customHeaders'>
        /// Headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        /// <exception cref="ErrorException">
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
        public async Task<AzureOperationHeaderResponse<BlobsGetMetadataHeaders>> GetMetadataWithHttpMessagesAsync(string accountName, string container, string blob, System.DateTime? snapshot = default(System.DateTime?), int? timeout = default(int?), string leaseId = default(string), System.DateTime? ifModifiedSince = default(System.DateTime?), System.DateTime? ifUnmodifiedSince = default(System.DateTime?), string ifMatches = default(string), string ifNoneMatch = default(string), Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (accountName == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "accountName");
            }
            if (container == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "container");
            }
            if (blob == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "blob");
            }
            if (blob != null)
            {
                if (!System.Text.RegularExpressions.Regex.IsMatch(blob, "^(?!.*\\/$)^[\\s\\S]{1,1024}$"))
                {
                    throw new ValidationException(ValidationRules.Pattern, "blob", "^(?!.*\\/$)^[\\s\\S]{1,1024}$");
                }
            }
            if (timeout < 0)
            {
                throw new ValidationException(ValidationRules.InclusiveMinimum, "timeout", 0);
            }
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
                tracingParameters.Add("blob", blob);
                tracingParameters.Add("snapshot", snapshot);
                tracingParameters.Add("timeout", timeout);
                tracingParameters.Add("leaseId", leaseId);
                tracingParameters.Add("ifModifiedSince", ifModifiedSince);
                tracingParameters.Add("ifUnmodifiedSince", ifUnmodifiedSince);
                tracingParameters.Add("ifMatches", ifMatches);
                tracingParameters.Add("ifNoneMatch", ifNoneMatch);
                tracingParameters.Add("comp", comp);
                tracingParameters.Add("cancellationToken", cancellationToken);
                ServiceClientTracing.Enter(_invocationId, this, "GetMetadata", tracingParameters);
            }
            // Construct URL
            var _baseUrl = Client.BaseUri;
            var _url = _baseUrl + (_baseUrl.EndsWith("/") ? "" : "/") + "{container}/{blob}";
            _url = _url.Replace("{accountName}", accountName);
            _url = _url.Replace("{container}", System.Uri.EscapeDataString(container));
            _url = _url.Replace("{blob}", System.Uri.EscapeDataString(blob));
            List<string> _queryParameters = new List<string>();
            if (snapshot != null)
            {
                _queryParameters.Add(string.Format("snapshot={0}", System.Uri.EscapeDataString(SafeJsonConvert.SerializeObject(snapshot, new DateTimeRfc1123JsonConverter()).Trim('"'))));
            }
            if (timeout != null)
            {
                _queryParameters.Add(string.Format("timeout={0}", System.Uri.EscapeDataString(SafeJsonConvert.SerializeObject(timeout, Client.SerializationSettings).Trim('"'))));
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
            if (ifMatches != null)
            {
                if (_httpRequest.Headers.Contains("If-Match"))
                {
                    _httpRequest.Headers.Remove("If-Match");
                }
                _httpRequest.Headers.TryAddWithoutValidation("If-Match", ifMatches);
            }
            if (ifNoneMatch != null)
            {
                if (_httpRequest.Headers.Contains("If-None-Match"))
                {
                    _httpRequest.Headers.Remove("If-None-Match");
                }
                _httpRequest.Headers.TryAddWithoutValidation("If-None-Match", ifNoneMatch);
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
                var ex = new ErrorException(string.Format("Operation returned an invalid status code '{0}'", _statusCode));
                try
                {
                    _responseContent = await _httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                    Error _errorBody =  SafeJsonConvert.DeserializeObject<Error>(_responseContent, Client.DeserializationSettings);
                    if (_errorBody != null)
                    {
                        ex.Body = _errorBody;
                    }
                }
                catch (JsonException)
                {
                    // Ignore the exception
                }
                ex.Request = new HttpRequestMessageWrapper(_httpRequest, _requestContent);
                ex.Response = new HttpResponseMessageWrapper(_httpResponse, _responseContent);
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
            var _result = new AzureOperationHeaderResponse<BlobsGetMetadataHeaders>();
            _result.Request = _httpRequest;
            _result.Response = _httpResponse;
            if (_httpResponse.Headers.Contains("x-ms-request-id"))
            {
                _result.RequestId = _httpResponse.Headers.GetValues("x-ms-request-id").FirstOrDefault();
            }
            try
            {
                _result.Headers = _httpResponse.GetHeadersAsJson().ToObject<BlobsGetMetadataHeaders>(JsonSerializer.Create(Client.DeserializationSettings));
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
        /// The Set Blob Metadata operation sets user-defined metadata for the
        /// specified blob as one or more name-value pairs
        /// </summary>
        /// <param name='accountName'>
        /// The Azure storage account to use.
        /// </param>
        /// <param name='container'>
        /// The container name.
        /// </param>
        /// <param name='blob'>
        /// The blob name.
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
        /// <exception cref="ErrorException">
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
        public async Task<AzureOperationHeaderResponse<BlobsSetMetadataHeaders>> SetMetadataWithHttpMessagesAsync(string accountName, string container, string blob, int? timeout = default(int?), IDictionary<string, string> xMsMeta = default(IDictionary<string, string>), string leaseId = default(string), Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (accountName == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "accountName");
            }
            if (container == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "container");
            }
            if (blob == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "blob");
            }
            if (blob != null)
            {
                if (!System.Text.RegularExpressions.Regex.IsMatch(blob, "^(?!.*\\/$)^[\\s\\S]{1,1024}$"))
                {
                    throw new ValidationException(ValidationRules.Pattern, "blob", "^(?!.*\\/$)^[\\s\\S]{1,1024}$");
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
                tracingParameters.Add("blob", blob);
                tracingParameters.Add("timeout", timeout);
                tracingParameters.Add("xMsMeta", xMsMeta);
                tracingParameters.Add("leaseId", leaseId);
                tracingParameters.Add("comp", comp);
                tracingParameters.Add("cancellationToken", cancellationToken);
                ServiceClientTracing.Enter(_invocationId, this, "SetMetadata", tracingParameters);
            }
            // Construct URL
            var _baseUrl = Client.BaseUri;
            var _url = _baseUrl + (_baseUrl.EndsWith("/") ? "" : "/") + "{container}/{blob}";
            _url = _url.Replace("{accountName}", accountName);
            _url = _url.Replace("{container}", System.Uri.EscapeDataString(container));
            _url = _url.Replace("{blob}", System.Uri.EscapeDataString(blob));
            List<string> _queryParameters = new List<string>();
            if (timeout != null)
            {
                _queryParameters.Add(string.Format("timeout={0}", System.Uri.EscapeDataString(SafeJsonConvert.SerializeObject(timeout, Client.SerializationSettings).Trim('"'))));
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
                var ex = new ErrorException(string.Format("Operation returned an invalid status code '{0}'", _statusCode));
                try
                {
                    _responseContent = await _httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                    Error _errorBody =  SafeJsonConvert.DeserializeObject<Error>(_responseContent, Client.DeserializationSettings);
                    if (_errorBody != null)
                    {
                        ex.Body = _errorBody;
                    }
                }
                catch (JsonException)
                {
                    // Ignore the exception
                }
                ex.Request = new HttpRequestMessageWrapper(_httpRequest, _requestContent);
                ex.Response = new HttpResponseMessageWrapper(_httpResponse, _responseContent);
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
            var _result = new AzureOperationHeaderResponse<BlobsSetMetadataHeaders>();
            _result.Request = _httpRequest;
            _result.Response = _httpResponse;
            if (_httpResponse.Headers.Contains("x-ms-request-id"))
            {
                _result.RequestId = _httpResponse.Headers.GetValues("x-ms-request-id").FirstOrDefault();
            }
            try
            {
                _result.Headers = _httpResponse.GetHeadersAsJson().ToObject<BlobsSetMetadataHeaders>(JsonSerializer.Create(Client.DeserializationSettings));
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
        /// The Lease Blob operation establishes and manages a lock on a blob for write
        /// and delete operations
        /// </summary>
        /// <param name='accountName'>
        /// The Azure storage account to use.
        /// </param>
        /// <param name='container'>
        /// The container name.
        /// </param>
        /// <param name='blob'>
        /// The blob name.
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
        /// <param name='ifMatches'>
        /// Specify an ETag value to operate only on blobs with a matching value.
        /// </param>
        /// <param name='ifNoneMatch'>
        /// Specify an ETag value to operate only on blobs without a matching value.
        /// </param>
        /// <param name='customHeaders'>
        /// Headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        /// <exception cref="ErrorException">
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
        public async Task<AzureOperationHeaderResponse<BlobsLeaseHeaders>> LeaseWithHttpMessagesAsync(string accountName, string container, string blob, string action, int? timeout = default(int?), string leaseId = default(string), int? breakPeriod = default(int?), int? duration = default(int?), string proposedLeaseId = default(string), string origin = default(string), System.DateTime? ifModifiedSince = default(System.DateTime?), System.DateTime? ifUnmodifiedSince = default(System.DateTime?), string ifMatches = default(string), string ifNoneMatch = default(string), Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (accountName == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "accountName");
            }
            if (container == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "container");
            }
            if (blob == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "blob");
            }
            if (blob != null)
            {
                if (!System.Text.RegularExpressions.Regex.IsMatch(blob, "^(?!.*\\/$)^[\\s\\S]{1,1024}$"))
                {
                    throw new ValidationException(ValidationRules.Pattern, "blob", "^(?!.*\\/$)^[\\s\\S]{1,1024}$");
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
            // Tracing
            bool _shouldTrace = ServiceClientTracing.IsEnabled;
            string _invocationId = null;
            if (_shouldTrace)
            {
                _invocationId = ServiceClientTracing.NextInvocationId.ToString();
                Dictionary<string, object> tracingParameters = new Dictionary<string, object>();
                tracingParameters.Add("accountName", accountName);
                tracingParameters.Add("container", container);
                tracingParameters.Add("blob", blob);
                tracingParameters.Add("timeout", timeout);
                tracingParameters.Add("leaseId", leaseId);
                tracingParameters.Add("action", action);
                tracingParameters.Add("breakPeriod", breakPeriod);
                tracingParameters.Add("duration", duration);
                tracingParameters.Add("proposedLeaseId", proposedLeaseId);
                tracingParameters.Add("origin", origin);
                tracingParameters.Add("ifModifiedSince", ifModifiedSince);
                tracingParameters.Add("ifUnmodifiedSince", ifUnmodifiedSince);
                tracingParameters.Add("ifMatches", ifMatches);
                tracingParameters.Add("ifNoneMatch", ifNoneMatch);
                tracingParameters.Add("comp", comp);
                tracingParameters.Add("cancellationToken", cancellationToken);
                ServiceClientTracing.Enter(_invocationId, this, "Lease", tracingParameters);
            }
            // Construct URL
            var _baseUrl = Client.BaseUri;
            var _url = _baseUrl + (_baseUrl.EndsWith("/") ? "" : "/") + "{container}/{blob}";
            _url = _url.Replace("{accountName}", accountName);
            _url = _url.Replace("{container}", System.Uri.EscapeDataString(container));
            _url = _url.Replace("{blob}", System.Uri.EscapeDataString(blob));
            List<string> _queryParameters = new List<string>();
            if (timeout != null)
            {
                _queryParameters.Add(string.Format("timeout={0}", System.Uri.EscapeDataString(SafeJsonConvert.SerializeObject(timeout, Client.SerializationSettings).Trim('"'))));
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
            if (ifMatches != null)
            {
                if (_httpRequest.Headers.Contains("If-Match"))
                {
                    _httpRequest.Headers.Remove("If-Match");
                }
                _httpRequest.Headers.TryAddWithoutValidation("If-Match", ifMatches);
            }
            if (ifNoneMatch != null)
            {
                if (_httpRequest.Headers.Contains("If-None-Match"))
                {
                    _httpRequest.Headers.Remove("If-None-Match");
                }
                _httpRequest.Headers.TryAddWithoutValidation("If-None-Match", ifNoneMatch);
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
                var ex = new ErrorException(string.Format("Operation returned an invalid status code '{0}'", _statusCode));
                try
                {
                    _responseContent = await _httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                    Error _errorBody =  SafeJsonConvert.DeserializeObject<Error>(_responseContent, Client.DeserializationSettings);
                    if (_errorBody != null)
                    {
                        ex.Body = _errorBody;
                    }
                }
                catch (JsonException)
                {
                    // Ignore the exception
                }
                ex.Request = new HttpRequestMessageWrapper(_httpRequest, _requestContent);
                ex.Response = new HttpResponseMessageWrapper(_httpResponse, _responseContent);
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
            var _result = new AzureOperationHeaderResponse<BlobsLeaseHeaders>();
            _result.Request = _httpRequest;
            _result.Response = _httpResponse;
            if (_httpResponse.Headers.Contains("x-ms-request-id"))
            {
                _result.RequestId = _httpResponse.Headers.GetValues("x-ms-request-id").FirstOrDefault();
            }
            try
            {
                _result.Headers = _httpResponse.GetHeadersAsJson().ToObject<BlobsLeaseHeaders>(JsonSerializer.Create(Client.DeserializationSettings));
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
        /// The Snapshot Blob operation creates a read-only snapshot of a blob
        /// </summary>
        /// <param name='accountName'>
        /// The Azure storage account to use.
        /// </param>
        /// <param name='container'>
        /// The container name.
        /// </param>
        /// <param name='blob'>
        /// The blob name.
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
        /// <param name='ifModifiedSince'>
        /// Specify this header value to operate only on a blob if it has been modified
        /// since the specified date/time.
        /// </param>
        /// <param name='ifUnmodifiedSince'>
        /// Specify this header value to operate only on a blob if it has not been
        /// modified since the specified date/time.
        /// </param>
        /// <param name='ifMatches'>
        /// Specify an ETag value to operate only on blobs with a matching value.
        /// </param>
        /// <param name='ifNoneMatch'>
        /// Specify an ETag value to operate only on blobs without a matching value.
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
        /// <exception cref="ErrorException">
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
        public async Task<AzureOperationHeaderResponse<BlobsTakeSnapshotHeaders>> TakeSnapshotWithHttpMessagesAsync(string accountName, string container, string blob, int? timeout = default(int?), IDictionary<string, string> xMsMeta = default(IDictionary<string, string>), System.DateTime? ifModifiedSince = default(System.DateTime?), System.DateTime? ifUnmodifiedSince = default(System.DateTime?), string ifMatches = default(string), string ifNoneMatch = default(string), string leaseId = default(string), Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (accountName == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "accountName");
            }
            if (container == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "container");
            }
            if (blob == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "blob");
            }
            if (blob != null)
            {
                if (!System.Text.RegularExpressions.Regex.IsMatch(blob, "^(?!.*\\/$)^[\\s\\S]{1,1024}$"))
                {
                    throw new ValidationException(ValidationRules.Pattern, "blob", "^(?!.*\\/$)^[\\s\\S]{1,1024}$");
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
            string comp = "snapshot";
            // Tracing
            bool _shouldTrace = ServiceClientTracing.IsEnabled;
            string _invocationId = null;
            if (_shouldTrace)
            {
                _invocationId = ServiceClientTracing.NextInvocationId.ToString();
                Dictionary<string, object> tracingParameters = new Dictionary<string, object>();
                tracingParameters.Add("accountName", accountName);
                tracingParameters.Add("container", container);
                tracingParameters.Add("blob", blob);
                tracingParameters.Add("timeout", timeout);
                tracingParameters.Add("xMsMeta", xMsMeta);
                tracingParameters.Add("ifModifiedSince", ifModifiedSince);
                tracingParameters.Add("ifUnmodifiedSince", ifUnmodifiedSince);
                tracingParameters.Add("ifMatches", ifMatches);
                tracingParameters.Add("ifNoneMatch", ifNoneMatch);
                tracingParameters.Add("leaseId", leaseId);
                tracingParameters.Add("comp", comp);
                tracingParameters.Add("cancellationToken", cancellationToken);
                ServiceClientTracing.Enter(_invocationId, this, "TakeSnapshot", tracingParameters);
            }
            // Construct URL
            var _baseUrl = Client.BaseUri;
            var _url = _baseUrl + (_baseUrl.EndsWith("/") ? "" : "/") + "{container}/{blob}";
            _url = _url.Replace("{accountName}", accountName);
            _url = _url.Replace("{container}", System.Uri.EscapeDataString(container));
            _url = _url.Replace("{blob}", System.Uri.EscapeDataString(blob));
            List<string> _queryParameters = new List<string>();
            if (timeout != null)
            {
                _queryParameters.Add(string.Format("timeout={0}", System.Uri.EscapeDataString(SafeJsonConvert.SerializeObject(timeout, Client.SerializationSettings).Trim('"'))));
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
            if (ifMatches != null)
            {
                if (_httpRequest.Headers.Contains("If-Match"))
                {
                    _httpRequest.Headers.Remove("If-Match");
                }
                _httpRequest.Headers.TryAddWithoutValidation("If-Match", ifMatches);
            }
            if (ifNoneMatch != null)
            {
                if (_httpRequest.Headers.Contains("If-None-Match"))
                {
                    _httpRequest.Headers.Remove("If-None-Match");
                }
                _httpRequest.Headers.TryAddWithoutValidation("If-None-Match", ifNoneMatch);
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
                var ex = new ErrorException(string.Format("Operation returned an invalid status code '{0}'", _statusCode));
                try
                {
                    _responseContent = await _httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                    Error _errorBody =  SafeJsonConvert.DeserializeObject<Error>(_responseContent, Client.DeserializationSettings);
                    if (_errorBody != null)
                    {
                        ex.Body = _errorBody;
                    }
                }
                catch (JsonException)
                {
                    // Ignore the exception
                }
                ex.Request = new HttpRequestMessageWrapper(_httpRequest, _requestContent);
                ex.Response = new HttpResponseMessageWrapper(_httpResponse, _responseContent);
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
            var _result = new AzureOperationHeaderResponse<BlobsTakeSnapshotHeaders>();
            _result.Request = _httpRequest;
            _result.Response = _httpResponse;
            if (_httpResponse.Headers.Contains("x-ms-request-id"))
            {
                _result.RequestId = _httpResponse.Headers.GetValues("x-ms-request-id").FirstOrDefault();
            }
            try
            {
                _result.Headers = _httpResponse.GetHeadersAsJson().ToObject<BlobsTakeSnapshotHeaders>(JsonSerializer.Create(Client.DeserializationSettings));
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
        /// The Copy Blob operation copies a blob to a destination within the storage
        /// account.
        /// </summary>
        /// <param name='accountName'>
        /// The Azure storage account to use.
        /// </param>
        /// <param name='container'>
        /// The container name.
        /// </param>
        /// <param name='blob'>
        /// The blob name.
        /// </param>
        /// <param name='copySource'>
        /// Specifies the name of the source page blob snapshot. This value is a URL of
        /// up to 2 KB in length that specifies a page blob snapshot. The value should
        /// be URL-encoded as it would appear in a request URI. The source blob must
        /// either be public or must be authenticated via a shared access signature.
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
        /// <param name='sourceIfModifiedSince'>
        /// Specify this header value to operate only on a blob if it has been modified
        /// since the specified date/time.
        /// </param>
        /// <param name='sourceIfUnmodifiedSince'>
        /// Specify this header value to operate only on a blob if it has not been
        /// modified since the specified date/time.
        /// </param>
        /// <param name='sourceIfMatches'>
        /// Specify an ETag value to operate only on blobs with a matching value.
        /// </param>
        /// <param name='sourceIfNoneMatch'>
        /// Specify an ETag value to operate only on blobs without a matching value.
        /// </param>
        /// <param name='ifModifiedSince'>
        /// Specify this header value to operate only on a blob if it has been modified
        /// since the specified date/time.
        /// </param>
        /// <param name='ifUnmodifiedSince'>
        /// Specify this header value to operate only on a blob if it has not been
        /// modified since the specified date/time.
        /// </param>
        /// <param name='ifMatches'>
        /// Specify an ETag value to operate only on blobs with a matching value.
        /// </param>
        /// <param name='ifNoneMatch'>
        /// Specify an ETag value to operate only on blobs without a matching value.
        /// </param>
        /// <param name='leaseId'>
        /// If specified, the operation only succeeds if the container's lease is
        /// active and matches this ID.
        /// </param>
        /// <param name='sourceLeaseId'>
        /// Specify this header to perform the operation only if the lease ID given
        /// matches the active lease ID of the source blob.
        /// </param>
        /// <param name='customHeaders'>
        /// Headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        /// <exception cref="ErrorException">
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
        public async Task<AzureOperationHeaderResponse<BlobsCopyHeaders>> CopyWithHttpMessagesAsync(string accountName, string container, string blob, string copySource, int? timeout = default(int?), IDictionary<string, string> xMsMeta = default(IDictionary<string, string>), System.DateTime? sourceIfModifiedSince = default(System.DateTime?), System.DateTime? sourceIfUnmodifiedSince = default(System.DateTime?), string sourceIfMatches = default(string), string sourceIfNoneMatch = default(string), System.DateTime? ifModifiedSince = default(System.DateTime?), System.DateTime? ifUnmodifiedSince = default(System.DateTime?), string ifMatches = default(string), string ifNoneMatch = default(string), string leaseId = default(string), string sourceLeaseId = default(string), Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (accountName == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "accountName");
            }
            if (container == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "container");
            }
            if (blob == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "blob");
            }
            if (blob != null)
            {
                if (!System.Text.RegularExpressions.Regex.IsMatch(blob, "^(?!.*\\/$)^[\\s\\S]{1,1024}$"))
                {
                    throw new ValidationException(ValidationRules.Pattern, "blob", "^(?!.*\\/$)^[\\s\\S]{1,1024}$");
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
            if (copySource == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "copySource");
            }
            // Tracing
            bool _shouldTrace = ServiceClientTracing.IsEnabled;
            string _invocationId = null;
            if (_shouldTrace)
            {
                _invocationId = ServiceClientTracing.NextInvocationId.ToString();
                Dictionary<string, object> tracingParameters = new Dictionary<string, object>();
                tracingParameters.Add("accountName", accountName);
                tracingParameters.Add("container", container);
                tracingParameters.Add("blob", blob);
                tracingParameters.Add("timeout", timeout);
                tracingParameters.Add("xMsMeta", xMsMeta);
                tracingParameters.Add("sourceIfModifiedSince", sourceIfModifiedSince);
                tracingParameters.Add("sourceIfUnmodifiedSince", sourceIfUnmodifiedSince);
                tracingParameters.Add("sourceIfMatches", sourceIfMatches);
                tracingParameters.Add("sourceIfNoneMatch", sourceIfNoneMatch);
                tracingParameters.Add("ifModifiedSince", ifModifiedSince);
                tracingParameters.Add("ifUnmodifiedSince", ifUnmodifiedSince);
                tracingParameters.Add("ifMatches", ifMatches);
                tracingParameters.Add("ifNoneMatch", ifNoneMatch);
                tracingParameters.Add("copySource", copySource);
                tracingParameters.Add("leaseId", leaseId);
                tracingParameters.Add("sourceLeaseId", sourceLeaseId);
                tracingParameters.Add("cancellationToken", cancellationToken);
                ServiceClientTracing.Enter(_invocationId, this, "Copy", tracingParameters);
            }
            // Construct URL
            var _baseUrl = Client.BaseUri;
            var _url = _baseUrl + (_baseUrl.EndsWith("/") ? "" : "/") + "{container}/{blob}";
            _url = _url.Replace("{accountName}", accountName);
            _url = _url.Replace("{container}", System.Uri.EscapeDataString(container));
            _url = _url.Replace("{blob}", System.Uri.EscapeDataString(blob));
            List<string> _queryParameters = new List<string>();
            if (timeout != null)
            {
                _queryParameters.Add(string.Format("timeout={0}", System.Uri.EscapeDataString(SafeJsonConvert.SerializeObject(timeout, Client.SerializationSettings).Trim('"'))));
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
            if (sourceIfModifiedSince != null)
            {
                if (_httpRequest.Headers.Contains("x-ms-source-if-modified-since"))
                {
                    _httpRequest.Headers.Remove("x-ms-source-if-modified-since");
                }
                _httpRequest.Headers.TryAddWithoutValidation("x-ms-source-if-modified-since", SafeJsonConvert.SerializeObject(sourceIfModifiedSince, new DateTimeRfc1123JsonConverter()).Trim('"'));
            }
            if (sourceIfUnmodifiedSince != null)
            {
                if (_httpRequest.Headers.Contains("x-ms-source-if-unmodified-since"))
                {
                    _httpRequest.Headers.Remove("x-ms-source-if-unmodified-since");
                }
                _httpRequest.Headers.TryAddWithoutValidation("x-ms-source-if-unmodified-since", SafeJsonConvert.SerializeObject(sourceIfUnmodifiedSince, new DateTimeRfc1123JsonConverter()).Trim('"'));
            }
            if (sourceIfMatches != null)
            {
                if (_httpRequest.Headers.Contains("x-ms-source-if-match"))
                {
                    _httpRequest.Headers.Remove("x-ms-source-if-match");
                }
                _httpRequest.Headers.TryAddWithoutValidation("x-ms-source-if-match", sourceIfMatches);
            }
            if (sourceIfNoneMatch != null)
            {
                if (_httpRequest.Headers.Contains("x-ms-source-if-none-match"))
                {
                    _httpRequest.Headers.Remove("x-ms-source-if-none-match");
                }
                _httpRequest.Headers.TryAddWithoutValidation("x-ms-source-if-none-match", sourceIfNoneMatch);
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
            if (ifMatches != null)
            {
                if (_httpRequest.Headers.Contains("If-Match"))
                {
                    _httpRequest.Headers.Remove("If-Match");
                }
                _httpRequest.Headers.TryAddWithoutValidation("If-Match", ifMatches);
            }
            if (ifNoneMatch != null)
            {
                if (_httpRequest.Headers.Contains("If-None-Match"))
                {
                    _httpRequest.Headers.Remove("If-None-Match");
                }
                _httpRequest.Headers.TryAddWithoutValidation("If-None-Match", ifNoneMatch);
            }
            if (copySource != null)
            {
                if (_httpRequest.Headers.Contains("x-ms-copy-source"))
                {
                    _httpRequest.Headers.Remove("x-ms-copy-source");
                }
                _httpRequest.Headers.TryAddWithoutValidation("x-ms-copy-source", copySource);
            }
            if (leaseId != null)
            {
                if (_httpRequest.Headers.Contains("x-ms-lease-id"))
                {
                    _httpRequest.Headers.Remove("x-ms-lease-id");
                }
                _httpRequest.Headers.TryAddWithoutValidation("x-ms-lease-id", leaseId);
            }
            if (sourceLeaseId != null)
            {
                if (_httpRequest.Headers.Contains("x-ms-source-lease-id"))
                {
                    _httpRequest.Headers.Remove("x-ms-source-lease-id");
                }
                _httpRequest.Headers.TryAddWithoutValidation("x-ms-source-lease-id", sourceLeaseId);
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
            if ((int)_statusCode != 202)
            {
                var ex = new ErrorException(string.Format("Operation returned an invalid status code '{0}'", _statusCode));
                try
                {
                    _responseContent = await _httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                    Error _errorBody =  SafeJsonConvert.DeserializeObject<Error>(_responseContent, Client.DeserializationSettings);
                    if (_errorBody != null)
                    {
                        ex.Body = _errorBody;
                    }
                }
                catch (JsonException)
                {
                    // Ignore the exception
                }
                ex.Request = new HttpRequestMessageWrapper(_httpRequest, _requestContent);
                ex.Response = new HttpResponseMessageWrapper(_httpResponse, _responseContent);
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
            var _result = new AzureOperationHeaderResponse<BlobsCopyHeaders>();
            _result.Request = _httpRequest;
            _result.Response = _httpResponse;
            if (_httpResponse.Headers.Contains("x-ms-request-id"))
            {
                _result.RequestId = _httpResponse.Headers.GetValues("x-ms-request-id").FirstOrDefault();
            }
            try
            {
                _result.Headers = _httpResponse.GetHeadersAsJson().ToObject<BlobsCopyHeaders>(JsonSerializer.Create(Client.DeserializationSettings));
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
        /// The Abort Copy Blob operation aborts a pending Copy Blob operation, and
        /// leaves a destination blob with zero length and full metadata.
        /// </summary>
        /// <param name='accountName'>
        /// The Azure storage account to use.
        /// </param>
        /// <param name='container'>
        /// The container name.
        /// </param>
        /// <param name='blob'>
        /// The blob name.
        /// </param>
        /// <param name='copyId'>
        /// The copy identifier provided in the x-ms-copy-id header of the original
        /// Copy Blob operation.
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
        /// <exception cref="ErrorException">
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
        public async Task<AzureOperationHeaderResponse<BlobsAbortCopyHeaders>> AbortCopyWithHttpMessagesAsync(string accountName, string container, string blob, string copyId, int? timeout = default(int?), string leaseId = default(string), Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (accountName == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "accountName");
            }
            if (container == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "container");
            }
            if (blob == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "blob");
            }
            if (blob != null)
            {
                if (!System.Text.RegularExpressions.Regex.IsMatch(blob, "^(?!.*\\/$)^[\\s\\S]{1,1024}$"))
                {
                    throw new ValidationException(ValidationRules.Pattern, "blob", "^(?!.*\\/$)^[\\s\\S]{1,1024}$");
                }
            }
            if (copyId == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "copyId");
            }
            if (timeout < 0)
            {
                throw new ValidationException(ValidationRules.InclusiveMinimum, "timeout", 0);
            }
            string copyActionAbortConstant = "abort";
            string comp = "copy";
            // Tracing
            bool _shouldTrace = ServiceClientTracing.IsEnabled;
            string _invocationId = null;
            if (_shouldTrace)
            {
                _invocationId = ServiceClientTracing.NextInvocationId.ToString();
                Dictionary<string, object> tracingParameters = new Dictionary<string, object>();
                tracingParameters.Add("accountName", accountName);
                tracingParameters.Add("container", container);
                tracingParameters.Add("blob", blob);
                tracingParameters.Add("copyId", copyId);
                tracingParameters.Add("timeout", timeout);
                tracingParameters.Add("leaseId", leaseId);
                tracingParameters.Add("copyActionAbortConstant", copyActionAbortConstant);
                tracingParameters.Add("comp", comp);
                tracingParameters.Add("cancellationToken", cancellationToken);
                ServiceClientTracing.Enter(_invocationId, this, "AbortCopy", tracingParameters);
            }
            // Construct URL
            var _baseUrl = Client.BaseUri;
            var _url = _baseUrl + (_baseUrl.EndsWith("/") ? "" : "/") + "{container}/{blob}";
            _url = _url.Replace("{accountName}", accountName);
            _url = _url.Replace("{container}", System.Uri.EscapeDataString(container));
            _url = _url.Replace("{blob}", System.Uri.EscapeDataString(blob));
            List<string> _queryParameters = new List<string>();
            if (copyId != null)
            {
                _queryParameters.Add(string.Format("copyid={0}", System.Uri.EscapeDataString(copyId)));
            }
            if (timeout != null)
            {
                _queryParameters.Add(string.Format("timeout={0}", System.Uri.EscapeDataString(SafeJsonConvert.SerializeObject(timeout, Client.SerializationSettings).Trim('"'))));
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
            if (copyActionAbortConstant != null)
            {
                if (_httpRequest.Headers.Contains("x-ms-copy-action"))
                {
                    _httpRequest.Headers.Remove("x-ms-copy-action");
                }
                _httpRequest.Headers.TryAddWithoutValidation("x-ms-copy-action", copyActionAbortConstant);
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
            if ((int)_statusCode != 204)
            {
                var ex = new ErrorException(string.Format("Operation returned an invalid status code '{0}'", _statusCode));
                try
                {
                    _responseContent = await _httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                    Error _errorBody =  SafeJsonConvert.DeserializeObject<Error>(_responseContent, Client.DeserializationSettings);
                    if (_errorBody != null)
                    {
                        ex.Body = _errorBody;
                    }
                }
                catch (JsonException)
                {
                    // Ignore the exception
                }
                ex.Request = new HttpRequestMessageWrapper(_httpRequest, _requestContent);
                ex.Response = new HttpResponseMessageWrapper(_httpResponse, _responseContent);
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
            var _result = new AzureOperationHeaderResponse<BlobsAbortCopyHeaders>();
            _result.Request = _httpRequest;
            _result.Response = _httpResponse;
            if (_httpResponse.Headers.Contains("x-ms-request-id"))
            {
                _result.RequestId = _httpResponse.Headers.GetValues("x-ms-request-id").FirstOrDefault();
            }
            try
            {
                _result.Headers = _httpResponse.GetHeadersAsJson().ToObject<BlobsAbortCopyHeaders>(JsonSerializer.Create(Client.DeserializationSettings));
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
        /// The Append Block operation commits a new block of data to the end of an
        /// existing append blob. The Append Block operation is permitted only if the
        /// blob was created with x-ms-blob-type set to AppendBlob. Append Block is
        /// supported only on version 2015-02-21 version or later.
        /// </summary>
        /// <param name='accountName'>
        /// The Azure storage account to use.
        /// </param>
        /// <param name='container'>
        /// The container name.
        /// </param>
        /// <param name='blob'>
        /// The blob name.
        /// </param>
        /// <param name='body'>
        /// Initial data
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
        /// <param name='maxSize'>
        /// Optional conditional header. The max length in bytes permitted for the
        /// append blob. If the Append Block operation would cause the blob to exceed
        /// that limit or if the blob size is already greater than the value specified
        /// in this header, the request will fail with MaxBlobSizeConditionNotMet error
        /// (HTTP status code 412 - Precondition Failed).
        /// </param>
        /// <param name='appendPosition'>
        /// Optional conditional header, used only for the Append Block operation. A
        /// number indicating the byte offset to compare. Append Block will succeed
        /// only if the append position is equal to this number. If it is not, the
        /// request will fail with the AppendPositionConditionNotMet error (HTTP status
        /// code 412 - Precondition Failed).
        /// </param>
        /// <param name='ifModifiedSince'>
        /// Specify this header value to operate only on a blob if it has been modified
        /// since the specified date/time.
        /// </param>
        /// <param name='ifUnmodifiedSince'>
        /// Specify this header value to operate only on a blob if it has not been
        /// modified since the specified date/time.
        /// </param>
        /// <param name='ifMatches'>
        /// Specify an ETag value to operate only on blobs with a matching value.
        /// </param>
        /// <param name='ifNoneMatch'>
        /// Specify an ETag value to operate only on blobs without a matching value.
        /// </param>
        /// <param name='customHeaders'>
        /// Headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        /// <exception cref="ErrorException">
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
        public async Task<AzureOperationHeaderResponse<BlobsAppendBlockHeaders>> AppendBlockWithHttpMessagesAsync(string accountName, string container, string blob, Stream body, int? timeout = default(int?), string leaseId = default(string), int? maxSize = default(int?), int? appendPosition = default(int?), System.DateTime? ifModifiedSince = default(System.DateTime?), System.DateTime? ifUnmodifiedSince = default(System.DateTime?), string ifMatches = default(string), string ifNoneMatch = default(string), Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (accountName == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "accountName");
            }
            if (container == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "container");
            }
            if (blob == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "blob");
            }
            if (blob != null)
            {
                if (!System.Text.RegularExpressions.Regex.IsMatch(blob, "^(?!.*\\/$)^[\\s\\S]{1,1024}$"))
                {
                    throw new ValidationException(ValidationRules.Pattern, "blob", "^(?!.*\\/$)^[\\s\\S]{1,1024}$");
                }
            }
            if (timeout < 0)
            {
                throw new ValidationException(ValidationRules.InclusiveMinimum, "timeout", 0);
            }
            if (body == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "body");
            }
            string comp = "appendblock";
            // Tracing
            bool _shouldTrace = ServiceClientTracing.IsEnabled;
            string _invocationId = null;
            if (_shouldTrace)
            {
                _invocationId = ServiceClientTracing.NextInvocationId.ToString();
                Dictionary<string, object> tracingParameters = new Dictionary<string, object>();
                tracingParameters.Add("accountName", accountName);
                tracingParameters.Add("container", container);
                tracingParameters.Add("blob", blob);
                tracingParameters.Add("timeout", timeout);
                tracingParameters.Add("leaseId", leaseId);
                tracingParameters.Add("maxSize", maxSize);
                tracingParameters.Add("appendPosition", appendPosition);
                tracingParameters.Add("ifModifiedSince", ifModifiedSince);
                tracingParameters.Add("ifUnmodifiedSince", ifUnmodifiedSince);
                tracingParameters.Add("ifMatches", ifMatches);
                tracingParameters.Add("ifNoneMatch", ifNoneMatch);
                tracingParameters.Add("body", body);
                tracingParameters.Add("comp", comp);
                tracingParameters.Add("cancellationToken", cancellationToken);
                ServiceClientTracing.Enter(_invocationId, this, "AppendBlock", tracingParameters);
            }
            // Construct URL
            var _baseUrl = Client.BaseUri;
            var _url = _baseUrl + (_baseUrl.EndsWith("/") ? "" : "/") + "{container}/{blob}";
            _url = _url.Replace("{accountName}", accountName);
            _url = _url.Replace("{container}", System.Uri.EscapeDataString(container));
            _url = _url.Replace("{blob}", System.Uri.EscapeDataString(blob));
            List<string> _queryParameters = new List<string>();
            if (timeout != null)
            {
                _queryParameters.Add(string.Format("timeout={0}", System.Uri.EscapeDataString(SafeJsonConvert.SerializeObject(timeout, Client.SerializationSettings).Trim('"'))));
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
            if (maxSize != null)
            {
                if (_httpRequest.Headers.Contains("x-ms-blob-condition-maxsize"))
                {
                    _httpRequest.Headers.Remove("x-ms-blob-condition-maxsize");
                }
                _httpRequest.Headers.TryAddWithoutValidation("x-ms-blob-condition-maxsize", SafeJsonConvert.SerializeObject(maxSize, Client.SerializationSettings).Trim('"'));
            }
            if (appendPosition != null)
            {
                if (_httpRequest.Headers.Contains("x-ms-blob-condition-appendpos"))
                {
                    _httpRequest.Headers.Remove("x-ms-blob-condition-appendpos");
                }
                _httpRequest.Headers.TryAddWithoutValidation("x-ms-blob-condition-appendpos", SafeJsonConvert.SerializeObject(appendPosition, Client.SerializationSettings).Trim('"'));
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
            if (ifMatches != null)
            {
                if (_httpRequest.Headers.Contains("If-Match"))
                {
                    _httpRequest.Headers.Remove("If-Match");
                }
                _httpRequest.Headers.TryAddWithoutValidation("If-Match", ifMatches);
            }
            if (ifNoneMatch != null)
            {
                if (_httpRequest.Headers.Contains("If-None-Match"))
                {
                    _httpRequest.Headers.Remove("If-None-Match");
                }
                _httpRequest.Headers.TryAddWithoutValidation("If-None-Match", ifNoneMatch);
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
            if(body == null)
            {
              throw new System.ArgumentNullException("body");
            }
            if (body != null && body != Stream.Null)
            {
              _httpRequest.Content = new System.Net.Http.StreamContent(body);
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
            if ((int)_statusCode != 201)
            {
                var ex = new ErrorException(string.Format("Operation returned an invalid status code '{0}'", _statusCode));
                try
                {
                    _responseContent = await _httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                    Error _errorBody =  SafeJsonConvert.DeserializeObject<Error>(_responseContent, Client.DeserializationSettings);
                    if (_errorBody != null)
                    {
                        ex.Body = _errorBody;
                    }
                }
                catch (JsonException)
                {
                    // Ignore the exception
                }
                ex.Request = new HttpRequestMessageWrapper(_httpRequest, _requestContent);
                ex.Response = new HttpResponseMessageWrapper(_httpResponse, _responseContent);
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
            var _result = new AzureOperationHeaderResponse<BlobsAppendBlockHeaders>();
            _result.Request = _httpRequest;
            _result.Response = _httpResponse;
            if (_httpResponse.Headers.Contains("x-ms-request-id"))
            {
                _result.RequestId = _httpResponse.Headers.GetValues("x-ms-request-id").FirstOrDefault();
            }
            try
            {
                _result.Headers = _httpResponse.GetHeadersAsJson().ToObject<BlobsAppendBlockHeaders>(JsonSerializer.Create(Client.DeserializationSettings));
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

