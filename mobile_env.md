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
