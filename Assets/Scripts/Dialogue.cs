using UnityEngine;
using System.Collections;
using TMPro;


public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    [SerializeField]
    private DialogueContainer dialogueContainer;
    
    public float textSpeed;
    private int _index;
    string _currentSentence;
    [SerializeField]
    float delay=1f;

    private Animator _dialogueAnimator;
    
    
    void Start()
    {
        _dialogueAnimator = GetComponent<Animator>();
        textComponent.text = string.Empty;
        _index = 0;
        ShowDialoguePanel();
    }
    
    // --------------show panel --------------
    
    void ShowDialoguePanel()
    {
        _dialogueAnimator.SetTrigger("Enter");
        while(delay<=0) delay-=Time.deltaTime;
        StartDialogue();
    }
    
    // --------------start dialogue--------------
    void StartDialogue()
    {
        DialogueSequence(_index);
    }
    
    // --------------keep picking the next item in the dialogue list--------------
    
    void DialogueSequence(int index)
    {
        //get text in current list index
        _currentSentence=dialogueContainer.sentences[index];
        //type line
        StartCoroutine(TypeLine(_currentSentence));
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
        _index++;
        if (_index >= dialogueContainer.sentences.Length) HidePanel();
        else DialogueSequence(_index);
        textComponent.text = string.Empty;
    }
    
    //--------------hide panel--------------
    
    void HidePanel()
            {
                _dialogueAnimator.SetTrigger("Exit");
            }
}
