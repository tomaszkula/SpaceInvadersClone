using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "event_NewEvent", menuName = "Space Invaders/Event System/Event")]
public class SI_Event : ScriptableObject
{
    private List<SI_EventListener> eventListeners = new List<SI_EventListener>();

    public void Register(SI_EventListener _eventListener)
    {
        eventListeners.Add(_eventListener);
    }

    public void UnRegister(SI_EventListener _eventListener)
    {
        eventListeners.Remove(_eventListener);
    }

    public void Invoke()
    {
        for (int i = 0; i < eventListeners.Count; i++)
        {
            eventListeners[i].Invoke(this);
        }
    }
}
