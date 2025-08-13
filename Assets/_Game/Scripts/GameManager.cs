using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool iniciado = false;
    public GameObject playerGame;
    public GameObject textoCanvas;

    private void iniciaJogo()
    {
        iniciado = true;
        playerGame.GetComponent<Player>().enabled = true;
        playerGame.GetComponent<BoxCollider>().enabled = true;
        textoCanvas.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetButtonDown("Derrubar") && iniciado == false)
        {

            iniciaJogo();


        }


    }
}
