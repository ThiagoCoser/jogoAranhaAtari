using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TesteAranha : MonoBehaviour
{
    public Transform targetPos;
    public Transform randomChild;

    public GameObject parentObject;

    // public Transform[] targetPosTeste;

    private float tempoParaAndar = 5f;

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

    }
}