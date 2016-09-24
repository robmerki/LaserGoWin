using UnityEngine;
using System.Collections;
using UnityEngine.UI;

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

	void Start ()
	{
		StartCoroutine(RequestMap(49.27763f,-123.1186f,14));

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
	}

	string url = "";
	LocationInfo li;
	Vector2 size = new Vector2(640,640);

	public IEnumerator RequestMap(float lat, float lon, float zoom)
	{

		url = "https://maps.googleapis.com/maps/api/staticmap?center="+lat+","+lon+"&zoom="+zoom+"&size="+size.x+"x"+size.y+"&key="+"AIzaSyA3PCTWtIVqJkbp41RlYFsrba3eCkY8aTA";

		WWW www = new WWW(url);

		yield return www;

		mapMat.mainTexture = www.texture;
		//transform.position = new Vector3(lat,lon,0);

		//playerMapObject.position = new Vector3(lat,lon,0);
		//cameraObject.position = new Vector3(lat,lon,-5);
	}

	public void GoToGameScreen()
	{
		MasterManager.Instance.ChangeScene("main");
	}

	public void GoToShopScreen()
	{
		MasterManager.Instance.ChangeScene("shop");
	}
}
