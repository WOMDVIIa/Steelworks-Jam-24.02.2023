using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmployedPerson : PersonStats
{
    // Start is called before the first frame update
    void Start()
    {
        skillSet = GameManager.instance.hiredPersonSkillSet;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
