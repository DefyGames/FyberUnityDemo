using UnityEngine;
using System.Collections;
using FyberPlugin;

public class FyberAPI : MonoBehaviour {

	// Public Variables

	#if UNITY_ANDROID && !UNITY_EDITOR
		string appId = "39117"; 
		string securityToken = "bc06f7d5851c140c29fbbc5b1ffea397";       
	#else
		string appId = "39115"; 
		string securityToken = "f812b5ad63208dad770323f28b3e7bcc";
	#endif
	string userId = "";
	string customCurrencyName = "TestCoins";
	string placementId = "1";
	string currencyId = "";

	Ad videoAd, interstitialAd, ofwAd;

	// Use this for initialization
	void Start () {
		Settings settings = Fyber.With(appId)
			//.WithUserId(userId)
			//.WithParameters(dictionary)
			.WithSecurityToken(securityToken)
			//.WithManualPrecaching()
			.Start();
	}

	public void RewardedVideo() {
		RewardedVideoRequester.Create()
			// optional method chaining
			//.AddParameter("key", "value")
			//.AddParameters(dictionary)
			//.WithPlacementId(placementId)
			// changing the GUI notification behaviour when the user finishes viewing the video
			//.NotifyUserOnCompletion(true)
			// you can add a virtual currency requester to a video requester instead of requesting it separately
			//.WithVirtualCurrencyRequester(virtualCurrencyRequester)
			// you don't need to add a callback if you are using delegates
			//.WithCallback(requestCallback)
			// requesting the video
			.Request();
	}

	private void ShowVideo()
	{
		if (videoAd != null)
		{
			videoAd.Start();
			videoAd = null;
		}
	}


	void OnEnable()
	{
		FyberCallback.NativeError += OnNativeExceptionReceivedFromSDK;
		// Ad availability
		FyberCallback.AdAvailable += OnAdAvailable;
		FyberCallback.AdNotAvailable += OnAdNotAvailable;
		
		//generic request error     
		FyberCallback.RequestFail += OnRequestFail;

		// Ad life cycle
		FyberCallback.AdStarted += OnAdStarted;
		FyberCallback.AdFinished += OnAdFinished;
	}
	
	void OnDisable()
	{
		FyberCallback.NativeError -= OnNativeExceptionReceivedFromSDK;
		// Ad availability
		FyberCallback.AdAvailable -= OnAdAvailable;
		FyberCallback.AdNotAvailable -= OnAdNotAvailable;
		
		//generic request error     
		FyberCallback.RequestFail -= OnRequestFail;

		// Ad life cycle
		FyberCallback.AdStarted -= OnAdStarted;
		FyberCallback.AdFinished -= OnAdFinished;
	}

	private void OnAdAvailable(Ad ad)
	{
		switch(ad.AdFormat)
		{
		case AdFormat.REWARDED_VIDEO:
			videoAd = ad;
			ShowVideo();
			break;
		case AdFormat.INTERSTITIAL:
			interstitialAd = ad;
			break;
		case AdFormat.OFFER_WALL:
			ofwAd = ad;
			break;
		default:
			break;
		}
	}

	private void OnAdNotAvailable(AdFormat adFormat)
	{
		switch(adFormat)
		{
		case AdFormat.OFFER_WALL:
			ofwAd = null;
			break;
		case AdFormat.REWARDED_VIDEO:
			videoAd = null;
			break;
		case AdFormat.INTERSTITIAL:
			interstitialAd = null;
			break;
		default:
			break;
		}
	}

	private void OnAdStarted(Ad ad)
	{
		// this is where you mute the sound and toggle buttons if necessary
		switch (ad.AdFormat)
		{
		case AdFormat.OFFER_WALL:
			ofwAd = null;
			break;
		case AdFormat.REWARDED_VIDEO:
			videoAd = null;
			break;
		case AdFormat.INTERSTITIAL:
			interstitialAd = null;
			break;
		default:
			break;
		}
	}

	private void OnAdFinished(AdResult result)
	{
		// this is the place where you can resume the sound
		// reenable buttons, etc
		UnityEngine.Debug.Log("OnAdFinished. Ad " + result.AdFormat +
		                      " finished with status: " + result.Status +
		                      " and message: " + result.Message);
		switch (result.AdFormat)
		{
			case AdFormat.REWARDED_VIDEO:
				UnityEngine.Debug.Log("video closed with result: " + result.Status +
				                      "and message: " + result.Message);
				// result.Message can be:
				// "CLOSE_ABORTED",
				// "CLOSE_FINISHED" or
				// "ERROR" if result.Status equals AdStatus.Error
				break;
				// handle other ad formats
		}
	}

	private void OnRequestFail(RequestError error)
	{
		// process error
		UnityEngine.Debug.Log("OnRequestError: " + error.Description);
	}

	
	public void OnNativeExceptionReceivedFromSDK(string message)
	{
		//handle exception
	}


	// Update is called once per frame
	void Update () {
	
	}
}
