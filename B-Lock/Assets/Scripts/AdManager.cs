using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.IO;
using System.Text;
using UnityEngine;

public class AdManager : MonoBehaviour {

	string adImagesPath = "Sprites" + Path.DirectorySeparatorChar + "Ads";
	string gameBackgroundPath = "Sprites" + Path.DirectorySeparatorChar + 
									"GameBackgrounds" + Path.DirectorySeparatorChar;
	string adGamePrefabsPath = "Prefabs" + Path.DirectorySeparatorChar + 
									"AdGames" + Path.DirectorySeparatorChar;
	string[] gameBackgroundFolders = {"1x1", "1x5", "3x2"};
	float[] adRatios = {1f, 0.2f, 1.333f};
	Sprite[] adSprites;
	Sprite[][] gameBackgrounds;
	GameObject[] adGamePrefabs;

	// Use this for initialization
	void Awake () {
		adSprites = Resources.LoadAll<Sprite>(adImagesPath);
		int currentFolder = 0;
		gameBackgrounds = new Sprite[gameBackgroundFolders.Length][];
		foreach(string folder in gameBackgroundFolders){
			string folderPath = new StringBuilder(gameBackgroundPath).Append(folder).ToString();
			gameBackgrounds[currentFolder] = Resources.LoadAll<Sprite>(folderPath);
			currentFolder++;
		}
		adGamePrefabs = Resources.LoadAll<GameObject>(adGamePrefabsPath);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void CreateAd(Vector2 position){
		//Get random ad image from list generated in start()
		int randomIndex = Random.Range(0,adSprites.Length);
		Sprite randomAdImage = adSprites[randomIndex];

		//Calculate size ratio and pick which defined one it corresponds to
		float spriteWidth = randomAdImage.rect.width;
		float spriteLength = randomAdImage.rect.height;
		float spriteRatio = spriteWidth/spriteLength;

		float minRatio = 1000000f;
		int whichRatio = 0; 
		for(int i = 0; i < adRatios.Length; i++){
			if (minRatio > Mathf.Abs(spriteRatio-adRatios[i])){
				minRatio = Mathf.Abs(spriteRatio-adRatios[i]);
				whichRatio = i;
			}
		}
		
		//Get random game background image
		randomIndex = Random.Range(0,gameBackgrounds[whichRatio].Length);
		Sprite backgroundSprite = gameBackgrounds[whichRatio][randomIndex];

		//Get random game prefab
		randomIndex = Random.Range(0,adGamePrefabs.Length);
		GameObject newAdObject = Instantiate(adGamePrefabs[randomIndex],position,Quaternion.identity);

		BoxCollider2D collider = newAdObject.AddComponent<BoxCollider2D>();
		collider.size = new Vector2(spriteWidth,spriteLength);

		//Initialize Ad
		newAdObject.GetComponent<Ad>().Initialize(randomAdImage,backgroundSprite);
	}

}
