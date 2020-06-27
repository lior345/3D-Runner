using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collactable : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {

        PlayerPrefs.SetInt("score", PlayerPrefs.GetInt("score") + 50);
        
        Destroy(gameObject);
    }
}
