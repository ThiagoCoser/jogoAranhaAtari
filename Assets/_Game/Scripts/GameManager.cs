using System.Collections;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{

    // variaveis de dificuldade

    public int score;

    public int gameLevel;
    public int HP = 5;


    public bool iniciado = false;
    public GameObject playerGame;
    public GameObject textoCanvas;
    public GameObject textoPause;
    public bool pausado = false;

    public TextMeshProUGUI scoregame;

    public GameObject spiderSpamGame;


    public GameObject gameoverText;

    public IEnumerator gameOver()
    {
        //Tela de gameOver
        gameoverText.SetActive(true);
        Time.timeScale = 0;

        //Salva high score
        yield return new WaitForSeconds(3f);
        // resetar o jogo
        Time.timeScale = 1;
        iniciaJogo();
       // resetaJogo();
    }

    void resetaJogo()
    {

        Time.timeScale = 1;
    }


    public void atualizaScore()
    {

        scoregame.text = score.ToString();
    }


    private void iniciaJogo()
    {

        StartCoroutine(spiderSpamGame.GetComponent<SpiderSpawn>().SpawnPrefabsCoroutine());
        iniciado = true;
        playerGame.GetComponent<Player>().enabled = true;
        playerGame.GetComponent<BoxCollider>().enabled = true;
        textoCanvas.SetActive(false);
    }

    private IEnumerator PausarCoroutine()
    {
        textoPause.SetActive(true);
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
                textoPause.SetActive(false);
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
