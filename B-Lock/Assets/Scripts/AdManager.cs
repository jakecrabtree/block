using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.IO;
using System.Text;
using UnityEngine;

public class AdManager : MonoBehaviour {

	string adImagesPath = "Sprites" + Path.DirectorySeparatorChar + "Ads";
	string gameBackgroundPath = "Prefabs" + Path.DirectorySeparatorChar + "GameBackgrounds";
	Sprite[] adSprites;
	GameObject[] gameBackgrounds;
	int numAdSprites;

	// Use this for initialization
	void Start () {
		adSprites = Resources.LoadAll<Sprite>(adImagesPath);
		gameBackgrounds = Resources.LoadAll<GameObject>(gameBackgroundPath);
		numAdSprites = adSprites.Length;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void CreateAd(Vector2 position){
		int randomIndex = Random.Range(0,numAdSprites);
		Sprite randomAdImage = adSprites[randomIndex];

	}

}
