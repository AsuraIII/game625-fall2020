using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager _instance;

    public AudioSource audio_Walk;
    public AudioSource audio_Attack;

    

    private void Awake()
    {
        _instance = this;
    }

    public void PlayAudioWalk()
    {
       
    }
}
