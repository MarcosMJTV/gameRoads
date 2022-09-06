using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class robotMOve : MonoBehaviour
{
    public float Speed;
    public Rigidbody2D rg;
    public ScreenDead dead;
    public PLayerController player;
    public bool right;
    public bool check;
    public float rotation = 40f;
    void Start()
    {
        right = true;
        rg = GetComponent<Rigidbody2D>();

    }


    void Update()
    {
        if (player.meta == true)
        {
            return;
        }
        Stability();
        MoveElementRight();
    }


    private void MoveElementRight()
    {
        if (right && check)
        {
            rg.AddForce(Vector2.right * Speed * Time.deltaTime,ForceMode2D.Impulse);
        }
                                                                      
    }

    public void Stability()
    {
        if (rg.rotation >= rotation && transform.position.y > 3f)
        {
            rg.MoveRotation(0);
        }else if (rg.rotation <= -rotation && transform.position.y > 3f)
        {
            rg.MoveRotation(0);
        }
        if (transform.rotation.z > 100 || transform.rotation.z > -100)
        {
            rg.MoveRotation(0);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("gool"))
        {
            right = false;
            dead.dead();
            dead.gameOver = true;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("mapping"))
        {
            check = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("mapping"))
        {
            check = false;
        }
    }
}

