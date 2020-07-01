using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttons : MonoBehaviour
{
    public GameObject pauseMenu;
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
        PlayerPrefs.SetFloat("Speed", 1f);
    }
    public void MediumSpeed()
    {
        PlayerPrefs.SetFloat("Speed", 1.5f);
    }
    public void HighSpeed()
    {
        PlayerPrefs.SetFloat("Speed", 2f);
    }
    public void somethingElse()
    {

    }
}
