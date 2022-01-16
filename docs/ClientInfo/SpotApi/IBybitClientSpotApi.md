---
title: IBybitClientSpotApi
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
**[IBybitClientSpotApiAccount](https://github.com/JKorf/Bybit.Net/wiki/IBybitClientSpotApiAccount) Account { get; }**  
***
*Endpoints related to retrieving market and system data*  
**[IBybitClientSpotApiExchangeData](https://github.com/JKorf/Bybit.Net/wiki/IBybitClientSpotApiExchangeData) ExchangeData { get; }**  
***
*Endpoints related to orders and trades*  
**[IBybitClientSpotApiTrading](https://github.com/JKorf/Bybit.Net/wiki/IBybitClientSpotApiTrading) Trading { get; }**  
