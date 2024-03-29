using UnityEditor;
using UnityEngine;

[ExecuteAlways]
public class RandomScripture : MonoBehaviour
{
    NamelessScriptures scripture;
    public int book;
    public string bookText;
    public int verse;
    public string verseText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        scripture = AssetDatabase.LoadAssetAtPath<NamelessScriptures>("Assets/ScriptableObjects/NamelessScriptures.asset");

        bookText = scripture.scriptures[book - 1].title;
        verseText = scripture.scriptures[book - 1].psalms[verse - 1].description;
    }

    [ContextMenu("Random")]
    public void Random()
    {
        this.GetComponent<DiceRoll>().Dice(6);
        book = this.GetComponent<DiceRoll>().diceValue;
        this.GetComponent<DiceRoll>().Dice(6);
        verse = this.GetComponent<DiceRoll>().diceValue;

        //this is a test formatting of how itd look in text
        //Debug.Log("You hear the words of " + bookText + ":" + book.ToString() + " being yelled off in the distance. " + "\"" + verseText + "\"");
    }
}
