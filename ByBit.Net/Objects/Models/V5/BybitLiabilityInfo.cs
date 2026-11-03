using System.Text.Json.Serialization;

namespace Bybit.Net.Objects.Models.V5
{
    /// <summary>
    /// UTA loan liability info of an asset
    /// </summary>
    [SerializationModel]
    public record BybitLiabilityInfo
    {
        /// <summary>
        /// ["<c>currency</c>"] Asset
        /// </summary>
        [JsonPropertyName("currency")]
        public string Asset { get; set; } = string.Empty;
        /// <summary>
        /// ["<c>totalBorrowAmount</c>"] Total liability
        /// </summary>
        [JsonPropertyName("totalBorrowAmount")]
        public decimal TotalBorrowQuantity { get; set; }
        /// <summary>
        /// ["<c>fixedBorrowAmount</c>"] Fixed-rate liability
        /// </summary>
        [JsonPropertyName("fixedBorrowAmount")]
        public decimal FixedBorrowQuantity { get; set; }
        /// <summary>
        /// ["<c>flexibleBorrowAmount</c>"] Floating-rate liability
        /// </summary>
        [JsonPropertyName("flexibleBorrowAmount")]
        public decimal FlexibleBorrowQuantity { get; set; }
        /// <summary>
        /// ["<c>spotTotalBorrow</c>"] Spot liability plus open order liability
        /// </summary>
        [JsonPropertyName("spotTotalBorrow")]
        public decimal SpotTotalBorrowQuantity { get; set; }
        /// <summary>
        /// ["<c>derivativesBorrow</c>"] Derivatives liability
        /// </summary>
        [JsonPropertyName("derivativesBorrow")]
        public decimal DerivativesBorrowQuantity { get; set; }
    }
}