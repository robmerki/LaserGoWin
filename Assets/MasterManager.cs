using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

// once at game start
public class MasterManager : MonoBehaviour
{
	public static MasterManager Instance;

	public AudioClip Laser;
	public AudioClip CoinsPickup;
	public AudioClip ChestHit;
	public AudioClip ChestExplode;
	public AudioClip ItemPickup;


	//public List<GameObject>ParticlePool = new List<GameObject>();
	public Dictionary<string,List<GameObject>>Pools = new Dictionary<string, List<GameObject>>();

	public GameObject GemPrefab;
	public GameObject LaserPrefab;
	public GameObject CashPrefab;
	public GameObject ExplodeParticle;
	public GameObject ChestPrefab;
	public GameObject SuperChestPrefab;

	void Start ()
	{
		if (Instance != null)
		{
			Destroy(gameObject);
			return;
		}
		DontDestroyOnLoad(gameObject);
		Instance = this;

		Pools.Add("chest",new List<GameObject>());
		Pools.Add("superchest",new List<GameObject>());
		Pools.Add("gem",new List<GameObject>());
		Pools.Add("laser",new List<GameObject>());
		Pools.Add("cash",new List<GameObject>());
		Pools.Add("explode",new List<GameObject>());
		for (int i = 0; i<5; i++)
		{
			Pools["chest"].Add((GameObject)GameObject.Instantiate(ChestPrefab));
			Pools["superchest"].Add((GameObject)GameObject.Instantiate(SuperChestPrefab));
			Pools["gem"].Add((GameObject)GameObject.Instantiate(GemPrefab));
			Pools["laser"].Add((GameObject)GameObject.Instantiate(LaserPrefab));
			Pools["cash"].Add((GameObject)GameObject.Instantiate(CashPrefab));
			Pools["explode"].Add((GameObject)GameObject.Instantiate(ExplodeParticle));
		}
	}

	public GameObject GetObject(string name, float duration = -1)
	{
		GameObject returngo;
		if (Pools[name].Count == 0)
		{
			//create new
			switch (name)
			{
			case "chest":
			Pools["chest"].Add((GameObject)GameObject.Instantiate(ChestPrefab));
				break;
			case "superchest":
				Pools["superchest"].Add((GameObject)GameObject.Instantiate(SuperChestPrefab));
				break;
			case "gem":
				Pools["gem"].Add((GameObject)GameObject.Instantiate(GemPrefab));
				break;
			case "laser":
				Pools["laser"].Add((GameObject)GameObject.Instantiate(LaserPrefab));
				break;
			case "cash":
				Pools["cash"].Add((GameObject)GameObject.Instantiate(CashPrefab));
				break;
			case "explode":
				Pools["explode"].Add((GameObject)GameObject.Instantiate(ExplodeParticle));
				break;
			}
		}

		returngo = Pools[name][0];

		if (duration > 0)
		{
			StartCoroutine(DelayReturn(name,returngo,duration));
		}

		return returngo;
	}

	IEnumerator DelayReturn(string name, GameObject go, float duration)
	{
		yield return new WaitForSeconds(duration);
		ReturnToPool(name,go);

	}

	public void ReturnToPool(string name, GameObject go)
	{
		if (go != null)
			Pools[name].Add(go);
	}

	public void DoExplode(Vector3 pos)
	{
		GameObject.Instantiate(ExplodeParticle,pos,Quaternion.identity);
	}

	public void ChangeScene(string sceneName)
	{
		SceneManager.LoadScene(sceneName);
	}
}
