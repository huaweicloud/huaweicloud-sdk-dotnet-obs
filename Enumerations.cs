


using System;

namespace OBS
{

    /// <summary>
    /// 鉴权类型
    /// </summary>
    public enum AuthTypeEnum
    {
        /// <summary>
        /// V2协议。
        /// </summary>
        V2,

        /// <summary>
        /// V4协议。
        /// </summary>
        [Obsolete]
        V4,

        /// <summary>
        /// OBS协议。
        /// </summary>
        OBS
    }



    public enum ErrorType
    {

        Sender,

        Receiver,

        Unknown
    }
}