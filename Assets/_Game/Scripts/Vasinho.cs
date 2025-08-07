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



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
