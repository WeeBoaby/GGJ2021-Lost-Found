using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FPSScript : MonoBehaviour
{
    public Text FpsText;

    private float CurrentTime = 0.0f;
    private float UpdateTime = 0.25f;

    void Update()
    {
        CurrentTime += Time.unscaledDeltaTime;

        if (CurrentTime > UpdateTime)
        {
            var fps = System.Math.Round((1.0f / Time.deltaTime), 0);
            FpsText.text = "FPS: " + fps.ToString();
            FpsText.color = fps < 60 ? Color.red : Color.green;

            CurrentTime = 0.0f;
        }
    }
}
