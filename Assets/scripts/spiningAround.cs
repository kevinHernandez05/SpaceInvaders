using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spiningAround : MonoBehaviour {

    public float speed;
    public Transform planets;

    void Update()
    {
        transform.RotateAround(planets.transform.position, planets.transform.up, speed * Time.deltaTime);
    }
}
