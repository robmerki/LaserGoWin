using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour{
	public const float laserCost = 0.2f;
	public const float goldRushCost = 10f;

	public void GoToMapScreen()
	{
		Debug.Log("go to map screen");
		MasterManager.Instance.ChangeScene("MapScreen");
	}

	//every time the shop is opened
	public void Start()
	{
		
	}

	// laser is bought with money
	public bool buyLaser(int quant) {
		Debug.Log("bought lasers");
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
	public bool buyGoldRush(int quant) {
		Debug.Log("bought goldrush");
		float cost = quant * goldRushCost;
		if (cost > Player.gemCount) {
			return false;
		} else {
			Player.gemCount -= cost;
			Player.goldRushCount += quant;
			return true;
		}
	}

	public void buyLaserButton() {
		if (buyLaser (5)) {
			// success
		} else {
			// not enough money
		}
	}

	public void buyGoldRushButton() {
		if (buyGoldRush (1)) {
			// success
		} else {
			// not enough gems
		}
	}
}
