// MIT

namespace BlobStorageTest.Client
{
    using Microsoft.Rest;
    using Microsoft.Rest.Azure;
    using Models;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Extension methods for ServiceOperations.
    /// </summary>
    public static partial class ServiceOperationsExtensions
    {
            /// <summary>
            /// Sets properties for a storage account's Blob service endpoint, including
            /// properties for Storage Analytics and CORS (Cross-Origin Resource Sharing)
            /// rules
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='accountName'>
            /// The Azure storage account to use.
            /// </param>
            /// <param name='storageServiceProperties'>
            /// The StorageService properties.
            /// </param>
            /// <param name='timeout'>
            /// The timeout parameter is expressed in seconds. For more information, see
            /// &lt;a
            /// href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations"&gt;Setting
            /// Timeouts for Blob Service Operations.&lt;/a&gt;
            /// </param>
            public static ServiceSetPropertiesHeaders SetProperties(this IServiceOperations operations, string accountName, StorageServiceProperties storageServiceProperties, int? timeout = default(int?))
            {
                return operations.SetPropertiesAsync(accountName, storageServiceProperties, timeout).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Sets properties for a storage account's Blob service endpoint, including
            /// properties for Storage Analytics and CORS (Cross-Origin Resource Sharing)
            /// rules
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='accountName'>
            /// The Azure storage account to use.
            /// </param>
            /// <param name='storageServiceProperties'>
            /// The StorageService properties.
            /// </param>
            /// <param name='timeout'>
            /// The timeout parameter is expressed in seconds. For more information, see
            /// &lt;a
            /// href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations"&gt;Setting
            /// Timeouts for Blob Service Operations.&lt;/a&gt;
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<ServiceSetPropertiesHeaders> SetPropertiesAsync(this IServiceOperations operations, string accountName, StorageServiceProperties storageServiceProperties, int? timeout = default(int?), CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.SetPropertiesWithHttpMessagesAsync(accountName, storageServiceProperties, timeout, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Headers;
                }
            }

            /// <summary>
            /// gets the properties of a storage account's Blob service, including
            /// properties for Storage Analytics and CORS (Cross-Origin Resource Sharing)
            /// rules.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='accountName'>
            /// The Azure storage account to use.
            /// </param>
            /// <param name='timeout'>
            /// The timeout parameter is expressed in seconds. For more information, see
            /// &lt;a
            /// href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations"&gt;Setting
            /// Timeouts for Blob Service Operations.&lt;/a&gt;
            /// </param>
            public static StorageServiceProperties GetProperties(this IServiceOperations operations, string accountName, int? timeout = default(int?))
            {
                return operations.GetPropertiesAsync(accountName, timeout).GetAwaiter().GetResult();
            }

            /// <summary>
            /// gets the properties of a storage account's Blob service, including
            /// properties for Storage Analytics and CORS (Cross-Origin Resource Sharing)
            /// rules.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='accountName'>
            /// The Azure storage account to use.
            /// </param>
            /// <param name='timeout'>
            /// The timeout parameter is expressed in seconds. For more information, see
            /// &lt;a
            /// href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations"&gt;Setting
            /// Timeouts for Blob Service Operations.&lt;/a&gt;
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<StorageServiceProperties> GetPropertiesAsync(this IServiceOperations operations, string accountName, int? timeout = default(int?), CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.GetPropertiesWithHttpMessagesAsync(accountName, timeout, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Retrieves statistics related to replication for the Blob service. It is
            /// only available on the secondary location endpoint when read-access
            /// geo-redundant replication is enabled for the storage account.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='accountName'>
            /// The Azure storage account to use.
            /// </param>
            /// <param name='timeout'>
            /// The timeout parameter is expressed in seconds. For more information, see
            /// &lt;a
            /// href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations"&gt;Setting
            /// Timeouts for Blob Service Operations.&lt;/a&gt;
            /// </param>
            public static StorageServiceStats GetStats(this IServiceOperations operations, string accountName, int? timeout = default(int?))
            {
                return operations.GetStatsAsync(accountName, timeout).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Retrieves statistics related to replication for the Blob service. It is
            /// only available on the secondary location endpoint when read-access
            /// geo-redundant replication is enabled for the storage account.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='accountName'>
            /// The Azure storage account to use.
            /// </param>
            /// <param name='timeout'>
            /// The timeout parameter is expressed in seconds. For more information, see
            /// &lt;a
            /// href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations"&gt;Setting
            /// Timeouts for Blob Service Operations.&lt;/a&gt;
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<StorageServiceStats> GetStatsAsync(this IServiceOperations operations, string accountName, int? timeout = default(int?), CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.GetStatsWithHttpMessagesAsync(accountName, timeout, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// The List Containers operation returns a list of the containers under the
            /// specified account
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='accountName'>
            /// The Azure storage account to use.
            /// </param>
            /// <param name='prefix'>
            /// Filters the results to return only containers whose name begins with the
            /// specified prefix.
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
            public static ContainerEnumerationResults ListContainers(this IServiceOperations operations, string accountName, string prefix = default(string), string marker = default(string), int? maxresults = default(int?), string include = default(string), int? timeout = default(int?))
            {
                return operations.ListContainersAsync(accountName, prefix, marker, maxresults, include, timeout).GetAwaiter().GetResult();
            }

            /// <summary>
            /// The List Containers operation returns a list of the containers under the
            /// specified account
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='accountName'>
            /// The Azure storage account to use.
            /// </param>
            /// <param name='prefix'>
            /// Filters the results to return only containers whose name begins with the
            /// specified prefix.
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
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<ContainerEnumerationResults> ListContainersAsync(this IServiceOperations operations, string accountName, string prefix = default(string), string marker = default(string), int? maxresults = default(int?), string include = default(string), int? timeout = default(int?), CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.ListContainersWithHttpMessagesAsync(accountName, prefix, marker, maxresults, include, timeout, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

    }
}

