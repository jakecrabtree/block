using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class NewBehaviourScript : Ad {

    GameObject kcObject;
    string kcPath = "Prefabs" + Path.DirectorySeparatorChar + "GamePieces" + Path.DirectorySeparatorChar + "Do Not Click - NOT BROKEN";
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
        kcObject = Instantiate(kcObject, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);
        kcObject.GetComponent<Renderer>().sortingOrder = gameObject.GetComponent<Renderer>().sortingOrder + 1;
        kcObject.GetComponent<TeaPotObject>().Initialize(this);
    }
}
