using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ships.events
{
    [CreateAssetMenu(menuName = "events/Void Event", fileName = "New Void Event", order = 1)]
    public class VoidEvent: GameEvent<Void>
    {
        public void FireEvent() => FireEvent(new Void());
    }

}

