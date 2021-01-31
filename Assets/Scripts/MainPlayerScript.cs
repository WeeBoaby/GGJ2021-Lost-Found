using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainPlayerScript : MonoBehaviour
{
    public static bool PlayerAlive = true;
    public static bool PlayerWon = false;
    public static int PlayerScore = 0;
    public static float gameTime = 0.0f;

    public float RaycastDistance = 1.0f;
    public float RaycastTimeout = 0.2f;
    private float RaycastTimer = 0.0f;

    private GameObject currentHighlightedObject;
    public LayerMask InteractLayerMask;

    void Awake()
    {
        PlayerAlive = true;
        PlayerWon = false;
        PlayerScore = 0;
        gameTime = 0.0f;

        RaycastTimer = 0.0f;
        RaycastTimeout = 0.2f;
    }

    void Update()
    {
        gameTime += Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.B))
        {
            Debug.Log("player deid");
            PlayerAlive = false;
        }

        if (Input.GetKeyDown(KeyCode.N))
        {
            PlayerWon = true;
        }

        RaycastTimer += Time.deltaTime;
    }

    void FixedUpdate()
    {
        if (RaycastTimer > RaycastTimeout)
        {
            CheckIfRayCastHit();
            RaycastTimer = 0.0f;
        }
    }

    void CheckIfRayCastHit()
    {
        RaycastHit hit;

        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, RaycastDistance, InteractLayerMask))
        {
            print($"HIT: {hit.collider.gameObject.name}");
            if (currentHighlightedObject != hit.collider.gameObject)
            {
                TryHighlightObject(currentHighlightedObject, false);

                currentHighlightedObject = hit.collider.gameObject;
                TryHighlightObject(currentHighlightedObject, true);
            }
        }
        else
        {
            TryHighlightObject(currentHighlightedObject, false);
            currentHighlightedObject = null;
        }
    }

    void TryHighlightObject(GameObject obj, bool highlight)
    {
        if (!obj)
        {
            return;
        }

        var currentCollectible = obj.GetComponent<Interactable>();
        if (currentCollectible)
        {
            currentCollectible.Highlighted(highlight);
        }
    }

    public static void ChangeScore(int scoreDifference)
    {
        PlayerScore += scoreDifference;
    }

    public static void GameOver()
    {
        PlayerAlive = false;
    }

    public static void GameWon()
    {
        PlayerWon = true;
    }
}
