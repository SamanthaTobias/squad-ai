using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PrefabTest : MonoBehaviour
{
    public GameObject soldierPrefab;
    public GameObject treePrefab;

    private readonly float minX = -5f;
    private readonly float maxX = 5f;
    private readonly float minY = -5f;
    private readonly float maxY = 5f;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Running PrefabTest Start");
        for (int i = 0; i < 12; i++)
        {
            PlaceObjectRandom(soldierPrefab, minX, maxX, minY, maxY, 100);
        }
        for (int i = 0; i < 10; i++)
        {
            PlaceObjectRandom(treePrefab, minX, maxX, minY, maxY, 100);
        }
    }

    private void PlaceObjectRandom(GameObject prefab, float minX, float maxX, float minY, float maxY, int maxAttempts)
    {
        int attempts = 0;

        while (attempts < maxAttempts)
        {
            Vector2 position = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
            Collider2D hitCollider = Physics2D.OverlapCircle(position, 1f); // adjust radius if needed

            if (hitCollider == null)
            {
                Instantiate(prefab, position, Quaternion.identity);
                return;
            }

            attempts++;
        }

        Debug.LogError("Critical Error: Could not place prefab");
        throw new Exception("Cannot place prefab");
    }
}
