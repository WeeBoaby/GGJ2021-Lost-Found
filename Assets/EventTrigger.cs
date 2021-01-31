using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Collider))]
public class EventTrigger : MonoBehaviour
{
    public EventObject EventObject;

    void OnTriggerEnter(Collider c)
    {
        if (c.gameObject.name == "Player" && !EventObject.IsTriggered)
        {
            EventObject.TriggerObject();
        }
    }
}
