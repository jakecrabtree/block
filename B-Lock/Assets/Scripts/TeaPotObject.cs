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

    double timeLeft = 1.5;
    

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
        GetComponentInChildren<TextMesh>().text = "1.5";
    }

    // Update is called once per frame
    void Update () {
        if (timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
            GetComponentInChildren<TextMesh>().text = Math.Round(timeLeft, 0).ToString();

        }
        else
        {
            GetComponentInChildren<TextMesh>().text = "0";
            ad.OnSucceed();
        }
    }

    void OnMouseDown()
    {
        ad.OnFailure();
    }
}
