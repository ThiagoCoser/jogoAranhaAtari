using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyTime : MonoBehaviour
{



    // Start is called before the first frame update
    void Start()
    {

        Invoke("destroyObjeto", 3f);

    }


    void destroyObjeto()
    {

        Destroy(gameObject);

}


}
