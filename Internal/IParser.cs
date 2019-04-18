using OBS.Model;
using OBS.Internal.Negotiation;

namespace OBS.Internal
{
    internal interface IParser
    {
        ListBucketsResponse ParseListBucketsResponse(HttpResponse httpResponse);

        GetBucketStoragePolicyResponse ParseGetBucketStoragePolicyResponse(HttpResponse httpResonse);

        GetBucketMetadataResponse ParseGetBucketMetadataResponse(HttpResponse httpResponse);

        GetBucketLocationResponse ParseGetBucketLocationResponse(HttpResponse httpResponse);

        GetBucketStorageInfoResponse ParseGetBucketStorageInfoResponse(HttpResponse httpResponse);

        ListObjectsResponse ParseListObjectsResponse(HttpResponse httpResponse);

        ListVersionsResponse ParseListVersionsResponse(HttpResponse httpResponse);

        GetBucketQuotaResponse ParseGetBucketQuotaResponse(HttpResponse httpResponse);

        GetBucketAclResponse ParseGetBucketAclResponse(HttpResponse httpResponse);

        ListMultipartUploadsResponse ParseListMultipartUploadsResponse(HttpResponse httpResponse);

        GetBucketLoggingResponse ParseGetBucketLoggingResponse(HttpResponse httpResponse);

        GetBucketPolicyResponse ParseGetBucketPolicyResponse(HttpResponse httpResponse);

        GetBucketCorsResponse ParseGetBucketCorsResponse(HttpResponse httpResponse);

        GetBucketLifecycleResponse ParseGetBucketLifecycleResponse(HttpResponse httpResponse);

        GetBucketWebsiteResponse ParseGetBucketWebsiteResponse(HttpResponse httpResponse);

        GetBucketVersioningResponse ParseGetBucketVersioningResponse(HttpResponse httpResponse);

        GetBucketTaggingResponse ParseGetBucketTaggingResponse(HttpResponse httpResponse);

        GetBucketNotificationReponse ParseGetBucketNotificationReponse(HttpResponse httpResponse);

        DeleteObjectResponse ParseDeleteObjectResponse(HttpResponse httpResponse);

        DeleteObjectsResponse ParseDeleteObjectsResponse(HttpResponse httpResponse);

        ListPartsResponse ParseListPartsResponse(HttpResponse httpResponse);

        CompleteMultipartUploadResponse ParseCompleteMultipartUploadResponse(HttpResponse httpResponse);

        GetObjectAclResponse ParseGetObjectAclResponse(HttpResponse httpResponse);

        PutObjectResponse ParsePutObjectResponse(HttpResponse httpResponse);

        CopyObjectResponse ParseCopyObjectResponse(HttpResponse httpResponse);

        InitiateMultipartUploadResponse ParseInitiateMultipartUploadResponse(HttpResponse httpResponse);

        CopyPartResponse ParseCopyPartResponse(HttpResponse httpResponse);

        UploadPartResponse ParseUploadPartResponse(HttpResponse httpResponse);

        GetBucketReplicationResponse ParseGetBucketReplicationResponse(HttpResponse httpResponse);

        GetObjectMetadataResponse ParseGetObjectMetadataResponse(HttpResponse httpResponse);

        GetObjectResponse ParseGetObjectResponse(HttpResponse httpResponse);

        AppendObjectResponse ParseAppendObjectResponse(HttpResponse httpResponse);
    }
}
