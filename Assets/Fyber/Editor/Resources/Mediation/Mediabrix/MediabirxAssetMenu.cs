using System;
using UnityEditor;
using UnityEngine;

namespace FyberEditor
{
	public class MediabrixAssetMenu
	{

#if !UNITY_5
		[MenuItem("Fyber/Mediation Assets Generation/Mediabrix")]
		public static void GenerateMediabrixAsset()
		{
			var asset = ScriptableObject.CreateInstance<MediabrixBundleDefinition>();
			AssetDatabase.CreateAsset(asset, "Assets/Fyber/Editor/Resources/Mediation/Mediabrix/MediabrixFyberBundle.asset");
			AssetDatabase.SaveAssets();
		}

		[MenuItem("Fyber/Mediation Assets Generation/Mediabrix", true)]
		public static bool GenerateMediabrixAsset_Validator()
		{
			var asset = Resources.Load<MediabrixBundleDefinition>("Mediation/Mediabrix/MediabrixFyberBundle");
			return asset == null;
		}
#endif

	}
}

