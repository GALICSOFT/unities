# IOS deploy Web

### plist
- .plst 필요
- bundle-identifier, version, tile을 정확히 명시
- url: html에서 구성한 다운로드 경로와 일치 시킴
```xml
<?xml version="1.0" encoding="UTF-8"?>
<!DOCTYPE plist PUBLIC "-//Apple//DTD PLIST 1.0//EN" "http://www.apple.com/DTDs/PropertyList-1.0.dtd">
<plist version="1.0">
<dict>
    <key>items</key>
    <array>
        <dict>
            <key>assets</key>
            <array>
                <dict>
				            <key>kind</key>
                    <string>software-package</string>
                    <key>url</key>
                    <string>https://deploy url/install/deploy.ipa</string>
                </dict>
            </array>
            <key>metadata</key>
            <dict>
                <key>bundle-identifier</key>
                <string>deploy bundle id</string>
                <key>bundle-version</key>
                <string>99.99.99</string>
                <key>kind</key>
                <string>software</string>
                <key>title</key>
                <string>Project Title</string>
            </dict>
        </dict>
    </array>
</dict>
</plist>
```

### html
- macOS의 설치 서비스 호출: itms-services 링크 구성
```html
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html>
<body>
<a href= "itms-services://?action=download-manifest&url=https://deploy url/install/deploy.plist">install ipa</a>
</body>
</html>
```
