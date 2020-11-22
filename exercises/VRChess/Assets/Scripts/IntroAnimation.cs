using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroAnimation : MonoBehaviour
{
    public Animator cameraAnimator;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   
        if (BoardManager.PlayerColorType == ColorType.White)
        {
            cameraAnimator.SetTrigger("WhitePlay");
        }
        if (BoardManager.PlayerColorType == ColorType.Black)
        {
            cameraAnimator.SetTrigger("BlackPlay");
        }
    }
}
