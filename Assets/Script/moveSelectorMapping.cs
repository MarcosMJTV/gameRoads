using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class moveSelectorMapping : MonoBehaviour
{
    public GameObject audioMananger;
    private int index;
    public Text textName;
    public Text textScore;
    public ListMapping lisMapp;
    public void nextCharacter()
    {
        if (audioMananger.activeInHierarchy)
        {
            audioMananger.GetComponent<AudioSource>().Play();
        }
        if (index == lisMapp.listMap.Length - 1)
        {
            index = 0;
            lisMapp.listMap[index].SetActive(true);
            lisMapp.listMap[lisMapp.listMap.Length - 1].SetActive(false);
            textName.text = "";
            textScore.text = "";
        }
        else
        {
            index = index + 1;
            lisMapp.listMap[index].SetActive(true);
            lisMapp.listMap[index - 1].SetActive(false);
            textName.text = "";
            textScore.text = "";
        }
    }

    public void previousCharacter()
    {
        if (audioMananger.activeInHierarchy)
        {
            audioMananger.GetComponent<AudioSource>().Play();
        }
        if (index == 0)
        {
            index = lisMapp.listMap.Length - 1;
            lisMapp.listMap[0].SetActive(false);
            lisMapp.listMap[lisMapp.listMap.Length - 1].SetActive(true);
            textName.text = "";
            textScore.text = "";
        }
        else
        {
            index = index - 1;
            lisMapp.listMap[index].SetActive(true);
            lisMapp.listMap[index + 1].SetActive(false);
            textName.text = "";
            textScore.text = "";
        }
    }
}
