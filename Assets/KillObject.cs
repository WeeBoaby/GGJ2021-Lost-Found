using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillObject : MonoBehaviour
{
    void OnCollisionEnter(Collision c)
    {
        if (c.collider.gameObject.name == "Player")
        {
            MainPlayerScript.GameOver();
        }
    }
}
