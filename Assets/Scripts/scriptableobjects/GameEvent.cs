using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvent: ScriptableObject
{
    private List<GameEventSubscriber> subscribers =
        new List<GameEventSubscriber>();

    public void FireEvent()
    {
        for(int i = 0; i < subscribers.Count; ++i)
        {
            subscribers[i].OnEventFired();
        }
    }

    public static GameEvent operator +(GameEvent evt, GameEventSubscriber sub)
    {
        evt.subscribers.Add(sub);
        return evt;
    }

    public static GameEvent operator -(GameEvent evt, GameEventSubscriber sub)
    {
        evt.subscribers.Remove(sub);
        return evt;
    }
}
