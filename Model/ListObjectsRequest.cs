


using System.Collections.Generic;

namespace OBS.Model
{
    /// <summary>
    /// 列举桶内对象的请求参数。
    /// </summary>
    public class ListObjectsRequest : ObsBucketWebServiceRequest
    {

        internal override string GetAction()
        {
            return "ListObjectsRequest";
        }


        /// <summary>
        /// 对象名进行分组的字符。
        /// </summary>
        /// <remarks>
        /// <para>
        /// 参数可选。
        /// 对于对象名中包含Delimiter的对象，其对象名（如果请求中指定了Prefix，则此处的对象名需要去掉Prefix）
        /// 中从首字符至第一个Delimiter之间的字符串将作为一个分组并作为CommonPrefix返回。
        /// </para>
        /// </remarks>
        public string Delimiter
        {
            get;
            set;
        }



        /// <summary>
        /// 列举对象时的起始位置。
        /// </summary>
        /// <remarks>
        /// <para>
        /// 参数可选。
        /// 列举对象的起始位置，返回的对象列表将是对象名按照字典序排序后该参数以后的所有对象。
        /// </para>
        /// </remarks>
        public string Marker
        {
            get;
            set;
        }


        /// <summary>
        /// 列举对象的最大条目数。
        /// </summary>
        /// <remarks>
        /// <para>
        /// 参数可选，默认列举最多1000个对象。
        /// </para>
        /// </remarks>
        public int? MaxKeys
        {
            get;
            set;
        }



        /// <summary>
        /// 列举对象时的对象名前缀。
        /// </summary>
        /// <remarks>
        /// <para>
        /// 参数可选。
        /// </para>
        /// </remarks>
        public string Prefix
        {
            get;
            set;
        }

    }
}
    
