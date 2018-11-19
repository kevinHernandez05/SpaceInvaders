using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour {

    private Rigidbody rb;

    public float vectorx;
    public float vectory;
    int delay;
    public float shootingDelay = 0.1f;

    //actions

    public bool isRotating;

    public GameObject bullet;
    public GameObject offset;
    public GameObject explosion;

    public int vida;

    void Start () {
        rb = GetComponent<Rigidbody>();
	}
	
	void Update () {
        isShooting();
        checkShootingDelay();

        if (vida <= 0){
            stageManager.score += 100;
            Instantiate(explosion, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(vectorx, vectory);
    }

    private void checkShootingDelay()
    {

        if(Time.timeScale > 0){
            if (delay <= 0)
                delay = (int)shootingDelay;
            else
                delay--;
        }
    }

    private void isShooting()
    {

        if (delay == 0)
        {
            GameObject newBullet = Instantiate(bullet, offset.transform.position, transform.rotation);
            newBullet.GetComponent<bullet>().Init(Mathf.Sign(-transform.localScale.y));
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "player bullet")
            vida -= 10;
    }
}
