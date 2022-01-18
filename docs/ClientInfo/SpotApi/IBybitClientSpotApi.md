---
title: IBybitClientSpotApi
has_children: true
parent: Rest API documentation
---
*[generated documentation]*  
`BybitClient > SpotApi`  
*Bybit spot API endpoints*
  
***
*Get the ISpotClient for this client. This is a common interface which allows for some basic operations without knowing any details of the exchange.*  
**ISpotClient CommonSpotClient { get; }**  
***
*Endpoints related to account settings, info or actions*  
**[IBybitClientSpotApiAccount](IBybitClientSpotApiAccount.html) Account { get; }**  
***
*Endpoints related to retrieving market and system data*  
**[IBybitClientSpotApiExchangeData](IBybitClientSpotApiExchangeData.html) ExchangeData { get; }**  
***
*Endpoints related to orders and trades*  
**[IBybitClientSpotApiTrading](IBybitClientSpotApiTrading.html) Trading { get; }**  
