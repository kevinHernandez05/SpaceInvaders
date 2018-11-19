using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotatingSphere : MonoBehaviour {
    public float rotation;

	void Update () {
        transform.Rotate(Vector3.up, rotation * Time.deltaTime);
    }
}
