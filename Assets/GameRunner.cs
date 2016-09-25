using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class GameRunner : MonoBehaviour {
	public GameObject normalChestPrefab;
	public GameObject superChestPreFab;
	public float objectSpeed;
	public List<GameObject> chests = new List<GameObject>();
	private GameObject parentImageTrackerObject;

	public Text debug;

	private const float chestSpeed = 10.0f;
	private const int regChestRegGame = 6;
	private const int supChestRegGame = 0;
	private const int regChestPowGame = 4;
	private const int supChestPowGame = 2;
	private Vector3[] positions = {
		new Vector3 (-3f, -3f, 1f),
		new Vector3 (3f, -3f, 1f),
		new Vector3 (-3f, 0.0f, 1f),
		new Vector3 (3f, 0.0f, 1f),
		new Vector3 (-3f, 3f, 1f),
		new Vector3 (3f, 3f, 1f)
	};
	private int iterator = 0;
	private Box box = new Box(new Vector3(0,0,1), 20.0f);

	// Use this for initialization
	void Start () {
		debug = GameObject.Find ("DEBUG").GetComponent<Text>();
	}
		
	// Update is called once per frame
	void Update () {
		foreach (GameObject chestGameObj in chests) {
			TreasureChest chest = chestGameObj.GetComponent<TreasureChest> ();
			
			chestGameObj.transform.position = Vector3.MoveTowards (
				chestGameObj.transform.position,
				chest.currentTarget,
				(chest.goFast ? chestSpeed * 2 : chestSpeed) * Time.deltaTime
			);
			if (Vector3.Distance (chestGameObj.transform.position, chest.currentTarget) < 1.0f) {
				chest.currentTarget = box.getRandPoint ();
			}
		}
	}

	public void StartGame(bool powered, GameObject parentImageTrackerObjectIn) {
		parentImageTrackerObject = parentImageTrackerObjectIn;

		if (powered) {
			for (int i = 0; i < regChestPowGame; i++) 
				AddTreasureChest (false);
			for (int i = 0; i < supChestPowGame; i++)
				AddTreasureChest (true);
		} else {
			for (int i = 0; i < regChestRegGame; i++)
				AddTreasureChest (false);
			for (int i = 0; i < supChestRegGame; i++)
				AddTreasureChest (true);
		}
	}

	// todo
	public void reattachChests(GameObject parentImageTrackerObjectIn) {
		
	}

	private void AddTreasureChest(bool superChest) {
		GameObject go;
		TreasureChest tc;
		if (superChest) {
			go = (GameObject) GameObject.Instantiate (normalChestPrefab, getPos(), Quaternion.identity);
		} else {
			go = (GameObject) GameObject.Instantiate (superChestPreFab, getPos(), Quaternion.identity);
		}
		go.transform.SetParent(parentImageTrackerObject.transform);
		go.GetComponent<TreasureChest> ().currentTarget = box.getRandPoint ();
		chests.Add (go);
	}

	private Vector3 getPos() {
		if (iterator >= positions.Length) {
			iterator = 0;
		}
		return positions [iterator++];
	}
}

public class Box {
	private Vector3 boxCenter;
	private float boxWidth;
	private float x1, x2, y1, y2, z1, z2;

	public Box(Vector3 boxCenterIn, float boxWidthIn) { 
		boxCenter = boxCenterIn;
		boxWidth = boxWidthIn;
		float boxHalfWidth = boxWidth / 2;
		x1 = boxCenter.x - boxHalfWidth;
		x2 = boxCenter.x + boxHalfWidth;
		y1 = boxCenter.y - boxHalfWidth;
		y2 = boxCenter.y + boxHalfWidth;
		z1 = boxCenter.z - boxHalfWidth;
		z2 = boxCenter.z + boxHalfWidth;
	}

	public Vector3 getRandPoint() {
		return new Vector3 (Random.Range (x1, x2), Random.Range (y1, y2), Random.Range (z1, z2) );
	}

}
