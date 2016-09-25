using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LaserBuyButton : MonoBehaviour {

	public string cost = "$1.35";
	public string desc = "Lasers";
	public int lasercount;

	public void Start()
	{
		GetComponentInChildren<Text>().text = desc;
	}
}
