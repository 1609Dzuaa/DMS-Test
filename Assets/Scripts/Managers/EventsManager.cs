using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Enums;

public class EventsManager : BaseSingleton<EventsManager>
{
    private Dictionary<EEvents, Action<object>> _dictEvents = new();
    private readonly Action<object> SwordOnReceiveDirection;

    protected override void Awake()
    {
        base.Awake();
        AddEventsToDictionary();
        DontDestroyOnLoad(gameObject);
    }

    private void AddEventsToDictionary()
    {
        HandleAddEventsToDictionary(EEvents.SwordOnReceiveDirection, SwordOnReceiveDirection);
    }

    private void HandleAddEventsToDictionary(EEvents events, Action<object> callback)
    {
        //Vì thứ tự chạy của Awake & OnEnable khá loạn nên phải check kỹ
        if (!_dictEvents.ContainsKey(events))
            _dictEvents.Add(events, callback);
    }

    public void SubcribeToAnEvent(EEvents eventType, Action<object> callback)
    {
        if (!_dictEvents.ContainsKey(eventType))
            _dictEvents.Add(eventType, callback);

        _dictEvents[eventType] += callback;
        //Debug.Log("Func Registered: " + eventType);
    }

    public void UnSubcribeToAnEvent(EEvents eventType, Action<object> callback)
    {
        _dictEvents[eventType] -= callback;
    }

    public void NotifyObservers(EEvents eventType, object eventArgsType)
    {
        _dictEvents[eventType]?.Invoke(eventArgsType);
    }
}