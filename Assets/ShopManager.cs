using UnityEngine;
using System.Collections;

public static class ShopManager {
	public const float laserCost = 0.2f;
	public const float goldRushCost = 10f;

	// laser is bought with money
	public static bool buyLaser(int quant) {
		float cost = quant * laserCost;
		if (cost > Player.moneyCount) {
			return false;
		} else {
			Player.moneyCount -= cost;
			Player.laserCount += quant;
			return true;
		}
	}

	// goldRush is bought with gems
	public static bool buyGoldRush(int quant) {
		float cost = quant * goldRushCost;
		if (cost > Player.gemCount) {
			return false;
		} else {
			Player.gemCount -= cost;
			Player.goldRushCount += quant;
			return true;
		}
	}

	public static void buyLaserButton() {
		if (buyLaser (5)) {
			// success
		} else {
			// not enough money
		}
	}

	public static void buyGoldRushButton() {
		if (buyGoldRush (1)) {
			// success
		} else {
			// not enough gems
		}
	}
}
