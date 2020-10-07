using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(menuName = "evets/GameEvent", fileName = "GameEvent")]
public class GameEvent: ScriptableObject
{
    private List<GameEventSubscriber> subscribers =
        new List<GameEventSubscriber>();

    public void FireEvent()
    {
        for(int i = 0; i < subscribers.Count; ++i)
        {
            Debug.Log("event fired");
            subscribers[i].OnEventFired();
        }
    }

    public static GameEvent operator +(GameEvent evt, GameEventSubscriber sub)
    {
        Debug.Log("subscribed");
        evt.subscribers.Add(sub);
        return evt;
    }

    public static GameEvent operator -(GameEvent evt, GameEventSubscriber sub)
    {
        Debug.Log("unsubscribed");
        evt.subscribers.Remove(sub);
        return evt;
    }
}
