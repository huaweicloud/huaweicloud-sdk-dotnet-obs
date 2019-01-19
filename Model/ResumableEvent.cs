using System;
using System.Collections.Generic;
using System.Text;

namespace OBS.Model
{
    /// <summary>
    /// 断点续传下载事件。
    /// </summary>
    public class ResumableDownloadEvent : EventArgs
    {
        internal ResumableDownloadEvent()
        {

        }

        /// <summary>
        /// 事件类型。
        /// </summary>
        public ResumableDownloadEventTypeEnum EventType
        {
            get;
            internal set;
        }

        /// <summary>
        /// 分段号。
        /// </summary>
        public int PartNumber
        {
            get;
            internal set;
        }

    }

    /// <summary>
    /// 断点续传上传事件。
    /// </summary>
    public class ResumableUploadEvent : EventArgs
    {

        internal ResumableUploadEvent()
        {
           
        }
       
        /// <summary>
        /// 事件类型。
        /// </summary>
        public ResumableUploadEventTypeEnum EventType
        {
            get;
            internal set;
        }

        /// <summary>
        /// 分段上传任务ID。
        /// </summary>
        public string UploadId
        {
            get;
            internal set;
        }
    
        /// <summary>
        /// 分段号。
        /// </summary>
        public int PartNumber
        {
            get;
            internal set;
        }

        /// <summary>
        /// ETag值。
        /// </summary>
        public string ETag
        {
            get;
            internal set;
        }


    }
}
