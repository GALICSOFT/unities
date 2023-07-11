using UnityEditor;
using UnityEngine;
using UnityEditor.Build.Reporting;

public class GlcBuild : MonoBehaviour
{
	[MenuItem("Build/Build AOS")]
	public static void BuildAndroid()
	{
		BuildPlayerOptions opt = new BuildPlayerOptions();
		opt.scenes = new[] { "Assets/Scenes/MainScene.unity" };
		opt.locationPathName = "build-aos/moma2.apk";
		opt.target = BuildTarget.Android;
		opt.options = BuildOptions.None;
		
		BuildReport report = BuildPipeline.BuildPlayer(opt);
		BuildSummary summary = report.summary;
		if (summary.result == BuildResult.Succeeded)
		{
			Debug.Log("Build succeeded: " + summary.totalSize + " bytes");
		}
		if (summary.result == BuildResult.Failed)
		{
			Debug.Log("Build failed");
		}
	}
}
