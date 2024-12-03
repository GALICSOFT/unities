# Miscellaneous

### useful code and util
* atom md preview
	- https://atom.io/packages/markdown-preview => hot key ctrl-shift-m


* git LFS
```
		git lfs install
```
* git long path
```
		git config --system core.longpaths true
```

* current class and function
```cs
		Debug.Log($"++++++  {GetType().Name}::{MethodBase.GetCurrentMethod().Name}");
```

* NullReferenceException on GameObjectInspector Editor ⇒ delete Temp and Library folders


* dropdown fill
```cs
		dropdown.ClearOptions();
		var option_data = Enumerable.Range(begin, count).Select(x =>
		{
			return new Dropdown.OptionData { text = x.ToString() };
		});
		var options = new List<Dropdown.OptionData>();
		options.AddRange(option_data);
		dropdown.AddOptions(options);

		// or
		dropdown.ClearOptions();
		var option_data = Enumerable.Range(begin, count).Select(x => x.ToString()).ToList();
		dropdown.AddOptions(option_data);
```

* Explorer Search
```bat
system.filename :~< .svn
System.FileName:~>".svn" OR System.FileName:~>".zip" OR System.FileName:~>".ipa" OR System.FileName:~>".apk" System.FileName:~>".aab"
System.FileName:~="test"
System.FileName:="lastStableBuild" OR System.FileName:~>".zip" OR System.FileName:~>".ipa" OR System.FileName:~>".apk"
```
* svn auth
  - svn info --username "uid" --password "pwd"  --trust-server-cert --non-interactive http://svn_server

* Speed up the Visual Studio Installer Download
```sh
C:\Windows\System32\drivers\etc\hosts
93.184.215.201 download.visualstudio.microsoft.com
#68.232.34.200
#192.229.232.200
#36.25.247.107
#192.16.48.200
```
* login start chrome with url
	- create batch to c root, and create short in C:\Users\<user name>\AppData\Roaming\Microsoft\Windows\Start Menu\Programs\Startup
```bat
@echo off
start /d call "C:\Program Files\Google\Chrome\Application\chrome.exe" https://xxxxxx.aspx
```

* window terminal enviroment
```json
{
    "$help": "https://aka.ms/terminal-documentation",
    "$schema": "https://aka.ms/terminal-profiles-schema",
    "actions": 
    [
        {
            "command": "find",
            "id": "User.find",
            "keys": "ctrl+shift+f"
        },
        {
            "command": 
            {
                "action": "splitPane",
                "split": "auto",
                "splitMode": "duplicate"
            },
            "id": "User.splitPane.A6751878",
            "keys": "alt+shift+d"
        },
        {
            "command": "paste",
            "id": "User.paste",
            "keys": "ctrl+v"
        },
        {
            "command": 
            {
                "action": "copy",
                "singleLine": false
            },
            "id": "User.copy.644BA8F2",
            "keys": "ctrl+c"
        }
    ],
    "copyFormatting": "none",
    "copyOnSelect": true,
    "defaultProfile": "{0caa0dad-35be-5f56-a8ff-afceeeaa6101}",
    "disableAnimations": true,
    "initialCols": 210,
    "initialRows": 60,
    "launchMode": "maximized",
    "newTabMenu": 
    [
        {
            "type": "remainingProfiles"
        }
    ],
    "profiles": 
    {
        "defaults": 
        {
            "cursorHeight": 32,
            "cursorShape": "vintage",
            "font": 
            {
                "face": "Cascadia Code",
                "size": 9.5,
                "weight": "extra-light"
            }
        },
        "list": 
        [
            {
                "commandline": "%SystemRoot%\\System32\\cmd.exe",
                "guid": "{0caa0dad-35be-5f56-a8ff-afceeeaa6101}",
                "hidden": false,
                "name": "\uba85\ub839 \ud504\ub86c\ud504\ud2b8",
                "startingDirectory": "D:\\"
            },
            {
                "guid": "{574e775e-4f2a-5b96-ac1e-a2962a402336}",
                "hidden": false,
                "icon": "C:\\Program Files\\PowerShell\\7\\assets\\Powershell_av_colors.ico",
                "name": "PowerShell",
                "source": "Windows.Terminal.PowershellCore",
                "startingDirectory": "D:\\"
            },
            {
                "guid": "{2ece5bfe-50ed-5f3a-ab87-5cd4baafed2b}",
                "hidden": false,
                "icon": "C:\\Git\\mingw64\\share\\git\\git-for-windows.ico",
                "name": "Git Bash",
                "source": "Git",
                "startingDirectory": "D:\\"
            },
            {
                "commandline": "%SystemRoot%\\System32\\WindowsPowerShell\\v1.0\\powershell.exe",
                "guid": "{61c54bbd-c2c6-5271-96e7-009a87ff44bf}",
                "hidden": false,
                "name": "Windows PowerShell 1.0"
            },
            {
                "guid": "{b453ae62-4e3d-5e58-b989-0a998ec441b8}",
                "hidden": false,
                "name": "Azure Cloud Shell",
                "source": "Windows.Terminal.Azure"
            },
            {
                "guid": "{14ac5739-f175-574c-8c9e-c3d42b4a5d1b}",
                "hidden": false,
                "name": "Developer Command Prompt for VS 2019",
                "source": "Windows.Terminal.VisualStudio"
            },
            {
                "guid": "{fff08421-4e1f-5d47-be38-e1cf9260742f}",
                "hidden": false,
                "name": "Developer PowerShell for VS 2019",
                "source": "Windows.Terminal.VisualStudio"
            },
            {
                "guid": "{f72ae17a-f116-53fc-9e43-c52eaa707fe9}",
                "hidden": true,
                "name": "Developer Command Prompt for VS 2017",
                "source": "Windows.Terminal.VisualStudio"
            },
            {
                "guid": "{fe6a60a7-5a2a-5ed1-b1a8-890cec76bbdf}",
                "hidden": false,
                "name": "Developer Command Prompt for VS 2022",
                "source": "Windows.Terminal.VisualStudio"
            },
            {
                "guid": "{1eeabb3c-fe2f-5422-962d-7c2755107f77}",
                "hidden": false,
                "name": "Developer PowerShell for VS 2022",
                "source": "Windows.Terminal.VisualStudio"
            },
            {
                "guid": "{17bf3de4-5353-5709-bcf9-835bd952a95e}",
                "hidden": true,
                "name": "Ubuntu-22.04",
                "source": "Windows.Terminal.Wsl"
            },
            {
                "guid": "{4ff56d04-d9cf-57ea-bae2-ad396374e7e3}",
                "hidden": false,
                "name": "Ubuntu 22.04.5 LTS",
                "source": "CanonicalGroupLimited.Ubuntu22.04LTS_79rhkp1fndgsc"
            }
        ]
    },
    "schemes": [],
    "themes": []
}
```

