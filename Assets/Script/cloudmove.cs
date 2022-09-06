using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cloudmove : MonoBehaviour
{
    public List<GameObject> listPrebas = new List<GameObject>();
    public GameObject cloudcontainer;
    public Camera camara;
    public GameObject refe;
    private Vector3 vectoRefe;
    private int randow;
    float timer;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 1.5f)
        {
            int ran = Random.Range(4,15);
            int ran2 = Random.Range(7, 15);
            vectoRefe = new Vector3(camara.transform.localPosition.x+20+ran,1.3f+ran2, refe.transform.localPosition.z-3);
            randow = Random.Range(0, 3);
            spawnCloud(randow,vectoRefe);
            timer = 0;
        }
    }

    private void spawnCloud(int i , Vector3 VectorRefe)
    {
        GameObject cloud =  Instantiate(listPrebas[i],VectorRefe,Quaternion.identity);
        cloud.transform.parent = cloudcontainer.transform;
    }
}
