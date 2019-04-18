
using System.Collections.Generic;

namespace OBS.Model
{
    /// <summary>
    /// 批量删除对象的响应结果。
    /// </summary>
    public class DeleteObjectsResponse : ObsWebServiceResponse
    {
        private IList<DeletedObject> deleted;
        private IList<DeleteError> errors;

        /// <summary>
        /// 删除成功的对象列表。
        /// </summary>
        public IList<DeletedObject> DeletedObjects
        {
            get {
               
                return this.deleted ?? (this.deleted = new List<DeletedObject>());
            }
            internal set { this.deleted = value; }
        }

        /// <summary>
        /// 删除失败的结果列表。
        /// </summary>
        public IList<DeleteError> DeleteErrors
        {
            get {
               
                return this.errors ?? (this.errors = new List<DeleteError>());
            }
            internal set { this.errors = value; }
        }

    }
}
    
