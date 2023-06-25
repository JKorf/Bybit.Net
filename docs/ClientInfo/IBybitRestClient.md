---
title: IBybitRestClient
has_children: true
---
*[generated documentation]*  
### BybitClient  
*Client for accessing the Bybit Rest API.*
  
***
*Copy trading API endpoints*  
**IBybitRestClientCopyTradingApi CopyTradingApi { get; }**  
***
*Derivatives API endpoints*  
**IBybitRestClientDerivativesApi DerivativesApi { get; }**  
***
*General API endpoints*  
**IBybitRestClientGeneralApi GeneralApi { get; }**  
***
*Inverse futures API endpoints*  
**IBybitRestClientInverseFuturesApi InverseFuturesApi { get; }**  
***
*Inverse perpetual API endpoints*  
**IBybitRestClientInversePerpetualApi InversePerpetualApi { get; }**  
***
*Set the API credentials for this client. All Api clients in this client will use the new credentials, regardless of earlier set options.*  
**void SetApiCredentials(ApiCredentials credentials);**  
***
*Spot API endpoints (v1)*  
**IBybitRestClientSpotApiV1 SpotApiV1 { get; }**  
***
*Spot API endpoints (v3)*  
**IBybitRestClientSpotApiV3 SpotApiV3 { get; }**  
***
*USD perpetual API endpoints*  
**IBybitRestClientUsdPerpetualApi UsdPerpetualApi { get; }**  
***
*V5 API endpoints*  
**V5.IBybitRestClientApi V5Api { get; }**  
