using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aranhaBehaviour : MonoBehaviour
{
    public GameObject gameManager;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("vasinho"))
        {

            gameManager.GetComponent<GameManager>().score+=1;
            Debug.Log(gameManager.GetComponent<GameManager>().score);
        }
    }


}
