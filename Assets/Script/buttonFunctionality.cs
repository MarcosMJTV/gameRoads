using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonFunctionality : MonoBehaviour
{
    public GameObject enter;
    public GameObject exit;
    public GameObject audioMananger;

    public void buttonPress()
    {
        if (audioMananger.activeInHierarchy)
        {
            audioMananger.GetComponent<AudioSource>().Play();
        }
        exit.SetActive(false);
        enter.SetActive(true);
    }
}
