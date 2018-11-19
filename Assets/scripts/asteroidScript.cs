using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class asteroidScript : MonoBehaviour {

    private Rigidbody rb;

    public float speed;
    public float vectorx;
    public float vectory;

    public bool isDeformable;
    public bool isAnAsteroid;

    public int life;

    public GameObject explosion;


    void Start () {

        if(isDeformable){
            transform.localScale = new Vector3(Random.Range(0.67f, 0.1f), Random.Range(0.71f, 0.1f), Random.Range(0.47f, 0.1f));
        }
        rb = GetComponent<Rigidbody>();


    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(vectorx,vectory);
        //rb.rotation = new Quaternion(1f, 0.5f, 0f, 0f);
    }

    private void Update()
    {
        if (transform.position.y <= -5){
            Destroy(gameObject);
        }

        if (isAnAsteroid && life <= 0){
            Destroy(gameObject);
            Instantiate(explosion, transform.position, transform.rotation);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "player bullet" && isAnAsteroid){
            life -= 10;

        }   
    }
}
