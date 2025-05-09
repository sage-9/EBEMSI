using UnityEngine;
using System.Collections;

public class DialogueManager : MonoBehaviour
{
    public GameObject dialoguePanel;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartCoroutine(StartDialogueAfterDelay());
        }
    }

    IEnumerator StartDialogueAfterDelay()
    {
        yield return new WaitForSeconds(.5f);
        dialoguePanel.SetActive(true);
    }

}
