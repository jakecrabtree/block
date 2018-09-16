using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class XToClose : Ad
{
    GameObject xButton;
    string xButtonPath = "Prefabs" + Path.DirectorySeparatorChar + "GamePieces" + Path.DirectorySeparatorChar + "XButton";
    bool hasBeenInitialized = false;
    protected void OnMouseDown()
    {
        base.OnMouseDown();
        if (!hasBeenInitialized){
            InitializeGame();
            hasBeenInitialized = true;
        }
    }

    void InitializeGame(){
        Debug.Log("Called");
        xButton = Resources.Load<GameObject>(xButtonPath);
        xButton = Instantiate(xButton, transform);
        xButton.GetComponent<XObject>().Initialize(this);
    }
}
