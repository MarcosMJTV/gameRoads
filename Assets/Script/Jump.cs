using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    private void Start()
    {
        if (PlayerPrefs.GetInt("boolMute") == 1)
        {
            GetComponent<AudioSource>().pitch = 0;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
       
        if (collision.collider.CompareTag("Player"))
        {
            GetComponent<AudioSource>().Play();
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up*50,ForceMode2D.Impulse);
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.right, ForceMode2D.Impulse);
        }
        if (collision.collider.CompareTag("Enemy"))
        {
            GetComponent<AudioSource>().Play();
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 20, ForceMode2D.Impulse);
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.right, ForceMode2D.Impulse);
        }
    }
}
