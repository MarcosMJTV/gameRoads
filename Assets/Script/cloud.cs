using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cloud : MonoBehaviour
{
    private Rigidbody2D rg;
    float timer;
    void Start()
    {
        rg = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        rg.AddForce(Vector2.left*0.00003f*Time.deltaTime,ForceMode2D.Impulse);
        timer += Time.deltaTime;
        if (timer > 30f)
        {
            Destroy(gameObject);
            timer = 0;
        }
    }
}
