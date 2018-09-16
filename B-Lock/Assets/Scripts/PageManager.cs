using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

public class PageManager : MonoBehaviour {

	AdManager adManager;
	string resourcesPath = "Sprites" + Path.DirectorySeparatorChar + "Pages";
	Sprite[] pageBackgrounds;
	void Awake(){
		GameObject adManagerObject = new GameObject();
		adManager = adManagerObject.AddComponent<AdManager>();
		Instantiate(adManagerObject);
		pageBackgrounds = Resources.LoadAll<Sprite>(resourcesPath);
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void LoadPage(){
		adManager.CreateAd(new Vector2());
	}
}
