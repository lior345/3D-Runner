using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collactableCoin : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {

        PlayerPrefs.SetInt("score", PlayerPrefs.GetInt("score") + 10);

        Destroy(gameObject);
    }
}
