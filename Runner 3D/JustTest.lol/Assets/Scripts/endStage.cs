using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class endStage : MonoBehaviour
{
    public movement playerScript;
    public GameObject repalyText;
    public Animator anim;
    private void OnTriggerEnter(Collider other)
    {
        Time.timeScale = 0;
        repalyText.gameObject.SetActive(true);
    }

}
