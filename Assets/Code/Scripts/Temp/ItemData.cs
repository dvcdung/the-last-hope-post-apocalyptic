using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Items/Item")]
public class ItemData : ScriptableObject
{
    public string itemName;
    public Sprite icon;
    public int maxStack;
    public ItemType itemType;
}

public enum ItemType
{
    Health,
    Energy,
    Oxygen
}
