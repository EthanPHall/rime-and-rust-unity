using TMPro;
using UnityEngine;

public class WorkerDisplay : MonoBehaviour
{
    public SurvivorManager survivorManager;
    public TextMeshProUGUI text;

    private void Update()
    {
        text.text = $"{survivorManager.FreeWorkers}/{survivorManager.workersMax}";
    }
}
