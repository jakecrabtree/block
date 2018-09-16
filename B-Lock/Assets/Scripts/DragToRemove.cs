using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragToRemove : Ad
{
    GameObject X;
    public void OnClick()
    {
        X = Instantiate(new GameObject());
        X.AddComponent<XObject>();
        X.transform.parent = transform;
    }
}
