// Our custom header

namespace blob-storage
{
    using Microsoft.Rest;
    using Microsoft.Rest.Azure;
    using Models;
    using System.Collections;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Extension methods for ContainerOperations.
    /// </summary>
    public static partial class ContainerOperationsExtensions
    {
            /// <summary>
            /// creates a new container under the specified account. If the container with
            /// the same name already exists, the operation fails
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
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
            public static ContainerCreateHeaders Create(this IContainerOperations operations, string accountName, string container, int? timeout = default(int?), IDictionary<string, string> xMsMeta = default(IDictionary<string, string>), string access = default(string))
            {
                return operations.CreateAsync(accountName, container, timeout, xMsMeta, access).GetAwaiter().GetResult();
            }

            /// <summary>
            /// creates a new container under the specified account. If the container with
            /// the same name already exists, the operation fails
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
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
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<ContainerCreateHeaders> CreateAsync(this IContainerOperations operations, string accountName, string container, int? timeout = default(int?), IDictionary<string, string> xMsMeta = default(IDictionary<string, string>), string access = default(string), CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.CreateWithHttpMessagesAsync(accountName, container, timeout, xMsMeta, access, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Headers;
                }
            }

            /// <summary>
            /// returns all user-defined metadata and system properties for the specified
            /// container. The data returned does not include the container's list of blobs
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
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
            public static ContainerGetPropertiesHeaders GetProperties(this IContainerOperations operations, string accountName, string container, int? timeout = default(int?), string leaseId = default(string))
            {
                return operations.GetPropertiesAsync(accountName, container, timeout, leaseId).GetAwaiter().GetResult();
            }

            /// <summary>
            /// returns all user-defined metadata and system properties for the specified
            /// container. The data returned does not include the container's list of blobs
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
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
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<ContainerGetPropertiesHeaders> GetPropertiesAsync(this IContainerOperations operations, string accountName, string container, int? timeout = default(int?), string leaseId = default(string), CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.GetPropertiesWithHttpMessagesAsync(accountName, container, timeout, leaseId, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Headers;
                }
            }

            /// <summary>
            /// operation marks the specified container for deletion. The container and any
            /// blobs contained within it are later deleted during garbage collection
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
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
            public static void Delete(this IContainerOperations operations, string accountName, string container, int? timeout = default(int?), string leaseId = default(string), System.DateTime? ifModifiedSince = default(System.DateTime?), System.DateTime? ifUnmodifiedSince = default(System.DateTime?))
            {
                operations.DeleteAsync(accountName, container, timeout, leaseId, ifModifiedSince, ifUnmodifiedSince).GetAwaiter().GetResult();
            }

            /// <summary>
            /// operation marks the specified container for deletion. The container and any
            /// blobs contained within it are later deleted during garbage collection
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
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
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task DeleteAsync(this IContainerOperations operations, string accountName, string container, int? timeout = default(int?), string leaseId = default(string), System.DateTime? ifModifiedSince = default(System.DateTime?), System.DateTime? ifUnmodifiedSince = default(System.DateTime?), CancellationToken cancellationToken = default(CancellationToken))
            {
                await operations.DeleteWithHttpMessagesAsync(accountName, container, timeout, leaseId, ifModifiedSince, ifUnmodifiedSince, null, cancellationToken).ConfigureAwait(false);
            }

            /// <summary>
            /// returns all user-defined metadata for the container
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
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
            public static ContainerGetMetadataHeaders GetMetadata(this IContainerOperations operations, string accountName, string container, int? timeout = default(int?), string leaseId = default(string))
            {
                return operations.GetMetadataAsync(accountName, container, timeout, leaseId).GetAwaiter().GetResult();
            }

            /// <summary>
            /// returns all user-defined metadata for the container
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
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
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<ContainerGetMetadataHeaders> GetMetadataAsync(this IContainerOperations operations, string accountName, string container, int? timeout = default(int?), string leaseId = default(string), CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.GetMetadataWithHttpMessagesAsync(accountName, container, timeout, leaseId, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Headers;
                }
            }

            /// <summary>
            /// operation sets one or more user-defined name-value pairs for the specified
            /// container.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
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
            public static ContainerSetMetadataHeaders SetMetadata(this IContainerOperations operations, string accountName, string container, int? timeout = default(int?), string leaseId = default(string), IDictionary<string, string> xMsMeta = default(IDictionary<string, string>), System.DateTime? ifModifiedSince = default(System.DateTime?))
            {
                return operations.SetMetadataAsync(accountName, container, timeout, leaseId, xMsMeta, ifModifiedSince).GetAwaiter().GetResult();
            }

