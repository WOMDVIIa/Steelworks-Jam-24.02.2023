using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnemployedPerson : PersonStats
{
    public static bool firstUnemployedSpawned = false;
    static float minWaitingTime = 50.0f;
    static float maxWaitingTime = 60.0f;
    static int minStats = 1;
    static int maxStats = 3;

    float waitingForJobTimer;
    [SerializeField] GameObject hiredPrefab;
    Vector3 hiredLocation = new Vector3(1.4f, -3, 0);

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
    void StatsForFirstUnemployed()
    {
        for (int i = 0; i < skillSet.Length; i++)
        {
            skillSet[i] = 2.0f;
        }
    }
    void RandomStats()
    {
        for (int i = 0; i < skillSet.Length; i++)
        {
            skillSet[i] = Random.Range(minStats, maxStats + 1); //max exclusive
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (GameManager.instance.hiredPerson != null)
        {
            Destroy(GameManager.instance.hiredPerson);
        }
        GameManager.instance.hiredPersonSkillSet = skillSet;
        GameManager.instance.hiredPerson = Instantiate(hiredPrefab, hiredLocation, transform.rotation);
        Destroy(gameObject);
    }
}
