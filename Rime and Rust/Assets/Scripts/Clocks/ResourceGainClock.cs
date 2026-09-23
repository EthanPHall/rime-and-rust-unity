using UnityEngine;

public class ResourceGainClock : MonoBehaviour
{
    public float timeUntilTrigger = 5f;
    public float timer;
    public RimeRustEvent toPublishOnTrigger;

    private EventBus eventBusInstance;

    private void Start()
    {
        timer = timeUntilTrigger;

        eventBusInstance = EventBus.Instance;
    }

    private void Update()
    {
        timer -= Time.deltaTime;

        if( timer < 0)
        {
            eventBusInstance.PublishEvent(toPublishOnTrigger);
            timer = timeUntilTrigger;
        }
    }
}
