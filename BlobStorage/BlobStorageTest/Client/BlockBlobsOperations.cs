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
    using System.Xml;
    using System.Xml.Linq;

    /// <summary>
    /// BlockBlobsOperations operations.
    /// </summary>
    internal partial class BlockBlobsOperations : IServiceOperations<AzureBlobStorageClient>, IBlockBlobsOperations
    {
        /// <summary>
        /// Initializes a new instance of the BlockBlobsOperations class.
        /// </summary>
        /// <param name='client'>
        /// Reference to the service client.
        /// </param>
        /// <exception cref="System.ArgumentNullException">
        /// Thrown when a required parameter is null
        /// </exception>
        internal BlockBlobsOperations(AzureBlobStorageClient client)
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
        /// The Put Block operation creates a new block to be committed as part of a
        /// blob
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
        /// <param name='blockId'>
        /// A valid Base64 string value that identifies the block. Prior to encoding,
        /// the string must be less than or equal to 64 bytes in size. For a given
        /// blob, the length of the value specified for the blockid parameter must be
        /// the same size for each block.
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
        public async Task<AzureOperationHeaderResponse<BlockBlobsPutBlockHeaders>> PutBlockWithHttpMessagesAsync(string accountName, string container, string blob, string blockId, Stream body, int? timeout = default(int?), string leaseId = default(string), Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken))
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
            if (blockId == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "blockId");
            }
            if (timeout < 0)
            {
                throw new ValidationException(ValidationRules.InclusiveMinimum, "timeout", 0);
            }
            if (body == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "body");
            }
            string comp = "block";
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
                tracingParameters.Add("blockId", blockId);
                tracingParameters.Add("timeout", timeout);
                tracingParameters.Add("leaseId", leaseId);
                tracingParameters.Add("body", body);
                tracingParameters.Add("comp", comp);
                tracingParameters.Add("cancellationToken", cancellationToken);
                ServiceClientTracing.Enter(_invocationId, this, "PutBlock", tracingParameters);
            }
            // Construct URL
            var _baseUrl = Client.BaseUri;
            var _url = _baseUrl + (_baseUrl.EndsWith("/") ? "" : "/") + "{container}/{blob}";
            _url = _url.Replace("{accountName}", accountName);
            _url = _url.Replace("{container}", System.Uri.EscapeDataString(container));
            _url = _url.Replace("{blob}", System.Uri.EscapeDataString(blob));
            List<string> _queryParameters = new List<string>();
            if (blockId != null)
            {
                _queryParameters.Add(string.Format("blockid={0}", System.Uri.EscapeDataString(blockId)));
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
            var _result = new AzureOperationHeaderResponse<BlockBlobsPutBlockHeaders>();
            _result.Request = _httpRequest;
            _result.Response = _httpResponse;
            if (_httpResponse.Headers.Contains("x-ms-request-id"))
            {
                _result.RequestId = _httpResponse.Headers.GetValues("x-ms-request-id").FirstOrDefault();
            }
            try
            {
                _result.Headers = _httpResponse.GetHeadersAsJson().ToObject<BlockBlobsPutBlockHeaders>(JsonSerializer.Create(Client.DeserializationSettings));
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
        /// The Put Block List operation writes a blob by specifying the list of block
        /// IDs that make up the blob. In order to be written as part of a blob, a
        /// block must have been successfully written to the server in a prior Put
        /// Block operation. You can call Put Block List to update a blob by uploading
        /// only those blocks that have changed, then committing the new and existing
        /// blocks together. You can do this by specifying whether to commit a block
        /// from the committed block list or from the uncommitted block list, or to
        /// commit the most recently uploaded version of the block, whichever list it
        /// may belong to.
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
        /// <param name='blocks'>
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
        public async Task<AzureOperationHeaderResponse<BlockBlobsPutBlockListHeaders>> PutBlockListWithHttpMessagesAsync(string accountName, string container, string blob, IList<string> blocks, int? timeout = default(int?), string xMsBlobCacheControl = default(string), string xMsBlobContentType = default(string), string xMsBlobContentEncoding = default(string), string xMsBlobContentLanguage = default(string), string xMsBlobContentMd5 = default(string), IDictionary<string, string> xMsMeta = default(IDictionary<string, string>), string leaseId = default(string), string xMsBlobContentDisposition = default(string), System.DateTime? ifModifiedSince = default(System.DateTime?), System.DateTime? ifUnmodifiedSince = default(System.DateTime?), string ifMatches = default(string), string ifNoneMatch = default(string), Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken))
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
            if (blocks == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "blocks");
            }
            string comp = "blocklist";
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
                tracingParameters.Add("xMsBlobContentEncoding", xMsBlobContentEncoding);
                tracingParameters.Add("xMsBlobContentLanguage", xMsBlobContentLanguage);
                tracingParameters.Add("xMsBlobContentMd5", xMsBlobContentMd5);
                tracingParameters.Add("xMsMeta", xMsMeta);
                tracingParameters.Add("leaseId", leaseId);
                tracingParameters.Add("xMsBlobContentDisposition", xMsBlobContentDisposition);
                tracingParameters.Add("ifModifiedSince", ifModifiedSince);
                tracingParameters.Add("ifUnmodifiedSince", ifUnmodifiedSince);
                tracingParameters.Add("ifMatches", ifMatches);
                tracingParameters.Add("ifNoneMatch", ifNoneMatch);
                tracingParameters.Add("blocks", blocks);
                tracingParameters.Add("comp", comp);
                tracingParameters.Add("cancellationToken", cancellationToken);
                ServiceClientTracing.Enter(_invocationId, this, "PutBlockList", tracingParameters);
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
            if(blocks != null)
            {
                _requestContent = new XElement("BlockList", System.Linq.Enumerable.Select(blocks, x => new XElement("Latest", x))).ToString();
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
            var _result = new AzureOperationHeaderResponse<BlockBlobsPutBlockListHeaders>();
            _result.Request = _httpRequest;
            _result.Response = _httpResponse;
            if (_httpResponse.Headers.Contains("x-ms-request-id"))
            {
                _result.RequestId = _httpResponse.Headers.GetValues("x-ms-request-id").FirstOrDefault();
            }
            try
            {
                _result.Headers = _httpResponse.GetHeadersAsJson().ToObject<BlockBlobsPutBlockListHeaders>(JsonSerializer.Create(Client.DeserializationSettings));
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
        /// The Get Block List operation retrieves the list of blocks that have been
        /// uploaded as part of a block blob
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
        /// <param name='listType'>
        /// Specifies whether to return the list of committed blocks, the list of
        /// uncommitted blocks, or both lists together. Possible values include:
        /// 'committed', 'uncommitted', 'all'
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
        public async Task<AzureOperationResponse<BlockList,BlockBlobsGetBlockListHeaders>> GetBlockListWithHttpMessagesAsync(string accountName, string container, string blob, System.DateTime? snapshot = default(System.DateTime?), BlockListType? listType = default(BlockListType?), int? timeout = default(int?), string leaseId = default(string), Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken))
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
            string comp = "blocklist";
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
                tracingParameters.Add("listType", listType);
                tracingParameters.Add("timeout", timeout);
                tracingParameters.Add("leaseId", leaseId);
                tracingParameters.Add("comp", comp);
                tracingParameters.Add("cancellationToken", cancellationToken);
                ServiceClientTracing.Enter(_invocationId, this, "GetBlockList", tracingParameters);
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
            if (listType != null)
            {
                _queryParameters.Add(string.Format("blocklisttype={0}", System.Uri.EscapeDataString(SafeJsonConvert.SerializeObject(listType, Client.SerializationSettings).Trim('"'))));
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
            var _result = new AzureOperationResponse<BlockList,BlockBlobsGetBlockListHeaders>();
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
                    BlockList _tmp_ = null;
                    if (_httpResponse.Content.Headers.ContentType.MediaType == "application/xml" &&
                        XmlSerialization.Root(XmlSerialization.ToDeserializer(e => BlockList.XmlDeserialize(e)))(XElement.Parse(_responseContent), out _tmp_))
                    {
                        _result.Body = _tmp_;
                    }else
                    {
                        _result.Body = SafeJsonConvert.DeserializeObject<BlockList>(_responseContent, Client.DeserializationSettings);
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
                _result.Headers = _httpResponse.GetHeadersAsJson().ToObject<BlockBlobsGetBlockListHeaders>(JsonSerializer.Create(Client.DeserializationSettings));
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

