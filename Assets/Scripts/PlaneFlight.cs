using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneFlight : MonoBehaviour
{
    protected float instantiateTime;
    protected float destroyVelocityThreshold = 0.1f;

    protected Rigidbody ownRb;

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

                case 2:

                    break;
            }
        }
    }

    void AssignEmployer(Collider other)
    {
        Quaternion assignRotation = new Quaternion(0, 0, 0.5f, 0);
        GameObject newAssign = Instantiate(GameManager.instance.hiredPerson.GetComponent<EmployedPerson>().assignedPrefab, other.transform.position, assignRotation);
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
