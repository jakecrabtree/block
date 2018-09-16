using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragToRemove : Ad
{
    GameObject X;
    public void OnClick()
    {
        Debug.Log("Hi");
        X = Instantiate(new GameObject());
        X.AddComponent<XObject>();
        X.transform.parent = transform;
      //  X.GetComponent<XObject>().Initialize();
    }
}
