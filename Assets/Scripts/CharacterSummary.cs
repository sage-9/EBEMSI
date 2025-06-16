using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "CharacterSummary", menuName = "Scriptable Objects/CharacterSummary")]
public class CharacterSummary : ScriptableObject
{
    public Sprite characterIcon;
    public string characterName;
    public string characterBackGround;
    public string[] characterAbilities;
    public string characterSignatureTool;

    
}
