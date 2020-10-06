using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship_Weapons : GameEvent
{
    private List<GameEventSubscriber> subscribers =
        new List<GameEventSubscriber>();
    //type of game event. attach a list of subscribers 
    //responsible for creating projectiles
    //responsible for defining the delegate to call when fired. 
}
