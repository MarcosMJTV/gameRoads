using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioMananger : MonoBehaviour
{
    public AudioClip[] listAudio;
    public AudioSource controlaudio;

    private void Awake()
    {
        controlaudio = GetComponent<AudioSource>();
    }

    public void SelectorAudio(int index, float volumen)
    {
        controlaudio.volume = volumen;
        controlaudio.clip = listAudio[index];
            controlaudio.Play();        
    }

    
}
