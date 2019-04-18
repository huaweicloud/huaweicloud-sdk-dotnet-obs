
using OBS.Internal;
using System;
using System.Collections.Generic;

namespace OBS.Model
{
    /// <summary>
    /// 自定义元数据信息。
    /// </summary>
    public sealed class MetadataCollection
    {
        
        private IDictionary<string, string> values = new Dictionary<string, string>();

        /// <summary>
        /// 自定义元数据。
        /// </summary>
        /// <param name="name">元数据元素名。</param>
        /// <returns>元数据元素值。</returns>
        public string this[string name]
        {
            get
            {
                string value;
                if (values.TryGetValue(name, out value))
                {
                    return value;
                }

                return null;
            }
            set
            {
                values[name] = value;
            }
        }

        /// <summary>
        /// 添加自定义元数据。
        /// </summary>
        /// <param name="name">元数据元素名。</param>
        /// <param name="value">元数据元素值。</param>
        public void Add(string name, string value)
        {
            this[name] = value;
        }

        /// <summary>
        /// 对应元数据头域个数。
        /// </summary>
        public int Count
        {
            get { return this.values.Count; }
        }

        /// <summary>
        /// 元数据元素名集合。
        /// </summary>
        public ICollection<string> Keys
        {
            get { return values.Keys; }
        }

        /// <summary>
        /// 元数据元素值集合。
        /// </summary>
        public ICollection<string> Values
        {
            get { return values.Values; }
        }

        /// <summary>
        /// 元数据键值对。
        /// </summary>
        public IList<KeyValuePair<string, string>> KeyValuePairs
        {
            get { return new List<KeyValuePair<string, string>>(this.values); }
        }
    }
}
