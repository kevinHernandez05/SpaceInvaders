using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyer : MonoBehaviour {

    public float destroyAtPosition;
	void Update () 
    {
        if (transform.position.y <= destroyAtPosition)
        {
            Destroy(gameObject);
        }
    }
}
