using UnityEngine;
using System.Collections;

public static class ShopManager {
	public const int laserCost = 1;
	public const int goldRushCost = 10;

	public static bool buyLaser(int quant) {
		int cost = quant * laserCost;
		if (cost > Player.moneyCount) {
			return false;
		} else {
			Player.moneyCount -= cost;
			Player.laserCount += quant;
			return true;
		}
	}

	public static bool buyGoldRush(int quant) {
		int cost = quant * goldRushCost;
		if (cost > Player.gemCount) {
			return false;
		} else {
			Player.gemCount -= cost;
			Player.goldRushCount += quant;
			return true;
		}
	}
}
