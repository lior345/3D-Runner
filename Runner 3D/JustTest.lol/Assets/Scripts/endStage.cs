using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class endStage : MonoBehaviour
{
    public GameObject repalyText;
    private void OnTriggerEnter(Collider other)//colliding with the finishline trigger
    {
        Time.timeScale = 0;
        repalyText.gameObject.SetActive(true);
    }

}
