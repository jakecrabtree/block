using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockGameManager : MonoBehaviour {

	private static BlockGameManager manager = null;
	Timer timer;
	PageManager pageManager;

	int timePenalty = 3;
	int adPerLevelAmount = 7;
	int adCount;
	int numLevels = 3;
	int level = 0;


	/// <summary>
	/// Awake is called when the script instance is being loaded.
	/// </summary>
	void Awake()
	{	
		if (manager == null){
			manager = this;
		}
		else if (manager != this){
			Destroy(this.gameObject);
		}
		GameObject pageManagerObject = new GameObject();
		pageManager = pageManagerObject.AddComponent<PageManager>();
		Instantiate(pageManagerObject);
		pageManager.Initialize(this);
		pageManager.LoadPage(adPerLevelAmount);
		adCount = adPerLevelAmount;
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void AdCompleted(bool succeeded){
		if (!succeeded){
			timer.DecreaseTime(timePenalty);
		}
		if (--adCount == 0){
			NextLevel();
		}
	}

	void NextLevel(){
		adCount = adPerLevelAmount;
		if (++level > numLevels - 1){
			GameOver(true);
		}
		pageManager.LoadPage(adPerLevelAmount);
	}

	void GameOver(bool win){
		if (win){
			Debug.Log("Win!");
		}else{
			Debug.Log("Lose!");
		}
	}
}
