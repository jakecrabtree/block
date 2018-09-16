using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hover : MonoBehaviour {

    public Texture2D defaultTexture;
    public Texture2D clickableTexture;
    public Texture2D clickingTexture;
    public CursorMode curMode = CursorMode.Auto;
    public Vector2 hotspot = Vector2.zero;
}
}
