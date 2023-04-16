---
title: Rest API documentation
has_children: true
---
*[generated documentation]*  
### BybitClient  
*Client for accessing the Bybit Rest API.*
  
***
*Copy trading API endpoints*  
**[IBybitClientCopyTradingApi](CopyTradingApi/IBybitClientCopyTradingApi.html) CopyTradingApi { get; }**  
***
*Derivatives API endpoints*  
**[IBybitClientDerivativesApi](DerivativesApi/IBybitClientDerivativesApi.html) DerivativesApi { get; }**  
***
*General API endpoints*  
**[IBybitClientGeneralApi](GeneralApi/IBybitClientGeneralApi.html) GeneralApi { get; }**  
***
*Inverse futures API endpoints*  
**[IBybitClientInverseFuturesApi](InverseFuturesApi/IBybitClientInverseFuturesApi.html) InverseFuturesApi { get; }**  
***
*Inverse perpetual API endpoints*  
**[IBybitClientInversePerpetualApi](InversePerpetualApi/IBybitClientInversePerpetualApi.html) InversePerpetualApi { get; }**  
***
*Set the API credentials for this client. All Api clients in this client will use the new credentials, regardless of earlier set options.*  
**void SetApiCredentials(ApiCredentials credentials);**  
***
*Spot API endpoints (v1)*  
**[IBybitClientSpotApiV1](IBybitClientSpotApiV1.html) SpotApiV1 { get; }**  
***
*Spot API endpoints (v3)*  
**[IBybitClientSpotApiV3](IBybitClientSpotApiV3.html) SpotApiV3 { get; }**  
***
*USD perpetual API endpoints*  
**[IBybitClientUsdPerpetualApi](UsdPerpetualApi/IBybitClientUsdPerpetualApi.html) UsdPerpetualApi { get; }**  
***
*V5 API endpoints*  
**V5.IBybitClientApi V5Api { get; }**  
