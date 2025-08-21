using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class TesteAranha : MonoBehaviour
{

    
    public Transform targetPos;
    public Transform randomChild;

    public GameObject parentObject;
    public GameObject gameManager;

    // public Transform[] targetPosTeste;

    private float tempoParaAndar = 5f;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("vasinho"))
        {


            gameManager.GetComponent<GameManager>().score += 1;
            gameManager.GetComponent<GameManager>().atualizaScore();
            gameObject.GetComponent<SphereCollider>().enabled = false;
            transform.GetChild(0).gameObject.SetActive(false);
            // gameObject.GetComponent<MeshRenderer>().enabled = false;

        }

        if (other.CompareTag("Vida"))
        {

            gameManager.GetComponent<GameManager>().HP -= 1;
            //gameManager.GetComponent<GameManager>().atualizaScore();
            gameObject.GetComponent<SphereCollider>().enabled = false;
            transform.GetChild(0).gameObject.SetActive(false);

            if(gameManager.GetComponent<GameManager>().HP == 0){

                StartCoroutine(gameManager.GetComponent<GameManager>().gameOver());

            }


        }



        }





            private void sorteioAleatorio()
    {
        if (parentObject != null && parentObject.transform.childCount > 0)
        {
            randomChild = GetRandomChildTransform(parentObject.transform);
            Debug.Log("Filho sorteado: " + randomChild.name);
        }
        else
        {
            Debug.LogWarning("Objeto pai não definido ou não tem filhos.");
        }

        Transform GetRandomChildTransform(Transform parent)
        {
            int randomIndex = Random.Range(0, parent.childCount);
            return parent.GetChild(randomIndex);
        }
    }

   void Awake()
    {
        parentObject = GameObject.Find("SpiderSpawn");
        gameManager = GameObject.Find("GameManager");
        sorteioAleatorio();
    }

    void Start() {
        
        // Move até o target em x segundos (pode ajustar)
        StartCoroutine(MoveToTarget(transform, randomChild.position, tempoParaAndar));
    }

    IEnumerator MoveToTarget(Transform objTransform, Vector3 targetPos, float duration)
    {
        Vector3 startPos = objTransform.position;
        float elapsed = 0f;

        while (elapsed < duration)
        {
            float t = elapsed / duration;
            objTransform.position = Vector3.Lerp(startPos, targetPos, t);
            elapsed += Time.deltaTime;
            yield return null;
        }

        objTransform.position = targetPos; // garante que chega exatamente no fim

        //Alguma outra coisa ao concluir o lerp
        StartCoroutine(MoveToY(gameObject.transform, 10f, 5f)); // sobe até y=5 em 2 segundos

    }

    IEnumerator MoveToY(Transform objTransform, float targetY, float duration)
    {
        Vector3 startPos = objTransform.position;
        Vector3 targetPos = new Vector3(startPos.x, targetY, startPos.z);
        float elapsed = 0f;

        objTransform.rotation = objTransform.rotation * Quaternion.Euler(-90f, 0f, 0f);


        while (elapsed < duration)
        {
            float t = elapsed / duration;
            float newY = Mathf.Lerp(startPos.y, targetY, t);
            objTransform.position = new Vector3(startPos.x, newY, startPos.z);
            elapsed += Time.deltaTime;
            yield return null;
        }

        objTransform.position = targetPos; // garante que chega exatamente no fim
    }



}