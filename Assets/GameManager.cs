using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	public static GameManager instance;
	public GameObject gameRunner;
	private GameObject gameRunnerInstance;

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

	public void GoToMapScreen()
	{
		MasterManager.Instance.ChangeScene("MapScreen");
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
