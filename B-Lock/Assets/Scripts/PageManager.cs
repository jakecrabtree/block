using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

public class PageManager : MonoBehaviour {

	BlockGameManager blockGameManager;
	AdManager adManager;
	string resourcesPath = "Prefabs" + Path.DirectorySeparatorChar + "Pages";
	GameObject[] pageBackgrounds;
	GameObject currentPage;

	public void Initialize(BlockGameManager blockGameManager){
		this.blockGameManager  = blockGameManager;
	}

	void Awake(){
		GameObject adManagerObject = new GameObject();
		adManager = adManagerObject.AddComponent<AdManager>();
		adManager.GetComponent<AdManager>().Initialize(this);
		Instantiate(adManagerObject);
		pageBackgrounds = Resources.LoadAll<GameObject>(resourcesPath);
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void LoadPage(int adPerLevelAmount){
		currentPage = Instantiate(pageBackgrounds[Random.Range(0,pageBackgrounds.Length)]);
		for (int i = 0; i < adPerLevelAmount; i++){
			adManager.CreateAd(new Vector2());
		}
	}

	public void AdCompleted(bool succeeded){
		blockGameManager.AdCompleted(succeeded);
	}
}
