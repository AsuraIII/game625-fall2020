using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffect : MonoBehaviour
{

    public void PlayAudioWalk()
    {
        SoundManager._instance.audio_Walk.Play();
    }

    public void PlayAudioAttack()
    {
        SoundManager._instance.audio_Attack.Play();
    }
}
