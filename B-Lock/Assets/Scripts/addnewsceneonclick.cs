using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class addnewsceneonclick : MonoBehaviour
{


    /// <summary>
    /// OnMouseDown is called when the user has pressed the mouse button while
    /// over the GUIElement or Collider.
    /// </summary>
    void OnMouseDown()
    {
     LoadByIndex(1);   
    }
    public void LoadByIndex (int sceneIndex)
           {
                SceneManager.LoadScene (sceneIndex);
            }
}

