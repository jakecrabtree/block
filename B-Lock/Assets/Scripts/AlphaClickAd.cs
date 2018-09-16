using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class AlphaClickAd : Ad {

	// Use this for initialization
	GameObject xButton;
    string xButtonPath = "Prefabs" + Path.DirectorySeparatorChar + "GamePieces" + Path.DirectorySeparatorChar + "XButton";
    bool hasBeenInitialized = false;
	void Start () {
		
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

	}
}
