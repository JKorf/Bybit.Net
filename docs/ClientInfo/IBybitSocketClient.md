---
title: Socket API documentation
has_children: true
---
*[generated documentation]*  
### BybitSocketClient  
*Client for accessing the bybit websocket API*
  
***
*Contract private streams*  
**[IBybitSocketClientContractApi](ContractApi/IBybitSocketClientContractApi.html) ContractApi { get; }**  
***
*Copy trading streams*  
**[IBybitSocketClientCopyTradingApi](CopyTradingApi/IBybitSocketClientCopyTradingApi.html) CopyTradingApi { get; }**  
***
*Derivatives public streams*  
**[IBybitSocketClientDerivativesPublicApi](DerivativesPublicApi/IBybitSocketClientDerivativesPublicApi.html) DerivativesApi { get; }**  
***
*Inverse perpetual streams*  
**[IBybitSocketClientInversePerpetualApi](InversePerpetualApi/IBybitSocketClientInversePerpetualApi.html) InversePerpetualApi { get; }**  
***
*Set the API credentials for this client. All Api clients in this client will use the new credentials, regardless of earlier set options.*  
**void SetApiCredentials(ApiCredentials credentials);**  
***
*Spot streams v1*  
**[IBybitSocketClientSpotApiV1](IBybitSocketClientSpotApiV1.html) SpotV1Api { get; }**  
***
*Spot streams v2*  
**[IBybitSocketClientSpotApiV2](IBybitSocketClientSpotApiV2.html) SpotV2Api { get; }**  
***
*Spot streams v3*  
**[IBybitSocketClientSpotApiV3](IBybitSocketClientSpotApiV3.html) SpotV3Api { get; }**  
***
*Unified margin private streams*  
**[IBybitSocketClientUnifiedMarginApi](UnifiedMarginApi/IBybitSocketClientUnifiedMarginApi.html) UnifiedMarginApi { get; }**  
***
*USD perpetual streams*  
**[IBybitSocketClientUsdPerpetualApi](UsdPerpetualApi/IBybitSocketClientUsdPerpetualApi.html) UsdPerpetualApi { get; }**  
***
*V5 Inverse contract streams*  
**[IBybitSocketClientInverseApi](InverseApi/IBybitSocketClientInverseApi.html) V5InverseApi { get; }**  
***
*V5 Linear streams*  
**[IBybitSocketClientLinearApi](LinearApi/IBybitSocketClientLinearApi.html) V5LinearApi { get; }**  
***
*V5 Option streams*  
**[IBybitSocketClientOptionApi](OptionApi/IBybitSocketClientOptionApi.html) V5OptionsApi { get; }**  
***
*V5 Private streams*  
**[IBybitSocketClientPrivateApi](PrivateApi/IBybitSocketClientPrivateApi.html) V5PrivateApi { get; }**  
***
*V5 Spot streams*  
**[IBybitSocketClientSpotApi](SpotApi/IBybitSocketClientSpotApi.html) V5SpotApi { get; }**  
