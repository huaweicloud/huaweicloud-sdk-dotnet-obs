
using System.Collections.Generic;

namespace OBS.Model
{
    /// <summary>
    /// 列举桶内多版本对象的响应结果。
    /// </summary>
    public class ListVersionsResponse : ObsWebServiceResponse
    {

        private IList<ObsObjectVersion> versions;
        private IList<string> commonPrefixes;

        /// <summary>
        /// 判断列举结果是否被截断。
        ///  true表示截断，本次没有返回全部结果；false表示未截断，本次已经返回了全部结果。
        /// </summary>
        public bool IsTruncated
        {
            get;
            internal set;
        }


        /// <summary>
        /// 本次请求的起始位置（按对象名排序）。
        /// </summary>
        public string KeyMarker
        {
            get;
            internal set;
        }


        /// <summary>
        /// 本次请求的起始位置（按对象版本号排序）。
        /// </summary>
        public string VersionIdMarker
        {
            get;
            internal set;
        }


        /// <summary>
        /// 下次请求的起始位置（按对象名排序）。
        /// </summary>
        public string NextKeyMarker
        {
            get;
            internal set;
        }


        /// <summary>
        /// 下次请求的起始位置（按对象版本号排序）。
        /// </summary>
        public string NextVersionIdMarker
        {
            get;
            internal set;
        }


        /// <summary>
        /// 多版本对象列表。
        /// </summary>
        public IList<ObsObjectVersion> Versions
        {
            get {
               
                return this.versions ?? (this.versions = new List<ObsObjectVersion>()); }
            internal set { this.versions = value; }
        }


        /// <summary>
        /// 桶名。
        /// </summary>
        public string BucketName
        {
            get;
            internal set;
        }

        /// <summary>
        /// 本次请求的对象名前缀。
        /// </summary>
        public string Prefix
        {
            get;
            internal set;
        }

        /// <summary>
        /// 本次请求的最大条目数。
        /// </summary>
        public int? MaxKeys
        {
            get;
            internal set;
        }

        /// <summary>
        /// 分组后的对象名前缀列表。
        /// </summary>
        public IList<string> CommonPrefixes
        {
            get {
                
                return this.commonPrefixes ?? (this.commonPrefixes = new List<string>()); }
            internal set { this.commonPrefixes = value; }
        }

        /// <summary>
        /// 本次请求对对象名进行分组的字符。
        /// </summary>
        public string Delimiter
        {
            get;
            internal set;
        }

        /// <summary>
        /// 桶的区域位置
        /// </summary>
        public string Location
        {
            get;
            internal set;
        }

    }
}
    
