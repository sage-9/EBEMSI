using UnityEngine;
using System.Collections;
using TMPro;
using System.Collections.Generic;

public class Dialogue : MonoBehaviour
{
    public GameObject dialoguePanel;
    public TextMeshProUGUI textComponent;
    public string[] sentences;
    public float textSpeed;
    private int index;
    private Animator dialogueAnimator;
    private bool startDialogue = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        dialogueAnimator = GetComponent<Animator>();
        textComponent.text = string.Empty;
        StartDialogue();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if (startDialogue)
            {
                dialogueAnimator.SetTrigger("Enter");
                startDialogue = false;
            }
            else
            {
                NextSentence();
            }
        }
    }

    void StartDialogue()
    {
        index = 0;

        StartCoroutine(ShowDialogueSequence());
        
    }

    void NextSentence()
    {
        if (index <= sentences.Length - 1)
        {
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            textComponent.text = string.Empty;
            dialogueAnimator.SetTrigger("Exit");
            
        }
    }

    IEnumerator ShowDialogueSequence()
    {
        yield return new WaitForSeconds(2f);
        yield return StartCoroutine(TypeLine());
    }
    IEnumerator TypeLine()
    {
        foreach(char letter in sentences[index].ToCharArray())
        {
            textComponent.text += letter;
            yield return new WaitForSeconds(textSpeed);
        }
        index++;
    }
}
