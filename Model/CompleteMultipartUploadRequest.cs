using System.Collections.Generic;

namespace OBS.Model
{
    /// <summary>
    /// 合并段的请求参数。
    /// </summary>
    public class CompleteMultipartUploadRequest : ObsBucketWebServiceRequest
    {
        internal override string GetAction()
        {
            return "CompleteMultipartUpload";
        }

        private IList<PartETag> partETags;


        /// <summary>
        /// 对象名。
        /// </summary>
        /// <remarks>
        /// <para>
        /// 参数必选。
        ///  </para> 
        /// </remarks>
        public string ObjectKey
        {
            get;
            set;
        }


        /// <summary>
        /// 待合并的段列表。
        /// </summary>
        /// <remarks>
        /// <para>
        /// 参数必选。
        ///  </para> 
        /// </remarks>
        public IList<PartETag> PartETags
        {
            get
            {
                return this.partETags ?? (this.partETags = new List<PartETag>());
            }
            set { this.partETags = value; }
        }

        /// <summary>
        /// 添加段信息到待合并的段列表。
        /// </summary>
        /// <param name="partETags">待添加段信息。</param>
        public void AddPartETags(params PartETag[] partETags)
        {
            foreach (PartETag part in partETags)
            {
                this.PartETags.Add(part);
            }
        }

        /// <summary>
        ///  添加段信息到待合并的段列表。
        /// </summary>
        /// <param name="partETags">待添加段信息。</param>
        public void AddPartETags(IEnumerable<PartETag> partETags)
        {
            foreach (PartETag part in partETags)
            {
                this.PartETags.Add(part);
            }
        }

        /// <summary>
        /// 从分段上传的响应中取出段信息，添加到待合并的段列表。
        /// </summary>
        /// <param name="responses">分段上传的响应。</param>
        public void AddPartETags(params UploadPartResponse[] responses)
        {
            foreach (UploadPartResponse response in responses)
            {
                this.PartETags.Add(new  PartETag(response.PartNumber, response.ETag));
            }
        }

        /// <summary>
        /// 从分段上传的响应中取出段信息，添加到待合并的段列表。
        /// </summary>
        /// <param name="responses">分段上传的响应。</param>
        public void AddPartETags(IEnumerable<UploadPartResponse> responses)
        {
            foreach (UploadPartResponse response in responses)
            {
                this.PartETags.Add(new PartETag(response.PartNumber, response.ETag));
            }
        }

        /// <summary>
        ///从拷贝段的响应中取出段信息，添加到待合并的段列表。
        /// </summary>
        /// <param name="responses">拷贝段的响应。</param>
        public void AddPartETags(params CopyPartResponse[] responses)
        {
            foreach (CopyPartResponse response in responses)
            {
                this.PartETags.Add(new PartETag(response.PartNumber, response.ETag));
            }
        }

        /// <summary>
        /// 从拷贝段的响应中取出段信息，添加到待合并的段列表。
        /// </summary>
        /// <param name="responses">拷贝段的响应。</param>
        public void AddPartETags(IEnumerable<CopyPartResponse> responses)
        {
            foreach (CopyPartResponse response in responses)
            {
                this.PartETags.Add(new PartETag(response.PartNumber, response.ETag));
            }
        }

        /// <summary>
        /// 分段上传任务的ID。
        /// </summary>
        /// <remarks>
        /// <para>
        /// 参数必选。
        ///  </para> 
        /// </remarks>
        public string UploadId
        {
            get;
            set;
        }

    }
}
    
