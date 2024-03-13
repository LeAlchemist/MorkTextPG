using UnityEngine;
using UnityEditor;

public enum CharClass
    {FangedDeserter,
    GutterbornScum,
    EsotericHermit,
    WretchedRoyalty,
    HereticalPriest,
    OccultHerbmaster};

[ExecuteAlways]
public class PlayerCharacterGenerator : MonoBehaviour
{
    public string charName;
    NameList nameList;
    public CharClass charClass;
    public int hp, omens, agility, presence, strength, toughness, silver;
    public Items[] weapons, armor;

    void Update()
    {
        nameList = AssetDatabase.LoadAssetAtPath<NameList>("Assets/ScriptableObjects/Name List.asset");
    }

    [ContextMenu("Generate Character")]
    public void GenChar()
    {
        GenName();
        GenOmn();
        GenAgi();
        GenPre();
        GenStr();
        GenTgh();
        GenHP();
        GenSilver();

        PlayerCharacter asset = ScriptableObject.CreateInstance<PlayerCharacter>();
        string name = UnityEditor.AssetDatabase.GenerateUniqueAssetPath("Assets/ScriptableObjects/PlayerCharacters/" + charName + ".asset");
        asset.name = charName;
        asset.charName = charName;
        asset.charClass = charClass;
        asset.hp = hp;
        asset.omens = omens;
        asset.agility = agility;
        asset.presence = presence;
        asset.strength = strength;
        asset.toughness = toughness;
        asset.silver = silver;
        AssetDatabase.CreateAsset(asset, name);

        AssetDatabase.SaveAssets();
        EditorUtility.FocusProjectWindow();
    }

    public void GenName()
    {
        charName = null; 

        this.GetComponent<DiceRoll>().Dice(3);
        int value = this.GetComponent<DiceRoll>().diceValue;

        for (int i = 1; i <= value; ++i){
                    this.GetComponent<DiceRoll>().Dice(6);
                    int val1 = this.GetComponent<DiceRoll>().diceValue;
                    this.GetComponent<DiceRoll>().Dice(8);
                    int val2 = this.GetComponent<DiceRoll>().diceValue;
                    charName += nameList.names[val1-1].name[val2-1] + " ";
                    }
    }

    public void GenOmn()
    {
        omens = 0;

        switch (charClass)
        {
            default:
                this.GetComponent<DiceRoll>().Dice(2);
                omens = this.GetComponent<DiceRoll>().diceValue;
            break;
            case CharClass.EsotericHermit or CharClass.HereticalPriest:
                this.GetComponent<DiceRoll>().Dice(4);
                omens = this.GetComponent<DiceRoll>().diceValue;
            break;
        }
    }

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
            case CharClass.EsotericHermit or CharClass.HereticalPriest:
                for (int i = 1; i <= 3; ++i){
                    this.GetComponent<DiceRoll>().Dice(6);
                    presence += this.GetComponent<DiceRoll>().diceValue;}

                    presence += 2;
            break;
        }

        StatMod(presence, out presence);
    }

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
            case CharClass.GutterbornScum or CharClass.EsotericHermit or CharClass.HereticalPriest or CharClass.OccultHerbmaster:
                for (int i = 1; i <= 3; ++i){
                    this.GetComponent<DiceRoll>().Dice(6);
                    strength += this.GetComponent<DiceRoll>().diceValue;}

                    strength -= 2;
            break;
        }

        StatMod(strength, out strength);
    }

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
            case CharClass.OccultHerbmaster:
                for (int i = 1; i <= 3; ++i){
                    this.GetComponent<DiceRoll>().Dice(6);
                    toughness += this.GetComponent<DiceRoll>().diceValue;}

                    toughness += 2;
            break;
        }

        StatMod(toughness, out toughness);
    }

    public void GenHP()
    {
        hp = 0;

        switch(charClass)
        {
            default:
                this.GetComponent<DiceRoll>().Dice(8);
                hp += this.GetComponent<DiceRoll>().diceValue + toughness; 
            break;
            case CharClass.FangedDeserter:
                this.GetComponent<DiceRoll>().Dice(10);
                hp += this.GetComponent<DiceRoll>().diceValue + toughness; 
            break;
            case CharClass.GutterbornScum or CharClass.WretchedRoyalty or CharClass.OccultHerbmaster:
                this.GetComponent<DiceRoll>().Dice(6);
                hp += this.GetComponent<DiceRoll>().diceValue + toughness; 
            break;
            case CharClass.EsotericHermit:
                this.GetComponent<DiceRoll>().Dice(4);
                hp += this.GetComponent<DiceRoll>().diceValue + toughness; 
            break;
        }

        if (hp <= 0)
        {
            hp = 1;
        }
    }

    public void GenSilver()
    {
        silver = 0;

        switch(charClass)
        {
            default:
                for (int i = 1; i <= 2; ++i){
                    this.GetComponent<DiceRoll>().Dice(6);
                    silver += this.GetComponent<DiceRoll>().diceValue;}

                    silver = silver * 10;
            break;
            case CharClass.GutterbornScum or CharClass.EsotericHermit:
                this.GetComponent<DiceRoll>().Dice(6);
                silver += this.GetComponent<DiceRoll>().diceValue* 10;
            break;
            case CharClass.WretchedRoyalty:
                for (int i = 1; i <= 4; ++i){
                    this.GetComponent<DiceRoll>().Dice(6);
                    silver += this.GetComponent<DiceRoll>().diceValue;}

                    silver = silver * 10;
            break;
            case CharClass.HereticalPriest:
                for (int i = 1; i <= 3; ++i){
                    this.GetComponent<DiceRoll>().Dice(6);
                    silver += this.GetComponent<DiceRoll>().diceValue;}

                    silver = silver * 10;
            break;
        }
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