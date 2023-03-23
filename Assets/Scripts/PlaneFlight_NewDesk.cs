using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneFlight_NewDesk : PlaneFlight
{
    [SerializeField] GameObject jobSlot;

    bool tooCloseToAnotherDesk = false;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Job Slot"))
        {
            tooCloseToAnotherDesk = true;
            Debug.Log("Too Close!");
        }
        else
        {
            if (collision.gameObject.CompareTag("Builder") && !tooCloseToAnotherDesk)
            {
                Vector3 location = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, -0.1f);
                Instantiate(jobSlot, location, jobSlot.transform.rotation);
            }
            Destroy(gameObject);
        }
    }
}
