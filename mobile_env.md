# Mobile Env memo

### Android Keystore
- keystore  를 java17에서 생성하면 java 11 keytool에서 읽기 실패
- [java 11](https://jdk.java.net/archive/) download
- using <jdk>/bin/keytool
-- ex)
```console
-dname:
  CN: Common Name
  OU: Organizational Unit
  O: Organization
  L: Locality
  ST: State
  C: Country
-storetype : default PKCS12, JKS(option)

jdk\keytool.exe -genkey -v -keystore my_app_id.keystore -alias my_alias -keyalg RSA -keysize 2048 -dname "CN=galic, O=Company, L=Seoul, C=KR" -storetype JKS(option) -validity 33333 (<=year 91)
keytool -v -list -keystore my_app_id.keystore
```
#### resigning example on unity
```console
@echo off

set ANDROID_SDK=C:\Program Files\Unity\Hub\Editor\2022.3.33f1\Editor\Data\PlaybackEngines\AndroidPlayer
set ZipAlign="%ANDROID_SDK%\SDK\build-tools\32.0.0\zipalign.exe"
set ApkSigner="%ANDROID_SDK%\SDK\build-tools\32.0.0\apksigner.bat"
set JarSigner="%ANDROID_SDK%\OpenJDK\bin\jarsigner.exe"

set SourceApk="source_aos.apk"
set TargetApk="target_aos.apk"
set Keystore="keystore_location\my_keystore.file"
set Password=keystore_pwd
set Alias=keystore_alias

echo -----------------------------------------------------------
echo - %SourceApk% resigning
echo -----------------------------------------------------------

call apktool d %SourceApk% -o temp_unpack
echo apktool d %SourceApk% -o temp_unpack

echo apktool b temp_unpack -o temp_unpack.apk
call apktool b temp_unpack -o temp_unpack.apk

echo %ZipAlign% -f -v 4 temp_unpack.apk %TargetApk%
call %ZipAlign% -f -v 4 temp_unpack.apk %TargetApk%

echo %ApkSigner% sign --v1-signing-enabled true --v2-signing-enabled --ks %Keystore% --ks-key-alias %Alias% --ks-pass pass:%Password% %TargetApk%
call %ApkSigner% sign --v1-signing-enabled true --v2-signing-enabled --ks %Keystore% --ks-key-alias %Alias% --ks-pass pass:%Password% %TargetApk%

echo %JarSigner% -verify -verbose -certs %TargetApk%
call %JarSigner% -verify -verbose -certs %TargetApk%
```

### Maven
- maven: https://mvnrepository.com/
- Major Repo
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
