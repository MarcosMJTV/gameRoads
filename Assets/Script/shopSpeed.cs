using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class shopSpeed : MonoBehaviour
{
    public int levelUp;
    public int costUpgrade;
    public Text textCoin;
    public Text textButton;
    public GameObject audioMananger;
    public GameObject cointValue;
    public Text textCoinGlobal;
    public Text textMessage;
    public GameObject equip;
    public string id;
    private int moneyExchange;

    private void Start()
    {
        if (cointValue.activeInHierarchy)
        {
            textCoin.text = costUpgrade.ToString();
        }
        if (PlayerPrefs.GetInt("boolBuy" + id + levelUp, 0) == 1)
        {
            cointValue.SetActive(false);
            textButton.text = "select";
        }
    }
    private void FixedUpdate()
    {
        desactiveItem();
    }
    public void upgradeBuySpeed()
    {
        if (audioMananger.activeInHierarchy)
        {
            audioMananger.GetComponent<AudioSource>().Play();
        }
        if (PlayerPrefs.GetInt("boolBuy"+id + levelUp, 0) == 0 && PlayerPrefs.GetInt("nameCoint") >= costUpgrade)
        {
            PlayerPrefs.SetInt(id+"Upgrade", levelUp);
            textMessage.text = "selected improvement";
            moneyExchange = PlayerPrefs.GetInt("nameCoint") - costUpgrade;
            PlayerPrefs.SetInt("nameCoint", moneyExchange);
            textCoinGlobal.text = PlayerPrefs.GetInt("nameCoint").ToString();
            PlayerPrefs.SetInt("boolBuy"+id + levelUp, 1);
            PlayerPrefs.SetInt("bool"+id+"Activate", 1);
            cointValue.SetActive(false);
            Invoke("resetMessage", 1.3f);
            textButton.text = "select";
            return;
        }
        else if (PlayerPrefs.GetInt("boolBuy"+id + levelUp, 0) == 0 && PlayerPrefs.GetInt("nameCoint") < costUpgrade)
        {
            textMessage.text = "insufficient money";
            Invoke("resetMessage", 1.3f);
            return;
        }

        if (PlayerPrefs.GetInt("bool"+id+"Activate", 0) != 0 && PlayerPrefs.GetInt(id+"Upgrade", 0) == levelUp)
        {
            PlayerPrefs.SetInt("bool"+id+"Activate", 0);
            PlayerPrefs.SetInt(id+"Upgrade", 0);
            textMessage.text = "enhancement disabled";
        }
        else
        {
            PlayerPrefs.SetInt("bool"+id+"Activate", 1);
            PlayerPrefs.SetInt(id+"Upgrade", levelUp);
            textMessage.text = "enhancement activated";

        }
        Invoke("resetMessage", 1.3f);
    }
    private void resetMessage()
    {
        textMessage.text = "";
    }
    private void desactiveItem()
    {
        if (PlayerPrefs.GetInt("bool" + id + "Activate", 0) != 0 && PlayerPrefs.GetInt(id + "Upgrade", 0) == levelUp)
        {
            equip.SetActive(true);
        }
        else
        {
            equip.SetActive(false);
        }
    }
}
