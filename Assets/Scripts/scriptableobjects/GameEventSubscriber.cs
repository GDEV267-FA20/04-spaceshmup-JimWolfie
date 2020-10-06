using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameEventSubscriber: MonoBehaviour
{
    public GameEvent gameEvent;
    public UnityEvent unityEvent;

    public void OnEventFired()
    {
        unityEvent?.Invoke();
    }

    private void OnEnable()
    {
        gameEvent += this;
    }

    private void OnDisable()
    {
        gameEvent -= this;
    }
}
