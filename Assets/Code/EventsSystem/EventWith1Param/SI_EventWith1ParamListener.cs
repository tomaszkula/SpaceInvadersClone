using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SI_EventWith1ParamListener<T> : MonoBehaviour
{
    [Serializable]
    public class EventData
    {
        public SI_EventWith1Param<T> Event = null;
        public UnityEvent<T> Actions = null;
    }

    [SerializeField] private List<EventData> eventsData = new List<EventData>();

    private void OnEnable()
    {
        for (int i = 0; i < eventsData.Count; i++)
        {
            eventsData[i].Event.Register(this);
        }
    }

    private void OnDisable()
    {
        for (int i = 0; i < eventsData.Count; i++)
        {
            eventsData[i].Event.UnRegister(this);
        }
    }

    public void Invoke(SI_EventWith1Param<T> _event, T _param)
    {
        for (int i = 0; i < eventsData.Count; i++)
        {
            if (eventsData[i].Event != _event)
            {
                continue;
            }

            eventsData[i].Actions?.Invoke(_param);
        }
    }
}
