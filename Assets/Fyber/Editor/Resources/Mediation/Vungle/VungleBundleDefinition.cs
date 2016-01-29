using UnityEngine;
using UnityEditor;
using System;

namespace FyberEditor
{

	[Serializable]
	[BundleDefinitionAttribute("Vungle", "com.fyber.mediation.vungle.VungleMediationAdapter", "3.3.3-r1", 3)]
	public class VungleBundleDefinition : BundleDefinition
	{

		[SerializeField]
		[FyberPropertyAttribute("app.id")]
		private string AppId;
	
		[SerializeField]
		[FyberPropertyAttribute("incentivized.mode")]
		private bool IncentivizedMode;

		[SerializeField]
		[FyberPropertyAttribute("sound.enabled")]
		private bool SoundEnabled;
		
		[SerializeField]
		[FyberPropertyAttribute("auto.rotation.enabled")]
		private bool AutoRotationEnabled;
		
		[SerializeField]
		[FyberPropertyAttribute("back.button.enabled")]
		private bool BackButtonEnabled;
		
		[SerializeField]
		[FyberPropertyAttribute("cancel.dialog.title")]
		private string CancelDialogTitle;
		
		[SerializeField]
		[FyberPropertyAttribute("cancel.dialog.text")]
		private string CancelDialogText;
		
		[SerializeField]
		[FyberPropertyAttribute("cancel.dialog.button")]
		private string CancelDialogButton;
		
		[SerializeField]
		[FyberPropertyAttribute("keep.watching.text")]
		private string KeepWatchingText;

	}
}
