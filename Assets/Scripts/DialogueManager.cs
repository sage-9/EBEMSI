using UnityEngine;
using System.Collections;

public class DialogueManager : MonoBehaviour
{
    public GameObject dialoguePanel;
    // Update is called once per frame

    void Awake()
    {
        dialoguePanel.SetActive(false);
    }
    public void StartDialoguePanel()
    {
        dialoguePanel.SetActive(true);
    }
}
