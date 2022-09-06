using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPause : MonoBehaviour
{
    public GameObject panelMenu;
    public bool pause = false;
    public void SceneMenu()
    {
        SceneManager.LoadScene("Menu");
        Time.timeScale = 1f;
    }

    public void SceneReset()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
    }
    public void PauseCanvas()
    {
            if (Time.timeScale == 1)
            {
                Time.timeScale = 0f;
                panelMenu.SetActive(true);
                pause = true;
            }
            else
            {
                Time.timeScale = 1f;
                panelMenu.SetActive(false);
                pause = false;
            }          
    }
}
