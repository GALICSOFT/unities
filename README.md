# Unity works

# useful code and util
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
