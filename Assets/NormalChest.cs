using UnityEngine;
using System.Collections;

public class NormalChest : TreasureChest {

	// Use this for initialization
	void Start () {
		health = 1;
		contents.Add (new TreasureContents ());
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
