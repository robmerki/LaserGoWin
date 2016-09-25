using UnityEngine;
using System.Collections;

public class LookAtCamera : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		Vector3 rot = new Vector3(0,90,0);

		transform.rotation = Camera.main.transform.rotation * Quaternion.Euler(rot);
	}
}
