---
title: IBybitRestClientApi
has_children: true
parent: IBybitRestClientV5
grand_parent: Rest API documentation
---
*[generated documentation]*  
`BybitRestClient > V5 > Api`  
*Bybit V5 API endpoints*
  
***
*Get the ISpotClient for this client. This is a common interface which allows for some basic operations without knowing any details of the exchange.*  
**ISpotClient CommonSpotClient { get; }**  
***
*Endpoints related to account settings, info or actions*  
**[IBybitRestClientApiAccount](IBybitRestClientApiAccount.html) Account { get; }**  
***
*Endpoints related to retrieving market and system data*  
**[IBybitRestClientApiExchangeData](IBybitRestClientApiExchangeData.html) ExchangeData { get; }**  
***
*Endpoint for managing sub accounts*  
**[IBybitRestClientApiSubAccounts](IBybitRestClientApiSubAccounts.html) SubAccount { get; }**  
***
*Endpoints related to orders and trades*  
**[IBybitRestClientApiTrading](IBybitRestClientApiTrading.html) Trading { get; }**  
