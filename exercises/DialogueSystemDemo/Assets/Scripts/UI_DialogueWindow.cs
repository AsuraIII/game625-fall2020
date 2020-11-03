using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_DialogueWindow : MonoBehaviour
{
    public Text characterName;
    public Text dialogueContent;

    public void SetCharacterName(string name)
    {
        characterName.text = name;
    }

    public void SetDialogueContent(string content)
    {
        dialogueContent.text = content;
    }

    public void ActiveWindow()
    {
        this.gameObject.SetActive(true);
    }

    public void DeActiveWindow()
    {
        this.gameObject.SetActive(false);
    }
}
