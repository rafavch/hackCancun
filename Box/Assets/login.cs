using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using Facebook.Unity;

public class login : MonoBehaviour
{
	public GameObject DialogLoggedIn;
	public GameObject DialogLoggedOut;
	public GameObject DialogUsername;
	public GameObject DialogProfilePic;

	// Use this for initialization
	void Awake() {
		FbManager.Instance.InitFB ();
		DealWithFBMenus (FB.IsLoggedIn);
	}

	public void FBlogin() {
		List<string> permissions = new List<string>();
		//permissions.Add("public_profile");
		permissions.Add("publish_actions");

		FB.LogInWithPublishPermissions(permissions, AuthCallback);
	}

	void AuthCallback(IResult result) {
		if (result.Error != null) {
			Debug.Log(result.Error);
		} else {
			if (FB.IsLoggedIn) {
				FbManager.Instance.IsLoggedIn = true;
				FbManager.Instance.GetProfile ();
				Debug.Log("FB is logged in");
			} else {
				Debug.Log("FB is not logged in");
			}

			DealWithFBMenus (FB.IsLoggedIn);
		}
	}

	void DealWithFBMenus (bool isLoggedIn) {
		if (isLoggedIn) {
			DialogLoggedIn.SetActive (true);
			DialogLoggedOut.SetActive (false);

			if (FbManager.Instance.ProfileName != null) {
				Text UserName = DialogUsername.GetComponent<Text> ();
				UserName.text = "" + FbManager.Instance.ProfileName;
			} else {
				StartCoroutine ("WaitForProfileName");
			}

			if (FbManager.Instance.ProfilePic != null) {
				Image ProfilePic = DialogProfilePic.GetComponent<Image> ();
				ProfilePic.sprite = FbManager.Instance.ProfilePic;
			} else {
				StartCoroutine ("WaitForProfilePic");
			}
		} else {
			DialogLoggedIn.SetActive (false);
			DialogLoggedOut.SetActive (true);
		}
	}

	IEnumerator WaitForProfileName() {
		while(FbManager.Instance.ProfileName == null) {
			yield return null;
		}

		DealWithFBMenus (FbManager.Instance.IsLoggedIn);
	}

	IEnumerator WaitForProfilePic() {
		while(FbManager.Instance.ProfilePic == null) {
			yield return null;
		}

		DealWithFBMenus (FbManager.Instance.IsLoggedIn);
	}

	public void Share() {
		FbManager.Instance.Share ();
	}

	public void Invite() {
		FbManager.Instance.Invite ();
	}

	public void ShareWithUsers() {
		FbManager.Instance.ShareWithUsers ();
	}

}