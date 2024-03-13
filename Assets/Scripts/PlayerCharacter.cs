using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : ScriptableObject
{
    public string charName;
    public CharClass charClass;
    public int hp, omens, agility, presence, strength, toughness, silver;
    public Items[] weapons, armor;
}
