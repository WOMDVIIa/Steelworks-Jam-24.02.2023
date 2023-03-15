using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class PersonStats : MonoBehaviour
{
    //public static bool firstUnemployedSpawned = false;
    //static float minWaitingTime = 50.0f;
    //static float maxWaitingTime = 60.0f;
    //static int minStats = 1;
    //static int maxStats = 3;    

    [SerializeField] protected GameObject statsDisplay;
    [SerializeField] protected TextMeshProUGUI[] statsText;

    //float waitingForJobTimer;
    protected float[] skillSet;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("jestem w person stats");
        //    skillSet = new float[GameManager.instance.noOfPlaneTypes];
        //    if (!firstUnemployedSpawned)
        //    {
        //        StatsForFirstUnemployed();
        //        firstUnemployedSpawned = true;
        //    }
        //    else
        //    {
        //        RandomStats();
        //    }
        //    waitingForJobTimer = Random.Range(minWaitingTime, maxWaitingTime);
        //    //SetNextUnemployedTimer();
    }

    // Update is called once per frame
    //void Update()
    //{
    //    waitingForJobTimer -= Time.deltaTime;
    //    if (waitingForJobTimer < 0)
    //    {
    //        Destroy(gameObject);
    //    }
    //}

    protected void OnMouseOver()
    {
        if (!GameManager.instance.planeMenuOn)
        {
            DisplayStats(skillSet);
        }
    }

    protected void OnMouseExit()
    {
        HideStats();
    }

    //void RandomStats()
    //{
    //    for (int i = 0; i < skillSet.Length; i++)
    //    {
    //        skillSet[i] = Random.Range(minStats, maxStats + 1); //max exclusive
    //    }        
    //}

    //public void StatsForFirstUnemployed()
    //{
    //    for (int i = 0; i < skillSet.Length; i++)
    //    {
    //        skillSet[i] = 2.0f;
    //    }
    //}

    protected void DisplayStats(float[] skills)
    {
        statsDisplay.SetActive(true);
        statsText[0].text = "Writing: " + System.Math.Round(skills[0], 1);
        statsText[1].text = "Drawing: " + System.Math.Round(skills[1], 1);
        statsText[2].text = "Maths: " + System.Math.Round(skills[2], 1);
    }

    protected void HideStats()
    {
        statsDisplay.SetActive(false);
    }
}
