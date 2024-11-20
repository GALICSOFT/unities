# jenkins memo

### svn

* subversion download for windows
   - [current](https://www.visualsvn.com/downloads)
   - [1.7.10](https://www.visualsvn.com/files/Apache-Subversion-1.7.10.zip)

* svn add all and commit
```
    svn add --force * --no-ignore --parents --depth infinity -q
    svn commit --non-interactive --trust-server-cert --username "${USER_NAME}" --password "${USER_PWD}" -m "${VAR_COMMITMSG}"
```
### M1,M2 Mac jenkins setting
* jdk install
   - brew install : copy bash script in homebrew site.  ⇒ https://brew.sh/ko/
```console
    /bin/bash -c "$(curl -fsSL https://raw.githubusercontent.com/Homebrew/install/HEAD/install.sh)"
    # brew command error: zsh: command not found: brew
    vi ~/.zshrc
    export PATH=/opt/homebrew/bin:$PATH
    # etc
    sudo defaults write com.apple.finder AppleShowAllFiles YES
```
   - brew search jdk
   - brew install jdk@17 ⇐ Formulae
* setup java virtual machine
   - sudo ln -sfn /opt/homebrew/Cellar/openjdk@17/17.0.9/libexec/openjdk.jdk /Library/Java/JavaVirtualMachines/openjdk.jdk
   - java -version

* svn install
   - brew search svn
   - brew install svn
   - svn --version
* install openssl
   - brew search openssl
   - brew install openssl
   - openssl version
* install xcode
   - xcode 15 download
   - change Xcode + version
   - Xcode ⇒ Locations Derived Data ⇒ Relative
   - create jenkins work forlder
* jenkins node shared folder
   - create folder to /Users/${USER_ID}/build.app.jenkins.slave
   - setup the shared folder
       - cd /Users/Shared
       - ln -s /Users/${USER_ID}/build.app.jenkins.slave Jenkins.slave
* create jenkins build agent on master
   - path setup
       - jenkins master Node properties ⇒ Environment variables ⇒ add Key-Value ⇒ PATH+HOMEBREW_PATH /opt/homebrew/bin
   - agent.jar download and rename jenins agent.jar ⇒ /Users/${USER_ID}/agent.141.jar
   - create agent file ⇒ /Users/${USER_ID}/Library/LaunchAgents/build.jenkins.agent.plist
       - ex) build.jenkins.agent.plist for jnlpUrl
```xml
        <?xml version="1.0" encoding="UTF-8"?>
        <!DOCTYPE plist PUBLIC "-//Apple//DTD PLIST 1.0//EN" "http://www.apple.com/DTDs/PropertyList-1.0.dtd">
        <plist version="1.0">
        <dict>
        	<key>Label</key>
        	<string>jenkins.build</string>
        	<key>ProgramArguments</key>
        	<array>
        		<string>/usr/libexec/java_home</string>
        		<string>-v</string>
        		<string>1.17</string>
        		<string>--exec</string>
        		<string>java</string>
        		<string>-Dmail.smtp.starttls.enable=true</string>
        		<string>-jar</string>
        		<string>/Users/${USER_ID}/agent.141.jar</string>
        		<string>-jnlpUrl</string>
        		<string>http://jenkins_master_url/computer/NODE_NAME/jenkins-agent.jnlp</string>
        		<string>-secret</string>
        		<string>secret hash</string>
        		<string>-workDir</string>
        		<string>/Users/Shared/Jenkins.slave</string>
        	</array>
        	<key>RunAtLoad</key>
        	<true/>
        	<key>StandardOutPath</key>
        	<string>/Users/${USER_ID}/build-app-agent.log</string>
        	<key>StandardErrorPath</key>
        	<string>/Users/${USER_ID}/build-app-agent.err</string>
        </dict>
        </plist>
```
       - ex) build.jenkins.agent.plist with url
```xml
        <?xml version="1.0" encoding="UTF-8"?>
        <!DOCTYPE plist PUBLIC "-//Apple//DTD PLIST 1.0//EN" "http://www.apple.com/DTDs/PropertyList-1.0.dtd">
        <plist version="1.0">
        <dict>
        	<key>Label</key>
        	<string>jenkins.build</string>
        	<key>ProgramArguments</key>
        	<array>
        		<string>java</string>
        		<string>-jar</string>
        		<string>/Users/${USER_ID}/_jenkins.agent/agent.244.jar</string>
        		<string>-url</string>
        		<string>http://jenkins_master_url</string>
        		<string>-secret</string>
        		<string>secret hash</string>
        		<string>-name</string>
        		<string>agent node name</string>
        		<string>-workDir</string>
        		<string>/Users/Shared/Jenkins.slave</string>
        	</array>
        	<key>RunAtLoad</key>
        	<true/>
        	<key>StandardOutPath</key>
        	<string>/Users/${USER_ID}/_jenkins.agent/agent.log</string>
        	<key>StandardErrorPath</key>
        	<string>/Users/${USER_ID}/_jenkins.agent/agent.err</string>
        </dict>
        </plist>
```

   - launchctl {load|stop|unload} ~/Library/LaunchAgents/build.jenkins.agent.plist

* script console: java, svn, node name
```groovy
println System.getProperty("java.version")
println "--------------------------------"
println System.getProperty("java.home")
println "--------------------------------"
def svnVersion = 'svn --version --quiet'.execute().text.trim()
println "SVN Version: ${svnVersion}"
println "--------------------------------"
Jenkins.instance.nodes.each { node ->
    println node.nodeName
```

