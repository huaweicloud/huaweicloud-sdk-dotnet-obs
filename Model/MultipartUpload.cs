using System;
namespace OBS.Model
{
    /// <summary>
    /// 分段上传任务。
    /// </summary>
    public class MultipartUpload
    {


        /// <summary>
        /// 分段上传任务的创建时间。 
        /// </summary>
        public DateTime? Initiated
        {
            get;
            internal set;
        }

        /// <summary>
        /// 分段上传任务的创建者。
        /// </summary>
        public Initiator Initiator
        {
            get;
            internal set;
        }

        /// <summary>
        /// 对象名。 
        /// </summary>
        public string ObjectKey
        {
            get;
            internal set;
        }


        /// <summary>
        /// 分段上传任务的所有者。
        /// </summary>
        public Owner Owner
        {
            get;
            internal set;
        }

        /// <summary>
        /// 分段上传任务对象的存储类型。  
        /// </summary>
        public StorageClassEnum? StorageClass
        {
            get;
            internal set;
        }

        /// <summary>
        /// 分段上传任务的ID号。
        /// </summary>
        public string UploadId
        {
            get;
            internal set;
        }

    }
}
