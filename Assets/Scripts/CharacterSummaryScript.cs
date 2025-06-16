using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSummaryScript : MonoBehaviour
{
    
    public CharacterSummary[] characterSummary;
    public Image characterSprite;
    public TextMeshProUGUI characterName;
    public TextMeshProUGUI characterBackGround;
    public TextMeshProUGUI characterAbilities;
    public TextMeshProUGUI characterSignatureTool;
    int _index = 0;
    public Animator animator;

    void Start()
    {
        animator.SetTrigger("Enter");
        DisplayCurrentCharacter(characterSummary[_index]);
    }

    void EmptyTextBox()
    {
        characterName.text =string.Empty;
        characterBackGround.text =string.Empty;
        characterAbilities.text =string.Empty;
        characterSignatureTool.text =string.Empty;
    }
    void DisplayCurrentCharacter(CharacterSummary summary)
    {
        EmptyTextBox();
        characterSprite.sprite = summary.characterIcon;
        characterName.text = summary.characterName;
        characterBackGround.text = summary.characterBackGround;
        foreach (string ability in summary.characterAbilities)
        {
            characterAbilities.text += $"- {ability}\n";
        }
        characterSignatureTool.text = summary.characterSignatureTool;
    }

    public void NextCharacter()
    {
        _index++;
        if(_index >=characterSummary.Length) _index = characterSummary.Length - 1;
        animator.SetTrigger("HideText");
        DisplayCurrentCharacter(characterSummary[_index]);
        animator.SetTrigger("ShowText");
    }

    public void PreviousCharacter()
    {
        _index--;
        if (_index < 0) _index = 0;
        animator.SetTrigger("HideText");
        DisplayCurrentCharacter(characterSummary[_index]);
        animator.SetTrigger("ShowText");
    }
}
