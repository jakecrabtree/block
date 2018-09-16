using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class keyboardInput : Ad {

    GameObject kcObject;
    string kcPath = "Prefabs" + Path.DirectorySeparatorChar + "GamePieces" + Path.DirectorySeparatorChar + "keyboardCatObject";
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
        kcObject = Resources.Load<GameObject>(kcPath);
        kcObject = Instantiate(kcObject, new Vector3(transform.position.x-2, transform.position.y+3, 0), Quaternion.identity);
        kcObject.GetComponent<Renderer>().sortingOrder = gameObject.GetComponent<Renderer>().sortingOrder + 1;
        kcObject.GetComponent<keyboardCatObject>().Initialize(this);
    }
}
