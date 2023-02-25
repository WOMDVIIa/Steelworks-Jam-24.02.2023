using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PersonStats : MonoBehaviour
{
    public float[] skillSet;

    //GameObject statsDisplay;
    UnemployedHandling UnemployedHandlerObject;
    float minWaitingForNextUnemployed = 1.0f;
    float maxWaitingForNextUnemployed = 2.0f;
    float minStats = 0.0f;
    float maxStats = 3.0f;
    float waitingForJobTimer;
    float minWaitingTime = 13.0f;
    float maxWaitingTime = 17.0f;

    // Start is called before the first frame update
    void Start()
    {
        //statsDisplay = GameObject.Find("SkillSetOfUnemployed");
        skillSet = new float[GameManager.instance.noOfPlaneTypes];
        RandomStats();
        SetUnemployedTimer();
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
        UnemployedHandlerObject.DisplayStats(skillSet);
    }

    private void OnMouseExit()
    {
        UnemployedHandlerObject.HideStats();
    }

    void SetUnemployedTimer()
    {
        UnemployedHandlerObject = GameObject.Find("Unemployed Grid").GetComponent<UnemployedHandling>();
        UnemployedHandlerObject.nextUnemployedTimer = Random.Range(minWaitingForNextUnemployed, maxWaitingForNextUnemployed);
    }

    void RandomStats()
    {
        for (int i = 0; i < skillSet.Length; i++)
        {
            skillSet[i] = Random.Range(minStats, maxStats);
        }

        waitingForJobTimer = Random.Range(minWaitingTime, maxWaitingTime);
    }

    public void StatsForFirstUnemployed()
    {
        for (int i = 0; i < skillSet.Length; i++)
        {
            skillSet[i] = 2.0f;
        }
    }
}
