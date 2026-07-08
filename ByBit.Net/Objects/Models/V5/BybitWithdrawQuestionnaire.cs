using Bybit.Net;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Bybit.Net.Objects.Models.V5
{
    /// <summary>
    /// Withdrawal questionnaire base
    /// </summary>
    public abstract record BybitWithdrawQuestionnaire
    {
        /// <summary>
        /// Create a questionnaire for a withdrawal for Eu
        /// </summary>
        [JsonIgnore]
        public static BybitWithdrawQuestionnaireEu Eu => new BybitWithdrawQuestionnaireEu();
        /// <summary>
        /// Create a questionnaire for a withdrawal for Turkey
        /// </summary>
        [JsonIgnore]
        public static BybitWithdrawQuestionnaireTurkey Turkey => new BybitWithdrawQuestionnaireTurkey();
        /// <summary>
        /// Create a questionnaire for a withdrawal for Kazakhstan
        /// </summary>
        [JsonIgnore]
        public static BybitWithdrawQuestionnaireKazakhstan Kazakhstan => new BybitWithdrawQuestionnaireKazakhstan();
        /// <summary>
        /// Create a questionnaire for a withdrawal for India
        /// </summary>
        [JsonIgnore]
        public static BybitWithdrawQuestionnaireIndia India => new BybitWithdrawQuestionnaireIndia();
        /// <summary>
        /// Create a questionnaire for a withdrawal for Korea
        /// </summary>
        [JsonIgnore]
        public static BybitWithdrawQuestionnaireKorea Korea => new BybitWithdrawQuestionnaireKorea();


        /// <summary>
        /// ["<c>walletType</c>"] Wallet type. '0': custodial/VASP wallet. '1': non-custodial (personal) wallet
        /// </summary>
        [JsonPropertyName("walletType")]
        public int WalletType { get; set; }
        /// <summary>
        /// ["<c>legalType</c>"] Entity type. 'individual': natural person. 'company': legal entity / institution
        /// </summary>
        [JsonPropertyName("legalType")]
        public int LegalType { get; set; }
        /// <summary>
        /// ["<c>vaspCode</c>"] Counterparty VASP code. Required when 'walletType=0'. Use 'others' if not matched. Retrieve valid codes via the VASP List API
        /// </summary>
        [JsonPropertyName("vaspCode")]
        public string VaspCode { get; set; } = string.Empty;
        /// <summary>
        /// ["<c>isSelfWallet</c>"] Whether the wallet belongs to the user themselves. For non-custodial wallets only
        /// </summary>
        [JsonPropertyName("isSelfWallet")]
        public bool IsSelfWallet { get; set; }
        /// <summary>
        /// ["<c>firstName</c>"] First name. Required when 'legalType=individual'
        /// </summary>
        [JsonPropertyName("firstName")]
        public string? FirstName { get; set; }
        /// <summary>
        /// ["<c>lastName</c>"] Last name. Required when 'legalType=individual'
        /// </summary>
        [JsonPropertyName("lastName")]
        public string? LastName { get; set; }
        /// <summary>
        /// ["<c>companyName</c>"] Company / institution name. Required when 'legalType=company'
        /// </summary>
        [JsonPropertyName("companyName")]
        public string? CompanyName { get; set; }

#pragma warning disable IL2026 // Members annotated with 'RequiresUnreferencedCodeAttribute' require dynamic access otherwise can break functionality when trimming application code
#pragma warning disable IL3050 // Calling members annotated with 'RequiresDynamicCodeAttribute' may break functionality when AOT compiling.
        internal virtual string Serialize() => JsonSerializer.Serialize(this, SerializerOptions.WithConverters(BybitExchange._serializerContext).GetTypeInfo(GetType()))!;
#pragma warning restore IL3050 // Calling members annotated with 'RequiresDynamicCodeAttribute' may break functionality when AOT compiling.
#pragma warning restore IL2026 // Members annotated with 'RequiresUnreferencedCodeAttribute' require dynamic access otherwise can break functionality when trimming application code
    }

    /// <summary>
    /// EU withdraw questionnaire
    /// </summary>
    public record BybitWithdrawQuestionnaireEu : BybitWithdrawQuestionnaire
    {
        /// <summary>
        /// ["<c>transactionPurpose</c>"] Transaction purpose. Minimum 20 characters
        /// </summary>
        [JsonPropertyName("transactionPurpose")]
        public string TransactionPurpose { get; set; } = string.Empty;
    }

    /// <summary>
    /// Turkey withdraw questionnaire
    /// </summary>
    public record BybitWithdrawQuestionnaireTurkey : BybitWithdrawQuestionnaire
    {
        /// <summary>
        /// ["<c>poiType</c>"] Document type. ID_CARD / PASSPORT / DRIVERS / RESIDENCE_PERMIT / OTHER
        /// </summary>
        [JsonPropertyName("poiType")]
        public string PoiType { get; set; } = string.Empty;
        /// <summary>
        /// ["<c>poiNumber</c>"] Document number
        /// </summary>
        [JsonPropertyName("poiNumber")]
        public string PoiNumber { get; set; } = string.Empty;
        /// <summary>
        /// ["<c>poiIssuingCountry</c>"] Document issuing country, three-letter country code
        /// </summary>
        [JsonPropertyName("poiIssuingCountry")]
        public string PoiIssuingCountry { get; set; } = string.Empty;
        /// <summary>
        /// ["<c>poiExpiredDate</c>"] Document expiry date, YYYY-MM-DD
        /// </summary>
        [JsonPropertyName("poiExpiredDate")]
        public string PoiExpiredDate { get; set; } = string.Empty;
        /// <summary>
        /// ["<c>transactionPurpose</c>"] Transaction purpose. Minimum 20 characters
        /// </summary>
        [JsonPropertyName("transactionPurpose")]
        public string TransactionPurpose { get; set; } = string.Empty;
    }

    /// <summary>
    /// Kazakhstan withdraw questionnaire
    /// </summary>
    public record BybitWithdrawQuestionnaireKazakhstan : BybitWithdrawQuestionnaire
    {
        /// <summary>
        /// ["<c>poiType</c>"] Document type. ID_CARD / PASSPORT / DRIVERS / RESIDENCE_PERMIT / OTHER
        /// </summary>
        [JsonPropertyName("poiType")]
        public string PoiType { get; set; } = string.Empty;
        /// <summary>
        /// ["<c>poiNumber</c>"] Document number
        /// </summary>
        [JsonPropertyName("poiNumber")]
        public string PoiNumber { get; set; } = string.Empty;
        /// <summary>
        /// ["<c>poiIssuingCountry</c>"] Document issuing country, three-letter country code
        /// </summary>
        [JsonPropertyName("poiIssuingCountry")]
        public string PoiIssuingCountry { get; set; } = string.Empty;
        /// <summary>
        /// ["<c>poiExpiredDate</c>"] Document expiry date, YYYY-MM-DD
        /// </summary>
        [JsonPropertyName("poiExpiredDate")]
        public string PoiExpiredDate { get; set; } = string.Empty;
    }

    /// <summary>
    /// India withdraw questionnaire
    /// </summary>
    public record BybitWithdrawQuestionnaireIndia : BybitWithdrawQuestionnaire
    {
    }

    /// <summary>
    /// Korea withdraw questionnaire
    /// </summary>
    public record BybitWithdrawQuestionnaireKorea : BybitWithdrawQuestionnaire
    {
        /// <summary>
        /// ["<c>representativeFirstName</c>"] Company representative first name. Required when legalType=company (Korean SAFA requirement)
        /// </summary>
        [JsonPropertyName("representativeFirstName")]
        public string RepresentativeFirstName { get; set; } = string.Empty;
        /// <summary>
        /// ["<c>representativeLastName</c>"] Company representative last name. Required when legalType=company (Korean SAFA requirement)
        /// </summary>
        [JsonPropertyName("representativeLastName")]
        public string RepresentativeLastName { get; set; } = string.Empty;
    }
}

