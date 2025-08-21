using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TesteAranha : MonoBehaviour
{
    public Transform targetPos;

    public float tempoParaAndar = 10f;

    private void Start() {
        // Move até o target em 2 segundos (pode ajustar)
        StartCoroutine(MoveToTarget(transform, targetPos.position, tempoParaAndar));
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


    }
}
