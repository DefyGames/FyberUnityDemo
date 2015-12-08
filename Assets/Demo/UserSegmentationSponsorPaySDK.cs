using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
using System.Globalization;
using SponsorPay;
using SponsorPay.Demo;

/**
 * This is an example on how to use the SponsorPay Unity Plugin.
 * If you attach it to a game object, it will draw a user interface 
 * from which the plugin's methods can be exercised.
 */
public class UserSegmentationSponsorPaySDK : AbstractMonoBehaviour
{
	
	// Private Variables
	private static int enumUndefined = -1;
	private string age = string.Empty;
	private string birthdate = string.Empty;
	private int gender = enumUndefined;
	private int sexualOrientation = enumUndefined;
	private int ethnicity = enumUndefined;
	private string location = string.Empty;
	private int maritalStatus = enumUndefined;
	private string numberOfChildrens = string.Empty;
	private string annualHouseholdIncome = string.Empty;
	private int education = enumUndefined;
	private string zipcode = string.Empty;
	private string interests = string.Empty;
	private string iap = string.Empty;
	private string iapAmount = string.Empty;
	private string numberOfSessions = string.Empty;
	private string psTime = string.Empty;
	private string lastSession = string.Empty;
	private int connection = enumUndefined;
	private string device = string.Empty;
	private string appVersion = string.Empty;
	private Vector2 windowMargin;
	private Vector2 listMargin;
	SPUser SPUser;
#if UNITY_IPHONE || UNITY_IOS
		private bool locationToggleOn;
#endif

	private int numColumns = 2;

	// Awake: Called when the script instance is being loaded.
	
	void Awake ()
	{

	}
	
	
	// Start: Use this for initialization
	
	void Start ()
	{
		print ("UserSegmentationSponsorPaySDK's Start invoked");

		SPUser = SponsorPayPluginMonoBehaviour.PluginInstance.SPUser;
		ViewHeight = 4500;

#if UNITY_IPHONE || UNITY_IOS
				Input.location.Start();
#endif
		GetSPUserValues ();

	}
		
