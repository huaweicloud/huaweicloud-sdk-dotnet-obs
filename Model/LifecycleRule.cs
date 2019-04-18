
using System.Collections.Generic;
namespace OBS.Model
{
    /// <summary>
    /// 生命周期规则。
    /// </summary>
    public class LifecycleRule
    {
        
        private IList<Transition> transitions;
        private IList<NoncurrentVersionTransition> noncurrentVersionTransitions;

        /// <summary>
        /// 对象过期时间配置。
        /// </summary>
        /// <remarks>
        /// <para>
        /// 参数可选。
        /// </para>
        /// </remarks>
        public Expiration Expiration
        {
            get;
            set;
        }

        /// <summary>
        ///  规则ID，由不超过255个字符的字符串组成。
        /// </summary>
        /// <remarks>
        /// <para>
        /// 参数可选。
        /// </para>
        /// </remarks>
        public string Id
        {
            get;
            set;
        }


        /// <summary>
        /// 规则所匹配的对象名前缀。  
        /// </summary>
        /// <remarks>
        /// <para>
        /// 参数必选，用以标识哪些对象可以匹配到当前这条规则。可为空字符串，代表匹配桶内所有对象。
        /// </para>
        /// </remarks>
        public string Prefix
        {
            get;
            set;
        }


        /// <summary>
        /// 规则状态。
        /// </summary>
        /// <remarks>
        /// <para>
        /// 参数必选。
        /// </para>
        /// </remarks>
        public RuleStatusEnum Status
        {
            get;
            set;
        }

        /// <summary>
        /// 对象转换策略。
        /// </summary>
        /// <remarks>
        /// <para>
        /// 参数可选。
        /// </para>
        /// </remarks>
        public IList<Transition> Transitions
        {
            get {
                return this.transitions ?? (this.transitions = new List<Transition>()); }
            set { this.transitions = value; }
        }

        /// <summary>
        /// 历史版本对象过期时间配置。
        /// </summary>
        /// <remarks>
        /// <para>
        /// 参数可选。
        /// </para>
        /// </remarks>
        public NoncurrentVersionExpiration NoncurrentVersionExpiration
        {
            get;
            set;
        }

        /// <summary>
        /// 历史版本对象转换策略。
        /// </summary>
        /// <remarks>
        /// <para>
        /// 参数可选。
        /// </para>
        /// </remarks>
        public IList<NoncurrentVersionTransition> NoncurrentVersionTransitions
        {
            get {
                return this.noncurrentVersionTransitions ?? (this.noncurrentVersionTransitions = new List<NoncurrentVersionTransition>()); }
            set { this.noncurrentVersionTransitions = value; }
        }

    }
}
