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

* Speed up the Visual Studio Installer Download
C:\Windows\System32\drivers\etc\hosts
93.184.215.201 download.visualstudio.microsoft.com
#68.232.34.200
#192.229.232.200
#36.25.247.107
#192.16.48.200