	override protected void DrawImpl ()
	{

		float y = GuiRectBigPadding;
		float x = HorizontalMargin;


		
		// ScrollView
		Rect outerScrollRect = new Rect (0, 0, Screen.width, Screen.height);
		Rect innerScrollRect = new Rect (0, 0, Screen.width, ViewHeight);
		scrollPosition = GUI.BeginScrollView (outerScrollRect, scrollPosition, innerScrollRect, false, false);

		// General SDK Settings
		GUI.Label (new Rect (x, y, GuiRectWidth, GuiLabelHeight), "Age:");
		y += GuiLabelHeight + GuiRectSmallPadding;
		
		age = TextField ("age", new Rect (x, y, GuiRectWidth, GuiTapTargetHeight), age, TouchScreenKeyboardType.NumberPad);
		
		y += GuiTapTargetHeight + GuiRectBigPadding;

		// Birthday
		GUI.Label (new Rect (x, y, GuiRectWidth, GuiLabelHeight), "Birthday(yyyy/MM/dd): ");
		
		y += GuiLabelHeight + GuiRectSmallPadding;
		birthdate = TextField ("birthdate", new Rect (x, y, GuiRectWidth, GuiTapTargetHeight), birthdate, TouchScreenKeyboardType.Default);
		y += GuiTapTargetHeight + GuiRectBigPadding;

		// Gender
		GUI.Label (new Rect (x, y, GuiRectWidth, GuiLabelHeight), "Gender: ");
		y += GuiLabelHeight + GuiRectSmallPadding;
		int genderHeightMultiplier = (int)Math.Ceiling ((Enum.GetNames (typeof(SPUserGender)).Length / (double)numColumns));
		Rect genderRect = new Rect (x, y, GuiRectWidth, GuiTapTargetHeight * genderHeightMultiplier);
		gender = GUI.SelectionGrid (genderRect, gender, Enum.GetNames (typeof(SPUserGender)), numColumns);
		y += GuiTapTargetHeight * genderHeightMultiplier + GuiRectBigPadding;

		// Sexual Orientation
		GUI.Label (new Rect (x, y, GuiRectWidth, GuiLabelHeight), "Sexual Orientation: ");
		y += GuiLabelHeight + GuiRectSmallPadding;
		int sexualOrientationHeightMultiplier = (int)Math.Ceiling (Enum.GetNames (typeof(SPUserSexualOrientation)).Length / (double)numColumns);
		Rect sexualOrientationRect = new Rect (x, y, GuiRectWidth, GuiTapTargetHeight * sexualOrientationHeightMultiplier);
		sexualOrientation = GUI.SelectionGrid (sexualOrientationRect, sexualOrientation, Enum.GetNames (typeof(SPUserSexualOrientation)), 2);
		y += GuiTapTargetHeight * sexualOrientationHeightMultiplier + GuiRectBigPadding;

		// Ethnicity
		GUI.Label (new Rect (x, y, GuiRectWidth, GuiLabelHeight), "Ethnicity: ");
		y += GuiLabelHeight + GuiRectSmallPadding;
		int ethnicityHeightMultiplier = (int)Math.Ceiling (Enum.GetNames (typeof(SPUserEthnicity)).Length / (double)numColumns);
		Rect ethnicityRect = new Rect (x, y, GuiRectWidth, GuiTapTargetHeight * ethnicityHeightMultiplier);
		ethnicity = GUI.SelectionGrid (ethnicityRect, ethnicity, Enum.GetNames (typeof(SPUserEthnicity)), numColumns);
		y += GuiTapTargetHeight * ethnicityHeightMultiplier + GuiRectBigPadding;

		// Location
		GUI.Label (new Rect (x, y, GuiRectWidth, GuiLabelHeight), "latitude:value, longtitude:value ");
		
		y += GuiLabelHeight + GuiRectSmallPadding;
		location = TextField ("location", new Rect (x, y, GuiRectWidth, GuiTapTargetHeight), location, TouchScreenKeyboardType.Default);

#if UNITY_IPHONE || UNITY_IOS
				y += GuiTapTargetHeight + GuiRectSmallPadding;
				locationToggleOn = GUI.Toggle(new Rect (x, y + GuiPaddingTopToggle, GuiRectWidth, GuiTapTargetHeight), locationToggleOn, "Update location");
#endif

		y += GuiTapTargetHeight + GuiRectBigPadding;

		// Marital Status
		GUI.Label (new Rect (x, y, GuiRectWidth, GuiLabelHeight), "Marital Status: ");
		y += GuiLabelHeight + GuiRectSmallPadding;
		int maritalHeightMultiplier = (int)Math.Ceiling (Enum.GetNames (typeof(SPUserMaritalStatus)).Length / (double)numColumns);
		Rect maritalRect = new Rect (x, y, GuiRectWidth, GuiTapTargetHeight * maritalHeightMultiplier);
		maritalStatus = GUI.SelectionGrid (maritalRect, maritalStatus, Enum.GetNames (typeof(SPUserMaritalStatus)), numColumns);
		y += GuiTapTargetHeight * maritalHeightMultiplier + GuiRectBigPadding;


		// Annual HouseholdIncome
		GUI.Label (new Rect (x, y, GuiRectWidth, GuiLabelHeight), "Annual Household Income: ");
		
		y += GuiLabelHeight + GuiRectSmallPadding;
		annualHouseholdIncome = TextField ("annualHouseholdIncome", new Rect (x, y, GuiRectWidth, GuiTapTargetHeight), annualHouseholdIncome, TouchScreenKeyboardType.NumberPad);
		
		y += GuiTapTargetHeight + GuiRectBigPadding;

		// Education
		GUI.Label (new Rect (x, y, GuiRectWidth, GuiLabelHeight), "Education: ");
		y += GuiLabelHeight + GuiRectSmallPadding;
		int educationHeightMultiplier = (int)Math.Ceiling (Enum.GetNames (typeof(SPUserEducation)).Length / (double)numColumns);
		Rect educationRect = new Rect (x, y, GuiRectWidth, GuiTapTargetHeight * educationHeightMultiplier);
		education = GUI.SelectionGrid (educationRect, education, Enum.GetNames (typeof(SPUserEducation)), numColumns);
		y += GuiTapTargetHeight * educationHeightMultiplier + GuiRectBigPadding;

		GUI.Label (new Rect (x, y, GuiRectWidth, GuiLabelHeight), "Zipcode: ");
		
		y += GuiLabelHeight + GuiRectSmallPadding;
		zipcode = TextField ("zipcode", new Rect (x, y, GuiRectWidth, GuiTapTargetHeight), zipcode, TouchScreenKeyboardType.Default);

		y += GuiTapTargetHeight + GuiRectBigPadding;
 
		GUI.Label (new Rect (x, y, GuiRectWidth, GuiLabelHeight), "Interests: ");
		
		y += GuiLabelHeight + GuiRectSmallPadding;
		interests = TextField ("interests", new Rect (x, y, GuiRectWidth, GuiTapTargetHeight), interests, TouchScreenKeyboardType.Default);
		
		y += GuiTapTargetHeight + GuiRectBigPadding;

		GUI.Label (new Rect (x, y, GuiRectWidth, GuiLabelHeight), "IAP: ");
		
		y += GuiLabelHeight + GuiRectSmallPadding;
		iap = TextField ("iap", new Rect (x, y, GuiRectWidth, GuiTapTargetHeight), iap, TouchScreenKeyboardType.Default);
		
		y += GuiTapTargetHeight + GuiRectBigPadding;

		GUI.Label (new Rect (x, y, GuiRectWidth, GuiLabelHeight), "IAP amount: ");
		
		y += GuiLabelHeight + GuiRectSmallPadding;
		iapAmount = TextField ("iap_amount", new Rect (x, y, GuiRectWidth, GuiTapTargetHeight), iapAmount, TouchScreenKeyboardType.NumberPad);
		
		y += GuiTapTargetHeight + GuiRectBigPadding;

		GUI.Label (new Rect (x, y, GuiRectWidth, GuiLabelHeight), "Number of Sessions: ");
		
		y += GuiLabelHeight + GuiRectSmallPadding;
		numberOfSessions = TextField ("numberOfSessions", new Rect (x, y, GuiRectWidth, GuiTapTargetHeight), numberOfSessions, TouchScreenKeyboardType.NumberPad);
		
		y += GuiTapTargetHeight + GuiRectBigPadding;

		GUI.Label (new Rect (x, y, GuiRectWidth, GuiLabelHeight), "PS time: ");
		
		y += GuiLabelHeight + GuiRectSmallPadding;
		psTime = TextField ("ps_time", new Rect (x, y, GuiRectWidth, GuiTapTargetHeight), psTime, TouchScreenKeyboardType.NumberPad);
		
		y += GuiTapTargetHeight + GuiRectBigPadding;

		GUI.Label (new Rect (x, y, GuiRectWidth, GuiLabelHeight), "Last session: ");
		
		y += GuiLabelHeight + GuiRectSmallPadding;
		lastSession = TextField ("last_session", new Rect (x, y, GuiRectWidth, GuiTapTargetHeight), lastSession, TouchScreenKeyboardType.NumberPad);
		
		y += GuiTapTargetHeight + GuiRectBigPadding;

		// Connection
		GUI.Label (new Rect (x, y, GuiRectWidth, GuiLabelHeight), "Connection: ");
		y += GuiLabelHeight + GuiRectSmallPadding;
		int connectionHeightMultiplier = (int)Math.Ceiling (Enum.GetNames (typeof(SPUserConnection)).Length / (double)numColumns);
		Rect connectionRect = new Rect (x, y, GuiRectWidth, GuiTapTargetHeight * connectionHeightMultiplier);
		connection = GUI.SelectionGrid (connectionRect, connection, Enum.GetNames (typeof(SPUserConnection)), numColumns);
		y += GuiTapTargetHeight * connectionHeightMultiplier + GuiRectBigPadding; 

		// Device
		GUI.Label (new Rect (x, y, GuiRectWidth, GuiLabelHeight), "Device: ");
		
		y += GuiLabelHeight + GuiRectSmallPadding;
		device = TextField ("device", new Rect (x, y, GuiRectWidth, GuiTapTargetHeight), device, TouchScreenKeyboardType.Default);
		
		y += GuiTapTargetHeight + GuiRectBigPadding;

		GUI.Label (new Rect (x, y, GuiRectWidth, GuiLabelHeight), "App version: ");
		
		y += GuiLabelHeight + GuiRectSmallPadding;
		appVersion = TextField ("app_version", new Rect (x, y, GuiRectWidth, GuiTapTargetHeight), appVersion, TouchScreenKeyboardType.Default);
		
		y += GuiTapTargetHeight + GuiRectBigPadding;

		if (GUI.Button (new Rect (x, y, GuiRectWidth, GuiTapTargetHeight), "Submit")) {
			SetProvidedValues ();
			GotoInitialScene ();
		}

		y += GuiTapTargetHeight + GuiRectBigPadding;
				
		if (GUI.Button (new Rect (x, y, GuiRectWidth, GuiTapTargetHeight), "Clear")) {
			ResetSPUser ();
		}

		GUI.EndScrollView ();
	}
	
