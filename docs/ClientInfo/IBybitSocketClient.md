---
title: Socket API documentation
has_children: true
---
*[generated documentation]*  
### BybitSocketClient  
*Client for accessing the bybit websocket API*
  
***
*Contract private streams*  
**[IBybitSocketClientContractStreams](ContractApi/IBybitSocketClientContractStreams.html) ContractPrivate { get; }**  
***
*Copy trading streams*  
**[IBybitSocketClientCopyTradingStreams](CopyTradingApi/IBybitSocketClientCopyTradingStreams.html) CopyTrading { get; }**  
***
*Derivatives public streams*  
**[IBybitSocketClientDerivativesPublicStreams](DerivativesPublicApi/IBybitSocketClientDerivativesPublicStreams.html) DerivativesPublic { get; }**  
***
*Inverse perpetual streams*  
**[IBybitSocketClientInversePerpetualStreams](InversePerpetualApi/IBybitSocketClientInversePerpetualStreams.html) InversePerpetualStreams { get; }**  
***
*Set the API credentials for this client. All Api clients in this client will use the new credentials, regardless of earlier set options.*  
**void SetApiCredentials(ApiCredentials credentials);**  
***
*Spot streams v1*  
**[IBybitSocketClientSpotStreamsV1](IBybitSocketClientSpotStreamsV1.html) SpotStreamsV1 { get; }**  
***
*Spot streams v2*  
**[IBybitSocketClientSpotStreamsV2](IBybitSocketClientSpotStreamsV2.html) SpotStreamsV2 { get; }**  
***
*Spot streams v3*  
**[IBybitSocketClientSpotStreamsV3](IBybitSocketClientSpotStreamsV3.html) SpotStreamsV3 { get; }**  
***
*Unified margin private streams*  
**[IBybitSocketClientUnifiedMarginStreams](UnifiedMarginApi/IBybitSocketClientUnifiedMarginStreams.html) UnifiedMarginPrivate { get; }**  
***
*USD perpetual streams*  
**[IBybitSocketClientUsdPerpetualStreams](UsdPerpetualApi/IBybitSocketClientUsdPerpetualStreams.html) UsdPerpetualStreams { get; }**  
***
*V5 Linear streams*  
**[IBybitSocketClientLinearStreams](LinearApi/IBybitSocketClientLinearStreams.html) V5LinearStreams { get; }**  
***
*V5 Option streams*  
**[IBybitSocketClientOptionStreams](OptionApi/IBybitSocketClientOptionStreams.html) V5OptionsStreams { get; }**  
***
*V5 Private streams*  
**[IBybitSocketClientPrivateStreams](PrivateApi/IBybitSocketClientPrivateStreams.html) V5PrivateStreams { get; }**  
***
*V5 Spot streams*  
**[IBybitSocketClientSpotStreams](SpotApi/IBybitSocketClientSpotStreams.html) V5SpotStreams { get; }**  
