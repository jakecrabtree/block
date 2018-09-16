using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.IO;
using System.Text;
using UnityEngine;

public class AdManager : MonoBehaviour {

	public static AdManager manager = null;
	PageManager pageManager;
	string adImagesPath = "Prefabs" + Path.DirectorySeparatorChar + "AdImages";
	string gameBackgroundPath = "Sprites" + Path.DirectorySeparatorChar + 
									"GameBackgrounds" + Path.DirectorySeparatorChar;
	string adGamePrefabsPath = "Prefabs" + Path.DirectorySeparatorChar + 
									"AdGames" + Path.DirectorySeparatorChar;
	string[] gameBackgroundFolders = {"Squares", "Banners", "Rectangles"};
	float[] adRatios = {1f, 0.2f, 1.333f};
	GameObject[] adSprites;
	Sprite[][] gameBackgrounds;
	GameObject[] adGamePrefabs;

	// Use this for initialization
	void Awake () {
		if (manager == null){
			manager = this;
		}
		else if (manager != this){
			Destroy(this.gameObject);
		}
		adSprites = Resources.LoadAll<GameObject>(adImagesPath);
		int currentFolder = 0;
		gameBackgrounds = new Sprite[gameBackgroundFolders.Length][];
		foreach(string folder in gameBackgroundFolders){
			string folderPath = new StringBuilder(gameBackgroundPath).Append(folder).ToString();
			gameBackgrounds[currentFolder] = Resources.LoadAll<Sprite>(folderPath);
			currentFolder++;
		}
		adGamePrefabs = Resources.LoadAll<GameObject>(adGamePrefabsPath);
	}

	public void Initialize(PageManager pageManager){
		this.pageManager = pageManager;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void CreateAd(Vector2 position, int order){
		//Get random ad image from list generated in start()
		int randomIndex = Random.Range(0,adSprites.Length);
		GameObject randomAdImage = adSprites[randomIndex];
		Sprite randomAdImageSprite = randomAdImage.GetComponent<SpriteRenderer>().sprite;

		//Calculate size ratio and pick which defined one it corresponds to
		float spriteWidth = randomAdImageSprite.rect.width/randomAdImageSprite.pixelsPerUnit;
		float spriteLength = randomAdImageSprite.rect.height/randomAdImageSprite.pixelsPerUnit;
		float spriteRatio = spriteLength/spriteWidth;

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
		newAdObject.GetComponent<Renderer>().sortingOrder = 0;
		newAdObject.GetComponent<Renderer>().sortingLayerName = "Ad";
		Animator animator = randomAdImage.GetComponent<Animator>();
		if (animator != null){
			newAdObject.AddComponent<Animator>().runtimeAnimatorController = animator.runtimeAnimatorController;
		}


		BoxCollider2D collider = newAdObject.AddComponent<BoxCollider2D>();
		collider.size = new Vector2(spriteWidth,spriteLength);

		//Initialize Ad
		newAdObject.GetComponent<Ad>().Initialize(randomAdImageSprite,backgroundSprite,this, (Ad.AdShape)whichRatio,spriteWidth,spriteLength);
	}

	public void AdCompleted(Ad ad, bool succeeded){
		pageManager.AdCompleted(succeeded);
		Destroy(ad.gameObject);
	}

}
