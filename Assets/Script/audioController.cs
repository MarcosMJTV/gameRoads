using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioController : MonoBehaviour
{
    public AudioSource camara;
    public GameObject audioManager;
    public GameObject[] listElement;
    void Start()
    {
        checkMuteMap();
    }
    public void checkMuteMap()
    {
        if (PlayerPrefs.GetInt("boolMute") == 1)
        {
            audioManager.SetActive(false);
            foreach (GameObject elemet in listElement)
            {
                elemet.GetComponent<AudioSource>().volume = 0;
            }            
            camara.Pause();
        }
        if (PlayerPrefs.GetInt("boolMute") == 0)
        {
            audioManager.SetActive(true);
            foreach (GameObject elemet in listElement)
            {
                elemet.GetComponent<AudioSource>().volume = 0.23f;
            }            
           camara.Play();
        }
    }
}
