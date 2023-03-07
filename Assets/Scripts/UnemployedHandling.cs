using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.UI;
using TMPro;

public class UnemployedHandling : MonoBehaviour
{
    public int maxUnemployedWaiting = 10;
    public GameObject[] listOfWaitingUnemployed;

    [SerializeField] GameObject statsDisplay;
    [SerializeField] TextMeshProUGUI[] statsText;
    [SerializeField] GameObject[] unemployedPrefabs;
    //[SerializeField] GameObject unemployedGreek;
    public float nextUnemployedTimer;
    public Vector3[] unemployedCoordinates;
    // Start is called before the first frame update
    void Start()
    {
        listOfWaitingUnemployed = new GameObject[maxUnemployedWaiting];
        listOfWaitingUnemployed[0] = GameObject.Find("Unemployed Person");
        listOfWaitingUnemployed[0].GetComponent<PersonStats>().StatsForFirstUnemployed();
        //unemployedCoordinates = new Vector3[maxUnemployedWaiting];

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
        }
        else
        {
            SpawnUnemployed();
        }
    }

    public void DisplayStats(float[] skills)
    {
        statsDisplay.SetActive(true);
        statsText[0].text = "Writing: " + System.Math.Round(skills[0], 1);
        statsText[1].text = "Drawing: " + System.Math.Round(skills[1], 1);
        statsText[2].text = "Maths: " + System.Math.Round(skills[2], 1);
    }

    public void HideStats()
    {
        statsDisplay.SetActive(false);
    }
}
