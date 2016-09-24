using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

// once at game start
public class MasterManager : MonoBehaviour
{
	public static MasterManager Instance;

	void Start ()
	{
		if (Instance != null)
		{
			Destroy(gameObject);
			return;
		}
		DontDestroyOnLoad(gameObject);
		Instance = this;
	}
	public void ChangeScene(string sceneName)
	{
		SceneManager.LoadScene(sceneName);
	}
}
