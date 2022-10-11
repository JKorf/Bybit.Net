---
title: IBybitClientSpotApiV1
has_children: false
parent: IBybitClientSpotApi\v1
grand_parent: Rest API documentation
---
*[generated documentation]*  
`BybitClient > SpotApi\v1 > SpotApiV1`  
*Bybit spot API endpoints (v1)*
  
***
*Get the ISpotClient for this client. This is a common interface which allows for some basic operations without knowing any details of the exchange.*  
**ISpotClient CommonSpotClient { get; }**  
***
*Endpoints related to account settings, info or actions*  
**[IBybitClientSpotApiAccountV1](IBybitClientSpotApiAccountV1.html) Account { get; }**  
***
*Endpoints related to retrieving market and system data*  
**[IBybitClientSpotApiExchangeDataV1](IBybitClientSpotApiExchangeDataV1.html) ExchangeData { get; }**  
***
*Endpoints related to orders and trades*  
**[IBybitClientSpotApiTradingV1](IBybitClientSpotApiTradingV1.html) Trading { get; }**  
