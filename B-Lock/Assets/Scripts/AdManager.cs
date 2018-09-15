using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

public class AdManager : MonoBehaviour {

	string resourcesPath = "Sprites" + Path.DirectorySeparatorChar + "Ads" + Path.DirectorySeparatorChar;
	string[] adImageNames = {"default_singles"};
	List<Sprite> adSprites;
	int numAdSprites;

	// Use this for initialization
	void Start () {
		foreach (string name in adImageNames){
			string adImagePath = new StringBuilder(resourcesPath).Append(name).ToString();
			adSprites.Add(Resources.Load<Sprite>(adImagePath));
		}
		numAdSprites = adSprites.Count;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void CreateAd(Vector2 position){
		
	}

}
