﻿using UnityEngine;
using System.Collections;

public class PowerChest : TreasureChest {

	// Use this for initialization
	void Start () {
		health = 2;
		int treasureNum = rnd.Next(1,7);

		if (treasureNum < 5)
			treasureNum = 1;
		else if (treasureNum < 6)
			treasureNum = 2;
		else
			treasureNum = 3;
		treasureNum = treasureNum * 2;

		for (int i = 0; i < treasureNum; i++) {
			var tc = new TreasureContents ();
			tc.contentQuantity = tc.contentQuantity * 2;
			contents.Add (tc);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}