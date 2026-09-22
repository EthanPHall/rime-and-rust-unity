using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ResourceUI : MonoBehaviour
{
    [SerializeField] private ResourceManager resourceManager;
    [SerializeField] private TextMeshProUGUI resourcesTextField;

    //TODO: Don't update every frame, update on events or something
    private void Update()
    {
        resourcesTextField.text = string.Empty;

        foreach(Resource resource in resourceManager.Resources)
        {
            resourcesTextField.text += $"{resource.Name}: {resource.Amount}\n\n";
        }
    }
}
