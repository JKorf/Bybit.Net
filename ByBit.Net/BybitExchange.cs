namespace Bybit.Net
{
    /// <summary>
    /// Bybit exchange information and configuration
    /// </summary>
    public static class BybitExchange
    {
        /// <summary>
        /// Exchange name
        /// </summary>
        public static string ExchangeName => "Bybit";

        /// <summary>
        /// Url to the main website
        /// </summary>
        public static string Url { get; } = "https://www.bybit.com";

        /// <summary>
        /// Urls to the API documentation
        /// </summary>
        public static string[] ApiDocsUrl { get; } = new[] {
            "https://bybit-exchange.github.io/docs/v3/intro",
            "https://bybit-exchange.github.io/docs/v5/intro"
            };
    }
}
