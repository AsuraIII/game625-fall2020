using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager _instance;

    public Text scoreNum;

    public Text timeCount;

    public Text winMsg;

    public Text loseMsg;

    private void Awake()
    {
        _instance = this;
    }
    private void Start()
    {
        scoreNum.text = "0";
    }

    public void SetScoreNum(int num)
    {
        scoreNum.text = num.ToString();
    }

    public void SetTime(float time)
    {
        timeCount.text = time.ToString("f2");
    }

    public void ShowWinMsg() {
        winMsg.enabled = true;
    }

    public void ShowLoseMsg()
    {
        loseMsg.enabled = true;
    }

}
