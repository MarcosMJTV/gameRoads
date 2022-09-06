using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sheck : MonoBehaviour
{
    public GameObject particlesm;
    public GameObject particlesmturbo;
    public PLayerController player;
    public GameObject point1;
    public GameObject point2;
    public bool contac;
    public bool fly;
    

    void Start()
    {
        particlesm.GetComponent<ParticleSystem>().Pause();
        particlesmturbo.GetComponent<ParticleSystem>().Pause();
    }

    void Update()
    {

        if (player.Right && contac)
        {
            right();
        }
        else if (player.left && contac)
        {
            letf();
        }
        else if (player.turbo2)
        {
            turbo();
        }
        else
        {
            particlesm.SetActive(false);
        }       
    }
   
    private void right()
    {
        particlesm.SetActive(true);
        particlesm.transform.position = new Vector2(point1.transform.position.x, point1.transform.position.y);
        particlesm.transform.eulerAngles = new Vector2(-33, -90);
    }
    private void letf()
    {
        particlesm.SetActive(true);
        particlesm.transform.position = new Vector2(point2.transform.position.x, point2.transform.position.y);
        particlesm.transform.eulerAngles = new Vector2(-45, -240);
    }
    private void turbo()
    {
        particlesmturbo.GetComponent<ParticleSystem>().Play();
        particlesmturbo.transform.position = new Vector2(point1.transform.position.x, point1.transform.position.y);
        particlesmturbo.transform.eulerAngles = new Vector2(-33, -90);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "mapping")
        {
            contac = true;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "mapping")
        {
            fly = false;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "mapping")
        {
            contac = false;
            fly = true;
        }
    }
}
