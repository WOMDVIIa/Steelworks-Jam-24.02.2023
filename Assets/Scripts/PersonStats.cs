using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class PersonStats : MonoBehaviour
{
    public static bool firstUnemployedSpawned = false;
    
    float[] skillSet;

    [SerializeField] GameObject statsDisplay;
    [SerializeField] TextMeshProUGUI[] statsText;
    UnemployedHandling UnemployedHandlerObject;
    float minWaitingForNextUnemployed = 2.0f;
    float maxWaitingForNextUnemployed = 5.0f;
    int minStats = 1;
    int maxStats = 3;
    float waitingForJobTimer;
    float minWaitingTime = 50.0f;
    float maxWaitingTime = 60.0f;

    // Start is called before the first frame update
    void Start()
    {
        skillSet = new float[GameManager.instance.noOfPlaneTypes];
        if (!firstUnemployedSpawned)
        {
            StatsForFirstUnemployed();
            firstUnemployedSpawned = true;
        }
        else
        {
            RandomStats();
        }
        waitingForJobTimer = Random.Range(minWaitingTime, maxWaitingTime);
        SetNextUnemployedTimer();
    }

    // Update is called once per frame
    void Update()
    {
        waitingForJobTimer -= Time.deltaTime;
        if (waitingForJobTimer < 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnMouseOver()
    {
        if (!GameManager.instance.planeMenuOn)
        {
            DisplayStats(skillSet);
        }
    }

    private void OnMouseExit()
    {
        HideStats();
    }

    void SetNextUnemployedTimer()
    {
        UnemployedHandlerObject = GameObject.Find("Unemployed Grid").GetComponent<UnemployedHandling>();
        UnemployedHandlerObject.nextUnemployedTimer = Random.Range(minWaitingForNextUnemployed, maxWaitingForNextUnemployed);
    }

    void RandomStats()
    {
        for (int i = 0; i < skillSet.Length; i++)
        {
            skillSet[i] = Random.Range(minStats, maxStats + 1); //max exclusive
        }        
    }

    public void StatsForFirstUnemployed()
    {
        for (int i = 0; i < skillSet.Length; i++)
        {
            skillSet[i] = 2.0f;
        }
    }

    void DisplayStats(float[] skills)
    {
        statsDisplay.SetActive(true);
        statsText[0].text = "Writing: " + System.Math.Round(skills[0], 1);
        statsText[1].text = "Drawing: " + System.Math.Round(skills[1], 1);
        statsText[2].text = "Maths: " + System.Math.Round(skills[2], 1);
    }

    void HideStats()
    {
        statsDisplay.SetActive(false);
    }
}
