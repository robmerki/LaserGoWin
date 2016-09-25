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

	// Update is called once per frame
	void Update () {

	}

	// Use this for initialization
	void Start () {
		if (instance != null && instance != this) {
			Destroy (gameObject);
			return;
		}
		instance = this;
	}


	//from a button press
	public void Shoot()
	{
		if (gameRunner == null){return;}

		if (Player.laserCount <= 0){return;}

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
			}
		}

		Player.laserCount --;

		AudioSource.PlayClipAtPoint(MasterManager.Instance.Laser,Camera.main.transform.position);
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

	public void trackingFound (GameObject imageTrackerObject) {
		if (gameRunnerInstance != null) {
			gameRunnerInstance.GetComponent<GameRunner>().reattachChests (imageTrackerObject);
			return;
		}
		// todo: turn off all other image trackers?
		gameRunnerInstance = GameObject.Instantiate (gameRunner);
		gameRunnerInstance.GetComponent<GameRunner>().StartGame (true, imageTrackerObject);
	}
}
