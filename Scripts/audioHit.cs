using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioHit : MonoBehaviour
{
    [SerializeField]
    private AudioSource audio;
    [SerializeField]
    private AudioClip clip;

    public void play()
    {
        audio.clip = clip;
        audio.Play();
    }
}
