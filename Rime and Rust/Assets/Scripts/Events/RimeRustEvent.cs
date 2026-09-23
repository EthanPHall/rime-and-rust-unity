using UnityEngine;

public enum EventType 
{
    TriggerResourceGain
}

[CreateAssetMenu(fileName = "RimeRustEvent", menuName = "Scriptable Objects/RimeRustEvent")]
public class RimeRustEvent : ScriptableObject
{
    [SerializeField] private EventType type;
    [SerializeField] private int iterations;
    [SerializeField] private bool removeAfterOneCycle;

    public EventType Type { get => type; }
    public bool RemoveAfterOneCycle { get => removeAfterOneCycle; }
    public int Iterations { get => iterations; }

    /// <summary>
    /// 
    /// </summary>
    /// <returns>Whether or not the event is completed.</returns>
    public bool EvaluateEvent()
    {
        bool result = false;

        if (RemoveAfterOneCycle && iterations >= 1)
        {
            result = true;
        }

        ++iterations;

        return result;
    }
}
