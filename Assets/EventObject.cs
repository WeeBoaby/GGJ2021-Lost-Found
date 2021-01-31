using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventObject : MonoBehaviour
{
    public bool IsTriggered = false;

    // Start is called before the first frame update
    void Start()
    {
        IsTriggered = false;
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<Renderer>().material.color = IsTriggered ? Color.blue : Color.white;
    }

    void OnCollisionEnter(Collision c)
    {
        if (IsTriggered && c.collider.gameObject.name == "Player")
        {
            MainPlayerScript.GameOver();
        }
    }

    public void TriggerObject()
    {
        IsTriggered = true;

        OnTriggered();
    }

    protected virtual void OnTriggered()
    {

    }
}
