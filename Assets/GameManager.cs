using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
	public static GameManager instance;
	public GameObject gameRunner;
	private GameObject gameRunnerInstance;

	public Button ShootButton;
	public Color ShootButtonColor;
	public Color ShootButtonColorEmpty;

	public Text LaserCountText;
	public Image LaserCount;

	public GameObject LaserArt;
	public GameObject LaserImpact;

	// Use this for initialization
	void Start () {
		if (instance != null && instance != this) {
			Destroy (gameObject);
			return;
		}
		HideLaser();
		UpdateLaserCount();
		RefreshShootButton();
		instance = this;
	}

	//from a button press
	public void Shoot()
	{
		if (gameRunner == null){return;}

		if (Player.laserCount <= 0){return;}

//		gameRunnerInstance.GetComponent<GameRunner> ().debugKillChest ();

		RaycastHit hit;
		if (Physics.Raycast(Camera.main.transform.position,Camera.main.transform.forward,out hit, 1000))
		{
			//find a chest
			//open that chest
			TreasureChest tc = hit.collider.GetComponent<TreasureChest>();
			if (tc != null)
			{
				Debug.Log("chest hit");
				tc.hit();
				LaserImpact.SetActive(true);
			}
		}

		Player.laserCount --;

		UpdateLaserCount();

		if (MasterManager.Instance != null)
		AudioSource.PlayClipAtPoint(MasterManager.Instance.Laser,Camera.main.transform.position,0.75f);

		LaserArt.SetActive(true);
		Invoke("HideLaser",0.1f);
	}

	void UpdateLaserCount()
	{
		LaserCountText.text = Player.laserCount.ToString();
		//LaserCount.color = Player.laserCount > 0 ? ShootButtonColor : ShootButtonColorEmpty;
	}

	void HideLaser()
	{
		LaserArt.SetActive(false);
		LaserImpact.SetActive(false);
	}

	void RefreshShootButton()
	{
		ColorBlock cb = ShootButton.colors;
		cb.normalColor = Player.laserCount > 0 ? ShootButtonColor : ShootButtonColorEmpty;
		ShootButton.colors = cb;
	}

	public void GoToMapScreen()
	{
		MasterManager.Instance.ChangeScene("MapScreen");
	}

	public void GoToShopScreen()
	{
		MasterManager.Instance.ChangeScene("shop");
	}

	public void trackingFound (GameObject imageTrackerObject) {
		if (gameRunnerInstance != null) {
			// commenting this out for now
			// gameRunnerInstance.GetComponent<GameRunner>().reattachChests (imageTrackerObject);
			return;
		}
		// todo: turn off all other image trackers?
		gameRunnerInstance = GameObject.Instantiate (gameRunner);
		gameRunnerInstance.GetComponent<GameRunner>().StartGame (true, imageTrackerObject);
	}
}
