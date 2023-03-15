using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmployedPerson : PersonStats
{
    [SerializeField] protected GameObject playerWithCameraObject;

    // Start is called before the first frame update
    void Start()
    {
        skillSet = GameManager.instance.hiredPersonSkillSet;
        playerWithCameraObject = GameObject.Find("Player with Camera");
        transform.parent = playerWithCameraObject.transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
