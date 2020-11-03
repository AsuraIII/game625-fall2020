using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Dialogue : MonoBehaviour
{
    public static UI_Dialogue _instance;

    public Text dialogue;


    private void Awake()
    {
        _instance = this;
    }

    private void Start()
    {
        Invoke("ClearBoard", 50f);
    }

    public void SetDialogue(string dialogue)
    {
        this.dialogue.text += dialogue + "\n";
    }

    public void ClearBoard()
    {
        this.dialogue.text = "";
        Invoke("ClearBoard", 50f);
    }
}
