using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XToClose : Ad
{
    GameObject X;
    public void OnClick() 
    {
        X = new GameObject();
        X = Instantiate(X, transform);
        X.GetComponent<XObject>().Initiaize();
    }

    void Update()
    {
        if(X.GetComponent<XObject>().getClicked() == true)
        {
            OnSucceed();
        }
    }

}
