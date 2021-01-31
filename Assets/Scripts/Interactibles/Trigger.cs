using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : Interactable
{
    public GameObject Door;

    protected override void OnInteraction()
    {
        base.OnInteraction();

        MainPlayerScript.ChangeScore(100);
        Destroy(Door);
        IsInteractable = false;

        Highlighted(false);
    }
}
