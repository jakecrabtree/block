using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

public class PageManager : MonoBehaviour {

	AdManager adManager;
	string resourcesPath = "Sprites" + Path.DirectorySeparatorChar + "Pages" + Path.DirectorySeparatorChar;
	string[] pageBackgroundNames = {"rectangle_background"};
	List<Sprite> pageBackgrounds;
	int numPageBackgrounds;

	void Awake(){
		Instantiate(adManager);
	}

	// Use this for initialization
	void Start () {
		foreach (string name in pageBackgroundNames){
			string adImagePath = new StringBuilder(resourcesPath).Append(name).ToString();
			pageBackgrounds.Add(Resources.Load<Sprite>(adImagePath));
		}
		numPageBackgrounds = pageBackgrounds.Count;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void LoadPage(){
		
	}
}
