using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool iniciado = false;
    public GameObject playerGame;
    public GameObject textoCanvas;
    public bool pausado = false;

    public int score;

    private void iniciaJogo()
    {
        iniciado = true;
        playerGame.GetComponent<Player>().enabled = true;
        playerGame.GetComponent<BoxCollider>().enabled = true;
        textoCanvas.SetActive(false);

    }

    private void pausaJogo()
    {
        Time.timeScale = 0;
    }

    private void despausaJogo()
    {
        Time.timeScale = 1;
    }


    // Update is called once per frame
    void Update()
    {

      //  Debug.Log(Time.timeScale);

        if (Input.GetButtonDown("Derrubar") && iniciado == false)
        {

            iniciaJogo();


        }

        if (Input.GetButtonDown("Pausar") && pausado == false)
        {

            pausaJogo();


        }

        if (Input.GetButtonDown("Pausar") && pausado == true)
        {

            despausaJogo();


        }


    }
}
