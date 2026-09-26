using System;
using UnityEngine;

[Serializable]
public class Structure : SurvivorSink
{
    public string ID;
    public string Name;

    public string structureName;
    public ResourceData[] buildRecipe;
    public ResourceData[] produces;

    public int workers;

    public int GetNumberOfAttachedSurvivors()
    {
        return workers;
    }

    public int TryToAttachSurvivors(int amount)
    {
        workers += amount;
        return amount;
    }
}
