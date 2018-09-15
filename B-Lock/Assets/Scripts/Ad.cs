using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ad : MonoBehaviour {

	enum AdState{Unclicked, Clicked, Succeeded, Failed};
	AdState currState;
	SpriteRenderer renderer;
	Sprite adImage;
	Sprite gameBackground;

	//Initialize the ad with its given ad image
	public void Initialize(Sprite adImage, Sprite gameBackground){
		this.adImage = adImage;
		this.gameBackground = gameBackground;
	}


	// Use this for initialization
	void Start () {
		currState = AdState.Unclicked;
		renderer = GetComponent<SpriteRenderer>();
		renderer.sprite = adImage;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	/// <summary>
	/// OnMouseDown is called when the user has pressed the mouse button while
	/// over the GUIElement or Collider.
	/// </summary>
	void OnMouseDown()
	{
		renderer.sprite = gameBackground;
		currState = AdState.Clicked;
	}

	//This function is called when the player wins the corresponding minigame. 
	void OnSucceed(){

	}

	//This function is called when the player loses or fails the corresponding minigame.
	void OnFailure(){

	}
}
