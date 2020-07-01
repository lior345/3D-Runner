using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class score : MonoBehaviour
{
    private TextMeshProUGUI tmPro;
        void Start()
    {
        tmPro = GetComponent<TextMeshProUGUI>();
        PlayerPrefs.SetInt("score", 0);
    }

    // Update is called once per frame
    void Update()
    {
        tmPro.text = "Score:" + PlayerPrefs.GetInt("score".ToString());
    }
}
