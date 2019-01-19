using System;
using System.Collections.Generic;
using System.Reflection;
using OBS.Internal;

namespace OBS.Model
{
    /// <summary>
    /// 桶的集群类型
    /// </summary>
    public enum AvailableZoneEnum
    {
        [StringValue("3az")]
        MultiAz
    }

    /// <summary>
    /// 进度反馈方式。
    /// </summary>
    public enum ProgressTypeEnum
    {
        /// <summary>
        /// 以传输字节数为基准。
        /// </summary>
        ByBytes,
        /// <summary>
        /// 以秒为基准。
        /// </summary>
        BySeconds
    }

    /// <summary>
    /// 断点续传上传事件类型。
    /// </summary>
    public enum ResumableUploadEventTypeEnum
    {
        InitiateMultipartUploadSucceed,
        InitiateMultipartUploadFailed,
        UploadPartSucceed,
        UploadPartFailed,
        CompleteMultipartUploadSucceed,
        CompleteMultipartUploadFailed
    }

    /// <summary>
    /// 断点续传下载事件类型。
    /// </summary>
    public enum ResumableDownloadEventTypeEnum
    {
        DownloadPartSucceed,
        DownloadPartFailed,
    }


    /// <summary>
    /// 发布消息通知的事件类型。
    /// </summary>
    public enum EventTypeEnum
    {
        /// <summary>
        /// 所有创建对象事件。
        /// </summary>
        [StringValue("ObjectCreated:*")]
        ObjectCreatedAll,
        /// <summary>
        /// PUT上传对象事件。
        /// </summary>
        [StringValue("ObjectCreated:Put")]
        ObjectCreatedPut,
        /// <summary>
        /// POST上传对象事件。
        /// </summary>
        [StringValue("ObjectCreated:Post")]
        ObjectCreatedPost,

        /// <summary>
        /// 复制对象事件。
        /// </summary>
        [StringValue("ObjectCreated:Copy")]
        ObjectCreatedCopy,
        /// <summary>
        /// 合并段事件。
        /// </summary>
        [StringValue("ObjectCreated:CompleteMultipartUpload")]
        ObjectCreatedCompleteMultipartUpload,
        /// <summary>
        /// 所有删除对象事件。
        /// </summary>
        [StringValue("ObjectRemoved:*")]
        ObjectRemovedAll,
        /// <summary>
        /// 指定对象版本号删除对象事件。
        /// </summary>
        [StringValue("ObjectRemoved:Delete")]
        ObjectRemovedDelete,
        /// <summary>
        /// 多版本开启后，不指定对象版本号删除对象事件。
        /// </summary>
        [StringValue("ObjectRemoved:DeleteMarkerCreated")]
        ObjectRemovedDeleteMarkerCreated
    }

    /// <summary>
    /// HTTP方法类型
    /// </summary>
    public enum HttpVerb
    {
        /// <summary>
        /// HTTP GET请求。
        /// </summary>
        GET,
        /// <summary>
        /// HTTP HEAD请求。
        /// </summary>
        HEAD,
        /// <summary>
        /// HTTP PUT请求。
        /// </summary>
        PUT,
        /// <summary>
        /// HTTP POST请求。
        /// </summary>
        POST,
        /// <summary>
        /// HTTP DELETE请求。
        /// </summary>
        DELETE
    }

    /// <summary>
    /// 存储类型。
    /// </summary>
    public enum StorageClassEnum
    {
        /// <summary>
        /// 标准存储。
        /// </summary>
        [StringValue("STANDARD")]
        Standard,

        /// <summary>
        /// 低频访问存储。
        /// </summary>
        [StringValue("STANDARD_IA")]
        Warm,

        /// <summary>
        /// 归档存储。
        /// </summary>
        [StringValue("GLACIER")]
        Cold
    }

    /// <summary>
    /// 预定义访问策略。
    /// </summary>
    public enum CannedAclEnum
    {
        /// <summary>
        /// 私有读写。
        /// </summary>
        [StringValue("private")]
        Private,

        /// <summary>
        /// 公共读私有写。
        /// </summary>
        [StringValue("public-read")]
        PublicRead,

        /// <summary>
        /// 公共读写。
        /// </summary>
        [StringValue("public-read-write")]
        PublicReadWrite,

        /// <summary>
        /// 桶公共读，桶内对象公共读
        /// </summary>
        [StringValue("public-read-delivered")]
        PublicReadDelivered,

        /// <summary>
        /// 桶公共读写，桶内对象公共读写
        /// </summary>
        [StringValue("public-read-write-delivered")]
        PublicReadWriteDelivered,

        /// <summary>
        /// 授权用户读私有写。
        /// </summary>
        [StringValue("authenticated-read")]
        [Obsolete]
        AuthenticatedRead,

