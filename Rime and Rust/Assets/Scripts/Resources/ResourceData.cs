using System;
using UnityEngine;

[Serializable]
public struct ResourceData
{
    [SerializeField] public string ID;
    [SerializeField] public string Name;
    [SerializeField] public int amount;

    public ResourceData(string ID, string resourceName, int amount)
    {
        this.ID = ID;
        this.Name = resourceName;
        this.amount = amount;
    }
}
