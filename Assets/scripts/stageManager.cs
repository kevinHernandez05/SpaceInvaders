using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class stageManager : MonoBehaviour {

    public GameObject[] spawners;           //Objetos que tendran la instancia del Spawner (rocas, enemigos, itemes)
    public GameObject Player;               //Nave Principal
    public GameObject boss;                 //Jefe final
    public GameObject stagePresentationUI;  //UI que mostrara la descripcion del stage a jugar
    public GameObject warningUI;            //Presentacion del enemigo/boss final del Stage
    public GameObject bossSpawner;          //Spawner del enemigo


    public GameObject powerup1;
    public GameObject Powerup2;

    public AudioClip bossThemeAudioClip;


    public int[] fase;                      //Subdivisiones para spawmear X powerup para el player
    public static int score;                //Score del personaje en el juego
    public int introSeconds;                //Duracion (en segundos) el intro del stage
    public int scoreForBossApear;           //Score puesto para que le jefe del stage aparezca
    public Text scoreText;

    public static bool isABossFight;              //Determina si es una pelea contra el jefe final


    void Start()
    {
        StartCoroutine(startingStage());
    }

    void Update()
    {
        scoreText.text = score + "";

        //...eventos...

        if (score == 500){
            //tirar un powerup

            Instantiate(powerup1, spawners[0].transform.position, spawners[0].transform.rotation);
            score = 600;
        }

        else if(score == 1000){
            //tirar un powerup
            Instantiate(Powerup2, spawners[0].transform.position, spawners[0].transform.rotation);
            score = 1100;


        }

        else if(score == scoreForBossApear){
            isABossFight = true; //pelea con el jefe empieza

            if (isABossFight)
            {
                actorsState(false);
                score += 100;


                StartCoroutine(warning());
                isABossFight = false;

                PlayMusic.musicSource.clip = bossThemeAudioClip;
                PlayMusic.musicSource.Play();

                //...aparece el jefe a destruir a partir de aqui...

                //Instantiate(boss, spawners[0].transform.position, spawners[0].transform.rotation);
                //Se activa el spawner del boss
                bossSpawner.SetActive(true);
                

            }
        }
    }



    //...IEnumerator para poner un espacio de tiempo para ver lo que hay que hacer al inicio del juego...
    IEnumerator startingStage()
    {
        stagePresentationUI.SetActive(true);
        actorsState(false);

        yield return new WaitForSeconds(introSeconds);

        stagePresentationUI.SetActive(false);
        actorsState(true);

    }

    IEnumerator warning()
    {
        warningUI.SetActive(true);
        yield return new WaitForSeconds(3);
        warningUI.SetActive(false);


    }


    //...estado de los actores...
    public void actorsState(bool enable){
        if(!enable)
        {
            foreach (GameObject spanwer in spawners)
            {
                spanwer.SetActive(false);
            }
           // Player.SetActive(false);

        }
        else if(enable)
        {
            foreach (GameObject spanwer in spawners)
            {
                spanwer.SetActive(true);
            }
           // Player.SetActive(true);
        }
    }




   
}
