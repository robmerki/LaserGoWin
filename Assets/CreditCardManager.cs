using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CreditCardManager : MonoBehaviour {

	public Color selectColor;
	public Color idleColor;

	public Button[] Buttons;
	public Text CostText;
	Button selectedButton;

	public void Start()
	{
		CostText.text = Buttons[1].gameObject.GetComponent<LaserBuyButton>().cost;
		selectedButton = Buttons[1];
	}

	public void GoToShop(bool buy)
	{
		if (buy)
		{
			Player.laserCount += selectedButton.gameObject.GetComponent<LaserBuyButton>().lasercount;
		}

		MasterManager.Instance.ChangeScene("shop");
	}

	public void SelectButton(Button button)
	{
		foreach (var b in Buttons)
		{
			b.GetComponent<Image>().color = idleColor;
		}
		button.GetComponent<Image>().color = selectColor;
		selectedButton = button;

		CostText.text = button.gameObject.GetComponent<LaserBuyButton>().cost;
	}
}
