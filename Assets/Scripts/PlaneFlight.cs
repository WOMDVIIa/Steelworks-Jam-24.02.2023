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

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }
}
