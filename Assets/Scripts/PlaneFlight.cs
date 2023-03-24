using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneFlight : MonoBehaviour
{
    protected float instantiateTime;
    protected float destroyVelocityThreshold = 0.1f;

    protected Rigidbody ownRb;

    Quaternion assignRotation = new Quaternion(0, 0, 0.5f, 0);
    Vector3 tableOffset = new Vector3(0, -0.25f, 0);
    Vector3 assignOffset = new Vector3(0, 0, 0.1f);

    // Start is called before the first frame update
    protected void Start()
    {
        instantiateTime = Time.time;
        ownRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    protected void Update()
    {
        float lifeDuration = Time.time - instantiateTime;
        if (ownRb.velocity.magnitude < destroyVelocityThreshold && lifeDuration > 1)
        {
            ownRb.AddForce(Vector3.forward * 1000);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Job Slot"))
        {
            JobSlot deskHit = other.gameObject.GetComponent<JobSlot>();

            if (GameManager.instance.selectedPlaneIndex < 2)    // 0-1
            {
                switch (GameManager.instance.selectedPlaneIndex)
                {
                    case 0:     //Fire
                        if (deskHit.employer != null)
                        {
                            Destroy(deskHit.employer);
                        }
                        break;

                    case 1:     //Assign
                        if (deskHit.employer == null)
                        {
                            AssignEmployer(other);
                        }
                        break;
                }
            }
            else if (GameManager.instance.selectedPlaneIndex < 5)   // 2-4
            {
                if (deskHit.tableIndex == (int)JobSlot.tableType.empty)
                {
                    Destroy(deskHit.table);
                    deskHit.table = Instantiate(deskHit.tablesWithEQ[GameManager.instance.selectedPlaneIndex - 2], other.transform.position + tableOffset, assignRotation);
                    deskHit.table.transform.parent = other.transform;

                }
            }
            else if (GameManager.instance.selectedPlaneIndex > 5)   // 6+
            {
            
            }
        }
    }

    void AssignEmployer(Collider other)
    {
        GameObject newAssign = Instantiate(GameManager.instance.hiredPerson.GetComponent<EmployedPerson>().assignedPrefab, other.transform.position + assignOffset, assignRotation);
        newAssign.transform.parent = other.transform;
        other.gameObject.GetComponent<JobSlot>().employer = newAssign;
        GameManager.instance.stuffPlanesInPlaneMenu[0].GetComponent<PlaneSelect>().ActualSelection();
        Destroy(GameManager.instance.hiredPerson);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);        
    }
}
