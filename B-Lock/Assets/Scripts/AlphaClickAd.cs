﻿using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class AlphaClickAd : Ad {

	// Use this for initialization
	Sprite[] letterSprites;
	GameObject letterPrefab;
    string letterSpritesPath = "Sprites" + Path.DirectorySeparatorChar + "Buttons" + Path.DirectorySeparatorChar + "Alphabet";
    string letterPrefabPath = "Prefabs" + Path.DirectorySeparatorChar + "GamePieces" + Path.DirectorySeparatorChar + "Letter";

	int gameWidth = 2;
	int gameHeight = 2;

	int currLetter = 0;
	List<char> lettersSorted;
	GameObject[] letterObjects;

	bool hasBeenInitialized = false;
	void Start () {
		letterSprites = Resources.LoadAll<Sprite>(letterSpritesPath);
		letterPrefab = Resources.Load<GameObject>(letterPrefabPath);
		letterPrefab.GetComponent<SpriteRenderer>().sortingOrder = gameObject.GetComponent<Renderer>().sortingOrder + 1;
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
		char[] letters = new char[gameHeight*gameWidth];
		letterObjects = new GameObject[gameHeight*gameWidth];
		int currIndex = 0;
		Vector3 basePosition = transform.position; //- new Vector3(adImageWidth/2, adImageLength/2, 0.0f);
		for (int i = 0; i < gameWidth; i++){
			for (int j = 0; j < gameHeight; j++){
				letters[currIndex] = (char)Random.Range(0,26); 
				Sprite letterSprite = letterSprites[(int)letters[currIndex]];

				float spriteWidth = letterSprite.rect.width/letterSprite.pixelsPerUnit;
				float spriteHeight = letterSprite.rect.height/letterSprite.pixelsPerUnit;

				Vector3 letterPos = GetLetterOffset(currIndex, i,j,spriteWidth,spriteHeight) + basePosition;//new Vector3(letterX, letterY, 0.0f);
				letterObjects[currIndex] = Instantiate(letterPrefab, letterPos, Quaternion.identity);

				letterObjects[currIndex].GetComponent<Letter>().Initialize(letters[currIndex], this);

				letterObjects[currIndex].GetComponent<SpriteRenderer>().sprite = letterSprites[(int)letters[currIndex]];
				currIndex++;
			}
		}
		//deep copy then sort
		lettersSorted = new List<char>(letters);
		lettersSorted.Sort();
	}

	public void LetterClicked(char c){
		if (c == lettersSorted[currLetter]){
			if (++currLetter == lettersSorted.Count){
				OnSucceed();
			}
		}
		else{
			foreach(GameObject letter in letterObjects){
				Destroy(letter);
			}
			OnFailure();
		}
	}

	private Vector3 GetLetterOffset(int index, int i, int j, float spriteWidth, float spriteHeight){
		switch(shape){
			case AdShape.Banner:
				return new Vector3(spriteWidth*index-adImageWidth/4f, adImageLength/4f, 0.0f);
			case AdShape.Rectangle:
			case AdShape.Square:
				return new Vector3(spriteWidth*i-adImageWidth/4f, spriteHeight*j, 0.0f);
		}
		return new Vector3();
	}
}