using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour {

    public float sway = 0.05f;
    public float speed = 5f;
    public static Vector3 offset;
    private float direction = 0;
    private float vOffset = 0f;
    public float lifeTime = 1f;

    IEnumerator Start()
    {
        yield return new WaitForSeconds(lifeTime);
        Destroy(gameObject);
    }

    public void Init(float dir)
    {
        vOffset = Random.Range(-sway, sway);
        direction = dir;
        transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y * -dir, transform.localScale.y);
        offset.x *= dir;
        transform.position += offset;
    }

    void Update()
    {
        transform.position += new Vector3(0f,1f,0f) * speed * direction * Time.deltaTime + new Vector3(0f, 1f, 0f) * vOffset * Time.deltaTime;

    }

    private void FixedUpdate()
    {

    }


    private void OnCollisionEnter(Collision collision)
    {
        StopCoroutine("Start");
        Destroy(gameObject);
    }

    private void OnBecameInvisible()
    {
        StopCoroutine("Start");
        Destroy(gameObject);
    }
}


