using System;
using UnityEditor;
using UnityEngine;

namespace FyberEditor
{
	public class VungleAssetMenu
	{

#if !UNITY_5
		[MenuItem("Fyber/Mediation Assets Generation/Vungle")]
		public static void GenerateVungleAsset()
		{
			var asset = ScriptableObject.CreateInstance<VungleBundleDefinition>();
			AssetDatabase.CreateAsset(asset, "Assets/Fyber/Editor/Resources/Mediation/Vungle/VungleFyberBundle.asset");
			AssetDatabase.SaveAssets();
		}

		[MenuItem("Fyber/Mediation Assets Generation/Vungle", true)]
		public static bool GenerateVungleAsset_Validator()
		{
			var asset = Resources.Load<VungleBundleDefinition>("Mediation/Vungle/VungleFyberBundle");
			return asset == null;
		}
#endif

	}
}

