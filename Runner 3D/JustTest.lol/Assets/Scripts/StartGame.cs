using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class StartGame : MonoBehaviour
{
    public Controller controller;
    private void Start()
    {
        Time.timeScale = 0;
    }
    void Update()
    {
        if (Input.touches.Length > 0 || Input.GetMouseButtonDown(0))//tap or press mouse to start
        {
            if (controller.alive)
            {
                this.gameObject.SetActive(false);
                Time.timeScale = 1;
            }     
            else SceneManager.LoadScene("myScene");//if the text came up because we died- then the scene will reload

        }
    }
}

