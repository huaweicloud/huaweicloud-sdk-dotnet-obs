

namespace OBS.Model
{
    /// <summary>
    /// 列举桶内多版本对象的请求参数。
    /// </summary>
    public class ListVersionsRequest : ObsBucketWebServiceRequest
    {

        internal override string GetAction()
        {
            return "ListVersions";
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
        /// 列举多版本对象的起始位置（按对象名排序）。
        /// </summary>
        /// <remarks>
        /// <para>
        /// 参数可选。
        /// 返回的对象列表将是对象名按照字典序排序后该参数以后的所有对象。
        /// </para>
        /// </remarks>
        public string KeyMarker
        {
            get;
            set;
        }



        /// <summary>
        /// 列举多版本对象的最大条目数。
        /// </summary>
        /// <remarks>
        /// <para>
        /// 参数可选。
        /// 取值范围为1~1000，当超出范围时，按照默认的1000进行处理。
        /// </para>
        /// </remarks>
        public int? MaxKeys
        {
            get;
            set;
        }


        /// <summary>
        /// 列举多版本对象时的对象名前缀。
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



        /// <summary>
        /// 列举多版本对象的起始位置（按对象版本号排序）。
        /// </summary>
        /// <remarks>
        /// <para>
        /// 参数可选。
        /// 与KeyMarker配合使用，返回的对象列表将是对象名和版本号按照字典序排序后该参数以后的所有对象。
        /// 如果VersionIdMarker不是KeyMarker的一个版本号，则该参数无效。
        /// </para>
        /// </remarks>
        public string VersionIdMarker
        {
            get;
            set;
        }

    }
}

