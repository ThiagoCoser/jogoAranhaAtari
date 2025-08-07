using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vasinho : MonoBehaviour
{

    public GameObject vaseFXprefab;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ground"))
        {
Instantiate(vaseFXprefab, gameObject.transform.position, Quaternion.identity);
            Destroy(gameObject);

        }
    }

}
