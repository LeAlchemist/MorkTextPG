using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Name List", menuName = "Name List")]
public class NameList : ScriptableObject
{
    public Names[] names;
}

[System.Serializable]
public class Names
{
    public string[] name;
}