using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collactable : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Crystal"))
        {
            PlayerPrefs.SetInt("score", PlayerPrefs.GetInt("score") + 50);
            Destroy(other.gameObject);
        }

        if (other.gameObject.CompareTag("Coin"))
        {
            PlayerPrefs.SetInt("score", PlayerPrefs.GetInt("score") + 10);
            Destroy(other.gameObject);
        }
    }
}
