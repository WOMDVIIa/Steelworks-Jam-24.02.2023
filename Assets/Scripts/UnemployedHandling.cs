using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.UI;
using TMPro;

public class UnemployedHandling : MonoBehaviour
{
    public int maxUnemployedWaiting = 10;
    public GameObject[] listOfWaitingUnemployed;

    [SerializeField] GameObject[] unemployedPrefabs;

    public float nextUnemployedTimer;
    public Vector3[] unemployedCoordinates;

    float minWaitingForNextUnemployed = 2.0f;
    float maxWaitingForNextUnemployed = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        listOfWaitingUnemployed = new GameObject[maxUnemployedWaiting];
    }

    // Update is called once per frame
    void Update()
    {
        nextUnemployedTimer -= Time.deltaTime;
        if (nextUnemployedTimer < 0 && NumberOfWaitingUnemployed() < maxUnemployedWaiting)
        {
            SpawnUnemployed();
        }
    }

    int NumberOfWaitingUnemployed()
    {
        int currentlyWaiting = 0;
        for (int i = 0; i < maxUnemployedWaiting; i++)
        {
            if (listOfWaitingUnemployed[i] != null)
            {
                currentlyWaiting++;
            }
        }

        return currentlyWaiting;
    }

    void SpawnUnemployed()
    {
        int tempIndex = Random.Range(0, maxUnemployedWaiting);
        if (listOfWaitingUnemployed[tempIndex] == null)
        {
            int nationIndex = Random.Range(0, unemployedPrefabs.Length);
            listOfWaitingUnemployed[tempIndex] = Instantiate(unemployedPrefabs[nationIndex], unemployedCoordinates[tempIndex], unemployedPrefabs[nationIndex].transform.rotation);
            listOfWaitingUnemployed[tempIndex].transform.parent = gameObject.transform;
            nextUnemployedTimer = Random.Range(minWaitingForNextUnemployed, maxWaitingForNextUnemployed);
        }
        else
        {
            SpawnUnemployed();
        }
    }
}
