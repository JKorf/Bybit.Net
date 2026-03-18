using CryptoExchange.Net.Authentication;
using System;
using System.Linq;

namespace Bybit.Net
{
    /// <summary>
    /// Bybit credentials
    /// </summary>
    public class BybitCredentials : ApiCredentials
    {
        internal CredentialPair Credential { get; set; }

        public HMACCredential? HMAC
        {
            get => Credential as HMACCredential;
            set { if (value != null) Credential = value; }
        }

        public RSAXmlCredential? RSAXml
        {
            get => Credential as RSAXmlCredential;
            set { if (value != null) Credential = value; }
        }

#if NETSTANDARD2_1_OR_GREATER || NET7_0_OR_GREATER
        public RSAPemCredential? RSAPem
        {
            get => Credential as RSAPemCredential;
            set { if (value != null) Credential = value; }
        }
#endif

        public BybitCredentials WithHMAC(string key, string secret)
        {
            if (Credential != null) throw new InvalidOperationException("Credentials already set");

            Credential = new HMACCredential(key, secret);
            return this;
        }

        public BybitCredentials WithRSAXml(string key, string privateKey)
        {
            if (Credential != null) throw new InvalidOperationException("Credentials already set");

            Credential = new RSAXmlCredential(key, privateKey);
            return this;
        }

#if NETSTANDARD2_1_OR_GREATER || NET7_0_OR_GREATER
        public BybitCredentials WithRSAPem(string key, string privateKey)
        {
            if (Credential != null) throw new InvalidOperationException("Credentials already set");

            Credential = new RSAPemCredential(key, privateKey);
            return this;
        }
#endif

        /// <inheritdoc />
        public override ApiCredentials Copy() => new BybitCredentials { Credential = Credential };
    }
}
