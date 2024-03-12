using UnityEngine;

[CreateAssetMenu(fileName = "NamelessScriptures", menuName = "NamelessScriptures")]
public class NamelessScriptures : ScriptableObject
{
    public Scripture[] scriptures;
}

[System.Serializable]
public class Scripture
{
    public string title;
    public Psalm[] psalms;
}

[System.Serializable]
public class Psalm
{
    [TextAreaAttribute]
    public string description;
}