* window 작업 스케줄러
```xml
<?xml version="1.0" encoding="UTF-16"?>
<Task version="1.2" xmlns="http://schemas.microsoft.com/windows/2004/02/mit/task">
  <RegistrationInfo>
    <Date>2022-11-25T16:39:57.3506426</Date>
    <Author>NMPC\heesungoh</Author>
    <URI>\copy_mk</URI>
  </RegistrationInfo>
  <Triggers>
    <CalendarTrigger>
      <Repetition>
        <Interval>PT6H</Interval>
        <StopAtDurationEnd>false</StopAtDurationEnd>
      </Repetition>
      <StartBoundary>2024-11-25T01:00:00</StartBoundary>
      <ExecutionTimeLimit>PT4H</ExecutionTimeLimit>
      <Enabled>true</Enabled>
      <ScheduleByDay>
        <DaysInterval>1</DaysInterval>
      </ScheduleByDay>
    </CalendarTrigger>
  </Triggers>
  <Principals>
    <Principal id="Author">
      <UserId>S-1-5-21-1729783082-1026399692-4038529257-18585</UserId>
      <LogonType>InteractiveToken</LogonType>
      <RunLevel>LeastPrivilege</RunLevel>
    </Principal>
  </Principals>
  <Settings>
    <MultipleInstancesPolicy>IgnoreNew</MultipleInstancesPolicy>
    <DisallowStartIfOnBatteries>true</DisallowStartIfOnBatteries>
    <StopIfGoingOnBatteries>true</StopIfGoingOnBatteries>
    <AllowHardTerminate>true</AllowHardTerminate>
    <StartWhenAvailable>false</StartWhenAvailable>
    <RunOnlyIfNetworkAvailable>false</RunOnlyIfNetworkAvailable>
    <IdleSettings>
      <StopOnIdleEnd>true</StopOnIdleEnd>
      <RestartOnIdle>false</RestartOnIdle>
    </IdleSettings>
    <AllowStartOnDemand>true</AllowStartOnDemand>
    <Enabled>false</Enabled>
    <Hidden>false</Hidden>
    <RunOnlyIfIdle>false</RunOnlyIfIdle>
    <WakeToRun>false</WakeToRun>
    <ExecutionTimeLimit>PT2H</ExecutionTimeLimit>
    <Priority>7</Priority>
  </Settings>
  <Actions Context="Author">
    <Exec>
      <Command>C:\Windows\System32\WindowsPowerShell\v1.0\powershell.exe</Command>
      <Arguments>-NoProfile -WindowStyle Hidden -ExecutionPolicy Bypass -File "C:\tool\work.ps1" -WorkingDirectory "E:\my_work"</Arguments>
      <WorkingDirectory>E:\my_work</WorkingDirectory>
    </Exec>
  </Actions>
</Task>
```

