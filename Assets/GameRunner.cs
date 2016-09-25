using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;

public class GameRunner : MonoBehaviour {
	public GameObject normalChestPrefab;
	public GameObject superChestPreFab;
	public GameObject moneyRewardPrefab;
	public GameObject laserRewardPrefab;
	public GameObject gemRewardPrefab;
	public float objectSpeed;
	public List<GameObject> chests = new List<GameObject>();
	private GameObject parentImageTrackerObject;

	private const float chestSpeed = 2.0f;
	private const int regChestRegGame = 6; // regular chests in regular game
	private const int supChestRegGame = 0; // super chests in regular game
	private const int regChestPowGame = 4; // regular chests in gold rush game
	private const int supChestPowGame = 2; // super chests in gold rush game

	private Vector3[] positions = {
		new Vector3 (-3f, -3f, 1f),
		new Vector3 (3f, -3f, 1f),
		new Vector3 (-3f, 0.0f, 1f),
		new Vector3 (3f, 0.0f, 1f),
		new Vector3 (-3f, 3f, 1f),
		new Vector3 (3f, 3f, 1f)
	};
	private int iterator = 0;
	private Box box = new Box(new Vector3(0,0,1), 20.0f); // box bounding where the chests go

	// Use this for initialization
	void Start () {
	}


//	public void debugKillChest() {
//		chests [0].GetComponent<TreasureChest> ().markedForDeletion = true;
//	}
		
	// Update is called once per frame
	void Update () {
		// loop each chest
		foreach (GameObject chestGameObj in chests) {
			// if chest destroyed, continue
			if (chestGameObj == null) continue;
			// get chest obj
			TreasureChest chest = chestGameObj.GetComponent<TreasureChest> ();

			// logic for chests that have been killed
			if (chest.markedForDeletion) {
				Vector3 coordStart = chestGameObj.transform.position;
				List<TreasureContents> contents = chestGameObj.GetComponent<TreasureChest> ().contents;
				Player.awardChest (chest);
				if (MasterManager.Instance != null)
				{
					

					GameObject.Instantiate(MasterManager.Instance.ExplodeParticle,coordStart,Quaternion.identity);
				}
				Destroy (chestGameObj);
				foreach (TreasureContents content in contents) {
					animateReward (content, coordStart);
				}
			// logic for moving the chests around
			} else {
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
	}
		
	GameObject removeAndReturnFromList(List<GameObject> list) {
		// int index = list.FindIndex( SOME_PARAMETER_IN );
		int index = 0;
		GameObject result = list[index];
		list.RemoveAt(index);
		return result;
	}

	void animateReward (TreasureContents reward, Vector3 startLoc) {
		for (int i = 0; i < reward.treasureQualifier; i++) {
			animateRewardSub (reward, startLoc);
		}
	}
		
	void animateRewardSub (TreasureContents reward, Vector3 startLoc) {
		GameObject prefabToUse;
		switch (reward.contentType) {
		case "money":
			prefabToUse = moneyRewardPrefab;
			break;
		case "gem":
			prefabToUse = gemRewardPrefab;
			break;
		case "laser":
			prefabToUse = laserRewardPrefab;
			break;
		default:
			return;
		}
			
		GameObject go = (GameObject) GameObject.Instantiate (prefabToUse, startLoc, Quaternion.identity);
		Vector3 p1 = startLoc;
		Vector3 p4 = new Vector3 (0, 0.7f, 0);
		float scale = 2.0f;
		Vector3 p2 = ((p1+p4) * 3/4) + (Vector3.up * 3.0f) + new Vector3(UnityEngine.Random.Range(-scale,scale),UnityEngine.Random.Range(-scale,scale),UnityEngine.Random.Range(-scale,scale));
		Vector3 p3 = ((p1+p4) * 1/4) + (Vector3.up * 3.0f) + new Vector3(UnityEngine.Random.Range(-scale,scale),UnityEngine.Random.Range(-scale,scale),UnityEngine.Random.Range(-scale,scale));
		LeanTween.move (go, new LTBezierPath (new Vector3[] {p1,p2,p3,p4}), 2.0f).setDestroyOnComplete (true);;
	}

	public void StartGame(bool powered, GameObject parentImageTrackerObjectIn) {
		parentImageTrackerObject = parentImageTrackerObjectIn;

		if (powered) {
			for (int i = 0; i < regChestPowGame; i++) 
				AddTreasureChest (false).transform.SetParent(parentImageTrackerObject.transform);
			for (int i = 0; i < supChestPowGame; i++)
				AddTreasureChest (true).transform.SetParent(parentImageTrackerObject.transform);
		} else {
			for (int i = 0; i < regChestRegGame; i++)
				AddTreasureChest (false).transform.SetParent(parentImageTrackerObject.transform);
			for (int i = 0; i < supChestRegGame; i++)
				AddTreasureChest (true).transform.SetParent(parentImageTrackerObject.transform);
		}
	}

	// this tries to reset stuff when vuforia loses but then refinds the anchor, or a new anchor
	public void reattachChests(GameObject parentImageTrackerObjectIn) {
		// todo: see if cube needs to reset?? positions of currently moving boxes?????????
		// other todo: kill old cauldron, make new one. currently each anchor will have its own cauldron
		parentImageTrackerObject = parentImageTrackerObjectIn;
		foreach (GameObject gc in chests) {
			gc.transform.SetParent(parentImageTrackerObject.transform);
		}
	}

	// return value: the GameObject object, not the TreasureChest object
	private GameObject AddTreasureChest(bool superChest) {
		GameObject go;
		TreasureChest tc;
		if (superChest) {
			go = (GameObject) GameObject.Instantiate (normalChestPrefab, getPos(), Quaternion.identity);
		} else {
			go = (GameObject) GameObject.Instantiate (superChestPreFab, getPos(), Quaternion.identity);
		}
		go.GetComponent<TreasureChest> ().currentTarget = box.getRandPoint ();
		chests.Add (go);
		return go;
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
		return new Vector3 (UnityEngine.Random.Range (x1, x2), UnityEngine.Random.Range (y1, y2), UnityEngine.Random.Range (z1, z2) );
	}

}
