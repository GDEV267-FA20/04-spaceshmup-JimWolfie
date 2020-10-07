using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace ships.events
{
    public abstract class GameEventSubscriber<T, E, UER>: MonoBehaviour,
    Fans<T> where E : GameEvent<T> where UER : UnityEvent<T>
    {

        [SerializeField] private E gameEvent;
        public E GameEvent { get { return gameEvent; } set { gameEvent = value; } }
        [SerializeField] UER unityEventResponse;



        private void OnEnable()
        {
            if(gameEvent == null)
            {
                return;
            }
            GameEvent.RegisterListener(this);
        }

        private void OnDisable()
        {
            if(gameEvent == null)
            {
                return;
            }
            GameEvent.UnregisterListener(this);
        }
        public void OnEventFired(T item)
        {
            if(unityEventResponse != null)
            {
                unityEventResponse.Invoke(item);
            }
        }
    }
}

