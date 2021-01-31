using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    protected bool IsHighlighted = false;
    protected bool IsInteracted = false;

    protected bool IsInteractable = true;

    // Start is called before the first frame update
    void Start()
    {
        CustomStart();
    }

    // Update is called once per frame
    void Update()
    {
        CustomUpdate();
    }

    public void Highlighted(bool highlighted)
    {
        if (!IsInteractable)
        {
            gameObject.GetComponent<Renderer>().material.color = Color.white;
            return;
        }

        gameObject.GetComponent<Renderer>().material.color = highlighted ? Color.green : Color.red;
        IsHighlighted = highlighted;
    }

    protected virtual void CustomStart()
    {
        Highlighted(false);
        IsInteracted = false;
    }

    protected virtual void CustomUpdate()
    {
        if (IsHighlighted && Input.GetKeyDown(KeyCode.E))
        {
            OnInteraction();
        }
    }

    protected virtual void OnInteraction()
    {

    }
}
