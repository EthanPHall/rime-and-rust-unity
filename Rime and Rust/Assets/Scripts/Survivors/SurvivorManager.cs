using System.Collections.Generic;
using UnityEngine;

public class SurvivorManager : MonoBehaviour
{
    public int workersMax = 50;
    public int freeWorkers;
    public int occupiedWorkers;
    public int totalWorkers;

    public List<SurvivorSink> survivorSinks = new();

    public int FreeWorkers
    {
        get
        {
            int result = totalWorkers;
            foreach(SurvivorSink sink in survivorSinks)
            {
                result -= sink.GetNumberOfAttachedSurvivors();
            }

            return result;
        }
    }

    public void AddNewWorkers(int howMany)
    {
        totalWorkers += howMany;
        totalWorkers = Mathf.Min(totalWorkers, workersMax);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="structure">The structure to add workers to</param>
    /// <param name="amount">The amount of workers requested</param>
    public void RequestWorkers(Structure structure, int amount)
    {
        if (structure == null || amount <= 0 || FreeWorkers <= 0) return;

        int existingSinkIndex = survivorSinks.IndexOf(structure);
        if (existingSinkIndex != -1)
        {
            survivorSinks[existingSinkIndex].TryToAttachSurvivors(amount);
        }
        else
        {
            survivorSinks.Add(structure);
            structure.TryToAttachSurvivors(amount);
        }
    }
}