	override protected void DialogClosed ()
	{
		// do nothing
	}
		
	private void GetSPUserValues ()
	{
		setValue (out age, SPUser.GetAge ());
		setValue (out birthdate, SPUser.GetBirthdate ());
		setValue (out location, SPUser.GetLocation ());
		setValue (out numberOfChildrens, SPUser.GetNumberOfChildrens ());
		setValue (out annualHouseholdIncome, SPUser.GetAnnualHouseholdIncome ());
		setValue (out zipcode, SPUser.GetZipcode ());
		setValue (out interests, SPUser.GetInterests ());
		setValue (out iapAmount, SPUser.GetIapAmount ());
		setValue (out numberOfSessions, SPUser.GetNumberOfSessions ());
		setValue (out psTime, SPUser.GetPsTime ());
		setValue (out lastSession, SPUser.GetLastSession ());
		setValue (out device, SPUser.GetDevice ());
		setValue (out appVersion, SPUser.GetAppVersion ());

		setValue (out iap, SPUser.GetIap ());
		//enums
		gender = SPUser.GetGender () != null ? (int)SPUser.GetGender () : enumUndefined;
		sexualOrientation = SPUser.GetSexualOrientation () != null ? (int)SPUser.GetSexualOrientation () : enumUndefined;
		ethnicity = SPUser.GetEthnicity () != null ? (int)SPUser.GetEthnicity () : enumUndefined;
		education = SPUser.GetEducation () != null ? (int)SPUser.GetEducation () : enumUndefined;
		maritalStatus = SPUser.GetMaritalStatus () != null ? (int)SPUser.GetMaritalStatus () : enumUndefined;
		connection = SPUser.GetConnection () != null ? (int)SPUser.GetConnection () : enumUndefined;
	}

