using System;
using System.Collections.Generic;
using System.Text;

namespace OBS.Internal.Auth
{
    internal class ObsSigner : AbstractSigner
    {

        private static ObsSigner instance = new ObsSigner();

        private ObsSigner()
        {

        }

        public static Signer GetInstance()
        {
            return instance;
        }

        protected override string GetAuthPrefix()
        {
            return "OBS";
        }
    }
}
