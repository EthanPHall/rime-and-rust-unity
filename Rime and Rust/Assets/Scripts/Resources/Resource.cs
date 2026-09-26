using System;
using UnityEngine;

[Serializable]
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

        Name = data.Name;
        Amount = data.amount;
    }

    public string Name { get => _data.Name; private set => _data.Name = value; }
    public int Amount { get => _data.amount; private set => _data.amount = value; }

    public void ModifyAmount(int mod)
    {
        _data.amount += mod;
    }

    public Resource Copy()
    {
        return new Resource(_data.Name, _data.amount);
    }

    public bool Equals(Resource other)
    {
        if (other == null) return false;

        //Do they share a name? Amount isn't relevant for equality.
        return other._data.Name == _data.Name;
    }

    public override bool Equals(object obj)
    {
        return Equals(obj as Resource);
    }
}