	private void setValue (out string var, object value)
	{
		if (value != null) {
			if (value is SPLocation) {
				SPLocation loc = (SPLocation)value;
				var = "Latitude: " + loc.Lat + ", Longitude:" + loc.Long;
			} else if (value is string[]) {
				var = string.Join (", ", (string[])value);
			} else if (value is DateTime) {
				var = ((DateTime)value).ToString ("yyyy/MM/dd");
			} else {
				var = (string)Convert.ChangeType (value, TypeCode.String);
			}
		} else {
			var = string.Empty;
		}
	}

	private void ResetSPUser ()
	{
		age = string.Empty;
		birthdate = string.Empty;
		gender = enumUndefined;
		sexualOrientation = enumUndefined;
		ethnicity = enumUndefined;
		location = string.Empty;
		maritalStatus = enumUndefined;
		numberOfChildrens = string.Empty;
		annualHouseholdIncome = string.Empty;
		education = enumUndefined;
		zipcode = string.Empty;
		interests = string.Empty;
		iap = string.Empty;
		iapAmount = string.Empty;
		numberOfSessions = string.Empty;
		psTime = string.Empty;
		lastSession = string.Empty;
		connection = enumUndefined;
		device = string.Empty;
		appVersion = string.Empty;
	}

	private void SetProvidedValues ()
	{
		getAgeAndSetSPUser ();
		getBirthdateAndSetSPUser ();
#if UNITY_IPHONE || UNITY_IOS
				if (locationToggleOn) {
					getLocationAndSetSPUser ();
				}
#else
		getLocationAndSetSPUser ();
#endif
		getNumberOfChildrensAndSetSPUser ();
		getAnnualHouseholdIncomeAndSetSPUser ();
		getZipcodeAndSetSPUser ();
		getInterestsAndSetSPUser ();
		getIapAmountAndSetSPUser ();
		getNumberOfSessionsAndSetSPUser ();
//		getPsTimeAndSetSPUser ();
//		getLastSessionAndSetSPUser ();
		getDeviceAndSetSPUser ();
		getAppVersionAndSetSPUser ();


		hasIapAndSetSPUser ();

		//enums
		getGenderAndSetSPUser ();
		getSexualOrientationAndSetSPUser ();
		getEthnicityAndSetSPUser ();
		getMaritalStatusAndSetSPUser ();
		getEducationAndSetSPUser ();
		getConnectionAndSetSPUser ();

	}

	private void GotoInitialScene ()
	{
		Application.LoadLevel (0);
	}

	private Boolean checkIfValueHasBeenSet (string value)
	{
		return !string.IsNullOrEmpty (value);
	}

	private void getAgeAndSetSPUser ()
	{
		if (checkIfValueHasBeenSet (age)) {
			SPUser.SetAge (Int32.Parse (age));
		}
	}
	
	private void getBirthdateAndSetSPUser ()
	{
		if (checkIfValueHasBeenSet (birthdate)) {

			string pattern = "yyyy/MM/dd";
			DateTime parsedDate;
			
			DateTime.TryParseExact (birthdate, pattern, null, DateTimeStyles.None, out parsedDate);

			SPUser.SetBirthdate (parsedDate);
		}
	}
	
