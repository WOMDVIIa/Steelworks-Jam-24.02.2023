using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PersonStats : MonoBehaviour
{
    public float[] skillSet;

    //GameObject statsDisplay;
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
        if (!GameManager.instance.planeMenuOn)
        {
            UnemployedHandlerObject.DisplayStats(skillSet);
        }
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
            skillSet[i] = Random.Range(minStats, maxStats + 1); //max exclusive
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