        /// <summary>
        /// 桶所有者读对象所有者读写。
        /// </summary>
        [StringValue("bucket-owner-read")]
        [Obsolete]
        BucketOwnerRead,

        /// <summary>
        /// 桶所有者读写对象所有者读写。
        /// </summary>
        [StringValue("bucket-owner-full-control")]
        [Obsolete]
        BucketOwnerFullControl,

        /// <summary>
        /// 日志投递组写。
        /// </summary>
        [StringValue("log-delivery-write")]
        [Obsolete]
        LogDeliveryWrite

    }

    /// <summary>
    /// OBS桶扩展权限。
    /// </summary>
    public enum ExtensionBucketPermissionEnum
    {
        /// <summary>
        /// 授予domainId下的所有用户读权限，列举对象、列举多段任务、列举桶多版本、获取桶元数据。
        /// </summary>
        GrantRead,

        /// <summary>
        /// 授予domainId下的所有用户写权限，允许创建、删除、覆盖桶内所有对象，允许初始化段、上传段、拷贝段、合并段、取消多段上传任务。
        /// </summary>
        GrantWrite,

        /// <summary>
        /// 授予domainId下的所有用户读ACP权限，允许读桶的ACL信息。
        /// </summary>
        GrantReadAcp,

        /// <summary>
        /// 授予domainId下的所有用户写ACP权限，允许修改桶的ACL信息。
        /// </summary>
        GrantWriteAcp,

        /// <summary>
        /// 授予domainId下的所有用户完全控制权限。
        /// </summary>
        GrantFullControl,

        /// <summary>
        /// 授予domainId下的所有用户读权限，且在默认情况下，该读权限将传递给桶内所有对象。
        /// </summary>
        GrantReadDelivered,

        /// <summary>
        /// 授予domainId下的所有用户完全控制权限，且在默认情况下，该完全控制权限将传递给桶内所有对象。
        /// </summary>
        GrantFullControlDelivered
    }

    /// <summary>
    /// OBS桶扩展权限。
    /// </summary>
    public enum ExtensionObjectPermissionEnum
    {
        /// <summary>
        /// 授予domainId下的所有用户读权限，允许读对象、获取对象元数据
        /// </summary>
        GrantRead,

        /// <summary>
        /// 授予domainId下的所有用户读ACP权限，允许读对象的ACL信息
        /// </summary>
        GrantReadAcp,

        /// <summary>
        /// 授予domainId下的所有用户写ACP权限，允许修改对象的ACL信息
        /// </summary>
        GrantWriteAcp,

        /// <summary>
        /// 授予domainId下的所有用户完全控制权限，允许读对象、获取对象元数据、获取对象ACL信息、写对象ACL信息
        /// </summary>
        GrantFullControl
    }

    /// <summary>
    /// 规则状态。
    /// </summary>
    public enum RuleStatusEnum
    {
        /// <summary>
        /// 启用规则。
        /// </summary>
        Enabled,
        /// <summary>
        /// 禁用规则。
        /// </summary>
        Disabled
    }

    /// <summary>
    /// 权限类型。
    /// </summary>
    public enum PermissionEnum
    {
        /// <summary>
        /// 读权限。
        /// </summary>
        [StringValue("READ")]
        Read,

        /// <summary>
        /// 写权限。
        /// </summary>
        [StringValue("WRITE")]
        Write,

        /// <summary>
        /// 读ACP权限。
        /// </summary>
        [StringValue("READ_ACP")]
        ReadAcp,

        /// <summary>
        /// 写ACP权限。
        /// </summary>
        [StringValue("WRITE_ACP")]
        WriteAcp,

        /// <summary>
        /// 完全控制权限。
        /// </summary>
        [StringValue("FULL_CONTROL")]
        FullControl
    }

    /// <summary>
    /// 复制策略。
    /// </summary>
    public enum MetadataDirectiveEnum
    {
        /// <summary>
        /// 复制对象时，复制源对象属性。
        /// </summary>
        Copy,

        /// <summary>
        /// 复制对象时，重写源对象属性。
        /// </summary>
        Replace
    }

    /// <summary>
    /// 重定向协议
    /// </summary>
    public enum ProtocolEnum
    {
        /// <summary>
        /// 重定向请求时使用HTTP协议。
        /// </summary>
        Http,

        /// <summary>
        /// 重定向请求时使用HTTPS协议。
        /// </summary>
        Https
    }

    /// <summary>
    /// 子资源类型。
    /// </summary>
    public enum SubResourceEnum
    {
        /// <summary>
        /// 获取桶区域位置信息。
        /// </summary>
        [StringValue("location")]
        Location,

        /// <summary>
        ///  获取桶存量信息。
        /// </summary>
        [StringValue("storageinfo")]
        StorageInfo,