            /// <summary>
            /// operation sets one or more user-defined name-value pairs for the specified
            /// container.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
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
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<ContainerSetMetadataHeaders> SetMetadataAsync(this IContainerOperations operations, string accountName, string container, int? timeout = default(int?), string leaseId = default(string), IDictionary<string, string> xMsMeta = default(IDictionary<string, string>), System.DateTime? ifModifiedSince = default(System.DateTime?), CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.SetMetadataWithHttpMessagesAsync(accountName, container, timeout, leaseId, xMsMeta, ifModifiedSince, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Headers;
                }
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
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
            public static IList<SignedIdentifier> GetAcl(this IContainerOperations operations, string accountName, string container, int? timeout = default(int?), string leaseId = default(string))
            {
                return operations.GetAclAsync(accountName, container, timeout, leaseId).GetAwaiter().GetResult();
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
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
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<IList<SignedIdentifier>> GetAclAsync(this IContainerOperations operations, string accountName, string container, int? timeout = default(int?), string leaseId = default(string), CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.GetAclWithHttpMessagesAsync(accountName, container, timeout, leaseId, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
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
            public static ContainerSetAclHeaders SetAcl(this IContainerOperations operations, string accountName, string container, IList<SignedIdentifier> containerAcl = default(IList<SignedIdentifier>), int? timeout = default(int?), string leaseId = default(string), string access = default(string), System.DateTime? ifModifiedSince = default(System.DateTime?), System.DateTime? ifUnmodifiedSince = default(System.DateTime?))
            {
                return operations.SetAclAsync(accountName, container, containerAcl, timeout, leaseId, access, ifModifiedSince, ifUnmodifiedSince).GetAwaiter().GetResult();
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
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
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<ContainerSetAclHeaders> SetAclAsync(this IContainerOperations operations, string accountName, string container, IList<SignedIdentifier> containerAcl = default(IList<SignedIdentifier>), int? timeout = default(int?), string leaseId = default(string), string access = default(string), System.DateTime? ifModifiedSince = default(System.DateTime?), System.DateTime? ifUnmodifiedSince = default(System.DateTime?), CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.SetAclWithHttpMessagesAsync(accountName, container, containerAcl, timeout, leaseId, access, ifModifiedSince, ifUnmodifiedSince, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Headers;
                }
            }

            /// <summary>
            /// establishes and manages a lock on a container for delete operations. The
            /// lock duration can be 15 to 60 seconds, or can be infinite
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
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
            public static ContainerLeaseHeaders Lease(this IContainerOperations operations, string accountName, string container, string action, int? timeout = default(int?), string leaseId = default(string), int? breakPeriod = default(int?), int? duration = default(int?), string proposedLeaseId = default(string), string origin = default(string), System.DateTime? ifModifiedSince = default(System.DateTime?), System.DateTime? ifUnmodifiedSince = default(System.DateTime?))
            {
                return operations.LeaseAsync(accountName, container, action, timeout, leaseId, breakPeriod, duration, proposedLeaseId, origin, ifModifiedSince, ifUnmodifiedSince).GetAwaiter().GetResult();
            }

            /// <summary>
            /// establishes and manages a lock on a container for delete operations. The
            /// lock duration can be 15 to 60 seconds, or can be infinite
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
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
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<ContainerLeaseHeaders> LeaseAsync(this IContainerOperations operations, string accountName, string container, string action, int? timeout = default(int?), string leaseId = default(string), int? breakPeriod = default(int?), int? duration = default(int?), string proposedLeaseId = default(string), string origin = default(string), System.DateTime? ifModifiedSince = default(System.DateTime?), System.DateTime? ifUnmodifiedSince = default(System.DateTime?), CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.LeaseWithHttpMessagesAsync(accountName, container, action, timeout, leaseId, breakPeriod, duration, proposedLeaseId, origin, ifModifiedSince, ifUnmodifiedSince, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Headers;
                }
            }

            /// <summary>
            /// The List Blobs operation returns a list of the blobs under the specified
            /// container
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
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
            public static BlobEnumerationResults ListBlobs(this IContainerOperations operations, string accountName, string container, string prefix = default(string), string delimiter = default(string), string marker = default(string), int? maxresults = default(int?), string include = default(string), int? timeout = default(int?))
            {
                return operations.ListBlobsAsync(accountName, container, prefix, delimiter, marker, maxresults, include, timeout).GetAwaiter().GetResult();
            }

            /// <summary>
            /// The List Blobs operation returns a list of the blobs under the specified
            /// container
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
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
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<BlobEnumerationResults> ListBlobsAsync(this IContainerOperations operations, string accountName, string container, string prefix = default(string), string delimiter = default(string), string marker = default(string), int? maxresults = default(int?), string include = default(string), int? timeout = default(int?), CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.ListBlobsWithHttpMessagesAsync(accountName, container, prefix, delimiter, marker, maxresults, include, timeout, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

    }
}

