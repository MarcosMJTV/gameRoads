using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectorMenu : MonoBehaviour
{
    public GameObject shop;
    public ListCharacter list;
    public GameObject audioMananger;
    public Text text;
    public Text textMessage;
    private int index;

    public void nextCharacter()
    {
        if (audioMananger.activeInHierarchy)
        {
            audioMananger.GetComponent<AudioSource>().Play();
        }
        if (index == list.listCharacter.Length-1)
        {
            index = 0;
            list.listCharacter[index].SetActive(true);
            text.text = list.listCharacter[index].GetComponent<infoCharacter>().nameCharacter.ToString();
            list.listCharacter[list.listCharacter.Length-1].SetActive(false);
        }
        else
        {
            index = index + 1;
            list.listCharacter[index].SetActive(true);
            text.text = list.listCharacter[index].GetComponent<infoCharacter>().nameCharacter.ToString();
            list.listCharacter[index - 1].SetActive(false);
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
            index = list.listCharacter.Length - 1;
            list.listCharacter[0].SetActive(false);
            list.listCharacter[list.listCharacter.Length - 1].SetActive(true);
            text.text = list.listCharacter[list.listCharacter.Length - 1].GetComponent<infoCharacter>().nameCharacter.ToString();
        }
        else
        {
            index = index - 1;
            list.listCharacter[index].SetActive(true);
            text.text = list.listCharacter[index].GetComponent<infoCharacter>().nameCharacter.ToString();
            list.listCharacter[index + 1].SetActive(false);
        }       
    }
    public void SelectCharacter()
    {
        if (audioMananger.activeInHierarchy)
        {
            audioMananger.GetComponent<AudioSource>().Play();
        }
        textMessage.text = "selected character";
        PlayerPrefs.SetInt("indexValueCharacter",index);
    }
}
