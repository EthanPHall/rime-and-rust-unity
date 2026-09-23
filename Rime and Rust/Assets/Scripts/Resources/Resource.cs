using System;
using UnityEngine;

[Serializable]
//[CreateAssetMenu(fileName = "Resource", menuName = "Scriptable Objects/Resource")]
public class Resource
{
    [SerializeField] ResourceData _data;

    public Resource(string name, int amount)
    {
        _data = new ResourceData();

        Name = name;
        Amount = amount;
    }

    public Resource(ResourceData data)
    {
        _data = new ResourceData();

        Name = data.resourceName;
        Amount = data.amount;
    }

    public string Name { get => _data.resourceName; private set => _data.resourceName = value; }
    public int Amount { get => _data.amount; private set => _data.amount = value; }

    public void ModifyAmount(int mod)
    {
        _data.amount += mod;
    }

    public Resource Copy()
    {
        return new Resource(_data.resourceName, _data.amount);
    }

    public bool Equals(Resource other)
    {
        if (other == null) return false;

        //Do they share a name? Amount isn't relevant for equality.
        return other._data.resourceName == _data.resourceName;
    }

    public override bool Equals(object obj)
    {
        return Equals(obj as Resource);
    }
}