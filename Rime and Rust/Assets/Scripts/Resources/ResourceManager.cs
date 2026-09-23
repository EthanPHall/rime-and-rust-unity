using System;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    [SerializeField] private List<Resource> resources = new();

    public List<Resource> Resources { get => resources; }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            AddResource(new Resource("Lashing", 1));
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            AddResource(new Resource("Peanuts", 1));
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            AddResource(new Resource("Oranges", 1));
        }
        if (Input.GetKeyDown(KeyCode.M))
        {
            AddResource(new Resource("Money", 5));
        }
        if (Input.GetKeyDown(KeyCode.RightShift))
        {
            Debug.Log("Resources:");
            foreach(Resource r in resources)
            {
                Debug.Log($"{r.Name}: {r.Amount}");
            }
        }
    }

    public void AddResource(Resource resource)
    {
        //Does the resource already exist?
        int indexOfExistingResource = resources.IndexOf(resource);

        if(indexOfExistingResource == -1)
        {
            //No it does not exist, so add a new resource to the list
            resources.Add(resource);
        }
        else
        {
            //Yes it does exist, so just add the argument's amount to the existing entry
            resources[indexOfExistingResource].ModifyAmount(resource.Amount);
        }
    }

    public void AddDebugResources()
    {
        AddResource(new Resource("Lager", 1));
        AddResource(new Resource("Peanuts", 1));
        AddResource(new Resource("Oranges", 1));
        AddResource(new Resource("Money", 5));
    }
}


