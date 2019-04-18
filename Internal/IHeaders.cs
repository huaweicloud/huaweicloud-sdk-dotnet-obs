

namespace OBS.Internal
{
    internal interface IHeaders
    {
        string DefaultStorageClassHeader();
        string AclHeader();
        string RequestIdHeader();
        string RequestId2Header();
        string BucketRegionHeader();
        string LocationHeader();
        string StorageClassHeader();
        string WebsiteRedirectLocationHeader();
        string SuccessRedirectLocationHeader();
        string SseKmsHeader();
        string SseKmsKeyHeader();
        string SseCHeader();
        string SseCKeyHeader();
        string SseCKeyMd5Header();
        string ExpiresHeader();
        string VersionIdHeader();
        string CopySourceHeader();
        string CopySourceRangeHeader();
        string CopySourceVersionIdHeader();
        string CopySourceSseCHeader();
        string CopySourceSseCKeyHeader();
        string CopySourceSseCKeyMd5Header();
        string MetadataDirectiveHeader();
        string DateHeader();
        string DeleteMarkerHeader();
        string HeaderPrefix();
        string HeaderMetaPrefix();
        string SecurityTokenHeader();
        string ContentSha256Header();

        string ExpirationHeader();
        string RestoreHeader();

        string ServerVersionHeader();

        string GrantReadHeader();
        string GrantWriteHeader();
        string GrantReadAcpHeader();
        string GrantWriteAcpHeader();
        string GrantFullControlHeader();
        string GrantReadDeliveredHeader();
        string GrantFullControlDeliveredHeader();

        string CopySourceIfModifiedSinceHeader();
        string CopySourceIfUnmodifiedSinceHeader();
        string CopySourceIfNoneMatchHeader();
        string CopySourceIfMatchHeader();

        string ObjectTypeHeader();
        string NextPositionHeader();

        string AzRedundancyHeader();
    }
}
