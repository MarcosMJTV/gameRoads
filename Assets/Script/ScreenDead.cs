using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScreenDead : MonoBehaviour
{
    public List<GameObject> listHud = new List<GameObject>();
    public List<GameObject> listDead = new List<GameObject>();
    public List<GameObject> listVictory = new List<GameObject>();
    public AudioSource fondo;
    public GameObject player;
    private PLayerController contr;
    public Text countText;
    public Text timerText;
    public Text cointTotal;
    public Text timeFinal;
    public saveData data;
    public AudioMananger listAudio;
    public  int minutes, seconds, cents;
    private int Coint;
    public int index;
    bool check;
    bool game = true;
    float timer;
    public bool gameOver = false;
    float timecont = 0;

    void Start()
    {
        contr = player.GetComponent<PLayerController>();
        listAudio = FindObjectOfType<AudioMananger>();
        foreach (GameObject dead in listDead)
        {
            dead.SetActive(false);
        }
        foreach (GameObject victory in listVictory)
        {
            victory.SetActive(false);
        }
    }

    private void Update()
    {
       
        timer += Time.deltaTime;
        timecont += Time.deltaTime;       
        if (!gameOver && timecont >= 0.05f )
        {
            minutes = (int)(timer / 60f);
            seconds = (int)(timer - minutes * 60f);
            cents = (int)((timer - (int)timer) * 100f);
            timerText.text = ((minutes < 10 ? ("0" + minutes) : minutes)) + ":" + ((seconds < 10 ? ("0" + seconds) : seconds)) + ":" + ((cents < 10 ? ("0" + cents) : cents));
            timecont = 0;
        }
    }

    public void Check(bool check,bool meta)
    {            
        if (check == true && game == true)
        {
            Invoke("dead", 3f);           
            gameOver = true;
        }else
        if (meta == true && game == true)
        {
            Invoke("victory", 3f);
            gameOver = true;
        }             
    }
    public void ResetScreen()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    public void screenMenu()
    {
        
        if (Input.GetMouseButtonDown(0))
        {
            check = true;
            if (check)
            {
                data.sumOfMoney(Coint);
                data.scoreTime(minutes,seconds,cents);
                check = false;
            }
            SceneManager.LoadScene("Menu");
        }

    }
    public void dead()
    {
        if (game == false)
        {
            return;
        }
        foreach (GameObject hud in listHud)
        {
            hud.SetActive(false);
        }
        foreach (GameObject dead in listDead)
        {
            dead.SetActive(true);
        }
        fondo.Stop();
        game = false;
        player.GetComponent<AudioSource>().volume = 0;
        listAudio.gameObject.GetComponent<AudioSource>().pitch = 1;
        listAudio.SelectorAudio(3, 0.4f);
    }
    private void victory()
    {
        foreach (GameObject hud in listHud)
        {
            hud.SetActive(false);
        }
        foreach (GameObject victory in listVictory)
        {
            victory.SetActive(true);
        }
        Coint = player.GetComponent<PLayerController>().countCoint;
        fondo.Stop();
        player.GetComponent<AudioSource>().volume = 0;
        listAudio.gameObject.GetComponent<AudioSource>().pitch = 1;
        game = false;
        listAudio.SelectorAudio(2, 0.4f);
        cointTotal.text = "Coin " + Coint.ToString();
        timeFinal.text = "Time " + string.Format("{0:00}:{1:00}:{2:00}", minutes, seconds, cents);
    }
   
    public void changeScreen()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        
    }
    public void textCoin()
    {
        countText.text = contr.countCoint.ToString();
    }
}
