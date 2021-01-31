using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flicker : MonoBehaviour
{
    public float MinFlicker = 0.5f;
    public float MaxFlicker = 2.5f;

    public float FlickerSpeed = 0.035f;

    private Light Light;
    private float time = 0.0f;



    // Start is called before the first frame update
    void Start()
    {
        Light = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        if (time > FlickerSpeed)
        {
            Light.intensity = Random.Range(MinFlicker, MaxFlicker);
            time = 0.0f;
        }
    }
}
