using UnityEngine;
using System.Collections;

public class MapManager : MonoBehaviour
{


	float accuracyDistance = 20;
	float updateDistance = 20;

	void Start ()
	{
		Input.location.Start(accuracyDistance,updateDistance);
	}

	public void UpdateLocation()
	{
		
	}

	public void Update()
	{

	}
}
