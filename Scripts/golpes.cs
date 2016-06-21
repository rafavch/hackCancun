using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class golpes : MonoBehaviour {
	int value;
	public int collisionCount = 0;
	//string ourPostData = "{\"value\":\"" + value + "\"}";
	//string ourPostData = "{\"value\":\"133\"}";
	// Use this for initialization
	public void Start () {
		//string ourPostData = "{\"value\":\"" + value + "\"}";
		//doPost (ourPostData);
	}

	void OnCollisionEnter (Collision collision) {
		collisionCount += 1;
		print (collisionCount);
		float value = collisionCount;
		//print (value);
		string ourPostData = "{\"value\":\"" + value + "\"}";
		doPost (ourPostData);
	}

	//void Update() {

		//float value = collisionCount;
		//print (value);
		//string ourPostData = "{\"value\":\"" + value + "\"}";
		//doPost (ourPostData);
	//}

	private void doPost(string value) {
		//string url = "http://api-m2x.att.com/v2/devices/87a4bde5d92d52a57c9c86816b92908f/streams/nivel/value" -H "X-M2X-KEY:718017d8dddc0ae63b45e2963caa63fd" -H ""
		Dictionary<string, string> headers = new Dictionary<string, string>();
		headers.Add("X-HTTP-Method-Override", "PUT");
		headers.Add("Content-Type", "application/json");
		headers.Add("X-M2X-KEY", "718017d8dddc0ae63b45e2963caa63fd");
		byte[] pData = System.Text.Encoding.UTF8.GetBytes (value.ToCharArray ());

		WWW www = new WWW("http://api-m2x.att.com/v2/devices/87a4bde5d92d52a57c9c86816b92908f/streams/nivel/value", pData, headers);
		//form.AddField("var1", "value1");
		//form.AddField("var2", "value2");
		//WWW www = new WWW(url, pData, headers);

		StartCoroutine(WaitForRequest(www));
	}

	IEnumerator WaitForRequest(WWW www)
	{
		yield return www;

		// check for errors
		if (www.error == null)
		{
			Debug.Log("WWW Ok!: " + www.data);
		} else {
			Debug.Log("WWW Error: "+ www.error);
		}    
	}

	// Update is called once per frame
	//void Update () {
	//
	//}
}
