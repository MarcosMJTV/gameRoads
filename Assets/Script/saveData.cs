using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class saveData : MonoBehaviour
{
    public  int coint;
    private int index;
    public static saveData dataSave;


    private void Awake()
    {
        if (dataSave == null)
        {
            dataSave = this;
            DontDestroyOnLoad(gameObject);
        }else if (dataSave != null)
        {
            Destroy(gameObject);
        }      
    }

 
    public void sumOfMoney(int cointPlayer) {
        coint = PlayerPrefs.GetInt("nameCoint", 0) + cointPlayer;
        PlayerPrefs.SetInt("nameCoint",coint);
    }

    public void scoreTime( int minutes, int seconds, int cents)
    {
        index = PlayerPrefs.GetInt("index");
        if (PlayerPrefs.GetInt("minutesString"+index,0) == 0 && PlayerPrefs.GetInt("secondsString" + index, 0) == 0 && PlayerPrefs.GetInt("centsString" + index, 0) == 0)
        {
            PlayerPrefs.SetInt("minutesString" + index, minutes);
            PlayerPrefs.SetInt("secondsString" + index, seconds);
            PlayerPrefs.SetInt("centsString" + index, cents);
            return;
        }
        else
        {
            if (minutes < PlayerPrefs.GetInt("minutesString" + index, 0))
            {
                PlayerPrefs.SetInt("minutesString" + index, minutes);
                PlayerPrefs.SetInt("secondsString" + index, seconds);
                PlayerPrefs.SetInt("centsString" + index, cents);
                return;
            }
            else if (minutes == PlayerPrefs.GetInt("minutesString" + index, 0))
            {
                if (seconds < PlayerPrefs.GetInt("secondsString" + index, 0))
                {
                    PlayerPrefs.SetInt("minutesString" + index, minutes);
                    PlayerPrefs.SetInt("secondsString" + index, seconds);
                    PlayerPrefs.SetInt("centsString" + index, cents);
                    return;
                }else if (seconds == PlayerPrefs.GetInt("secondsString" + index, 0))
                {
                    if (cents < PlayerPrefs.GetInt("centsString" + index, 0))
                    {
                        PlayerPrefs.SetInt("minutesString" + index, minutes);
                        PlayerPrefs.SetInt("secondsString" + index, seconds);
                        PlayerPrefs.SetInt("centsString" + index, cents);
                        return;
                    }
                    else
                    {
                        return;
                    }
                }
                else
                {
                    return;
                }
            }else
            {                
                return;
            }
        }
    }  
    
    public void checkMute(int check)
    {
        PlayerPrefs.SetInt("boolMute", check);
    }
}
