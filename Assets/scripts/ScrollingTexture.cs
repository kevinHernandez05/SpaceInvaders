using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingTexture : MonoBehaviour {

    public float scrollSpeedX;
    public float scrollSpeedY;


    void Update()
    {
        GetComponent<Renderer>().material.mainTextureOffset = new Vector2(Time.time * scrollSpeedX, Time.time * scrollSpeedY);
    }
}
