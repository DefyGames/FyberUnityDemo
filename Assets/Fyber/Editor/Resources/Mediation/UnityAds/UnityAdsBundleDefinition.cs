using UnityEngine;
using UnityEditor;
using System;

namespace FyberEditor
{
	
	[Serializable]
	[BundleDefinitionAttribute("UnityAds", "com.fyber.mediation.unityads.UnityAdsMediationAdapter", "1.5.4-r2", 3, InternalName="Applifier")]
	public class UnityAdsBundleDefinition : BundleDefinition
	{

		[SerializeField]
		[FyberPropertyAttribute("game.id.key")]
		private string GameIdKey;
	
		[SerializeField]
		[FyberPropertyAttribute("debug.mode")]
		private bool DebugMode;

		[SerializeField]
		[FyberPropertyAttribute("zone.id.interstitial")]
		private string ZoneIdInterstitial;

		[SerializeField]
		[FyberPropertyAttribute("zone.id.rewarded.video")]
		private string ZoneIdRewardedVideo;

	}
}
