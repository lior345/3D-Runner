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
        playerScript.enabled = false;
        repalyText.gameObject.SetActive(true);
        anim.enabled = false;
    }

}
