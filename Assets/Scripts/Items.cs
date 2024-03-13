using UnityEngine;

public enum ItemType
{
    Weapon,
    Armor,
    UncleanScroll
}

[CreateAssetMenu(fileName = "Item", menuName = "Items/Item")]
public class Items : ScriptableObject
{
    public string itemName;
    public ItemType itemType;
    [TextArea]
    public string itemDescription;
    public int value;
    public int dice, faces;
}
