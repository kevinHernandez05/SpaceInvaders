using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ShipController : MonoBehaviour {

    public float life;
    public float currentLife;
    public float maxLife;
    public float speed;
    public float shootingDelay = 0.1f;
    public float scaleTime;
    
    //instancias
    SpriteRenderer sprite;
    Rigidbody rb;
    BoxCollider2D col2d;
    private float h, v;
    int delay;

    public GameObject bullet;
    public GameObject offset;
    public GameObject explosion;
    public GameObject GameOverScreen;
    public Image LifeBar;

    //sonidos
    public AudioSource shoot;

    //tipo de control
    public bool onCellphone;
    public bool onPC;

    //powerups

    public bool doubleShooting;
    public bool tripleShooting;
    public bool campoefuelza;

    void Start () {

        this.sprite = GetComponent<SpriteRenderer>();
        this.rb = GetComponent<Rigidbody>();
        this.col2d = GetComponent<BoxCollider2D>();
        GameOverScreen.SetActive(false);
        maxLife = life;
	}
	
	void Update () {

        checkAxis();
        isShooting();
        checkShootingDelay();
        checkLife();
        checkIfWow();
        scaleTime = Time.timeScale;

    }

    private void FixedUpdate()
    {
        if(onPC){

            //... player's axis controller section...

            if (h > 0)
            {
                rb.velocity = new Vector2(speed, 0f);
            }

            else if (h < 0)
            {
                rb.velocity = new Vector2(-speed, 0f);
            }

            else if (v > 0)
            {
                rb.velocity = new Vector2(0f, speed);
            }

            else if (v < 0)
            {
                rb.velocity = new Vector2(0f, -speed);
            }
            else if (h == 0 || v == 0)
            {
                rb.velocity = new Vector2(0f, 0f);
            }
        }
        else if(onCellphone){
            Vector3 temp = Input.mousePosition;
            temp.z = 10f;
            this.transform.position = Camera.main.ScreenToWorldPoint(temp);
        }
    }

    private void checkAxis(){

        h = (int)Input.GetAxis("Horizontal");
        v = (int)Input.GetAxis("Vertical");

    }

    private void checkShootingDelay(){

        if (delay <= 0)
            delay = (int)shootingDelay;
        else
            delay--;
    }

    private void isShooting()
    {
        //..Disparos normales y powerups...

        if ((Input.GetButton("Jump") && delay == 0 && scaleTime > 0) ||
           (Mathf.Approximately(rb.velocity.z, 0) && delay == 0 && scaleTime > 0) ||
            (Mathf.Approximately(rb.velocity.y, 0) && delay == 0 && scaleTime > 0))
        {
            shoot.Play();

            if (!doubleShooting && !tripleShooting){
                GameObject newBullet = Instantiate(bullet, offset.transform.position, transform.rotation);
                newBullet.GetComponent<bullet>().Init(Mathf.Sign(transform.localScale.y));
            }

            else if(doubleShooting && !tripleShooting){
                GameObject newBullet1 = Instantiate(bullet, new Vector3(offset.transform.position.x + 0.2f, offset.transform.position.y, offset.transform.position.z), transform.rotation);
                GameObject newBullet2 = Instantiate(bullet, new Vector3(offset.transform.position.x + -0.2f, offset.transform.position.y, offset.transform.position.z), transform.rotation);
                newBullet1.GetComponent<bullet>().Init(Mathf.Sign(transform.localScale.y));
                newBullet2.GetComponent<bullet>().Init(Mathf.Sign(transform.localScale.y));

            }

            else if (!doubleShooting && tripleShooting)
            {
               
                 GameObject newBullet1 = Instantiate(bullet, new Vector3(offset.transform.position.x + 0.4f, offset.transform.position.y, offset.transform.position.z), transform.rotation);
                 GameObject newBullet2 = Instantiate(bullet, new Vector3(offset.transform.position.x + -0.4f, offset.transform.position.y, offset.transform.position.z), transform.rotation);
                 GameObject newBullet = Instantiate(bullet, offset.transform.position, transform.rotation);
                 newBullet1.GetComponent<bullet>().Init(Mathf.Sign(transform.localScale.y));
                 newBullet2.GetComponent<bullet>().Init(Mathf.Sign(transform.localScale.y));
                 newBullet.GetComponent<bullet>().Init(Mathf.Sign(transform.localScale.y));
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {

        //...powerUp seccion...

        GameObject PowerUp;

        if (collision.gameObject.tag == "double bullet item"){
            doubleShooting = true;
            tripleShooting = false;
            Destroy(collision.gameObject);
            PowerUp = GameObject.Find("Enemy Spawner (PowerUp Double)");
            Destroy(PowerUp);
        }

        else if (collision.gameObject.tag == "triple bullet item"){
            doubleShooting = false;
            tripleShooting = true;
            Destroy(collision.gameObject);
            PowerUp = GameObject.Find("Enemy Spawner (Power Up Triple)");
            Destroy(PowerUp);
        }

        else if (collision.gameObject.tag == "Asteroid") {
            life = 0;
        }

        //...Seccion de damage...

        if (collision.gameObject.tag == "enemy bullet")
        {
            life--;
        }
    }

    public void die(){
        stageManager.score = 0;
        Destroy(gameObject);
        GameOverScreen.SetActive(true);
        Instantiate(explosion, transform.position, transform.rotation);
    }

    public void checkLife(){
        currentLife = life / maxLife; //calculo de 0 a 1 para jugar con localScale
        LifeBar.transform.localScale = new Vector3(Mathf.Clamp(currentLife, 0f, 1f), LifeBar.transform.localScale.y, LifeBar.transform.localScale.z);

        if(life == 4){
            LifeBar.color = Color.yellow;
        }

        if (life == 2){
            LifeBar.color = Color.red;
        }

        if(life <= 0){
            die();
        }
    }

    public void checkIfWow(){
        if (stageManager.score > 500000){
            StartCoroutine(loadGameScene());
        }
    }

    IEnumerator loadGameScene()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(2);

    }
}
