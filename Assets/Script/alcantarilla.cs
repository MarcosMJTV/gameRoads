using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class alcantarilla : MonoBehaviour
{

    public GameObject obstacle;
    public GameObject particuleSistem;
    public AudioSource aud;
    bool up = true;
    bool dowm = false;
    private float yStart;
    private float yEnd;
    private float radius = 3f;
    private float value = 0;
    private float speed= 0.9f;
    float timer;


    void Start()
    {
        yStart = obstacle.transform.position.y;
        yEnd = obstacle.transform.position.y + radius*2;
        aud = obstacle.GetComponent<AudioSource>();
        particuleSistem.SetActive(false);
        if (PlayerPrefs.GetInt("boolMute") == 1)
        {
            aud.volume = 0;
            particuleSistem.GetComponent<AudioSource>().volume = 0;
        }
        else
        {
            return;
        }
    }
   
    void Update()
    {
        timer += Time.deltaTime;
            if (up && timer > Random.Range(3f, 6f))
            {
                value += speed * Time.deltaTime;
                if (value > 1)
                {
                    up = false;
                    dowm = true;
                    value = 1;
                }
                particuleSistem.SetActive(true);
            }else
            if (dowm)
             {

                value -= speed * Time.deltaTime;
                if (value < 0)
                {

                    up = true;
                    dowm = false;
                    aud.Play();
                    value = 0;
                }
                particuleSistem.SetActive(false);
            timer = 0;
        }
            float yNewPosition = EaseOutQuad(yStart, yEnd, value);
            obstacle.transform.position = new Vector3(obstacle.transform.position.x, yNewPosition, obstacle.transform.position.z);
            
                
    }          
    public static float EaseOutQuad(float start, float end, float value)
    {
        end -= start;
        return -end * value * (value - 2) + start;
    }
}
