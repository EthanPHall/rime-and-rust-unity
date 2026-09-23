using System;
using System.Collections.Generic;
using UnityEngine;

public class EventBus : MonoBehaviour
{
    public static EventBus Instance { get; private set; }

    private List<RimeRustEvent> bus = new List<RimeRustEvent>();
    private Stack<RimeRustEvent> toRemoveFromBus = new Stack<RimeRustEvent>();

    private Dictionary<int, List<Action>> listeners = new Dictionary<int, List<Action>>();

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Debug.Assert
                (
                    false, 
                    "Multiple Eventbus classes in scene; EventBus is a Singleton." +
                    " Don't try to instantiate more than one of them."
                );

            Destroy(gameObject);
            return;
        }

        listeners.Clear();

        foreach (int eventType in Enum.GetValues(typeof(EventType)))
        {
            listeners.Add(eventType, new List<Action>());
        }
    }

    private void Start()
    {
    }

    public bool WasEventOfTypePublished(EventType eventType)
    {
        RimeRustEvent eventOfType = bus.Find((e) => { return e.Type == eventType; });
        return eventOfType != null;
    }

    private void LateUpdate()
    {
        //TODO: Evaluate whether or not the bus is actually necessary
        toRemoveFromBus.Clear();
        
        foreach(RimeRustEvent e in bus)
        {
            if (e.EvaluateEvent())
            {
                toRemoveFromBus.Push(e);
            }        
        }

        while(toRemoveFromBus.Count > 0)
        {
            RimeRustEvent toRemove = toRemoveFromBus.Pop();
            bus.Remove(toRemove);
        }
    }

    public void PublishEvent(RimeRustEvent e)
    {
        bus.Add(e);

        foreach(Action action in listeners[(int)e.Type])
        {
            action?.Invoke();
        }
    }

    public void AddListener(EventType eventTypeToListenTo, Action callback)
    {
        listeners[(int)eventTypeToListenTo].Add(callback);
    }

    public void RemoveListener(EventType eventTypeListenedTo, Action callback)
    {
        listeners[(int)eventTypeListenedTo].Remove(callback);
    }
}
