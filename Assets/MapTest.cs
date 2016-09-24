using UnityEngine;
using System.Collections;

public class MapTest : MonoBehaviour {

	// Use this for initialization
	void Start () {
		//StartCoroutine(RequestMap());
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetKeyDown(KeyCode.Space))
		{
			StartCoroutine(RequestMap());
		}
	}

	void SetMap()
	{

	}

	string url = "";
	public float lat = 49.27763f;
	public float lon = -123.1186f;
	LocationInfo li;
	public int zoom;

	IEnumerator RequestMap()
	{
		//li = new LocationInfo();

		//lat = li.latitude;
		//lon = li.longitude;

		//url = "https://maps.googleapis.com/maps/api/staticmap?center=Vancouver&size=640x640&style=element:labels|visibility:off&style=element:geometry.stroke|visibility:off&style=feature:landscape|element:geometry|saturation:-100&style=feature:water|saturation:-100|invert_lightness:true&key="+"AIzaSyA3PCTWtIVqJkbp41RlYFsrba3eCkY8aTA";
		//url = "https://maps.googleapis.com/maps/api/staticmap?maptype=satellite&center=37.530101,38.600062&zoom=14&size=640x400&key="+"AIzaSyA3PCTWtIVqJkbp41RlYFsrba3eCkY8aTA";

		url = "https://maps.googleapis.com/maps/api/staticmap?center="+lat+","+lon+"&zoom="+zoom+"&size=640x640&key="+"AIzaSyA3PCTWtIVqJkbp41RlYFsrba3eCkY8aTA";

		WWW www = new WWW(url);

		yield return www;

		GetComponent<MeshRenderer>().material.mainTexture = www.texture;

	}
}
