using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DoNotClickX : Ad {

    GameObject TeaPotObject;
    string TeaPotPathButtonPath = "Prefabs" + Path.DirectorySeparatorChar + "GamePieces" + Path.DirectorySeparatorChar + "TeaPotObject";
    bool hasBeenInitialized = false;
    protected void OnMouseDown()
    {
        base.OnMouseDown();
        if (!hasBeenInitialized)
        {
            InitializeGame();
            hasBeenInitialized = true;
        }
    }

    void InitializeGame()
    {
        TeaPotObject = Resources.Load<GameObject>(TeaPotPathButtonPath);
        TeaPotObject = Instantiate(TeaPotObject, transform);
        TeaPotObject.GetComponent<TeaPotObject>().Initialize(this);
    }
}
