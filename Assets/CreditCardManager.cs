using UnityEngine;
using System.Collections;

public class CreditCardManager : MonoBehaviour {

	public void GoToShop()
	{
		MasterManager.Instance.ChangeScene("shop");
	}
}
