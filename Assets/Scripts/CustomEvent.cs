using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;

[CreateAssetMenu(fileName = "New Event", menuName = "Game Event", order = 52)]
public class CustomEvent : ScriptableObject
{
    private List<EventListener> elisteners = new List<EventListener>();

    public void Register(EventListener listener)
    {
        elisteners.Add(listener);
    }

    public void Unregister(EventListener listener)
    {
        elisteners.Remove(listener);
    }

    public void Occurred()
    {
        for (int i = 0; i < elisteners.Count; i++)
        {
            elisteners[i].OnEventOccurs();
        }
    }
}
