---
title: IBybitRestClientSpotApiV3
has_children: false
parent: IBybitClientSpotApi\v3
grand_parent: Rest API documentation
---
*[generated documentation]*  
`BybitClient > SpotApi\v3 > IBybitRestClientSpotApiV3`  
*Bybit spot API endpoints (v3)*
  
***
*Get the ISpotClient for this client. This is a common interface which allows for some basic operations without knowing any details of the exchange.*  
**ISpotClient CommonSpotClient { get; }**  
***
*Endpoints related to account settings, info or actions*  
**IBybitRestClientSpotApiAccountV3 Account { get; }**  
***
*Endpoints related to retrieving market and system data*  
**IBybitRestClientSpotApiExchangeDataV3 ExchangeData { get; }**  
***
*Endpoints related to orders and trades*  
**IBybitRestClientSpotApiTradingV3 Trading { get; }**  
