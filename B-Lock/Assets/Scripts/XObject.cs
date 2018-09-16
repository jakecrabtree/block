﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class XObject : MonoBehaviour {

    
    SpriteRenderer sr;
    Sprite s;
    Boolean clicked = false;

	// Use this for initialization
	void Start () {

	}

    public void Initiaize()
    {
        transform.Translate(50, 50, 0);
        s = Resources.Load<Sprite>("X_Button_0");
        sr = GetComponent<SpriteRenderer>();
        sr.sprite = s;
    }

    void OnMouseEnter()
    {
        s = Resources.Load<Sprite>("X_Button_1");
        sr.sprite = s;
    }

    void OnMouseExit()
    {
        s = Resources.Load<Sprite>("X_Button_0");
        sr.sprite = s;
    }

    public Boolean getClicked()
    {
        return clicked;
    }

    void OnMouseDown()
    {
        clicked = true;
    }
}