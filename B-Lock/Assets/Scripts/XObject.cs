using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class XObject : MonoBehaviour {

    
    SpriteRenderer sr;
    Sprite x0;
    Sprite x1;

    Ad ad;

	// Use this for initialization
    public void Initialize(Ad ad){
        this.ad = ad;
    }
	void Start () {
        sr = gameObject.GetComponent<SpriteRenderer>();
        x0 = sr.sprite;
	}

    void OnMouseEnter()
    {
        if (x1 == null){
            x1 = Resources.Load<Sprite>("Sprites" + Path.DirectorySeparatorChar + "Buttons" + 
                                        Path.DirectorySeparatorChar + "X_Button");
        }
        sr.sprite = x1;
    }

    void OnMouseExit()
    {
        sr.sprite = x0;
    }

    void OnMouseDown()
    {
        ad.OnSucceed();
    }
}
