using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class bossScript : MonoBehaviour {

    private Rigidbody rb;

    public float vectorxMax;
    public float vectorxMin;
    public bool xGoingleft;
    public bool xGoingRight;
    public float vectorx;

    int delay;
    public float shootingDelay = 0.01f;

    //Actions

    public bool isRotating;

    public GameObject bullet;
    public GameObject offsetx;
    public GameObject offsety;
    public GameObject explosion;

    public int vida;

    /*/moving stuff
    public float delta = 1.5f;  // Amount to move left and right from the start point
    public float speed = 2.0f;
    private Vector3 startPos;*/

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //startPos = transform.position;
    }

    void Update()
    {
        isShooting();
        checkShootingDelay();
        movinglikeABoss();

        if (vida <= 0)
        {
            stageManager.score += 500000;
            Instantiate(explosion, transform.position, transform.rotation);
          
            Destroy(gameObject);


        }
    }

   

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(Mathf.Sin(Time.time * vectorx), 0f);
    }

    private void checkShootingDelay()
    {

        if (Time.timeScale > 0)
        {
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
            GameObject newBullet1 = Instantiate(bullet, offsetx.transform.position, transform.rotation);
            GameObject newBullet2 = Instantiate(bullet, offsety.transform.position, transform.rotation);
            newBullet1.GetComponent<bullet>().Init(Mathf.Sign(-transform.localScale.y));
            newBullet2.GetComponent<bullet>().Init(Mathf.Sign(-transform.localScale.y));

        }

    }

    private void movinglikeABoss(){ 

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "player bullet")
            vida -= 10;
    }

}
