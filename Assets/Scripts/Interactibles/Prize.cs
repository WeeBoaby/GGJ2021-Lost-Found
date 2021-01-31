using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prize : Interactable
{
    protected override void OnInteraction()
    {
        base.OnInteraction();

        MainPlayerScript.ChangeScore(1000);
        MainPlayerScript.GameWon();
    }
}
