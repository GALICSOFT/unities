# Unity works

# useful code
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