        /// <summary>
        /// 获取/设置桶配额。
        /// </summary>
        [StringValue("quota")]
        Quota,

        /// <summary>
        /// 获取/设置桶（对象）设置访问权限。
        /// </summary>
        [StringValue("acl")]
        Acl,

        /// <summary>
        /// 获取/设置桶日志管理配置。
        /// </summary>
        [StringValue("logging")]
        Logging,

        /// <summary>
        /// 获取/设置/删除桶策略。
        /// </summary>
        [StringValue("policy")]
        Policy,

        /// <summary>
        /// 获取/设置/删除桶的生命周期规则。
        /// </summary>
        [StringValue("lifecycle")]
        Lifecyle,

        /// <summary>
        /// 获取/设置/删除桶的托管配置。
        /// </summary>
        [StringValue("website")]
        Website,

        /// <summary>
        /// 获取/设置桶的多版本状态。
        /// </summary>
        [StringValue("versioning")]
        Versioning,

        /// <summary>
        /// 获取/设置桶的存储类型。
        /// </summary>
        [StringValue("storageClass")]
        StorageClass,

        /// <summary>
        /// 获取/设置桶的存储策略。
        /// </summary>
        [StringValue("storagePolicy")]
        [Obsolete]
        StoragePolicy,

        /// <summary>
        /// 追加上传对象。
        /// </summary>
        [StringValue("append")]
        Append,

        /// <summary>
        /// 获取/设置/删除桶的跨域资源共享配置。
        /// </summary>
        [StringValue("cors")]
        Cors,

        /// <summary>
        /// 列举/初始化分段上传任务。
        /// </summary>
        [StringValue("uploads")]
        Uploads,

        /// <summary>
        /// 列举桶内多版本对象。
        /// </summary>
        [StringValue("versions")]
        Versions,

        /// <summary>
        /// 批量删除对象。
        /// </summary>
        [StringValue("delete")]
        Delete,

        /// <summary>
        /// 取回归档存储对象。
        /// </summary>
        [StringValue("restore")]
        Restore,

        /// <summary>
        /// 设置/获取/删除桶标签。
        /// </summary>
        [StringValue("tagging")]
        Tagging,

        /// <summary>
        /// 设置/获取桶的通知配置。
        /// </summary>
        [StringValue("notification")]
        Notification,

        /// <summary>
        /// 设置/获取/删除桶的跨Region复制配置。
        /// </summary>
        [StringValue("replication")]
        Replication,

    }


    /// <summary>
    /// 可被授权的用户组
    /// </summary>
    public enum GroupGranteeEnum
    {
        /// <summary>
        /// 匿名用户组，代表所有用户
        /// </summary>
        [StringValue("http://acs.amazonaws.com/groups/global/AllUsers")]
        AllUsers,

        /// <summary>
        /// OBS授权用户组，代表任何拥有OBS账户的用户
        /// </summary>
        [StringValue("http://acs.amazonaws.com/groups/global/AuthenticatedUsers")]
        [Obsolete]
        AuthenticatedUsers,

        /// <summary>
        /// 日志投递用户组，一般用户配置访问日志
        /// </summary>
        [StringValue("http://acs.amazonaws.com/groups/s3/LogDelivery")]
        [Obsolete]
        LogDelivery
    }


    /// <summary>
    /// 取回选项。
    /// </summary>
    public enum RestoreTierEnum
    {
        /// <summary>
        ///快速取回，取回对象耗时1~5分钟。
        /// </summary>
        Expedited,

        /// <summary>
        ///标准取回，表示取回对象耗时3~5 小时。
        /// </summary>
        Standard,

        /// <summary>
        /// 批量取回，取回对象耗时5~12 小时。
        /// </summary>
        [Obsolete]
        Bulk

    }

    /// <summary>
    /// SSE-C加密算法的类型。
    /// </summary>
    public enum SseCAlgorithmEnum
    {
        /// <summary>
        /// AES256算法
        /// </summary>
        Aes256
    }

    /// <summary>
    /// SSE-KMS加密算法类型。
    /// </summary>
    public enum SseKmsAlgorithmEnum
    {
        /// <summary>
        /// 基础KMS算法
        /// </summary>
        [StringValue("kms")]
        Kms
    }

    /// <summary>
    /// 多版本状态
    /// </summary>
    public enum VersionStatusEnum
    {
        /// <summary>
        /// 开启多版本。
        /// </summary>
        Enabled,
        /// <summary>
        /// 暂停多版本。
        /// </summary>
        Suspended
    }


    /// <summary>
    /// 过滤方式。
    /// </summary>
    public enum FilterNameEnum
    {
        /// <summary>
        /// 以前缀过滤。
        /// </summary>
        Prefix,

        /// <summary>
        /// 以后缀过滤。
        /// </summary>
        Suffix

    }

}