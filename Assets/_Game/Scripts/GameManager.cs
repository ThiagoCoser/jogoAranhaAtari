using System.Collections;
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

    private IEnumerator PausarCoroutine()
    {
        pausado = true;
        Time.timeScale = 0;

        Debug.Log("Jogo pausado");

        yield return new WaitForSecondsRealtime(0.5f); // <- CORRIGIDO AQUI

        // Espera até que o botão "Pausar" seja pressionado novamente
        while (pausado==true)
        {
            if (Input.GetButtonDown("Pausar")){

                Time.timeScale = 1;
                pausado = false;
                Debug.Log("Jogo despausado");

                break;
            }
            yield return null; // espera o próximo frame
        }

        

        
    }

    void Update()
    {
        if (Input.GetButtonDown("Derrubar") && !iniciado)
        {
            iniciaJogo();
        }

        // Inicia a corrotina de pausa se ainda não estiver pausado
        if (Input.GetButtonDown("Pausar") && !pausado)
        {
            StartCoroutine(PausarCoroutine());
        }
    }
}
