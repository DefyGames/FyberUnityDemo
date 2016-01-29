using UnityEngine;
using UnityEditor;
using System;

namespace FyberEditor
{

	[Serializable]
	[BundleDefinitionAttribute("Mediabrix", "com.fyber.mediation.mediabrix.MediaBrixMediationAdapter", "1.8.0-r1", 3)]
	public class MediabrixBundleDefinition : BundleDefinition
	{

		[SerializeField]
		[FyberPropertyAttribute("SPMediabrixAppId")]
		private string AppId;
	
		[SerializeField]
		[FyberPropertyAttribute("SPMediabrixBaseURL")]
		private string BaseURL;

		[SerializeField]
		[FyberPropertyAttribute("SPMediabrixOptInMessageEnabled")]
		private bool OptInMessageEnabled;

		[SerializeField]
		[FyberPropertyAttribute("SPMediabrixRescueZone")]
		private string RescueZone;

		[SerializeField]
		[FyberPropertyAttribute("SPMediabrixUID")]
		private string UID;

		[SerializeField]
		[FyberPropertyAttribute("SPMediabrixRewardText")]
		private string RewardText;
		
		[SerializeField]
		[FyberPropertyAttribute("SPMediabrixRewardIconURL")]
		private string RewardIconURL;
		
		[SerializeField]
		[FyberPropertyAttribute("SPMediabrixOptInButtonText")]
		private string OptInButtonText;
		
		[SerializeField]
		[FyberPropertyAttribute("SPMediabrixEnticeText")]
		private string EnticeText;

		[SerializeField]
		[FyberPropertyAttribute("SPMediabrixRescueTitle")]
		private string RescueTitle;

		[SerializeField]
		[FyberPropertyAttribute("SPMediabrixRescueText")]
		private string RescueText;

		[SerializeField]
		[FyberPropertyAttribute("SPMediabrixFacebookAppId")]
		private string FacebookAppId;

		[SerializeField]
		[FyberPropertyAttribute("SPMediabrixGeoEnabled")]
		private bool GeoEnabled;

		[SerializeField]
		[FyberPropertyAttribute("SPMediabrixCalendarEnabled")]
		private bool CalendarEnabled;

		[SerializeField]
		[FyberPropertyAttribute("SPMediabrixCameraEnabled")]
		private bool CameraEnabled;

	}
}
