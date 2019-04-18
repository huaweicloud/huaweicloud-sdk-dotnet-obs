

namespace OBS.Internal.Auth
{
    internal class V2Signer : AbstractSigner
    {

        private static V2Signer instance = new V2Signer();

        private V2Signer()
        {

        }

        public static Signer GetInstance()
        {
            return instance;
        }

        protected override string GetAuthPrefix()
        {
            return "AWS";
        }

    }
}
