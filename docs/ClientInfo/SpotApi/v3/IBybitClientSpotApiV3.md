---
title: IBybitClientSpotApiV3
has_children: false
parent: IBybitClientSpotApi\v3
grand_parent: Rest API documentation
---
*[generated documentation]*  
`BybitClient > SpotApi\v3 > SpotApiV3`  
*Bybit spot API endpoints (v3)*
  
***
*Get the ISpotClient for this client. This is a common interface which allows for some basic operations without knowing any details of the exchange.*  
**ISpotClient CommonSpotClient { get; }**  
***
*Endpoints related to account settings, info or actions*  
**[IBybitClientSpotApiAccountV3](IBybitClientSpotApiAccountV3.html) Account { get; }**  
***
*Endpoints related to retrieving market and system data*  
**[IBybitClientSpotApiExchangeDataV3](IBybitClientSpotApiExchangeDataV3.html) ExchangeData { get; }**  
***
*Endpoints related to orders and trades*  
**[IBybitClientSpotApiTradingV3](IBybitClientSpotApiTradingV3.html) Trading { get; }**  
