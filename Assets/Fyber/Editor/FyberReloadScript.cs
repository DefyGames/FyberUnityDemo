using System;
using System.IO;
using UnityEngine;
using UnityEditor;
using UnityEditor.Callbacks;

namespace FyberEditor
{
	[InitializeOnLoad]
	public class FyberReloadScript : AssetPostprocessor 
	{

		private static int counter = 0 ;

		static FyberReloadScript()
		{
			EditorApplication.update += Initialize;
			FyberEditorSettings.AndroidBundlesChanged += RestartCounter;
		}
		
		static void Initialize()
		{
			if (Application.isPlaying)
			{
				EditorApplication.update -= Initialize;
				FyberEditorSettings.AndroidBundlesChanged -= RestartCounter;
			}
			else
			{
				if ( counter > 0 )
				{
					counter--;
				} 
				else if (counter == 0)
				{
					FyberEditorSettings.Instance.ProcessAndroidAdapters();
					counter = -10;
				}
			}
		}

		static void OnPostprocessAllAssets (string[] importedAssets, string[] deletedAssets, string[] movedAssets, string[] movedFromAssetPaths) 
		{
			var needsUpdate = false;
			foreach (var str in importedAssets)
			{
				if (str.Contains("Fyber") && str.Contains("Mediation"))
				{
					needsUpdate = true;
					break;
				}
			}

			foreach (var str in deletedAssets)
			{
				if (str.Contains("Fyber") && str.Contains("Mediation"))
				{
					needsUpdate = true;
					break;
				}
			}

			if (needsUpdate)
				RestartCounter();
		}

		internal static void RestartCounter()
		{
			counter = 500;
		}

	}
}