---
title: IBybitRestClientSpotApiV1
has_children: false
parent: IBybitRestClientSpotApi\v1
grand_parent: Rest API documentation
---
*[generated documentation]*  
`BybitRestClient > SpotApi\v1 > SpotApiV1`  
*[DEPRECATED, WILL STOP WORKING ON 16/30 OCTOBER, USE V5 API INSTEAD] Bybit spot API endpoints (v1)*
  
***
*Get the ISpotClient for this client. This is a common interface which allows for some basic operations without knowing any details of the exchange.*  
**ISpotClient CommonSpotClient { get; }**  
***
*Endpoints related to account settings, info or actions*  
**[IBybitRestClientSpotApiAccountV1](IBybitRestClientSpotApiAccountV1.html) Account { get; }**  
***
*Endpoints related to retrieving market and system data*  
**[IBybitRestClientSpotApiExchangeDataV1](IBybitRestClientSpotApiExchangeDataV1.html) ExchangeData { get; }**  
***
*Endpoints related to orders and trades*  
**[IBybitRestClientSpotApiTradingV1](IBybitRestClientSpotApiTradingV1.html) Trading { get; }**  
