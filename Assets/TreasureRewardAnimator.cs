using UnityEngine;
using System.Collections;

// THIS CLASS CURRENTLY NOT USED

public class TreasureRewardAnimator : MonoBehaviour {
	[System.NonSerialized]
	public TreasureContents contents;

	// Use this for initialization
	void Start () {
	
	}
		
	public void set(TreasureContents contentsIn) {
		// set the reward contents
		contents = contentsIn;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
