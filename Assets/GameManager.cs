using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {
	public const int chestsPerGame = 6;

	public static GameManager instance;
	public bool isPowered;
	public List<TreasureChest> chests = new List<TreasureChest>();

	public Vector3[] positions = {
		new Vector3( 0f, -2.5f, -0.5f ),
		new Vector3( 3f, -2.5f, -0.5f ),
		new Vector3( 0f, 0f, -0.5f ),
		new Vector3( 3f, 0f, -0.5f ),
		new Vector3( 0f, 2.5f, -0.5f ),
		new Vector3( 3f, 2.5f, -0.5f )
	};

//	public Vector3[] positions = {
//		new Vector3( 0f, 0f, -0.5f ),
//		new Vector3( 0f, 0f, -0.5f ),
//		new Vector3( 0f, 0f, -0.5f ),
//		new Vector3( 0f, 0f, -0.5f ),
//		new Vector3( 0f, 0f, -0.5f ),
//		new Vector3( 0f, 0f, -0.5f )
//	};

	public void StartGame(bool power) {
		isPowered = power;
		Reset ();
		for (int i = 0; i < chestsPerGame; i++) {
			AddTreasureChest (positions[i]);
		}
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
		
	public void AddTreasureChest(Vector3 pos) {

		GameObject.Instantiate (Resources.Load ("normal_chest"),pos,Quaternion.identity);
		
	}

	public void Reset() {
		chests.Clear ();	
	}
}
