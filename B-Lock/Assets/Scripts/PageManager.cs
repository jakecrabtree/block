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
		Instantiate(adManager);
	}

	// Use this for initialization
	void Start () {
		pageBackgrounds = Resources.LoadAll<Sprite>(resourcesPath);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void LoadPage(){
		adManager.CreateAd(new Vector2());
	}
}
