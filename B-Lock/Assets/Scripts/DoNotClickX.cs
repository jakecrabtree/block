using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DoNotClickX : Ad {

    GameObject TeaPot;
    string TeaPotPathButtonPath = "Prefabs" + Path.DirectorySeparatorChar + "GamePieces" + Path.DirectorySeparatorChar + "Do Not Click - NOT BROKEN";
    bool hasBeenInitialized = false;
    protected void OnMouseDown()
    {
        base.OnMouseDown();
        if (!hasBeenInitialized)
        {
            InitializeGame();
            hasBeenInitialized = true;
        }
        UpdateSortingOrder();
    }

    void InitializeGame()
    {
        TeaPot = Resources.Load<GameObject>(TeaPotPathButtonPath);
        TeaPot = Instantiate(TeaPot, new Vector3(transform.position.x,transform.position.y,0),Quaternion.identity);
        UpdateSortingOrder();
        TeaPot.GetComponent<TeaPotObject>().Initialize(this);
    }

    public override void UpdateSortingOrder(){
        TeaPot.GetComponent<Renderer>().sortingOrder = gameObject.GetComponent<Renderer>().sortingOrder + 1;
    }
}
