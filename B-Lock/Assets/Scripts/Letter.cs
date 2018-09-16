using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Letter : MonoBehaviour {

	char letter;
	AlphaClickAd alphaClickAd;
	public void Initialize(char letter, AlphaClickAd alphaClickAd){
		this.letter = letter;
		this.alphaClickAd = alphaClickAd;
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
		alphaClickAd.LetterClicked(letter);
		Destroy(gameObject);
	}

	/// <summary>
	/// This function is called when the MonoBehaviour will be destroyed.
	/// </summary>
	void OnDestroy()
	{
	}
}
