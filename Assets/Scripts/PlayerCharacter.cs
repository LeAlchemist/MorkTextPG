using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEditor.Rendering.LookDev;
using UnityEngine;

public enum CharClass
    {FangedDeserter,
    GutterbornScum,
    EsotericHermit,
    WretchedRoyalty,
    HereticalPriest,
    OccultHerbmaster};

public class PlayerCharacter : MonoBehaviour
{
    public string charName;
    public CharClass charClass;
    public int agility, presence, strength, toughness;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    [ContextMenu("Generate Character")]
    public void GenChar()
    {
        GenAgi();
        GenPre();
        GenStr();
        GenTgh();
    }

    [ContextMenu("Generate Agility")]
    public void GenAgi()
    {
        agility = 0;

        switch (charClass)
        {
            default:
                for (int i = 1; i <= 3; ++i){
                    this.GetComponent<DiceRoll>().Dice(6);
                    agility += this.GetComponent<DiceRoll>().diceValue;}
            break;
            case CharClass.FangedDeserter:
                for (int i = 1; i <= 3; ++i){
                    this.GetComponent<DiceRoll>().Dice(6);
                    agility += this.GetComponent<DiceRoll>().diceValue;}

                    agility -= 1;
            break;
        }

        StatMod(agility, out agility);
    }

    [ContextMenu("Generate Presence")]
    public void GenPre()
    {
        presence = 0;

        switch (charClass)
        {
            default:
                for (int i = 1; i <= 3; ++i){
                    this.GetComponent<DiceRoll>().Dice(6);
                    presence += this.GetComponent<DiceRoll>().diceValue;}
            break;
            case CharClass.FangedDeserter:
                for (int i = 1; i <= 3; ++i){
                    this.GetComponent<DiceRoll>().Dice(6);
                    presence += this.GetComponent<DiceRoll>().diceValue;}

                    presence -= 1;
            break;
        }

        StatMod(presence, out presence);
    }

    [ContextMenu("Generate Strength")]
    public void GenStr()
    {
        strength = 0;

        switch (charClass)
        {
            default:
                for (int i = 1; i <= 3; ++i){
                    this.GetComponent<DiceRoll>().Dice(6);
                    strength += this.GetComponent<DiceRoll>().diceValue;}
            break;
            case CharClass.FangedDeserter:
                for (int i = 1; i <= 3; ++i){
                    this.GetComponent<DiceRoll>().Dice(6);
                    strength += this.GetComponent<DiceRoll>().diceValue;}

                    strength += 2;
            break;
        }

        StatMod(strength, out strength);
    }

    [ContextMenu("Generate Toughness")]
    public void GenTgh()
    {
        toughness = 0;

        switch (charClass)
        {
            default:
                for (int i = 1; i <= 3; ++i){
                    this.GetComponent<DiceRoll>().Dice(6);
                    toughness += this.GetComponent<DiceRoll>().diceValue;}
            break;
        }

        StatMod(toughness, out toughness);
    }

    public void StatMod(int value, out int _value)
    {
        switch(value)
        {
            case >=1 and <=4:
                value = -3;
            break;
            case >=5 and <=6:
                value = -2;
            break;
            case >=7 and <=8:
                value = -1;
            break;
            case >=9 and <=12:
                value = 0;
            break;
            case >=13 and <=14:
                value = 1;
            break;
            case >=15 and <=16:
                value = 2;
            break;
            case >17:
                value = 3;
            break;
        }
        
        _value = value;
    }
}