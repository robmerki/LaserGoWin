using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	public static GameManager instance;
	// this may be more complex in final version
	public bool isPowered;

	public void InitializeGame(bool power) {
		isPowered = power;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	// Use this for initialization
	void Start () {
		if (instance != null && instance != this) {
			Destroy (gameObject);
			return;
		}
		instance = this;
	}	

	public void ShootLaserButtonClick () {
		//
	}
	public void otherButtonClick() {
		// 
	}
}
