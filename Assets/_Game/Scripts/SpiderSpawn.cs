using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderSpawn : MonoBehaviour
{


    // Criar uma corotina para instanciar 12 prefabs, a cada 0.5 segundos
    // segundo de modo que cada um deles faça um lerp para um
    // GameObject aleatorio de um array de gameobjects


    public GameObject prefab;                    // Prefab a ser instanciado
    public Transform[] targetPoints;             // Alvos possíveis
    public float spawnInterval = 0.5f;           // Intervalo entre instâncias
    public int numberOfPrefabs = 12;             // Quantidade total de instâncias
    public float moveDuration = 2f;              // Tempo de Lerp até o alvo

    void Start()
    {
       // StartCoroutine(SpawnPrefabsCoroutine());
    }

    public IEnumerator SpawnPrefabsCoroutine()
    {
        for (int i = 0; i < numberOfPrefabs; i++)
        {
            GameObject instance = Instantiate(prefab, transform.position, Quaternion.identity);

            // Escolhe um alvo aleatório do array
            Transform randomTarget = targetPoints[Random.Range(0, targetPoints.Length)];

            // Inicia a corrotina para mover esse objeto até o alvo
            StartCoroutine(MoveToTarget(instance.transform, randomTarget.position, moveDuration));

            yield return new WaitForSeconds(spawnInterval);
        }
    }

    IEnumerator MoveToTarget(Transform objTransform, Vector3 targetPos, float duration)
    {
        Vector3 startPos = objTransform.position;
        float elapsed = 0f;

        while (elapsed < duration)
        {
            objTransform.position = Vector3.Lerp(startPos, targetPos, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }

        objTransform.position = targetPos; // Garante que chegue exatamente no destino
    }
}
