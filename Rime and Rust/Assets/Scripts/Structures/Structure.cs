using UnityEngine;

[CreateAssetMenu(fileName = "Structure", menuName = "Scriptable Objects/Structure")]
public class Structure : ScriptableObject, SurvivorSink
{
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
