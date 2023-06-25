---
title: IBybitRestClientSpotApiV1
has_children: false
parent: IBybitClientSpotApi\v1
grand_parent: Rest API documentation
---
*[generated documentation]*  
`BybitClient > SpotApi\v1 > IBybitRestClientSpotApiV1`  
*Bybit spot API endpoints (v1)*
  
***
*Get the ISpotClient for this client. This is a common interface which allows for some basic operations without knowing any details of the exchange.*  
**ISpotClient CommonSpotClient { get; }**  
***
*Endpoints related to account settings, info or actions*  
**IBybitRestClientSpotApiAccountV1 Account { get; }**  
***
*Endpoints related to retrieving market and system data*  
**IBybitRestClientSpotApiExchangeDataV1 ExchangeData { get; }**  
***
*Endpoints related to orders and trades*  
**IBybitRestClientSpotApiTradingV1 Trading { get; }**  
