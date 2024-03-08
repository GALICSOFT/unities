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
       - ex) build.jenkins.agent.plist
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
   - launchctl {load|stop|unload} ~/Library/LaunchAgents/build.jenkins.agent.plist
