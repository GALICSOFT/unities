# Mobile Env memo

### Android Keystore
- keystore  를 java17에서 생성하면 java 11 keytool에서 읽기 실패
- [java 11](https://jdk.java.net/archive/) download
- using <jdk>/bin/keytool
-- ex)
```console
keytool -genkey  -v -keystore my_app_id.keystore -alias my_alias -keyalg RSA -keysize 2048 -validity 33333 (<=year 91)
keytool -v -list -keystore my_app_id.keystore
```

### Maven
- maven: https://mvnrepository.com/
- Majer Repo
	- google maven: https://maven.google.com/web/index.html? 
	- Kakao SDK: https://developers.kakao.com/docs/latest/ko/android/getting-started#apply-sdk
	- netmarble maven: http://mavenpro.nmn.io/repository/netmarble-sdk-aos/com/netmarble/core
- Maven Repo check
	- url valid: curl -I http://xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
	- download: curl -O http://xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx

  
### Google Admobs
- https://developers.google.com/admob/android/rel-notes?hl=ko
- IOS Rewarded(Only English): https://developers.google.com/admob/ios/rewarded
- IOS API: https://developers.google.com/ad-manager/mobile-ads-sdk/ios/api/reference/Classes/GADRewardedAd  
- Unity: https://developers.google.com/admob/unity/quick-start
- Unity Plugin: https://developers.google.com/admob/unity/quick-start?hl=ko#import_the_mobile_ads_for_unity_plugin ⇒ https://github.com/googleads/googleads-mobile-unity 

### Line SDK
- https://developers.game.line.me/document/guides/detail
- libraries: https://developers.game.line.me/document/libraries
- GAME SDK 3.0 sample: https://developers.game.line.me/document/libraries/detail?id=/Libraries/trident3.0/sample 
