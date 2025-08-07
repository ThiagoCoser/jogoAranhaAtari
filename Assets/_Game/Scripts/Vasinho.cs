using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vasinho : MonoBehaviour
{

private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ground"))
        {
            
            Destroy(gameObject);

        }
    }

}
