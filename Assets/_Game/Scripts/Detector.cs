using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class Detector : MonoBehaviour
{
    public bool colidindo;
    public bool podeDerrubar = true;
    public GameObject vasoPrefab;
    public Transform spawnPoint;



    IEnumerator derrubaVaso()
    {
        //Instanciar o prefab do vasinho

        Instantiate(vasoPrefab, spawnPoint.position, Quaternion.identity);
        Debug.Log("Derrubou");
        podeDerrubar = false;
        yield return new WaitForSeconds(2f);
        podeDerrubar = true;
        Debug.Log("Reset");


}


    void Update()
    {

        if (Input.GetButtonDown("Derrubar") == true&&colidindo==true&&podeDerrubar==true)
        {
            StartCoroutine(derrubaVaso());

        }


}



    // Detecta quando algo entra no trigger
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            colidindo = true;
            Debug.Log(colidindo);
        }
    }

    // Detecta enquanto o objeto está dentro do trigger
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            colidindo = false;
            Debug.Log(colidindo);
        }
    }

}
    

