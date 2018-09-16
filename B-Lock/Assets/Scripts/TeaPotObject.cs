using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class TeaPotObject : MonoBehaviour {

    SpriteRenderer sr;
    Sprite TPSpriteNotBroke;
    Sprite TPSPriteBroke;

    Ad ad;

    double timeLeft = 2.5;
    float delayAfterClick = 2;
    Boolean clicked = false;
    Boolean calledPassOrFail = false;
    TextMesh textHolder;

    // Use this for initialization
    public void Initialize(Ad ad)
    {
        this.ad = ad;
    }
    void Start()
    {       
        sr = gameObject.GetComponent<SpriteRenderer>();
        TPSpriteNotBroke = Resources.Load<Sprite>("Sprites" + Path.DirectorySeparatorChar + "Buttons" +
                                        Path.DirectorySeparatorChar + "Do Not Click - NOT BROKEN");
        TPSPriteBroke = Resources.Load<Sprite>("Sprites" + Path.DirectorySeparatorChar + "Buttons" +
                                        Path.DirectorySeparatorChar + "Do Not Click - BROKEN");
        sr.sprite = TPSpriteNotBroke;
        textHolder = GetComponentInChildren<TextMesh>();
        textHolder.GetComponent<Renderer>().sortingOrder = gameObject.GetComponent<Renderer>().sortingOrder + 1;
        
    }

    // Update is called once per frame
    void Update () {

        if (timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
            textHolder.text = Math.Round(timeLeft, 0).ToString();          
        }
        else if(!calledPassOrFail)
        {
            calledPassOrFail = true;
            textHolder.text = "0";
            ad.OnSucceed();
            Destroy(gameObject, 0);
        }
    }

    void OnMouseDown()
    {
        sr.sprite = TPSPriteBroke;
        Destroy(gameObject, 1);
        ad.OnFailure();
    }
}
