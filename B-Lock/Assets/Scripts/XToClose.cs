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
        UpdateSortingOrder();
    }

    void InitializeGame(){
        xButton = Resources.Load<GameObject>(xButtonPath);
        xButton = Instantiate(xButton, transform);
        UpdateSortingOrder();
        xButton.GetComponent<XObject>().Initialize(this);
    }

    public override void UpdateSortingOrder(){
        xButton.GetComponent<Renderer>().sortingOrder = gameObject.GetComponent<Renderer>().sortingOrder + 1;
    }
}
