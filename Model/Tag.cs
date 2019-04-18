
namespace OBS.Model
{
    /// <summary>
    /// 桶标签。
    /// </summary>
    public class Tag
    {
        

        /// <summary>
        /// 标签键。 
        /// </summary>
        /// <remarks>
        /// <para>
        /// 参数必选。
        /// 最大36个字符。可以包含：A-Z，a-z，0-9，’-’，’_’以及Unicode(\u4E00-\u9FFF)。同一个桶，Tag的Key不能重复。
        /// </para>
        /// </remarks>
        public string Key
        {
            get;
            set;
        }

        /// <summary>
        /// 标签值。 
        /// </summary>
        /// <remarks>
        /// <para>
        /// 参数必选。
        /// 最大值为43个字符。可以包含：A-Z，a-z，0-9，’-’，’_’，’.’以及Unicode(\u4E00-\u9FFF)。
        /// </para>
        /// </remarks>
        public string Value
        {
            get;
            set;
        }

    }
}
