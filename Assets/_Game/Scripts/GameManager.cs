using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour

{

    // variaveis de dificuldade

    public float spiderSpeed;


    public int aranhasCount;


    public int score;
    public int highScore;

    public int gameLevel;
    public int HP = 3;


    public bool iniciado = false;
    public GameObject playerGame;
    public GameObject textoCanvas;
    public GameObject textoPause;
    public bool pausado = false;

    public TextMeshProUGUI scoregame;
    public TextMeshProUGUI highScoreGame;

    public GameObject spiderSpamGame;


    public GameObject gameoverText;

    public TextMeshProUGUI levelTxt;
   public int level;

    public bool nextLevelCheck;

    IEnumerator nextLevel()
    {
        spiderSpeed -= 1f;
        nextLevelCheck = true;
        level++;
        levelTxt.text = level.ToString();
        aranhasCount = 0;
        yield return new WaitForSeconds(3f);

        nextLevelCheck = false;
        //deleta aranhas
        //spawna aranhas
        StartCoroutine(spiderSpamGame.GetComponent<SpiderSpawn>().SpawnPrefabsCoroutine());
    }

 
    private void Start()
    {
        level = 1;
        spiderSpeed = 8f;
        //levelTxt.text = level.ToString();
        highScoreUpdate();
    }


         void highScoreUpdate()

    {
       // Debug.Log("inicia");
        highScore = PlayerPrefs.GetInt("HighScore");
       // Debug.Log(PlayerPrefs.GetInt("HighScore"));

        if (score > highScore)

        {

            PlayerPrefs.SetInt("HighScore", score);
   
           // Debug.Log(PlayerPrefs.GetInt("HighScore"));
        }
        highScoreGame.text = PlayerPrefs.GetInt("HighScore").ToString();
        //Debug.Log("Termina");
    }


    public IEnumerator gameOver()
    {
        //Tela de gameOver

        gameoverText.SetActive(true);
        highScoreUpdate();
       Time.timeScale = 0;

        //Salva high score


        yield return new WaitForSecondsRealtime(1f);
        // resetar o jogo
        Time.timeScale = 1;

        Debug.Log(Time.timeScale);
        //iniciaJogo();
     resetaJogo();
       // SceneManager.LoadScene(0);
    }

    void resetaJogo()
    {

        Debug.Log("Resetou");
        SceneManager.LoadScene(0);
       // Posição Player
       //Pode iniciar = true
       //Tela de pode jogar
       //Vida = 3
       //Reseta aranhas
       //Reseta velocida das aranhas

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

      //  Debug.Log("Jogo pausado");

        yield return new WaitForSecondsRealtime(0.5f); // <- CORRIGIDO AQUI

        // Espera até que o botão "Pausar" seja pressionado novamente
        while (pausado==true)
        {
            if (Input.GetButtonDown("Enter")){

                Time.timeScale = 1;
                pausado = false;
                textoPause.SetActive(false);
               // Debug.Log("Jogo despausado");

                break;
            }
            yield return null; // espera o próximo frame
        }

        

        
    }

    void Update()
    {
       // Debug.Log(aranhasCount);
        if(nextLevelCheck==false&& aranhasCount == 10)
        {

            StartCoroutine(nextLevel());
        }


        if (Input.GetButtonDown("Enter") && !iniciado)
        {
            iniciaJogo();
        }

        // Inicia a corrotina de pausa se ainda não estiver pausado
       else if (Input.GetButtonDown("Enter") && !pausado&& HP>0)
        {
            StartCoroutine(PausarCoroutine());
        }
    }
}
