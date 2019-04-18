
using System.Collections.Generic;

namespace OBS.Model
{
    public partial class DeleteObjectsRequest : ObsBucketWebServiceRequest
    {

        public void AddKey(string key)
        {
            AddKey(new KeyVersion { Key = key });
        }

        public void AddKey(string key, string versionId)
        {
            KeyVersion kv = new KeyVersion();
            kv.Key = key;
            kv.VersionId = versionId;
            AddKey(kv);
        }

        private void AddKey(KeyVersion keyVersion)
        {
            this.Objects.Add(keyVersion);
        }
    }
}
