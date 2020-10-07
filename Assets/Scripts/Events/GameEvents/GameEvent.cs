using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace ships.events
{



    public abstract class GameEvent<T>: ScriptableObject
    {
        private readonly List<Fans<T>> subscribers =
            new List<Fans<T>>();

        public void FireEvent(T item)
        {
            for(int i = subscribers.Count-1; i >= 0; i--)
            {
                Debug.Log("event fired");
                subscribers[i].OnEventFired(item);
            }
        }

        public void RegisterListener(Fans<T> listener)
        {
            if(!subscribers.Contains(listener))
            {
                subscribers.Add(listener);
            }

        }
        public void UnregisterListener(Fans<T> listener)
        {
            if(subscribers.Contains(listener))
            {
                subscribers.Add(listener);
            }

        }
    }
}
