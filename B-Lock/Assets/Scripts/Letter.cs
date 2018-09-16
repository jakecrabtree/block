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
}