	private void getGenderAndSetSPUser ()
	{	
		Console.WriteLine ("Setting Gender value: {0} ", (SPUserGender)gender);
		if (gender != -1) {
			SPUser.SetGender ((SPUserGender)gender);
		}
	}
	
	private void getSexualOrientationAndSetSPUser ()
	{
		if (sexualOrientation != enumUndefined) {
			SPUser.SetSexualOrientation ((SPUserSexualOrientation)sexualOrientation);
		}
	}
	
	private void getEthnicityAndSetSPUser ()
	{
		if (ethnicity != enumUndefined) {
			SPUser.SetEthnicity ((SPUserEthnicity)ethnicity);
		}
	}
	
	private void getLocationAndSetSPUser ()
	{
		if (checkIfValueHasBeenSet (location)) {
			String[] latAndLongt = location.Split (',');
	
			String latitude = spliLatAndLongt (latAndLongt [0]);
			String longtitude = spliLatAndLongt (latAndLongt [1]);
				
			SponsorPay.SPLocation locationToBeSet = new SponsorPay.SPLocation ();
			locationToBeSet.Lat = float.Parse (latitude);
			locationToBeSet.Long = float.Parse (longtitude);
	        
			SPUser.SetLocation (locationToBeSet);
		}
	}
	
	private String spliLatAndLongt (String latOrLongt)
	{
		String latOrLongtFullValue = latOrLongt;
		String[] latOrLongtArray = latOrLongtFullValue.Split (':');
		
		return latOrLongtArray [1].Replace (" ", "");
	}
	
	private void getMaritalStatusAndSetSPUser ()
	{
		if (maritalStatus != enumUndefined) {
			SPUser.SetMaritalStatus ((SPUserMaritalStatus)maritalStatus);
		}
	}
	
	private void getNumberOfChildrensAndSetSPUser ()
	{
		if (checkIfValueHasBeenSet (numberOfChildrens)) {
			SPUser.SetNumberOfChildrens (Int32.Parse (numberOfChildrens));
		}
	}
	
	private void getAnnualHouseholdIncomeAndSetSPUser ()
	{
		if (checkIfValueHasBeenSet (annualHouseholdIncome)) {
			SPUser.SetAnnualHouseholdIncome (Int32.Parse (annualHouseholdIncome));
		}
	}
	
	private void getEducationAndSetSPUser ()
	{
		if (education != enumUndefined) {
			SPUser.SetEducation ((SPUserEducation)education);
		}
	}
	
	private void getZipcodeAndSetSPUser ()
	{
		if (checkIfValueHasBeenSet (zipcode)) {
			SPUser.SetZipcode (zipcode);
		}
	}
	
	private void getInterestsAndSetSPUser ()
	{
		if (checkIfValueHasBeenSet (interests)) {
			string[] words = interests.Split (',');
			SPUser.SetInterests (words);
		}
	}
	
	private void hasIapAndSetSPUser ()
	{
		if (checkIfValueHasBeenSet (iap)) {				
			SPUser.SetIap (Boolean.Parse (iap));
		}
	}
	
	private void getIapAmountAndSetSPUser ()
	{
		if (checkIfValueHasBeenSet (iapAmount)) {
			SPUser.SetIapAmount (float.Parse (iapAmount));
		}
	}
	
	private void getNumberOfSessionsAndSetSPUser ()
	{
		if (checkIfValueHasBeenSet (numberOfSessions)) {
			SPUser.SetNumberOfSessions (Int32.Parse (numberOfSessions));
		}
	}
	
	private void getPsTimeAndSetSPUser ()
	{
		if (checkIfValueHasBeenSet (psTime)) {
			SPUser.SetPsTime (long.Parse (psTime));
		}
	}
	
	private void getLastSessionAndSetSPUser ()
	{
		if (checkIfValueHasBeenSet (lastSession)) {
			SPUser.SetLastSession (long.Parse (lastSession));
		}
	}
	
	private void getConnectionAndSetSPUser ()
	{
		if (connection != enumUndefined) {
			SPUser.SetConnection ((SPUserConnection)connection);
		}
	}
	
	private void getDeviceAndSetSPUser ()
	{
		if (checkIfValueHasBeenSet (device)) {
			SPUser.SetDevice (device);
		}
	}
	
	private void getAppVersionAndSetSPUser ()
	{
		if (checkIfValueHasBeenSet (appVersion)) {
			SPUser.SetAppVersion (appVersion);
		}
	}
	
}
	
