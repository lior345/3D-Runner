using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttons : MonoBehaviour
{
    public GameObject pauseMenu;
    public Controller controller;
    public GameObject[] interferences;
    public GameObject cam1;
    public GameObject cam2;


    private void Start()
    {
        PlayerPrefs.SetFloat("Speed", 1f);
    }
    public void MenuOpener()
    {
        Time.timeScale = 0;
        pauseMenu.SetActive(true);
    }
    public void MenuCloser()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }
    public void LowSpeed()
    {
        controller.SetSpeedMultiplier(1f);
    }
    public void MediumSpeed()
    {
        controller.SetSpeedMultiplier(1.5f);
    }
    public void HighSpeed()
    {
        controller.SetSpeedMultiplier(2f);
    }
    public void StillCamera()
    {
        controller.doesCameraFollow = 0;
        DisableSideView();

    }
    public void FollowCamera()
    {
        controller.doesCameraFollow = 1;
        DisableSideView();
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void SideCamera()
    {
        ActivateSideView();
    }
    public void ActivateSideView()
    {
        cam1.SetActive(false);
        cam2.SetActive(true);
        for (int i = 0; i < interferences.Length; i++)
        {
            interferences[i].SetActive(false);
        }
    }
    public void DisableSideView()
    {
        cam2.SetActive(false);
        cam1.SetActive(true);
        for (int i = 0; i < interferences.Length; i++)
        {
            interferences[i].SetActive(true);
        }
    }
}
