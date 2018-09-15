using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

public class PageManager : MonoBehaviour {

	AdManager adManager;
	string resourcesPath = "Sprites" + Path.DirectorySeparatorChar + "Pages";
	Sprite[] pageBackgrounds;
	int numPageBackgrounds;

	void Awake(){
		Instantiate(adManager);
	}

	// Use this for initialization
	void Start () {
		pageBackgrounds = Resources.LoadAll<Sprite>(resourcesPath);
		numPageBackgrounds = pageBackgrounds.Length;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void LoadPage(){
		
	}
}
