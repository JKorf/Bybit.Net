---
title: IBybitClientSpotApi
has_children: true
parent: IBybitClient
---
*[generated documentation]*  
`BybitClient > SpotApi`  
*Bybit spot API endpoints*
  
***
*Get the ISpotClient for this client. This is a common interface which allows for some basic operations without knowing any details of the exchange.*  
**ISpotClient ComonSpotClient { get; }**  
***
*Endpoints related to account settings, info or actions*  
**[IBybitClientSpotApiAccount](IBybitClientSpotApiAccount.html){:target="_blank"} Account { get; }**  
***
*Endpoints related to retrieving market and system data*  
**[IBybitClientSpotApiExchangeData](IBybitClientSpotApiExchangeData.html){:target="_blank"} ExchangeData { get; }**  
***
*Endpoints related to orders and trades*  
**[IBybitClientSpotApiTrading](IBybitClientSpotApiTrading.html){:target="_blank"} Trading { get; }**  
