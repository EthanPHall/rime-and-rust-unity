using System;
using UnityEngine;
using static UnityEditor.Progress;

[Serializable]
public class StructureResourcePair
{
    [SerializeField] string StructureID;
    [SerializeField] string ItemID;
    [SerializeField] int Amount;

    public StructureResourcePair()
    {
        StructureID = "";
        ItemID = "";
        Amount = 0;
    }

    public StructureResourcePair(string structureID, string itemID, int amount)
    {
        StructureID = structureID;
        ItemID = itemID;
        Amount = amount;
    }
}
