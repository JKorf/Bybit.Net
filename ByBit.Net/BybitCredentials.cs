using CryptoExchange.Net.Authentication;
using System.Linq;

namespace Bybit.Net
{
    /// <summary>
    /// Bybit credentials
    /// </summary>
    public class BybitCredentials : ApiCredentials
    {
        /// <summary>
        /// Credential type provided
        /// </summary>
        public ApiCredentialsType CredentialType => CredentialPairs.First().CredentialType;

        internal string? Passphrase =>
            CredentialType == ApiCredentialsType.Hmac ? GetCredential<HMACCredential>()?.Pass
            : CredentialType == ApiCredentialsType.Rsa ? GetCredential<RSACredential>()?.Passphrase
            : null;

        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="apiKey">The API key</param>
        /// <param name="secret">The API secret</param>
        public BybitCredentials(string apiKey, string secret) : this(new HMACCredential(apiKey, secret)) { }

        /// <summary>
        /// Create Bybit credentials using HMAC credentials
        /// </summary>
        /// <param name="credential">The HMAC credentials</param>
        public BybitCredentials(HMACCredential credential) : base(credential) { }

        /// <summary>
        /// Create Bybit credentials using RSA credentials
        /// </summary>
        /// <param name="rsaCredential">RSA credentials</param>
        public BybitCredentials(RSACredential rsaCredential)
            : base(rsaCredential)
        {
        }

        /// <inheritdoc />
        public override ApiCredentials Copy() =>
            CredentialType switch
            {
                ApiCredentialsType.Hmac => new BybitCredentials(GetCredential<HMACCredential>()!),
                ApiCredentialsType.Rsa => new BybitCredentials(GetCredential<RSACredential>()!)
            };
    }
}
