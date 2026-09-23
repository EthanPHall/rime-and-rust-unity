using System.Collections.Generic;
using UnityEngine;

public class StructureManager : MonoBehaviour
{
    public List<Structure> structures;
    public Structure debugStructure;
    public ResourceManager resourceManager;
    public SurvivorManager survivorManager;
    private bool hasInitialized = false;

    private void Start()
    {
        EventBus.Instance?.AddListener(EventType.TriggerResourceGain, DEBUG_TriggerResourceGainEvent);
    
        hasInitialized = true;
    }

    private void OnEnable()
    {
        if (hasInitialized)
        {
            Start();
        }
    }

    private void OnDisable()
    {
        EventBus.Instance.RemoveListener(EventType.TriggerResourceGain, DEBUG_TriggerResourceGainEvent);
    }
    private void OnDestroy()
    {
        EventBus.Instance.RemoveListener(EventType.TriggerResourceGain, DEBUG_TriggerResourceGainEvent);
    }

    public void DEBUG_TriggerResourceGainEvent()
    {
        Debug.Log("Resource Gain Event Triggered");
        foreach(Structure structure in structures)
        {
            foreach(ResourceData resourceData in structure.produces)
            {
                ResourceData adjustedResource = 
                    new ResourceData
                    (
                        resourceData.resourceName,
                        resourceData.amount * structure.workers
                    );

                resourceManager.AddResource(new Resource(adjustedResource));
            }
        }
    }

    /// <summary>
    /// Tries to build the requested structure using the provided resources. Subtracts
    /// from the provided resources if successful.
    /// </summary>
    /// <param name="toBuild">The structure to build</param>
    /// <param name="materials">Materials that can be drawn from to build the requested structure</param>
    /// <returns>Whether or not the structure was built.</returns>
    public bool BuildStructure(Structure toBuild, List<Resource> materials)
    {
        List<(int, int)> indicesAndCosts = new List<(int, int)>();

        foreach(ResourceData recipeRequirement in toBuild.buildRecipe)
        {
            int buildingBlockIndex = materials.IndexOf(new Resource(recipeRequirement));
            if (buildingBlockIndex != -1 && materials[buildingBlockIndex].Amount >= recipeRequirement.amount)
            {
                indicesAndCosts.Add((buildingBlockIndex, recipeRequirement.amount));
            }
            else
            {
                Debug.Log("Structure failed to build, not enough resources");

                //Couldn't build the structure, the recipe was unfulfilled.
                return false;
            }
        }

        //The recipe should be fulfilled so make the structure and remove resources.
        Structure newStructure = Instantiate(toBuild);
        structures.Add(newStructure);

        foreach((int,int) indexAndCost in indicesAndCosts)
        {
            materials[indexAndCost.Item1].ModifyAmount(-indexAndCost.Item2);
        }

        Debug.Log("Structure built successfully");
        survivorManager.AddNewWorkers(1);
        return true;
    }

    public void AddDebugStructure()
    {
        BuildStructure(debugStructure, resourceManager.Resources);
    }

    public void Debug_RequestWorkers()
    {
        if(structures.Count > 0)
        {
            survivorManager.RequestWorkers(structures[0], 1);
        }
    }
}
