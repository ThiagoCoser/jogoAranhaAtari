using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HPUpdate : MonoBehaviour
{

    public TextMeshProUGUI HPText;
    public GameManager gameManager;
   

   
    // Update is called once per frame
    void Update()
    {
        HPText.text = gameManager.HP.ToString();
    }
}