* system env
```console
AAPT_EXE                    Android\Sdk\build-tools\28.0.3\aapt.exe
ANDROID_HOME                Android\Sdk
ANDROID_NDK_HOME            Android\Sdk\android-ndk-r16b
ZIPALIGN                    Android\Sdk\build-tools\28.0.3\zipalign.exe
NDK_ROOT                    Android\Sdk\ndk\21.4.7075529
NDK_ROOT_R16B               Android\Sdk\android-ndk-r16b
NDK_ROOT_R21E               Android\Sdk\ndk\21.4.7075529

GLOBAL_APK_BUILDOPTION      --jobs=8
GLOBAL_GRADLE_BUILDOPTION   -P_NDK_BUILD_JOBS=8
GLOBAL_IPA_BUILDOPTION      -jobs 8
GRADLE_USER_HOME            GradleHome.jenkins
JAVA_HOME                   Java\jdk-11.0.16.1
jarsigner                   Java\jdk-11.0.16.1\bin\jarsigner.exe
JSIGNER                     Android Studio\jre\bin\jarsigner.exe

MSBUILD_2013                Program Files (x86)\MSBuild\12.0\Bin\MSBuild.exe
MSBUILD_2017                Program Files (x86)\Microsoft Visual Studio\2017\Professional\MSBuild\15.0\Bin\MSBuild.exe
MSBUILD_2019                Program Files (x86)\Microsoft Visual Studio\2019\BuildTools\MSBuild\Current\Bin\MSBuild.exe
MSBUILDBIN_VS2019           Program Files (x86)\Microsoft Visual Studio\2019\BuildTools\MSBuild\Current\Bin\MSBuild.exe
VSDEVCMD_2013               Program Files (x86)\Microsoft Visual Studio 12.0\Common7\Tools\VsDevCmd.bat
VSDEVCMD_2017               Program Files (x86)\Microsoft Visual Studio\2017\BuildTools\Common7\Tools\VsDevCmd.bat

NUGET_PACKAGES              Nuget\packages\Newtonsoft.Json.12.0.3
PATH_XCODE_VER_15.3         /Applications/XcodeV15.3.app
PROVPROF_ROOT               /Users/n2play/Library/MobileDevice/Provisioning Profiles

CURL                        curl\bin\curl.exe
svn                         Program Files (x86)\Subversion\bin\svn.exe
SVNBIN                      Program Files\TortoiseSVN\bin\svn.exe
```

### Windows
* visual studio download
   - download.visualstudio.microsoft.com
   -- goto C:\Windows\System32\drivers\etc\localhost
```bash
			93.184.215.201 download.visualstudio.microsoft.com
			#68.232.34.200
			#192.229.232.200
			#36.25.247.107
			#192.16.48.200
```
### Color
* usign Color ANSI Console Output with color on Execute shell
```bash
	#!sh
	echo -e "\033[31m====>\033[0m setup env +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++"
	echo -e "\033[01m     [01m : 굵게(bold) / 밝게           \033[0m"
	echo -e "\033[3m      [3m  : 이탤릭체(italic)            \033[0m"
	echo -e "\033[4m      [4m  : 밑줄(underline)             \033[0m"
	echo -e "\033[7m      [7m  : 반전(글자색/배경색을 거꾸로)\033[0m"
	echo -e "\033[9m      [9m  : 가로줄 치기                 \033[0m"
	echo -e "\033[22m     [22m : 굵게(bold) 제거             \033[0m"
	echo -e "\033[23m     [23m : 이탤릭체(italic)제거        \033[0m"
	echo -e "\033[24m     [24m : 밑줄(underline)제거         \033[0m"
	echo -e "\033[27m     [27m : 반전 제거                   \033[0m"
	echo -e "\033[29m     [29m : 가로줄 제거                 \033[0m"
	echo -e "\033[30m\033 [47m   [30m : 글자색:검정          \033[0m"
	echo -e "\033[31m     [31m : 글자색:빨강                 \033[0m"
	echo -e "\033[32m     [32m : 글자색:초록                 \033[0m"
	echo -e "\033[33m     [33m : 글자색:노랑                 \033[0m"
	echo -e "\033[34m     [34m : 글자색:파랑                 \033[0m"
	echo -e "\033[35m     [35m : 글자색:마젠트(분홍)         \033[0m"
	echo -e "\033[36m     [36m : 글자색:시안(청록)           \033[0m"
	echo -e "\033[37m     [37m : 글자색:백색                 \033[0m"
	echo -e "\033[39m     [39m : 글자색으로 기본값으로       \033[0m"
	echo -e "\033[40m     [40m : 바탕색:흑색                 \033[0m"
	echo -e "\033[41m     [41m : 바탕색:적색                 \033[0m"
	echo -e "\033[42m     [42m : 바탕색:녹색                 \033[0m"
	echo -e "\033[43m     [43m : 바탕색:황색                 \033[0m"
	echo -e "\033[44m     [44m : 바탕색:청색                 \033[0m"
	echo -e "\033[45m     [45m : 바탕색:분홍색               \033[0m"
	echo -e "\033[46m     [46m : 바탕색:청록색               \033[0m"
	echo -e "\033[47m     [47m : 바탕색:흰색                 \033[0m"
	echo -e "\033[49m     [49m : 바탕색을 기본값으로         \033[0m"
	echo ""
	echo ""
	echo -e "\033[31m\033[7m[ERROR] Something went wrong!    \033[0m"
	echo -e "\033[32m[SUCCESS] Everything is good!           \033[0m"
	echo -e "\033[33m[WARNING] Be careful!                   \033[0m"
	echo -e "\033[36m[INFO] Just letting you know.           \033[0m"
```
