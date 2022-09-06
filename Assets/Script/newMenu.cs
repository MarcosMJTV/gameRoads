using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class newMenu : MonoBehaviour
{
    public Text[] listText;
    public GameObject[] listButtonActive;
    public GameObject[] listAudioButton;
    public GameObject audioManager;
    public Text coin;
    public saveData data;
    public AudioSource music;
    public shopReset rese;
    private string nameScene;
    private int index;
     
    void Start()
    {
        coin.text = PlayerPrefs.GetInt("nameCoint", 0).ToString();
        if (PlayerPrefs.GetInt("boolMute",0) == 1)
        {
            Mute();
        }
        else
        {
            audioMute();
        }
    }

    public void activeOption()
    {
        if (audioManager.activeInHierarchy)
        {
            audioManager.GetComponent<AudioSource>().Play();
        }
        foreach (GameObject option in listButtonActive)
        {
            option.SetActive(true);
        }     
    }

    public void desactiveOption()
    {
        if (audioManager.activeInHierarchy)
        {
            audioManager.GetComponent<AudioSource>().Play();
        }
        foreach (GameObject option in listButtonActive)
        {
            option.SetActive(false);
        }
    }

    public void ResetValues()
    {
        if (audioManager.activeInHierarchy)
        {
            audioManager.GetComponent<AudioSource>().Play();
        }
        PlayerPrefs.DeleteAll();
        listText[2].text = "reset values";
        desactiveOption();
        audioMute();
        foreach (Text text in rese.listText)
        {
            text.text = "Buy";
        }
        foreach (GameObject imaff in rese.listImag)
        {
            imaff.SetActive(true);
        }
    }
    public void clickScene(InfoMapp info)
    {
        if (audioManager.activeInHierarchy)
        {
            audioManager.GetComponent<AudioSource>().Play();
        }
        listText[0].text = info.nameMapp.ToString();
        listText[1].text = "Best time: " + string.Format("{0:00}:{1:00}:{2:00}", PlayerPrefs.GetInt("minutesString" + info.index, 0),
           PlayerPrefs.GetInt("secondsString" + info.index, 0), PlayerPrefs.GetInt("centsString" + info.index, 0)).ToString();
        nameScene = info.directionScene;
        index = info.index;               
    }

    public void playScene()
    {
        if (audioManager.activeInHierarchy)
        {
            audioManager.GetComponent<AudioSource>().Play();
        }
        if (nameScene == null)
        {
            return;
        }
        else
        {           
            PlayerPrefs.SetInt("index", index);
            SceneManager.LoadScene(nameScene);
        }                
    }   

    public void Mute()
    {
        if (PlayerPrefs.GetInt("boolMute") == 0)
        {
            PlayerPrefs.SetInt("boolMute",1);
            data.checkMute(PlayerPrefs.GetInt("boolMute"));
        }        
        music.Stop();
        audioManager.SetActive(false);
        listAudioButton[1].SetActive(true);
        listAudioButton[0].SetActive(false);
    }

    public void audioMute()
    {
        if (PlayerPrefs.GetInt("boolMute") == 1)
        {
            PlayerPrefs.SetInt("boolMute", 0);
            data.checkMute(PlayerPrefs.GetInt("boolMute"));
        }
        music.Play();
        audioManager.SetActive(true);       
        listAudioButton[0].SetActive(true);
        listAudioButton[1].SetActive(false);
    }   

    public void exitGame()
    {
        if (audioManager.activeInHierarchy)
        {
            audioManager.GetComponent<AudioSource>().Play();
        }
        Application.Quit();
    }
}
