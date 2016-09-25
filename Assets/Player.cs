using UnityEngine;
using System.Collections;

public static class Player {
	public static int laserCount = 12;
	public static int gemCount = 780;
	public static float moneyCount = 10;
	public static int goldRushCount = 2;
	public static string name = "Meme MASTER";

	// awards all contents in TreasureChest object
	public static void awardChest(TreasureChest chestIn) {
		foreach (TreasureContents tc in chestIn.contents) {
			awardChestContentObj (tc);
		}
	}
	// awards a chestContents object
	public static void awardChestContentObj(TreasureContents contentsIn) {
		switch (contentsIn.contentType) {
		case "none":
			break;
		case "money":
			moneyCount += contentsIn.contentQuantity;
			break;
		case "gem":
			gemCount += contentsIn.contentQuantity;
			break;
		case "laser":
			laserCount += contentsIn.contentQuantity;
			break;
		}
	}
}
