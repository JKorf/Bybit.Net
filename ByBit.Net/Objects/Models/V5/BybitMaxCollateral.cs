using System.Text.Json.Serialization;

namespace Bybit.Net.Objects.Models.V5
{
    /// <summary>
    /// Max collateral info
    /// </summary>
    [SerializationModel]
    public record BybitMaxCollateral
    {
        /// <summary>
        /// Max collateral quantity
        /// </summary>
        [JsonPropertyName("maxCollateralAmount")]
        public decimal MaxCollateralQuantity { get; set; }
    }


}
