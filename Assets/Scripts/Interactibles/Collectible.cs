using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : Interactable
{
    protected override void OnInteraction()
    {
        base.OnInteraction();

        MainPlayerScript.ChangeScore(50);
        Destroy(gameObject);
    }
}
