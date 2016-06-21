using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;
using System.Collections.Generic;
using Facebook.Unity;


public class FbManager : MonoBehaviour {
	public static FbManager _instance;

	public static FbManager Instance {
		get { 
			if (_instance == null) {
				GameObject fbm = new GameObject ("FBManager");
				fbm.AddComponent<FbManager> ();
			}

			return _instance;
		}
	}

	public bool IsLoggedIn    { get; set;}
	public string ProfileName { get; set;}
	public Sprite ProfilePic  { get; set;}
	public string AppLinkUrl  { get; set;}


	void Awake() {
		DontDestroyOnLoad (this.gameObject);
		_instance = this;

		IsLoggedIn = true;
	}

	public void InitFB() {
		if (!FB.IsInitialized) {
			FB.Init (setInit, OnHideUnity);	
		} else {
			IsLoggedIn = FB.IsLoggedIn;
		}
	}

	void setInit() {
		if (FB.IsLoggedIn)
		{
			Debug.Log("FB is logged in");
			GetProfile ();
		}
		else
		{
			Debug.Log("FB is not logged in");
		}

		IsLoggedIn = FB.IsLoggedIn;
	}

	void OnHideUnity(bool isGameShown) {
		if (isGameShown)
		{
			Time.timeScale = 0;
		}
		else
		{
			Time.timeScale = 1;
		}
	}

	public void GetProfile() {
		FB.API ("/me?fields=first_name", HttpMethod.GET, DisplayUsername);
		FB.API ("/me/picture?type=square&height=128&Width=128", HttpMethod.GET, DisplayProfilePic);
		FB.GetAppLink (DealWithAppLink);
	}

	void DisplayUsername(IResult result) {

		if (result.Error == null) {
			ProfileName = "" + result.ResultDictionary ["first_name"]; 
		} else {
			Debug.Log (result.Error);
		}
	}

	void DisplayProfilePic(IGraphResult result) {
		if (result.Texture != null) {
			ProfilePic = Sprite.Create (result.Texture, new Rect (0, 0, 128, 128), new Vector2 ());
		}
	}

	void DealWithAppLink(IAppLinkResult result) {
		if (!string.IsNullOrEmpty (result.Url)) {
			AppLinkUrl = result.Url;
			Debug.Log (AppLinkUrl);
		}
	}

	public void Share() {
		FB.ShareLink(
			new Uri("https://developers.facebook.com/"),
			callback: ShareCallback
		);
	}

	void ShareCallback (IResult result) {
		if (result.Cancelled) {
			Debug.Log ("Share Cancelled");
		} else if (!string.IsNullOrEmpty (result.Error)) {
			Debug.Log ("Error on Share");
		} else if(!string.IsNullOrEmpty (result.RawResult)){
			Debug.Log ("Success on Share");
		}
	}

	public void Invite() {
		FB.Mobile.AppInvite (
			new Uri(AppLinkUrl),
			null,
			InviteCallback
		);
	}

	void InviteCallback(IResult result) {
		if (result.Cancelled) {
			Debug.Log ("Invite Cancelled");
		} else if (!string.IsNullOrEmpty (result.Error)) {
			Debug.Log ("Error on Invite");
		} else if(!string.IsNullOrEmpty (result.RawResult)){
			Debug.Log ("Success on Invite");
		}
	}

	public void ShareWithUsers() {
		FB.AppRequest (
			"Unete",
			new List<string>() { "1174721656"},
			null,
			null,
			10,
			"data",
			"title",
			ShareWithUsersCallback
		);
	}

	void ShareWithUsersCallback(IAppRequestResult result) {
		if (result.Cancelled) {
			Debug.Log ("Challenge Cancelled");
		} else if (!string.IsNullOrEmpty (result.Error)) {
			Debug.Log ("Error on Challenge");
		} else if(!string.IsNullOrEmpty (result.RawResult)){
			Debug.Log (result.RawResult);
		}
	}
}
