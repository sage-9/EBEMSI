using UnityEngine;
using System.Collections;
using TMPro;
using UnityEngine.Serialization;


public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    [SerializeField]
    private DialogueContainer dialogueContainer;
    [SerializeField]
    private GameObject characterSelector;
    
    public float textSpeed;
    private int index;
    string currentSentence;
    [SerializeField]
    float delay=1f;

    private bool canMoveOn;

    private Animator dialogueAnimator;
    
    
    void Start()
    {
        dialogueAnimator = GetComponent<Animator>();
        textComponent.text = string.Empty;
        index = 0;
        ShowDialoguePanel();
    }
    
    // --------------show panel --------------
    
    void ShowDialoguePanel()
    {
        dialogueAnimator.SetTrigger("Enter");
        while(delay<=0) delay-=Time.deltaTime;
        StartDialogue();
    }
    
    // --------------start dialogue--------------
    void StartDialogue()
    {
        DialogueSequence(index);
    }
    
    // --------------keep picking the next item in the dialogue list--------------
    
    void DialogueSequence(int num)
    {
        //get text in current list index
        currentSentence=dialogueContainer.sentences[num];
        //type line
        StartCoroutine(TypeLine(currentSentence));
    } 
    
    IEnumerator TypeLine(string sentence,float initialDelay=0.2f)
    {
         yield return new WaitForSeconds(initialDelay);
         foreach (char letter in sentence)
         {
             textComponent.text += letter;
             yield return new WaitForSeconds(textSpeed);
         }
    }
    
    public void NextInput()
    {
        StopAllCoroutines();
        index++;
        if (index >= dialogueContainer.sentences.Length) HidePanel();
        else DialogueSequence(index);
        textComponent.text = string.Empty;
    }
    
    //--------------hide panel--------------
    
    void HidePanel()
    {
        dialogueAnimator.SetTrigger("Exit");
        characterSelector.SetActive(true);
    }
}
