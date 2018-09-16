using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class XObject : MonoBehaviour {

    
    SpriteRenderer sr;
    Sprite[] xSprite;

    Ad ad;

	// Use this for initialization
    public void Initialize(Ad ad){
        this.ad = ad;
    }
	void Start () {
        sr = gameObject.GetComponent<SpriteRenderer>();
        xSprite = Resources.LoadAll<Sprite>("Sprites" + Path.DirectorySeparatorChar + "Buttons" + 
                                        Path.DirectorySeparatorChar + "X_Button");
	}

    void OnMouseEnter()
    {
        sr.sprite = xSprite[1];
    }

    void OnMouseExit()
    {
        sr.sprite = xSprite[0];
    }

    void OnMouseDown()
    {
        ad.OnSucceed();
    }
}
