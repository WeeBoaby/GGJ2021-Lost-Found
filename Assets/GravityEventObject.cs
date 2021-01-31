using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityEventObject : EventObject
{
    protected override void OnTriggered()
    {
        base.OnTriggered();

        StartCoroutine(WaitForStart());
    }

    private IEnumerator WaitForStart()
    {
        yield return new WaitForSeconds(1);

        gameObject.GetComponent<Rigidbody>().useGravity = true;
    }
}
