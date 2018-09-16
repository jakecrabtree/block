using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ad : MonoBehaviour {

	AdManager adManager;
	enum AdState{Unclicked, Clicked, Succeeded, Failed};
	AdState currState;
	SpriteRenderer renderer;
	Sprite adImage;
	Sprite gameBackground;

	//Initialize the ad with its given ad image
	public void Initialize(Sprite adImage, Sprite gameBackground, AdManager adManager){
		this.adImage = adImage;
		this.gameBackground = gameBackground;
		this.adManager = adManager;

		renderer = GetComponent<SpriteRenderer>();
		renderer.sprite = adImage;
		currState = AdState.Unclicked;
	}


	// Use this for initialization
	void Start () {
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
	//	float xScaleFactor = (float)adImage.rect.width / (float)gameBackground.rect.width;
	//	float yScaleFactor = (float)adImage.rect.height / (float)gameBackground.rect.height;
	//	gameObject.transform.localScale = new Vector3(xScaleFactor,yScaleFactor,0.0f);
		currState = AdState.Clicked;
        OnClick();
    }

	//This function is called when the player wins the corresponding minigame. 
	public void OnSucceed(){
		adManager.AdCompleted(this, true);
	}

	//This function is called when the player loses or fails the corresponding minigame.
	public void OnFailure(){
		adManager.AdCompleted(this, false);
	}

    void OnClick(){	}
}

