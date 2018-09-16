using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Draghand : MonoBehaviour
{


    SpriteRenderer sr;
    Sprite s;

    // Use this for initialization
    void Start()
    {

    }

    public void Initiaize()
    {
        Debug.Log("Hi2");
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

    void OnMouseDown()
    {
        transform.parent.GetComponent<XToClose>().OnSucceed();
    }
}
