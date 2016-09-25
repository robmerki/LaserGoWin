using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class MapManager : MonoBehaviour
{
	float accuracyDistance = 1;
	float updateDistance = 1;

	LocationInfo lastLocationInfo;
	float mapUpdateLimit = 10; //10 seconds
	float currentMapUpdate = 0;

	public Transform playerMapObject;
	public Transform cameraObject;
	public Material mapMat;
	public Text coords;

	//http://i.imgur.com/fOhHSpr.png //super
	//http://i.imgur.com/7jbGAnD.png //normal

	List<string> markers = new List<string>
	{
		//"&markers=icon:http://i.imgur.com/7jbGAnD.png%7C%7C49.2890615,-123.1412927",

		"&markers=icon:http://i.imgur.com/7jbGAnD.png%7C%7C49.282428,-123.1412927",
		"&markers=icon:http://i.imgur.com/7jbGAnD.png%7C%7C49.281148,-123.119334",
		"&markers=icon:http://i.imgur.com/fOhHSpr.png%7C%7C49.283039,-123.115147",
		"&markers=icon:http://i.imgur.com/7jbGAnD.png%7C%7C49.278847,-123.116423",
		"&markers=icon:http://i.imgur.com/7jbGAnD.png%7C%7C49.279406,-123.122609",
		"&markers=icon:http://i.imgur.com/7jbGAnD.png%7C%7C49.276736,-123.121911",
		"&markers=icon:http://i.imgur.com/7jbGAnD.png%7C%7C49.276006,-123.127235"

		/*
		"&markers=color:red%7Clabel:C%7C49.2890615,-123.1412927",
		"&markers=color:red%7Clabel:C%7C49.281148,-123.119334",
		"&markers=color:red%7Clabel:C%7C49.283039,-123.115147",
		"&markers=color:red%7Clabel:C%7C49.278847,-123.116423",
		"&markers=color:red%7Clabel:C%7C49.279406,-123.122609",
		"&markers=color:red%7Clabel:C%7C49.276736,-123.121911",
		"&markers=color:red%7Clabel:C%7C49.276006,-123.127235"
		*/
	};

	void Start ()
	{
		StartCoroutine(RequestMap(49.2813586f,-123.1171895f,14));

		Input.location.Start(accuracyDistance,updateDistance);
		lastLocationInfo = Input.location.lastData;
	}

	public void Update()
	{
		if (lastLocationInfo.timestamp != Input.location.lastData.timestamp)
		{
			if (Time.time >= currentMapUpdate)
			{
				currentMapUpdate += Time.time + mapUpdateLimit;
				lastLocationInfo = Input.location.lastData;
				StartCoroutine(RequestMap(lastLocationInfo.latitude,lastLocationInfo.longitude,14));

				coords.text = lastLocationInfo.latitude + "\n" + lastLocationInfo.longitude + "\n" + lastLocationInfo.timestamp;
			}
		}
		//if (Input.GetTouch(0)
	}

	string key = "AIzaSyA3PCTWtIVqJkbp41RlYFsrba3eCkY8aTA";
	LocationInfo li;
	Vector2 size = new Vector2(2048,2048);

	public IEnumerator RequestMap(float lat, float lon, float zoom)
	{
		//lock this down!
		string url = "";

		url = "https://maps.googleapis.com/maps/api/staticmap?key="+key+"&center="+lat+","+lon+"&zoom="+zoom+"&format=png&maptype=roadmap&style=feature:administrative%7Celement:geometry.fill%7Csaturation:28%7Clightness:-34&style=feature:administrative%7Celement:labels.icon%7Cvisibility:off&style=feature:administrative%7Celement:labels.text%7Cvisibility:on&style=feature:landscape%7Celement:geometry.fill%7Csaturation:-61%7Clightness:28%7Cgamma:1.09&style=feature:poi%7Celement:geometry.fill%7Csaturation:-39%7Clightness:-21%7Cgamma:1.76&style=feature:poi%7Celement:labels.icon%7Cvisibility:off&style=feature:poi%7Celement:labels.text%7Cvisibility:off&style=feature:road%7Celement:geometry.stroke%7Csaturation:40%7Clightness:-24%7Cgamma:8.24&style=feature:road%7Celement:labels.icon%7Cvisibility:off&style=feature:road%7Celement:labels.text%7Cvisibility:off&style=feature:transit%7Celement:geometry.fill%7Csaturation:73&style=feature:transit%7Celement:labels.icon%7Cvisibility:off&style=feature:transit%7Celement:labels.text%7Cvisibility:off&style=feature:water%7Celement:geometry.fill%7Csaturation:29%7Clightness:-6&size=2048x2048";


		//url = "https://maps.googleapis.com/maps/api/staticmap?center="+lat+","+lon+"&zoom="+zoom+"&size="+size.x+"x"+size.y;

		foreach (var m in markers)
		{
			url += m;
		}

		//url += "&key="+"AIzaSyA3PCTWtIVqJkbp41RlYFsrba3eCkY8aTA";

		Debug.Log(url);

		WWW www = new WWW(url);

		yield return www;

		mapMat.mainTexture = www.texture;
	}

	public void GoToGameScreen()
	{
		MasterManager.Instance.ChangeScene("GameScreen");
	}

	public void GoToShopScreen()
	{
		MasterManager.Instance.ChangeScene("shop");
	}
}
