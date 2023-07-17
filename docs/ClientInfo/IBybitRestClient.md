---
title: Rest API documentation
has_children: true
---
*[generated documentation]*  
### BybitRestClient  
*Client for accessing the Bybit Rest API.*
  
***
*Copy trading API endpoints*  
**[IBybitRestClientCopyTradingApi](CopyTradingApi/IBybitRestClientCopyTradingApi.html) CopyTradingApi { get; }**  
***
*Derivatives API endpoints*  
**[IBybitRestClientDerivativesApi](DerivativesApi/IBybitRestClientDerivativesApi.html) DerivativesApi { get; }**  
***
*General API endpoints*  
**[IBybitRestClientGeneralApi](GeneralApi/IBybitRestClientGeneralApi.html) GeneralApi { get; }**  
***
*Inverse futures API endpoints*  
**[IBybitRestClientInverseFuturesApi](InverseFuturesApi/IBybitRestClientInverseFuturesApi.html) InverseFuturesApi { get; }**  
***
*Inverse perpetual API endpoints*  
**[IBybitRestClientInversePerpetualApi](InversePerpetualApi/IBybitRestClientInversePerpetualApi.html) InversePerpetualApi { get; }**  
***
*Set the API credentials for this client. All Api clients in this client will use the new credentials, regardless of earlier set options.*  
**void SetApiCredentials(ApiCredentials credentials);**  
***
*Spot API endpoints (v1)*  
**[IBybitRestClientSpotApiV1](IBybitRestClientSpotApiV1.html) SpotApiV1 { get; }**  
***
*Spot API endpoints (v3)*  
**[IBybitRestClientSpotApiV3](IBybitRestClientSpotApiV3.html) SpotApiV3 { get; }**  
***
*USD perpetual API endpoints*  
**[IBybitRestClientUsdPerpetualApi](UsdPerpetualApi/IBybitRestClientUsdPerpetualApi.html) UsdPerpetualApi { get; }**  
***
*V5 API endpoints*  
**V5.IBybitRestClientApi V5Api { get; }**  
