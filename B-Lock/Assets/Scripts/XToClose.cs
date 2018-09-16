using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XToClose : Ad
{
    
    public void OnClick() 
    {
        XObject X = new XObject();
        X = Instantiate(X, transform);
    }

}
