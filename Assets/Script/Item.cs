using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    private float speed = 1.5f;
    private float value = 0;
    private float yStart;
    private float yEnd;
    private  float radius = 1.5f;
    bool up = true;
    bool down = false;

    private void Start()
    {
        yStart = transform.position.y;
        yEnd = transform.position.y + radius * 2;
    }
    void Update()
    {
        if (up )
        {
            value += speed * Time.deltaTime;
            if (value > 1)
            {
                up = false;
                down = true;
                value = 1;
            }
        }else if (down)
        {
            value -= speed * Time.deltaTime;
            if (value < 0)
            {
                up = true;
                down = false;
                value = 0;
            }
        }
        float Ypos = EaseInOutQuad(yStart, yEnd, value);
        transform.position = new Vector3(transform.position.x, Ypos,transform.position.z);
    }
    public static float EaseInOutQuad(float start, float end, float value)
    {
        value /= .5f;
        end -= start;
        if (value < 1) return end * 0.5f * value * value * value + start;
        value -= 2;
        return end * 0.5f * (value * value * value + 2) + start;
    }

}
