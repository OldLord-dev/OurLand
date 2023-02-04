using System;
using UnityEngine;
using UnityEngine.Events;

public class EventListener : MonoBehaviour
{
    public CustomEvent gameEvent;
    public UnityEvent response;

    private void OnEnable()
    {
        gameEvent.Register(this);
    }

    private void OnDisable()
    {
        gameEvent.Unregister(this);
    }

    public void OnEventOccurs()
    {
        response.Invoke();
    }
}
