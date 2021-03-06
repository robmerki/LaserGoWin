﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour{
	public const float laserCost = 0.2f;
	public const float goldRushCost = 10f;

	public Text GemText;
	public Text LaserText;
	public Text GoldRushText;

	public void GoToMapScreen()
	{
		Debug.Log("go to map screen");
		MasterManager.Instance.ChangeScene("MapScreen");
	}

	public void GoToGameScreen()
	{
		MasterManager.Instance.ChangeScene("GameScreen");
	}

	//every time the shop is opened
	public void Start()
	{
		UpdateNumbers();
	}

	public void UpdateNumbers()
	{
		GemText.text = Player.gemCount.ToString();
		LaserText.text = Player.laserCount.ToString();
		GoldRushText.text = Player.goldRushCount.ToString();
	}

	public void GoToCreditCardScreen()
	{
		MasterManager.Instance.ChangeScene("CreditCardScreen");
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
		int cost = (int)(quant * goldRushCost);
		if (cost > Player.gemCount) {
			return false;
		} else {
			Player.gemCount -= cost;
			Player.goldRushCount += quant;
			return true;
		}
	}

	public void buyLaserButton() {
		/*if (buyLaser (5)) {
			// success
		} else {
			// not enough money
		}*/
	}

	public void buyGoldRushButton() {

		if (Player.gemCount >= 150)
		{
			Player.goldRushCount ++;
			Player.gemCount -= 150;
		}

		UpdateNumbers();
	}
}
