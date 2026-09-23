using System;
using UnityEngine;

[Serializable]
public struct ResourceData
{
    [SerializeField] public string resourceName;
    [SerializeField] public int amount;

    public ResourceData(string resourceName, int amount)
    {
        this.resourceName = resourceName;
        this.amount = amount;
    }
}
