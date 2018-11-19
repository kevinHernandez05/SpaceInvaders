using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spanwer : MonoBehaviour 
{

    public GameObject enemy;
    public int delay;
    int delayCounter;
    public bool isObject;
    public bool isEnemy;
    public bool isBoss;
    public bool childSpanwer;

    private void Start()
    {
        delayCounter = delay;
    }
    void Update () 
    {
        if(Time.timeScale > 0){
            if (delayCounter <= 0)
            {
                delayCounter = delay;
                if(!isBoss && !childSpanwer){
                    transform.position = new Vector2(Random.Range(-2.0f, 2.0f), transform.position.y);
                }

                if (isObject && !isEnemy)
                {
                    isEnemy = false;
                    Instantiate(enemy, transform.position, transform.rotation);
                }

                else if (isEnemy && !isObject)
                {
                    isObject = false;
                    Instantiate(enemy);

                }
                else if(isBoss){
                    Instantiate(enemy, transform.position, transform.rotation);
                    Destroy(gameObject);
                }

                else if(childSpanwer){
                    Instantiate(enemy, transform.position, transform.rotation);

                }
            }
            else
            {
                delayCounter--;
            }
        }

    }
}

