using System.Collections.Generic;
using UnityEngine;

public abstract class SI_EventWith1Param<T> : ScriptableObject
{
    private List<SI_EventWith1ParamListener<T>> eventListeners = new List<SI_EventWith1ParamListener<T>>();

    public void Register(SI_EventWith1ParamListener<T> _eventListener)
    {
        eventListeners.Add(_eventListener);
    }

    public void UnRegister(SI_EventWith1ParamListener<T> _eventListener)
    {
        eventListeners.Remove(_eventListener);
    }

    public void Invoke(T _param)
    {
        for (int i = 0; i < eventListeners.Count; i++)
        {
            eventListeners[i].Invoke(this, _param);
        }
    }
}
