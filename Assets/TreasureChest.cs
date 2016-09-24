using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TreasureChest : MonoBehaviour {
	public List<TreasureContents> contents = new List<TreasureContents>();
	public System.Random rnd = new System.Random();
	public int health;

	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update () {}

	void openChest() {
		Player.awardChest (this);
	}

	bool hit() {
		health = health - 1;
		return (health <= 0);
	}
}

public class TreasureContents {
	// money, laser, gems, "nothing"
	public string contentType;
	public int contentQuantity;
	public bool rareTreasure;
	System.Random rnd = new System.Random();

	public TreasureContents () {
		
		switch (rnd.Next (1, 5)) {
		case 1:
			contentType = "money";
			contentQuantity = getQuant (1,50);
			break;
		case 2:
			contentType = "laser";
			contentQuantity = getQuant (1,10);
			break;
		case 3:
			contentType = "gem";
			contentQuantity = getQuant (10,100);
			break;
		case 4:
			contentType = "none";
			break;
		}
	}

	// when run, also sets rareTreasure bool on this instance
	private int getQuant(int min, int max) {
		int tempMax = max - min;
		float quant;

		rareTreasure = true;
		int seed = rnd.Next (1, 101);
		if (seed < 80) {
			quant = 0;
			rareTreasure = false;
		} else if (seed < 87) {
			quant = 0.1f * tempMax;
			rareTreasure = false;
		} else if (seed < 92) {
			quant = 0.3f * tempMax;
		} else if (seed < 95) {
			quant = 0.5f * tempMax;
		} else if (seed < 98) {
			quant = 0.7f * tempMax;
		} else {
			quant = 0.9f * tempMax;
		}
		quant = quant + tempMax * (0.1f * rnd.Next(1, 11));
		quant = quant + min;
		return (int) Mathf.Floor (quant);
	}
}
