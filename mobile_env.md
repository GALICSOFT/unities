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

### Android 32bit Test
## 디바이스의 지원 ABI 목록 확인
	adb shell getprop ro.product.cpu.abilist
	ex) adb shell getprop ro.product.cpu.abilist ==> arm64-v8a,armeabi-v7a,armeabi
 ## debug.force_32bit
	debug.force_32bit는 안드로이드 시스템에서 32비트 호환 모드를 강제로 활성화하는 시스템 속성(System Property)입니다. 
	이 속성을 사용하면 64비트 디바이스에서도 모든 앱이 32비트 모드로 실행되도록 강제할 수 있습니다. 주로 개발/테스트 목적으로 사용됩니다.

	명령어의 역할
	adb shell setprop debug.force_32bit true
	목적:
	64비트 디바이스에서 32비트 앱의 동작을 테스트하거나, 32비트 전용 라이브러리 호환성 문제를 재현하는 데 사용됩니다.
	
	동작 방식:
	시스템 속성을 true로 설정하면, 앱 프로세스가 32비트 모드로 실행됩니다.
	
	앱이 네이티브 라이브러리(.so 파일)를 사용하는 경우, 시스템은 armeabi-v7a (32비트) 라이브러리를 우선적으로 로드합니다.
	
	64비트 라이브러리(arm64-v8a)가 설치되어 있어도 무시됩니다.
	
	주요 특징
	임시 설정:
	
	재부팅 시 속성이 초기화되며, 영구적이지 않습니다.
	
	테스트 후 되돌리려면 다음 명령어를 사용합니다:
	
	adb shell setprop debug.force_32bit false
	디바이스 지원 여부:
	
	Android 5.0 (API 21) 이상에서 동작하지만, 제조사 커스텀 ROM이나 특정 디바이스에서는 지원되지 않을 수 있습니다.
	
	예: 삼성, 샤오미 등 일부 기기에서 동작하지 않을 수 있음.
	
	주의 사항:
	
	앱에 **32비트 라이브러리(armeabi-v7a)**가 포함되어 있지 않으면 크래시가 발생합니다.
	
	Google Play 정책상 2019년 8월 이후 출시된 앱은 64비트 라이브러리 필수이므로, 실제 배포 시 32비트 전용 빌드는 불가능합니다.
	
	사용 사례
	32비트 라이브러리 호환성 테스트:
 
	# 32비트 모드 활성화
	adb shell setprop debug.force_32bit true

## 앱 재시작
	adb shell am force-stop com.example.app
	adb shell monkey -p com.example.app 1
	문제 진단:
		64비트 디바이스에서 32비트 코드의 메모리 누수, 크래시 등을 재현할 때 유용합니다.

## Command Xcode build
```bash
# unity project 
/usr/bin/xcodebuild -version
/usr/bin/xcodebuild
 -workspace <project_path>/Unity-iPhone.xcworkspace
 -scheme Unity-iPhone
 -configuration Release archive
 -archivePath <project_path>/archive.xcarchive
 -destination generic/platform=iOS 

/Applications/Xcode.app/Contents/Developer/usr/bin/xcodebuild
 -workspace <project_path>/Unity-iPhone.xcworkspace
 -scheme Unity-iPhone
 -configuration Release archive
 -archivePath <project_path>/archive.xcarchive
 -destination generic/platform=iOS
 
/usr/bin/xcodebuild
 -exportArchive
 -archivePath <project_path>/archive.xcarchive
 -exportPath <export_path>
 -exportOptionsPlist <plist_path>/plist_path.plist
 
 # general project
/Applications/Xcode.app/Contents/Developer/usr/bin/xcodebuild -project <project_path>/project.xcodeproj -list
/Applications/Xcode.app/Contents/Developer/usr/bin/xcodebuild -project <project_path>/project.xcodeproj -showBuildSettings

xcodebuild
 -exportArchive
 -archivePath <project_path>/_archive.xcarchive
 -exportPath <export_path>
 -exportOptionsPlist <plist_path>/plist_path.plist
```
