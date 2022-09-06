using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonTransition : MonoBehaviour
{

    public GameObject entrada;
    public GameObject salida;
    public GameObject activate;
    public Text textCoint;
    public GameObject audioMananger;
    public SelectorMenu selectorMenu;
    public newMenu menu;

    private void Start()
    {
        if (selectorMenu == null || textCoint == null || activate == null)
        {
            return;
        }
    }
    public void moveTransition()
    {
        if (audioMananger.activeInHierarchy)
        {
            audioMananger.GetComponent<AudioSource>().Play();
        }
        salida.GetComponent<Animator>().SetBool("exit",true);
        entrada.SetActive(true);     
        Invoke("exitMove",1.3f);
        foreach(Text text in menu.listText)
        {
            text.text = "";
        }

        if (entrada.CompareTag("custom"))
        {
            selectorMenu.shop.SetActive(false);
            textCoint.text = PlayerPrefs.GetInt("nameCoint", 0).ToString();
        }
        if (activate == null)
        {
            return;
        }else if (!activate.activeInHierarchy)
        {
            Invoke("activateCustom", 1f);
        }
    }

    private void exitMove()
    {
        salida.SetActive(false);
    }
    private void activateCustom()
    {
        activate.SetActive(true);
    }
}
