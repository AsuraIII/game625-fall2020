using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager _instance;

    public UI_DialogueWindow ui_DialogueWindow;

    public GameObject e_indicator;

    private NPC curNpc;

    //private Queue<string> sentences;

    private void Awake()
    {
        _instance = this;
    }

    private void Start()
    {
        //sentences = new Queue<string>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && curNpc)
        {
            ShowDialogueWindow(curNpc);
            HideIndicator(true);
        }
    }

    public void ShowDialogueWindow(NPC npc)
    {
        ui_DialogueWindow.ActiveWindow();
        ui_DialogueWindow.SetCharacterName(npc.name);
        StartDialogue(npc.dialogue);
    }

    public void HideDialogueWindow()
    {
        ui_DialogueWindow.DeActiveWindow();
    }

    public void ShowIndicator(NPC npc)
    {
        curNpc = npc;
        var sizeNPC = npc.transform.GetComponent<Renderer>().bounds.size;
        var sizeIndicator = e_indicator.GetComponent<Renderer>().bounds.size;
        Vector2 spawnPoint = new Vector2(npc.transform.position.x, npc.transform.position.y + sizeNPC.y / 2 + sizeIndicator.y / 2);
        e_indicator.transform.position = spawnPoint;
        e_indicator.gameObject.SetActive(true);
    }

    public void HideIndicator(bool isOnCurNpc = false)
    {
        e_indicator.gameObject.SetActive(false);
        if (!isOnCurNpc)
        {
            curNpc = null;
        }
    }

    public void StartDialogue(Dialogue dialogue)
    {
        //sentences.Clear();
        //foreach (string sentence in dialogue.sentences)
        //{
        //    sentences.Enqueue(sentence);
        //}
        DisplayNextDialogueSentence();
    }

    public void DisplayNextDialogueSentence()
    {
        if (curNpc)
        {
            if (curNpc.sentences.Count == 0)
            {
                EndDialogue();
                return;
            }
            string text = curNpc.sentences.Dequeue();
            ui_DialogueWindow.SetDialogueContent(text);
        }
    }

    private void EndDialogue()
    {
        Debug.Log("End of conversation");
        HideDialogueWindow();
    }
}
