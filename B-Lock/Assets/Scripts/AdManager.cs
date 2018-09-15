using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.IO;
using System.Text;
using UnityEngine;

public class AdManager : MonoBehaviour {

	string adImagesPath = "Sprites" + Path.DirectorySeparatorChar + "Ads";
	string gameBackgroundPath = "Prefabs" + Path.DirectorySeparatorChar + 
									"GameBackgrounds" + Path.DirectorySeparatorChar;
	string[] gameBackgroundFolders = {"1x1", "1x5", "3x2"};
	float[] adRatios = {1f, 0.2f, 1.5f};
	Sprite[] adSprites;
	GameObject[][] gameBackgrounds;

	// Use this for initialization
	void Start () {
		adSprites = Resources.LoadAll<Sprite>(adImagesPath);
		int currentFolder = 0;
		gameBackgrounds = new GameObject[gameBackgroundFolders.Length][];
		foreach(string folder in gameBackgroundFolders){
			string folderPath = new StringBuilder(gameBackgroundPath).Append(folder).ToString();
			gameBackgrounds[currentFolder] = Resources.LoadAll<GameObject>(folderPath);
			currentFolder++;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void CreateAd(Vector2 position){
		//Get random ad image from list generated in start()
		int randomIndex = Random.Range(0,adSprites.Length);
		Sprite randomAdImage = adSprites[randomIndex];

		//Calculate size ratio and pick which defined one it corresponds to
		float spriteWidth = randomAdImage.border.z - randomAdImage.border.x;
		float spriteLength = randomAdImage.border.w - randomAdImage.border.y;
		float spriteRatio = spriteWidth/spriteLength;

		float minRatio = 1000000f;
		int whichRatio = 0; 
		for(int i = 0; i < adRatios.Length; i++){
			if (minRatio > Mathf.Abs(spriteRatio-adRatios[i])){
				minRatio = Mathf.Abs(spriteRatio-adRatios[i]);
				whichRatio = i;
			}
		}
		
		//Get random ad prefab (Ad + Background Image)
		randomIndex = Random.Range(0,gameBackgrounds[whichRatio].Length);
		GameObject newAdObject = Instantiate(gameBackgrounds[whichRatio][randomIndex],position,Quaternion.identity);

		//Initialize Ad
		Sprite newBackgroundImage = newAdObject.GetComponent<Sprite>();
		newAdObject.GetComponent<Ad>().Initialize(randomAdImage,newBackgroundImage);
	}

}
