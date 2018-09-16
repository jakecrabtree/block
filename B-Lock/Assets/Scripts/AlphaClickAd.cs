using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class AlphaClickAd : Ad {

	// Use this for initialization
	Sprite[] letterSprites;
	GameObject letterPrefab;
    string letterSpritesPath = "Sprites" + Path.DirectorySeparatorChar + "Buttons" + Path.DirectorySeparatorChar + "Alphabet";
    string letterPrefabPath = "Prefabs" + Path.DirectorySeparatorChar + "GamePieces" + Path.DirectorySeparatorChar + "Letter";

	int gameWidth = 3;
	int gameHeight = 3;

	bool hasBeenInitialized = false;
	void Start () {
		letterSprites = Resources.LoadAll<Sprite>(letterSpritesPath);
		letterPrefab = Resources.Load<GameObject>(letterPrefabPath);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	protected void OnMouseDown(){
		base.OnMouseDown();
		if (!hasBeenInitialized){
            InitializeGame();
            hasBeenInitialized = true;
        }
	}

	private void InitializeGame(){
		List<char> letters = new List<char>(gameHeight*gameWidth);
		GameObject[] letterObjects = new GameObject[gameHeight*gameWidth];
		//Generate 9 Letters
		for (int i = 0; i < gameWidth*gameHeight; i++){
			for (int j = 0; j < gameHeight; j++){
				letters[i*j] = (char)Random.Range(0,26); 
				letterObjects[i*j] = Instantiate(letterPrefab);
				letterObjects[i*j].GetComponent<Letter>().Initialize(letters[i*j], this);
				letterObjects[i*j].GetComponent<SpriteRenderer>().sprite = letterSprites[(int)letters[i*j]];
				letterObjects[i*j].GetComponent<SpriteRenderer>().sortingOrder = gameObject.GetComponent<Renderer>().sortingOrder + 1;
			}
		}
		//yikes
		List<char> lettersSorted = letters.ConvertAll(letter => (char)(letter + 0));
		lettersSorted.Sort();
		// Get corresponding letter sprite
		// Instantiate in grid like pattern
		// Set this script in letters

	}
}
