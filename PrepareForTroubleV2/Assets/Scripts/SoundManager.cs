using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource encounter;
    public AudioSource preparation;
    public AudioSource battle;

    public void Start()
    {
        preparation.Play();
    }
}
