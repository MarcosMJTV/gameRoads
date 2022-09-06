using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coint : MonoBehaviour
{
    public bool picked = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if(picked)
            {
                return;
            }
            picked = true;
            collision.gameObject.GetComponent<PLayerController>().pickCoin();
            Destroy(gameObject);
        }
    }
}
