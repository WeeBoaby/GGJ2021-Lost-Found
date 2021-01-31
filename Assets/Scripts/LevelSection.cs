using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSection : MonoBehaviour
{
    public GameObject Entrance;
    public GameObject Exit;

    // Start is called before the first frame update
    void Start()
    {
        if (Entrance == null)
        {
            throw new System.Exception("Entrance not set for LevelSection");
        }

        if (Exit == null)
        {
            throw new System.Exception("Exit not set for LevelSection");
        }
    }

    void Awake()
    {
        CustomOnAwake();
    }

    protected virtual void CustomOnAwake()
    {

    }
}
