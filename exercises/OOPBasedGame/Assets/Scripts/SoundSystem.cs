using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundSystem : MonoBehaviour
{
    public AudioClip collectSound;
    public AudioSource audioSource;
    private void Start()
    {
        Cube.OnCubeCollectedSound += PlayCollectSound;
    }

    public void PlayCollectSound()
    {
        audioSource.PlayOneShot(collectSound);
    }

}
