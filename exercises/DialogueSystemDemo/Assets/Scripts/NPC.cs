using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public string npcName;

    public Dialogue dialogue;

    public Queue<string> sentences;

    private void Start()
    {
        sentences = new Queue<string>();
        foreach (string str in dialogue.sentences)
        {
            sentences.Enqueue(str);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            DialogueManager._instance.ShowIndicator(this);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            DialogueManager._instance.HideIndicator();
            DialogueManager._instance.HideDialogueWindow();
            
        }
    }
}
